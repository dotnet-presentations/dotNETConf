using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using static Weather.Weather;
using WeatherClientLib;
using System;
using Microsoft.Extensions.Configuration;
using WeatherServiceML;

namespace BlazorWeather
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            services.AddGrpcWeatherForecastService(options =>
            {
                options.Address = new Uri(configuration["WeatherServiceUri"]);
            });
            services.AddScoped<IWeatherClassifier, WasmWeatherClassifier>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
