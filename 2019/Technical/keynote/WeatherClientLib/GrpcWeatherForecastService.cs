using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Grpc.Core;
using Weather;
using static Weather.Weather;
using System.Threading.Tasks;

namespace WeatherClientLib
{
    public class GrpcWeatherForecastService : IWeatherForecastService
    {
        private readonly WeatherClient _weatherClient;

        public GrpcWeatherForecastService(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public async Task<WeatherResponse> GetWeather()
        {
            return await _weatherClient.GetWeatherAsync(new Empty());
        }

        public IAsyncEnumerable<WeatherResponse> GetStreamingWeather(CancellationToken token)
        {
            return _weatherClient.GetWeatherStream(new Empty(), cancellationToken: token)
                .ResponseStream.ReadAllAsync();
        }
    }
}
