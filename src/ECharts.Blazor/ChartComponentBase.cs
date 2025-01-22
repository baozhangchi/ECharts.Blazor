using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public abstract class ChartComponentBase : ComponentBase, ISerializeSettings
{
    public virtual Dictionary<string, object?> SerializeSettings()
    {
        return new Dictionary<string, object?>();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            HasRendered = true;
        }
        return base.OnAfterRenderAsync(firstRender);
    }

    protected bool HasRendered { get; set; }
}

internal interface ISerializeSettings
{
    Dictionary<string, object?> SerializeSettings();
}