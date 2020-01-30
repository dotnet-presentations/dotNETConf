using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public partial class WeatherResponse
    {
        public DateTimeOffset RetrievedDateTimeOffset => RetrievedTime.ToDateTimeOffset();
    }
}
