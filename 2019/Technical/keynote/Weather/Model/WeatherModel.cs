using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Model
{
    public class Forecast
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public Realfeeltemperature RealFeelTemperature { get; set; }
        public Realfeeltemperatureshade RealFeelTemperatureShade { get; set; }
        public int RelativeHumidity { get; set; }
        public Dewpoint DewPoint { get; set; }
        public Wind Wind { get; set; }
        public Windgust WindGust { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public Visibility Visibility { get; set; }
        public string ObstructionsToVisibility { get; set; }
        public int CloudCover { get; set; }
        public Ceiling Ceiling { get; set; }
        public Pressure Pressure { get; set; }
        public Pressuretendency PressureTendency { get; set; }
        public Past24hourtemperaturedeparture Past24HourTemperatureDeparture { get; set; }
        public Apparenttemperature ApparentTemperature { get; set; }
        public Windchilltemperature WindChillTemperature { get; set; }
        public Wetbulbtemperature WetBulbTemperature { get; set; }
        public Precip1hr Precip1hr { get; set; }
        public Precipitationsummary PrecipitationSummary { get; set; }
        public Temperaturesummary TemperatureSummary { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Metric
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Realfeeltemperature
    {
        public Metric1 Metric { get; set; }
        public Imperial1 Imperial { get; set; }
    }

    public class Metric1
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial1
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Realfeeltemperatureshade
    {
        public Metric2 Metric { get; set; }
        public Imperial2 Imperial { get; set; }
    }

    public class Metric2
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial2
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Dewpoint
    {
        public Metric3 Metric { get; set; }
        public Imperial3 Imperial { get; set; }
    }

    public class Metric3
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial3
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Wind
    {
        public Direction Direction { get; set; }
        public Speed Speed { get; set; }
    }

    public class Direction
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Speed
    {
        public Metric4 Metric { get; set; }
        public Imperial4 Imperial { get; set; }
    }

    public class Metric4
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial4
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Windgust
    {
        public Speed1 Speed { get; set; }
    }

    public class Speed1
    {
        public Metric5 Metric { get; set; }
        public Imperial5 Imperial { get; set; }
    }

    public class Metric5
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial5
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Visibility
    {
        public Metric6 Metric { get; set; }
        public Imperial6 Imperial { get; set; }
    }

    public class Metric6
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial6
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Ceiling
    {
        public Metric7 Metric { get; set; }
        public Imperial7 Imperial { get; set; }
    }

    public class Metric7
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial7
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Pressure
    {
        public Metric8 Metric { get; set; }
        public Imperial8 Imperial { get; set; }
    }

    public class Metric8
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial8
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Pressuretendency
    {
        public string LocalizedText { get; set; }
        public string Code { get; set; }
    }

    public class Past24hourtemperaturedeparture
    {
        public Metric9 Metric { get; set; }
        public Imperial9 Imperial { get; set; }
    }

    public class Metric9
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial9
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Apparenttemperature
    {
        public Metric10 Metric { get; set; }
        public Imperial10 Imperial { get; set; }
    }

    public class Metric10
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial10
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Windchilltemperature
    {
        public Metric11 Metric { get; set; }
        public Imperial11 Imperial { get; set; }
    }

    public class Metric11
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial11
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Wetbulbtemperature
    {
        public Metric12 Metric { get; set; }
        public Imperial12 Imperial { get; set; }
    }

    public class Metric12
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial12
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Precip1hr
    {
        public Metric13 Metric { get; set; }
        public Imperial13 Imperial { get; set; }
    }

    public class Metric13
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial13
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Precipitationsummary
    {
        public Precipitation Precipitation { get; set; }
        public Pasthour PastHour { get; set; }
        public Past3hours Past3Hours { get; set; }
        public Past6hours Past6Hours { get; set; }
        public Past9hours Past9Hours { get; set; }
        public Past12hours Past12Hours { get; set; }
        public Past18hours Past18Hours { get; set; }
        public Past24hours Past24Hours { get; set; }
    }

    public class Precipitation
    {
        public Metric14 Metric { get; set; }
        public Imperial14 Imperial { get; set; }
    }

    public class Metric14
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial14
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Pasthour
    {
        public Metric15 Metric { get; set; }
        public Imperial15 Imperial { get; set; }
    }

    public class Metric15
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial15
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past3hours
    {
        public Metric16 Metric { get; set; }
        public Imperial16 Imperial { get; set; }
    }

    public class Metric16
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial16
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past6hours
    {
        public Metric17 Metric { get; set; }
        public Imperial17 Imperial { get; set; }
    }

    public class Metric17
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial17
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past9hours
    {
        public Metric18 Metric { get; set; }
        public Imperial18 Imperial { get; set; }
    }

    public class Metric18
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial18
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past12hours
    {
        public Metric19 Metric { get; set; }
        public Imperial19 Imperial { get; set; }
    }

    public class Metric19
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial19
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past18hours
    {
        public Metric20 Metric { get; set; }
        public Imperial20 Imperial { get; set; }
    }

    public class Metric20
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial20
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past24hours
    {
        public Metric21 Metric { get; set; }
        public Imperial21 Imperial { get; set; }
    }

    public class Metric21
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial21
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperaturesummary
    {
        public Past6hourrange Past6HourRange { get; set; }
        public Past12hourrange Past12HourRange { get; set; }
        public Past24hourrange Past24HourRange { get; set; }
    }

    public class Past6hourrange
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }

    public class Minimum
    {
        public Metric22 Metric { get; set; }
        public Imperial22 Imperial { get; set; }
    }

    public class Metric22
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial22
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Maximum
    {
        public Metric23 Metric { get; set; }
        public Imperial23 Imperial { get; set; }
    }

    public class Metric23
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial23
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past12hourrange
    {
        public Minimum1 Minimum { get; set; }
        public Maximum1 Maximum { get; set; }
    }

    public class Minimum1
    {
        public Metric24 Metric { get; set; }
        public Imperial24 Imperial { get; set; }
    }

    public class Metric24
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial24
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Maximum1
    {
        public Metric25 Metric { get; set; }
        public Imperial25 Imperial { get; set; }
    }

    public class Metric25
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial25
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Past24hourrange
    {
        public Minimum2 Minimum { get; set; }
        public Maximum2 Maximum { get; set; }
    }

    public class Minimum2
    {
        public Metric26 Metric { get; set; }
        public Imperial26 Imperial { get; set; }
    }

    public class Metric26
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial26
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Maximum2
    {
        public Metric27 Metric { get; set; }
        public Imperial27 Imperial { get; set; }
    }

    public class Metric27
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial27
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

}
