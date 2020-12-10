using InternetFridge.ViewModels.OpenWeather;
using Microsoft.AspNetCore.Components;

namespace InternetFridge.Shared
{
    public class ForecastPanelBase : ComponentBase
    {
        [Parameter] public ForecastItemViewModel ForecastItem { get; set; }
    }
}
