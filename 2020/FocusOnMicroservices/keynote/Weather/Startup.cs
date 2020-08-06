using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weather.Services;
using Weather.Workers;

namespace Weather
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            
            services.AddHttpClient("AccuWeather", (client) =>
            {
                client.BaseAddress = new Uri(Configuration["weather:uri"]);
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            });
            
            services.AddHttpClient("ClimateControl", (client) =>
            {
                // options.Address = new Uri("http://localhost:5040");
                client.BaseAddress = Configuration.GetServiceUri("climatecontrol");
            });

            services.AddMemoryCache();
            services.AddHostedService<WeatherWorker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<WeatherService>();

                endpoints.MapGet("/", context => context.Response.WriteAsync("Healthy"));
            });
        }
    }
}
