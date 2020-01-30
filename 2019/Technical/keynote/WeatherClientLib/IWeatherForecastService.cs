using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weather;

namespace WeatherClientLib
{
    public interface IWeatherForecastService
    {
        IAsyncEnumerable<WeatherResponse> GetStreamingWeather(CancellationToken token);
        Task<WeatherResponse> GetWeather();
    }
}