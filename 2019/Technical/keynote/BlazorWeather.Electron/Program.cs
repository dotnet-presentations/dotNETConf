using Microsoft.AspNetCore.Components.Electron;

namespace BlazorWeather
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsElectron.Run<Startup>("wwwroot/index.html");
        }
    }
}
