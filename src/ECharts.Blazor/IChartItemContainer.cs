using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public interface IChartItemContainer
{
    RenderFragment? ChildContent { get; set; }
    
    void Add(IChartItem item);

    void Remove(IChartItem item);
}