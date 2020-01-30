using Grpc.Net.ClientFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static Weather.Weather;

namespace WeatherClientLib
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGrpcWeatherForecastService(
            this IServiceCollection services, Action<GrpcClientFactoryOptions> configure)
        {
            services.AddGrpcClient<WeatherClient>(configure);
            services.AddScoped<IWeatherForecastService, GrpcWeatherForecastService>();
            return services;
        }

        public static IServiceCollection AddHttpWeatherForecastService(
            this IServiceCollection services, Action<HttpWeatherForecastServiceOptions> configure)
        {
            services.AddScoped<IWeatherForecastService, HttpWeatherForecastService>();
            services.Configure(configure);
            return services;
        }
    }
}
