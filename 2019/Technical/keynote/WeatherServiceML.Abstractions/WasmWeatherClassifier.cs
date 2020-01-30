using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherServiceML
{
    public class WasmWeatherClassifier : IWeatherClassifier
    {
        public Task<string> ClassifyWeather(string imageUrl)
        {
            return Task.FromResult("Not implemented, but it's always rainy in Seattle, silly!");
        }
    }
}
