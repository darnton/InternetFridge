using InternetFridge.ViewModels.OpenWeather;
using Microsoft.AspNetCore.Components;

namespace InternetFridge.Shared
{
    public class ForecastStripBase : ComponentBase
    {
        [Parameter] public ForecastViewModel Forecast { get; set; }
    }
}
