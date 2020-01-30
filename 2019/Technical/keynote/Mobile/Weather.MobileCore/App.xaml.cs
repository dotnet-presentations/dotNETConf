using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.MobileCore
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address

        public static string RestBackendUrl = 
           DeviceInfo.Platform  == DevicePlatform.Android ? "http://10.0.2.2:5051" : "http://localhost:5051";

        // Publish your backend to Azure to use gRPC
        public static string GRPCBackendUrl = "https://yourbackend.azurewebsites.net";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
