using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Hosting;
using WeatherServiceML.Model;

namespace WeatherServiceML
{
    public class MLWeatherClassifier : IWeatherClassifier
    {
        private readonly IWebHostEnvironment _env;

        public MLWeatherClassifier(IWebHostEnvironment env)
        {
            _env = env;
        }

        public Task<string> ClassifyWeather(string imageUrl)
        {
            var fullPath = Path.Combine(_env.WebRootPath, imageUrl);

            // TO DO: Add Machine Learning!  
            // Add input data
            var input = new ModelInput();
            input.ImageSource = fullPath;

            // Load model and predict output of sample data
            return Task.Run(() =>
            {
                ModelOutput result = ConsumeModel.Predict(input);
                return result.Prediction;
            });
        }
    }
}