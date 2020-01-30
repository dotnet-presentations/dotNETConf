using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Weather.MobileCore.Converters
{
    public class CaseConverter : IMarkupExtension, IValueConverter
    {
        public bool UseUpper { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;
            if (val == null)
                return value;

            return UseUpper ? val.ToUpperInvariant() : val.ToLowerInvariant();
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
