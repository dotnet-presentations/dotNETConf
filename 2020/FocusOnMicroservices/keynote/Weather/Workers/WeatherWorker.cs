using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Weather.Model;

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

                    // mock model just in case the external weather service hasn't been configured
                    Forecast[] model = new Forecast[] { new Forecast()
                    {
                        WeatherText = "Sunny",
                        IsDayTime = true,
                        RelativeHumidity = 45,
                        Temperature = new Temperature { Imperial = new Imperial { Value = 57 } },
                        UVIndex = 2,
                        WeatherIcon = 1,
                        Pressure = new Pressure { Imperial = new Imperial8 { Value = 29.99f } },
                        Wind = new Wind { Direction = new Direction { English = "SSE" }, Speed = new Speed { Imperial = new Imperial4 { Value = 5.8f } } },
                        TemperatureSummary = new Temperaturesummary { Past6HourRange = new Past6hourrange { Minimum = new Minimum { Imperial = new Imperial22 { Value = 55 } }, Maximum = new Maximum { Imperial = new Imperial23 { Value = 90 } } }
                    } } };

                    // has the external weather service been configured?
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        var client = _httpClientFactory.CreateClient("AccuWeather");

                        var response = await client.GetAsync($"/340247?apikey={token}&details=true");
                        
                        model = await response.Content.ReadFromJsonAsync<Forecast[]>();

                        expiresHeader = response.Content.Headers.Expires;
                    }
                    else
                    {
                        Console.WriteLine("No accuweather key set, returning mock data.");

                        model.First().Temperature.Imperial.Value = new Random().Next(50, 100);
                    }

                    // send the temperature to the climate control system
                    try
                    {
                        var climateControlClient = _httpClientFactory.CreateClient("ClimateControl");

                        var uri = $"/temperature/{model.First().Temperature.Imperial.Value}";

                        _logger.LogInformation($"Sending temp to {uri}");

                        var climateControlResponse = await climateControlClient.PostAsync(uri, new StringContent(string.Empty));
                    }
                    catch
                    {
                        // the climate control pi app might not always be running/responding
                    }

                    // cache the model
                    _cache.Set(Constants.LATEST_FORECAST_CACHE_KEY, model.First());

                    //Honoring the expires time
                    if (expiresHeader.HasValue)
                    {
                       await Task.Delay(expiresHeader.Value.UtcDateTime.Subtract(DateTime.UtcNow));
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5));
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
