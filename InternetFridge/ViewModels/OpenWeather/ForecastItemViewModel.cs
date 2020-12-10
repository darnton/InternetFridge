using Darnton.OpenWeather.Models;
using Darnton.Units;
using System.Globalization;
using System.Linq;

namespace InternetFridge.ViewModels.OpenWeather
{
    public class ForecastItemViewModel : OpenWeatherViewModel
    {
        private readonly ForecastItem _forecastItem;
        private readonly CultureInfo _cultureInfo;

        public ForecastItemViewModel(ForecastItem forecastItem, City city)
        {
            _forecastItem = forecastItem;
            _timezoneOffset = city.TimezoneOffset;
            _cultureInfo = CultureInfo.CreateSpecificCulture("en-NZ");
        }
        protected override bool IsNight => GetLocalDateTime(_forecastItem.Timestamp).Hour < 7 || GetLocalDateTime(_forecastItem.Timestamp).Hour > 19;

        public string LocalDate => GetLocalDateTime(_forecastItem.Timestamp).ToString("MMM d", _cultureInfo);
        public string LocalTime => GetLocalDateTime(_forecastItem.Timestamp).ToString("h tt", _cultureInfo).Replace(".", "").ToLower();
        public string TemperatureWithUnit => GetTemperatureWithUnit(_forecastItem.MainResult.Temperature);
        public string WeatherConditionsIconName => GetWeatherConditionIconName(_forecastItem.WeatherConditions.First().Id);
        public string WindSpeedWithUnit => GetSpeedWithUnit(_forecastItem.Wind.Speed.FromMetresPerSecond().ToKilometresPerHour());
        public string WindDirectionName => GetWindDirectionName(_forecastItem.Wind.Direction);
        public string WindAngle => _forecastItem.Wind.Direction + "deg";
        public string RainfallWithUnit => (_forecastItem.Rain?.OneHourVolume ?? 0m) + " mm";

    }
}
