using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Weather.Model;
using Weather.Services;
using Weather.Workers;
using Microsoft.OpenApi.Models;

namespace Weather
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddDefaultPolicy(builder => 
            {
                builder.AllowAnyOrigin();
            }));
            services.AddGrpc();
            services.AddHttpClient("AccuWeather")
                    .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler()
                    {
                        AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                    });
            services.AddMemoryCache();
            services.AddControllers();
            services.AddHostedService<WeatherWorker>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1");
            });
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<WeatherService>();

                endpoints.MapGet("/proto", async req =>
                {
                    await req.Response.SendFileAsync("Protos/weather.proto", req.RequestAborted);
                });

                endpoints.MapGet("/", async req => await req.Response.WriteAsync("Healthy"));
                endpoints.MapControllers();

            });
        }
    }
}
