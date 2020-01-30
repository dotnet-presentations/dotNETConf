using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Weather.MobileCore.Converters;
using Weather.MobileCore.Model;
using WeatherClientLib;
using Xamarin.Essentials;
using static Weather.Weather;

namespace Weather.MobileCore.ViewModel
{
    public class WeatherViewModel : BaseViewModel
    {
        readonly IWeatherForecastService weatherService;
        CancellationTokenSource cts = new CancellationTokenSource();
        public WeatherViewModel()
        {

        }

        public WeatherViewModel(string backendUrl)
        {
            var client = new WeatherClient(GrpcChannel.ForAddress(backendUrl));
            weatherService = new GrpcWeatherForecastService(client);
        }

        public string Date => string.Format("{0:dddd, MMMM d}", DateTime.Now);

        public ObservableRangeCollection<DataItem> WeatherItems { get; } = new ObservableRangeCollection<DataItem>();

        bool useCelsius;
        public bool UseCelsius
        {
            get => useCelsius;
            set
            {
                if (SetProperty(ref useCelsius, value))
                {
                    BackgroundColorConverter.UseCelcius = UseCelsius;
                    OnPropertyChanged(nameof(Temp));
                }
            }
        }

        int temp;
        public int Temp
        {
            get => UseCelsius ? (int)UnitConverters.FahrenheitToCelsius(temp) : temp;
            set => SetProperty(ref temp, value);
        }

        string currentConditions;
        public string CurrentConditions
        {
            get => currentConditions;
            set => SetProperty(ref currentConditions, value);
        }

        string timeStamp;
        public string TimeStamp
        {
            get => timeStamp;
            set => SetProperty(ref timeStamp, value);
        }

        string currentConditionsIcon;
        public string CurrentConditionsIcon
        {
            get => currentConditionsIcon;
            set => SetProperty(ref currentConditionsIcon, value);
        }

        public async Task InitializeWeatherStream()
        {
            await foreach (var message in weatherService.GetStreamingWeather(cts.Token))
            {
                UpdateWeather((int)message.Temperature, message.WeatherText,
                             !message.IsDayTime, message.RetrievedTime?.ToDateTime().ToLocalTime(), message.WeartherUri,
                             (int)message.Past6HourMin, (int)message.Past6HourMax, message.Pressure,
                             message.UVIndex, message.WindSpeed, message.WindDirection, (int)message.RelativeHumidity);
            }
        }

        void UpdateWeather(int temp, string conditions, bool isNight, DateTime? timeStamp, string iconUrl, int minTemp, int maxTemp, float pressure, int uvIndex, float windSpeed, string windDirection, int humidity)
        {
            var items = new List<DataItem>();
            items.Add(new DataItem { Name = "Wind", Value = $"{windSpeed:N1} mph {windDirection}" });
            items.Add(new DataItem { Name = "Pressure", Value = $"{pressure:N2} Hg" });
            items.Add(new DataItem { Name = "Humidity", Value = $"{humidity}%" });
            items.Add(new DataItem { Name = "UV Index", Value = $"{uvIndex}" });
            items.Add(new DataItem { Name = "6 Hr Min", Value = $"{minTemp}°" });
            items.Add(new DataItem { Name = "6 Hr Max", Value = $"{maxTemp}°" });

            MainThread.BeginInvokeOnMainThread(() =>
            {
                BackgroundColorConverter.IsNight = isNight;
                Temp = temp;
                CurrentConditions = conditions;
                CurrentConditionsIcon = iconUrl;
                TimeStamp = timeStamp?.ToLongTimeString() ?? DateTime.Now.ToLongTimeString();
                WeatherItems.ReplaceRange(items);
            });
        }

        public async Task UpdateWeatherViaGrpc()
        {
            var message = await weatherService.GetWeather();

            UpdateWeather((int)message.Temperature, message.WeatherText,
                            !message.IsDayTime, message.RetrievedTime?.ToDateTime().ToLocalTime(), message.WeartherUri,
                            (int)message.Past6HourMin, (int)message.Past6HourMax, message.Pressure,
                            message.UVIndex, message.WindSpeed, message.WindDirection, (int)message.RelativeHumidity);
        }


        public async Task GetWeatherViaRest()
        {
            var httpClient = new HttpClient();
            var client = new WeatherRestClient(App.RestBackendUrl, httpClient);

            var message = await client.JsonAsync();

            UpdateWeather((int)message.Temperature, message.WeatherText,
                              !message.IsDayTime, null, message.WeartherUri,
                              (int)message.Past6HourMin, (int)message.Past6HourMax, (float)message.Pressure,
                              message.UvIndex, (float)message.WindSpeed, message.WindDirection, (int)message.RelativeHumidity);
        }
    }
}
