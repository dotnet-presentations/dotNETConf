using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;
using System;

Host.CreateDefaultBuilder(null).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.Configure(app =>
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
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

                await context.Response.WriteAsJsonAsync(new { success = isSuccess });
            });
        });
    });
}).Build().Run();
