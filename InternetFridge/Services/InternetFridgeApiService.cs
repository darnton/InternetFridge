using Darnton.OpenWeather.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace InternetFridge.Services
{
    public interface IInternetFridgeApiService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(int cityId);
        Task<Forecast> GetForecastAsync(int cityId);
    }

    public class InternetFridgeApiService : IInternetFridgeApiService
    {
        private readonly HttpClient _client;

        public InternetFridgeApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CurrentWeather> GetCurrentWeatherAsync(int cityId)
        {
            var url = $"api/currentweather?cityId={cityId}";
            return await _client.GetFromJsonAsync<CurrentWeather>(url);
        }

        public async Task<Forecast> GetForecastAsync(int cityId)
        {
            var url = $"api/weatherforecast?cityId={cityId}";
            return await _client.GetFromJsonAsync<Forecast>(url);
        }
    }
}
