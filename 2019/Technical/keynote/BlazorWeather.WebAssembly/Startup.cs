using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using WeatherServiceML;
using WeatherClientLib;

namespace BlazorWeather
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpWeatherForecastService(options =>
            {
                options.Address = new System.Uri("https://localhost:5001/json");
            });
            services.AddScoped<IWeatherClassifier, WasmWeatherClassifier>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
