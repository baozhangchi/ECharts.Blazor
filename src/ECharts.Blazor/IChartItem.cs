using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public interface IChartItem
{
    [CascadingParameter] IChartItemContainer? Container { get; set; }
}

public abstract class ChartItemBase : ChartComponentBase, IChartItem, IAsyncDisposable
{
    [CascadingParameter] public IChartItemContainer? Container { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender) Container?.Add(this);
    }

    public virtual ValueTask DisposeAsync()
    {
        Container?.Remove(this);
        return ValueTask.CompletedTask;
    }
}