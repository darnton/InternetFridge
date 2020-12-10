using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace InternetFridge.Shared
{
    public class IconValuePairBase : ComponentBase
    {
        [Parameter] public string ImageName { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public int Width { get; set; } = 100;
        [Parameter] public int Height { get; set; } = 100;
        [Parameter] public string Size { get; set; } = "md";
        [Parameter] public bool SpinIcon { get; set; } = false;

        private Lazy<IDictionary<string, string>> _headerClasses => new Lazy<IDictionary<string, string>>(
                () => new Dictionary<string, string>
                {
                    { "xs", "h6" },
                    { "sm", "h5" },
                    { "md", "h3" },
                    { "lg", "h2" },
                    { "xl", "h1" },
                }
            );
        protected string HeaderClass => _headerClasses.Value[Size];

        private string SpinCss => SpinIcon ? " icon-spin" : "";
        protected string IconClass => $"icon-{Size}{SpinCss}";
    }
}
