using Darnton.OpenWeather.Models;
using System.Collections.Generic;
using System.Linq;

namespace InternetFridge.ViewModels.OpenWeather
{
    public class ForecastViewModel
    {
        private readonly Forecast _forecast;
        public ForecastViewModel(Forecast forecast)
        {
            _forecast = forecast;
        }

        public IEnumerable<ForecastItemViewModel> Items => _forecast.Items.Select(i => new ForecastItemViewModel(i, _forecast.City));
    }
}
