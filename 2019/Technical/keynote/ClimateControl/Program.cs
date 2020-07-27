using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClimateControl
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var ledService = new LEDService();
            var app = WebApplication.Create(args);

            app.MapGet("/temperature/{temp}", async http =>
            {
                var perfectTemperature = int.Parse(app.Configuration["perfectTemperature"]);
                var tempRouteValue = (string)http.Request.RouteValues["temp"];
                var temp = 0.0;
                var isSuccess = double.TryParse(tempRouteValue, out temp);
                var tolerance = 3;

                if (isSuccess)
                {
                    if(temp <= (perfectTemperature - tolerance))
                    {
                        Console.WriteLine("Too cold!");
                        ledService.ToggleGold(true);
                    }
                    else if(temp >= (perfectTemperature + tolerance))
                    {
                        Console.WriteLine("Too hot!");
                        ledService.ToggleRed(true);
                    }
                    else
                    {
                        Console.WriteLine("Just right!");
                        ledService.ToggleGreen(true);
                    }
                }

                await http.Response.WriteJsonAsync(new { success = isSuccess });
            });

            await app.RunAsync();
        }
    }
}
