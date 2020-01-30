using System.Threading.Tasks;

namespace WeatherServiceML
{
    public interface IWeatherClassifier
    {
        Task<string> ClassifyWeather(string imageUrl);
    }
}