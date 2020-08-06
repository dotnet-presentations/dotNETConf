using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServiceML
{
    public interface IWeatherClassifier
    {
        Task<string> ClassifyWeather(string imageUrl);
    }
}
