using Darnton.OpenWeather.Models;
using Darnton.OpenWeather.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetFridge.API.Controllers
{
    [ApiController]
    [Route("api/currentweather")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IConfiguration _config;
        private readonly ILogger<CurrentWeatherController> _logger;

        public CurrentWeatherController(IOpenWeatherService openWeatherService, IConfiguration config, ILogger<CurrentWeatherController> logger)
        {
            _openWeatherService = openWeatherService;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public async Task<CurrentWeather> Get(int cityId)
        {
            //return GetDummyCurrentWeather();

            return await _openWeatherService.GetCurrentWeatherAsync(cityId, new Guid(_config["OpenWeather:ApiKey"]));
        }

        private CurrentWeather GetDummyCurrentWeather()
        {

            return new CurrentWeather
            {
                Coordinates = new Coordinates
                {
                    Longitude = 172.63m,
                    Latitude = -43.53m
                },
                WeatherConditions = new List<WeatherCondition>
                {
                    new WeatherCondition
                    {
                        Id = (WeatherConditionCode)803,
                        Main = "Clouds",
                        Description = "broken clouds",
                        Icon = "04n"
                    }
                },
                Base = "stations",
                MainResult = new MainResult
                {
                    Temperature = 16.07m,
                    FeelsLike = 13.93m,
                    MinTemperature = 15.56m,
                    MaxTemperature = 16.67m,
                    Pressure = 1009,
                    Humidity = 67
                },
                Visibility = 10000,
                Wind = new Wind
                {
                    Speed = 3.1m,
                    Direction = 60
                },
                Clouds = new Clouds
                {
                    Cloudiness = 53
                },
                Rain = new Precipitation
                {
                    OneHourVolume = 0m,
                    ThreeHourVolume = 0m
                },
                Snow = new Precipitation
                {
                    OneHourVolume = 0m,
                    ThreeHourVolume = 0m
                },
                Timestamp = 1585334090L,
                System = new SystemResult
                {
                    Country = "NZ",
                    Sunrise = 1585161532L,
                    Sunset = 1585204279L
                },
                TimezoneOffset = 46800,
                CityId = 2192362,
                CityName = "Christchurch"
            };
        }
    }
}
