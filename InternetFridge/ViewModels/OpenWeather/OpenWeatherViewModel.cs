using Darnton.OpenWeather.Models;
using Darnton.Units;
using System;

namespace InternetFridge.ViewModels.OpenWeather
{
    public abstract class OpenWeatherViewModel
    {
        protected int RoundToInteger(decimal value) => (int)Math.Round(value, 0, MidpointRounding.AwayFromZero);

        protected int _timezoneOffset;
        protected DateTimeOffset GetLocalDateTime(long timestamp) => timestamp.FromUnixTime().ToDateTimeOffset(_timezoneOffset.FromSeconds());
        public string GetTemperatureWithUnit(decimal temperature) => RoundToInteger(temperature) + "°C";
        public string GetSpeedWithUnit(decimal speed) => RoundToInteger(speed) + " km/h";

        protected abstract bool IsNight { get; }
        protected string GetWeatherConditionIconName(WeatherConditionCode code)
        {
            var weatherConditionGroup = (WeatherConditionGroup)((int)code / 100);
            var isNight = IsNight;

            if (weatherConditionGroup == WeatherConditionGroup.Thunderstorm) return "thunderstorm.png";

            if (weatherConditionGroup == WeatherConditionGroup.Drizzle) return "rainy.png";

            if (weatherConditionGroup == WeatherConditionGroup.Rain) return "rainy.png";

            if (weatherConditionGroup == WeatherConditionGroup.Snow) return "snow.png";

            if (weatherConditionGroup == WeatherConditionGroup.Atmosphere)
            {
                switch (code)
                {
                    case WeatherConditionCode.Smoke:
                        return "forest-fire.png";
                    case WeatherConditionCode.VolcanicAsh:
                        return "volcano.png";
                    case WeatherConditionCode.Squalls:
                        return "rain-heavy.png";
                    case WeatherConditionCode.SandDustWhirls:
                    case WeatherConditionCode.Tornado:
                        return "tornado.png";
                    default:
                        return "fog.png";
                }
            }

            if (weatherConditionGroup == WeatherConditionGroup.Clouds)
            {
                switch (code)
                {
                    case WeatherConditionCode.Clear:
                        return isNight ? "crescent-moon.png" : "sun.png";
                    case WeatherConditionCode.FewClouds:
                    case WeatherConditionCode.ScatteredClouds:
                        return isNight ? "cloudy-night.png" : "partly-cloudy.png";
                    default:
                        return "cloudy.png";
                }
            }

            return "partly-cloudy.png";
        }

        protected string GetWindDirectionName(decimal windDirectionDegrees)
        {
            // Rotate by 1/32 to put 0° in the middle of the first sector
            // Take modulus to map 360° back to 0°
            // Divide into 16 sectors
            // Truncate to integer to get the sector index
            var sectorIndex = (int)(((windDirectionDegrees + 11.25m) % 360) / 22.5m);
            var sectorNames = new[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            return sectorNames[sectorIndex];
        }
    }
}
