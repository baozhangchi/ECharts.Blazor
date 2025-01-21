using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public interface IChartItem
{
    [CascadingParameter] IChartItemContainer? Container { get; set; }
}

public abstract class ChartItemBase : ChartComponentBase, IChartItem, IDisposable
{
    [CascadingParameter] public IChartItemContainer? Container { get; set; }

    public virtual void Dispose()
    {
        Container?.Remove(this);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender) Container?.Add(this);
    }
}