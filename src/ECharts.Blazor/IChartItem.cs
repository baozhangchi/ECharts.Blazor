using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public interface IChartItem
{
    [CascadingParameter] IChartItemContainer? Container { get; set; }
}