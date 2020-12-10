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
    [Route("api/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IOpenWeatherService openWeatherService, IConfiguration config, ILogger<WeatherForecastController> logger)
        {
            _openWeatherService = openWeatherService;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Forecast> Get(int cityId)
        {
            //return GetDummyForecast();

            return await _openWeatherService.GetForecastAsync(cityId, new Guid(_config["OpenWeather:ApiKey"]));
        }

        private Forecast GetDummyForecast()
        {
            return new Forecast
            {
                Count = 3,
                City = new City
                {
                    Id = 2192362,
                    Name = "Christchurch",
                    Coordinates = new Coordinates
                    {
                        Longitude = 172.63m,
                        Latitude = -43.53m
                    },
                    Country = "NZ",
                    TimezoneOffset = 46800,
                    Sunrise = 1585161532L,
                    Sunset = 1585204279L
                },
                Items = new List<ForecastItem>()
                {
                    GetDummyForecastItem(),
                    GetDummyForecastItem(),
                    GetDummyForecastItem(),
                }
            };
        }

        private ForecastItem GetDummyForecastItem()
        {
            return new ForecastItem
            {
                Timestamp = 1585344890L,
                MainResult = new MainResult
                {
                    Temperature = 16.07m,
                    FeelsLike = 13.93m,
                    MinTemperature = 15.56m,
                    MaxTemperature = 16.67m,
                    Pressure = 1009,
                    Humidity = 67
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
                }
            };
        }
    }
}
