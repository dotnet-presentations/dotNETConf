using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.MobileCore.Converters
{
    public class BackgroundColorConverter : IMarkupExtension, IValueConverter
    {
        public bool ForceNight { get; set; }
        public bool ForceCold { get; set; }
        public static bool IsNight { get; set; }
        public static bool UseCelcius { get; set; }
        public bool IsStart { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int temp)
            {

                var resources = Application.Current.Resources;

                var warmTemp = UseCelcius ? 16 : 60;


                if (IsNight || ForceNight)
                    return IsStart ? resources["NightStartColor"] : resources["NightEndColor"];

                if (temp >= warmTemp && !ForceCold)
                    return IsStart ? resources["WarmStartColor"] : resources["WarmEndColor"];


                return IsStart ? resources["ColdStartColor"] : resources["ColdEndColor"];
            }

            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
