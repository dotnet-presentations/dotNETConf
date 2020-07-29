using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.Configure((builderContext, app) =>
    {
        var client = new HttpClient
        {
            BaseAddress = builderContext.Configuration.GetServiceUri("pi")
        };
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/temperature/{temp}", async context =>
            {
                var perfectTemperature = 65;
                var tempRouteValue = (string)context.Request.RouteValues["temp"];
                var temp = 0.0;
                var isSuccess = double.TryParse(tempRouteValue, out temp);
                var tolerance = 3;

                if (isSuccess)
                {
                    if (temp <= (perfectTemperature - tolerance))
                    {
                        Console.WriteLine("Too cold!");
                    }
                    else if (temp >= (perfectTemperature + tolerance))
                    {
                        Console.WriteLine("Too hot!");
                    }
                    else
                    {
                        Console.WriteLine("Just right!");
                    }
                }

                await client.GetAsync($"/temperature/{temp}");

                await context.Response.WriteAsJsonAsync(new { success = isSuccess });
            });
        });
    });
}).Build().Run();
