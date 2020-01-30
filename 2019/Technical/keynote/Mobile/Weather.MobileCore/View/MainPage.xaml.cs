using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.MobileCore.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Weather.MobileCore
{
    public partial class MainPage : ContentPage
    {
        WeatherViewModel vm;
        WeatherViewModel VM => vm ?? (vm = (WeatherViewModel)BindingContext);
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new WeatherViewModel();

            // to use gRPC use new WeatherViewModel(App.GRPCBackendUrl);

            ImageSeattle.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await GetWeather();
                }),
                NumberOfTapsRequired = 2
            });
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrWhiteSpace(VM.CurrentConditions))
            {
                await GetWeather();      
            }
        }

        async Task GetWeather()
        {
            try
            {
                //Use InitializeWeatherStream for gRPC
                await VM.GetWeatherViaRest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
