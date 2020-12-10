using Darnton.OpenWeather.Services;
using InternetFridge.Services;
using InternetFridge.ViewModels.OpenWeather;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace InternetFridge.Pages
{
    public class WeatherBase : ComponentBase
    {
        [Inject] protected IConfiguration Config { get; set; }
        [Inject] protected IInternetFridgeApiService ApiService { get; set; }

        private int _cityId = 2192362; // Christchurch
        protected CurrentWeatherViewModel CurrentWeather;
        protected ForecastViewModel Forecast;
        private Timer _refreshTimer;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            RefreshWeatherData();

            var tenMinutes = 10 * 60 * 1000;
            _refreshTimer = new Timer(tenMinutes);
            _refreshTimer.Elapsed += OnRefreshTimerElapsed;
            _refreshTimer.Enabled = true;
        }

        private async void RefreshWeatherData()
        {
            CurrentWeather = new CurrentWeatherViewModel(await ApiService.GetCurrentWeatherAsync(_cityId));
            Forecast = new ForecastViewModel(await ApiService.GetForecastAsync(_cityId));
            StateHasChanged();
        }

        private void OnRefreshTimerElapsed(object source, ElapsedEventArgs e)
        {
            RefreshWeatherData();
        }
    }
}
