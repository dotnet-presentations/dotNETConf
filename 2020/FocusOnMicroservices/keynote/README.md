# Weather

[.NET Conf Keynote](https://dotnetconf.net) demo including all the things you can build in .NET including server, desktop, mobile, web apps, and machine learning.

## Server

A service that caches weather results and provides an endpoint for all the different demos. It has gRPC and JSON endpoints and supports streaming and non-streaming.

It uses [https://www.accuweather.com/](https://www.accuweather.com/) for its weather data. To run the service locally you will need to add an Accuweather token to your own UserSecrets with the key accuweathertoken

It includes some yaml files to configure a Kubernetes cluster to run the service. The setup for Kubernetes is to setup an Nginx ingress controller that uses Let's Encrypt certificates. The ingress controller terminates TLS and the connection after that is plain to the service. You can follow a guide here: [https://docs.microsoft.com/en-us/azure/aks/ingress-tls](https://docs.microsoft.com/en-us/azure/aks/ingress-tls).

## Desktop

The desktop application is a WinForms app targeting .NET Framework 4.8. It is using hardcoded dummy data for the weather. To connect this app to the real gRPC weather service you need to do the following:

1. Port the application to .NET Core 3.
1. Add a reference in this project to WeatherClientLib.
1. Delete GetDummyData() method and WeatherResponse class from the file.
1. Remove everything from PollWeather() method and insert the following lines:

````csharp
private async void PollWeather()
{
    var client = new WeatherClient(GrpcChannel.ForAddress(serviceUrl));            
    var weatherService = new GrpcWeatherForecastService(client);
    await foreach (var message in weatherService.GetStreamingWeather(cts.Token))
    {
            UpdateForm(message);
    };
}
````

## Mobile

A beautiful iOS and Android application written in C# with [Xamarin](https://dotnet.microsoft.com/apps/xamarin). This mobile app was built and designed using [XAML Hot Reload](https://aka.ms/xamlhotreload) as part of [.NET Conf Keynote](https://dotnetconf.net).

It shares core client libraries and logic including REST and gRPC backends with the Server, Desktop, and Blazor clients using .NET Standard.

### Built with the following
* [Pancake View](https://github.com/sthewissen/Xamarin.Forms.PancakeView)
* [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/)
* [Xamarin.Forms](http://xamarin.com/forms)
* Space Needle icon by [Blair Adams via The Noun Project](https://thenounproject.com/search/?q=space%20needle&i=915578)
* Design by [Guzman Barquin via Uplabs](https://www.uplabs.com/posts/weather-app-f41080cc-063a-499b-ad9c-18936575a5ac)

## Machine Learning - ML.NET

An ML.NET machine learning model trained using ML.NET Model Builder and consumed in the Blazor weather web app to predict the weather (cloudy, rainy, or sunny) based on images.

The model was trained on 15 images from Mendley Data's [Multi-class Weather Dataset for Image Classification](http://dx.doi.org/10.17632/4drtyfjtfy.1).

This sample includes the code necessary for model consumption in your end-user application. Support for image classification training in Model Builder is coming soon.

## IoT

The Weather LED Matrix example sample and part list is here: https://github.com/dotnet/iot/tree/master/samples/led-matrix-weather

## License

Under MIT