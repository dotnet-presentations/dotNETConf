using System.Threading.Tasks;

namespace WeatherServiceML
{
    public class WeatherClassifier : IWeatherClassifier
    {
        public Task<string> ClassifyWeather(string imageUrl)
        {
            return Task.FromResult("Looks fine");
        }
    }
}
