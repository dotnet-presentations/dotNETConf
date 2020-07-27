using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Weather.Model;
using Weather.Services;

namespace Weather.Workers
{
    public class WeatherWorker : BackgroundService
    {
        private ILogger<WeatherWorker> _logger;
        private IConfiguration _configuration;
        private IHttpClientFactory _httpClientFactory;
        private IMemoryCache _cache;

        public WeatherWorker(ILogger<WeatherWorker> logger,
                            IConfiguration configuration,
                            IHttpClientFactory httpClientFactory,
                            IMemoryCache cache)
        {
            _logger = logger;

            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    DateTimeOffset? expiresHeader = null;
                    var token = _configuration["accuweathertoken"];
                    Forecast[] model = null;
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        var client = _httpClientFactory.CreateClient("AccuWeather");

                        var response = await client.GetAsync($"{_configuration["weather:uri"]}/340247?apikey={_configuration["accuweathertoken"]}&details=true");

                        model = await JsonSerializer.DeserializeAsync<Forecast[]>(await response.Content.ReadAsStreamAsync());

                        _cache.Set(Constants.LATEST_FORECAST_CACHE_KEY, model.First());

                        expiresHeader = response.Content.Headers.Expires;
                    }
                    else
                    {
                        Console.WriteLine("No accuweather key set, returning mock data.");
                    }

                    // send the temperature to the climate control system
                    var temp = (model != null && model.Any())
                        ? model.First().Temperature.Imperial.Value
                        : new Random().Next(50,100);

                    var climateControlClient = _httpClientFactory.CreateClient("ClimateControl");

                    var uri = $"{_configuration["ClimateControl:uri"]}{temp}";

                    _logger.LogInformation($"Sending temp of {temp} to {uri}");

                    var climateControlResponse = await climateControlClient.GetAsync(uri);

                    //Honoring the expires time
                    if (expiresHeader.HasValue)
                    {
                       await Task.Delay(expiresHeader.Value.UtcDateTime.Subtract(DateTime.UtcNow));
                    }
                    else
                    {
                        //await Task.Delay(TimeSpan.FromMinutes(2));
                        await Task.Delay(TimeSpan.FromSeconds(10));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Unexpected error fetching weather data: {ex}", ex);
                }
            }
        }
    }
}
