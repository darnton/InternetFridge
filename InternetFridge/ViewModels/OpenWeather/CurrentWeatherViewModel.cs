using Darnton.OpenWeather.Models;
using Darnton.Units;
using InternetFridge.Services;
using System.Globalization;
using System.Linq;

namespace InternetFridge.ViewModels.OpenWeather
{
    public class CurrentWeatherViewModel : OpenWeatherViewModel
    {
        private readonly CurrentWeather _currentWeather;
        public CurrentWeatherViewModel(CurrentWeather currentWeather)
        {
            _currentWeather = currentWeather;
            _timezoneOffset = _currentWeather.TimezoneOffset;
        }

        protected override bool IsNight => _currentWeather.Timestamp < _currentWeather.System.Sunrise || _currentWeather.Timestamp > _currentWeather.System.Sunset;

        public string Location => $"{_currentWeather.CityName}, {_currentWeather.System.Country}";
        public string LocalDateAndTime => GetLocalDateTime(_currentWeather.Timestamp).ToString("f", CultureInfo.CreateSpecificCulture("en-NZ"));
        public string LocalSunrise => GetLocalDateTime(_currentWeather.System.Sunrise).ToString("hh:mm");
        public string LocalSunset => GetLocalDateTime(_currentWeather.System.Sunset).ToString("hh:mm");
        public string TemperatureWithUnit => GetTemperatureWithUnit(_currentWeather.MainResult.Temperature);
        public string TemperatuteIconName => _currentWeather.MainResult.Temperature <= 15 ? "thermometer-cold.png" : "thermometer-hot.png";
        public string WeatherConditionsIconName => GetWeatherConditionIconName(_currentWeather.WeatherConditions.First().Id);
        public string WeatherConditionName => _currentWeather.WeatherConditions.First().Description;
        public string WindSpeedWithUnit => GetSpeedWithUnit(_currentWeather.Wind.Speed.FromMetresPerSecond().ToKilometresPerHour());
        public string WindDirectionName => GetWindDirectionName(_currentWeather.Wind.Direction);
        public string HumidityWithUnit => RoundToInteger(_currentWeather.MainResult.Humidity) + "%";
        public string PressureWithUnit => RoundToInteger(_currentWeather.MainResult.Pressure) + " hPa";


    }
}
