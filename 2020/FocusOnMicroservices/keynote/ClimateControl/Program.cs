using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.Configure(app =>
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapPost("/temperature/{temp}", async context =>
            {
                var perfectTemperature = 65;
                var tempRouteValue = (string)context.Request.RouteValues["temp"];
                var isSuccess = double.TryParse(tempRouteValue, out var temp);
                var tolerance = 3;

                if (isSuccess)
                {
                    if (temp <= (perfectTemperature - tolerance))
                    {
                        Console.WriteLine($"{temp} is too cold!");
                    }
                    else if (temp >= (perfectTemperature + tolerance))
                    {
                        Console.WriteLine($"{temp} is too hot!");
                    }
                    else
                    {
                        Console.WriteLine($"{temp} is just right!");
                    }
                }

                await context.Response.WriteAsJsonAsync(new { success = isSuccess });
            });
        });
    });
}).Build().Run();
