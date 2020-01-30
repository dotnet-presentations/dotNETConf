using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather;

namespace WeatherClientLib
{
    public class HttpWeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private string weatherUri;


        public HttpWeatherForecastService(HttpClient httpClient, IOptionsMonitor<HttpWeatherForecastServiceOptions> options)
        {
            _httpClient = httpClient;
            weatherUri = options.CurrentValue?.Address?.ToString() ?? "json";
            
        }

        public async IAsyncEnumerable<WeatherResponse> GetStreamingWeather([EnumeratorCancellation] CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var weather = await _httpClient.GetJsonAsync<WeatherResponse>(weatherUri); 
                yield return weather; 
                await Task.Delay(5000); // poll every 5 sec
            }
        }

        public async Task<WeatherResponse> GetWeather()
        {
            return await _httpClient.GetJsonAsync<WeatherResponse>(weatherUri);
        }
    }
}
