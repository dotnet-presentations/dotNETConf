using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherWinFormsFx
{
    public partial class WeatherForm : Form
    {
        bool isCollapsed = true;
        readonly CancellationTokenSource cts = new CancellationTokenSource();
        readonly string serviceUrl = ConfigurationManager.AppSettings.Get("WeatherServiceUrl");
        
        public WeatherForm()
        {
            InitializeComponent();
            PollWeather();
        }

        private async void PollWeather()
        {
            var weather = await Task.Run(() => GetDummyData());
            UpdateForm(weather);

            // To switch from using the dummy data to real gRPC service:
            //  1. Port the application to .NET Core 3.
            //  2. Add a reference to WeatherClientLib.
            //  3. Remove two lines above, GetDummyData() method and WeatherResponse class from this file.
            //  4. Uncomment the lines bellow add required usings.
            //
            //var client = new WeatherClient(GrpcChannel.ForAddress(serviceUrl));
            //var weatherService = new GrpcWeatherForecastService(client);

            //await foreach (var message in weatherService.GetStreamingWeather(cts.Token))
            //{
            //    UpdateForm(message);
            //};
        }

        private WeatherResponse GetDummyData()
        {
            return new WeatherResponse()
            {
                Location = "Alderaan",
                WeatherText = "Too cold",
                WeatherIcon = 33,
                IsDayTime = true,
                Temperature = -432,
                RelativeHumidity = 0,
                WindSpeed = 0,
                Pressure = 0,
                UVIndex = 0,
                RetrievedDateTimeOffset = DateTimeOffset.Now,
                WeartherUri = "https://apidev.accuweather.com/developers/Media/Default/WeatherIcons/33-s.png"
            };
        }

        public class WeatherResponse
        {
            public string Location { get; set; }
            public string WeatherText { get; set; }
            public Int32 WeatherIcon { get; set; }
            public string WeartherUri { get; set; }
            public bool IsDayTime { get; set; }
            public float Temperature { get; set; }
            public float RelativeHumidity { get; set; }
            public float WindSpeed { get; set; }
            public Int32 UVIndex { get; set; }
            public float Pressure { get; set; }
            public float Past6HourMin { get; set; }
            public float Past6HourMax { get; set; }
            public DateTimeOffset RetrievedDateTimeOffset { get; set; }
        }

        private void UpdateForm(WeatherResponse weatherResponse)
        {
            City.Text = weatherResponse.Location;
            WeatherIcon.Load(weatherResponse.WeartherUri);
            Temperature.Text = (weatherResponse.Temperature == -432) ? "9K" : weatherResponse.Temperature.ToString();
            WeatherText.Text = weatherResponse.WeatherText;
            Pressure.Text = $"{weatherResponse.Pressure.ToString()} in";
            Wind.Text = $"{weatherResponse.WindSpeed.ToString()} mph";
            Humidity.Text = $"{weatherResponse.RelativeHumidity.ToString()} %";
            UVIndex.Text = weatherResponse.UVIndex.ToString();
            var localTime = weatherResponse.RetrievedDateTimeOffset.ToLocalTime();
            Updated.Text = $"Updated at {localTime.ToString("h:mm:ss tt")}";
        }

        private void CollapseExpandButton_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 640);
                CollapseExpandButton.Text = "ꓥ";
                isCollapsed = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 380);
                CollapseExpandButton.Text = "ꓦ";
                isCollapsed = true;
            }
        }
    }
}
