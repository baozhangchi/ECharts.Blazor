using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public abstract class ChartComponentBase : ComponentBase, ISerializeSettings
{
    public virtual Dictionary<string, object?> SerializeSettings()
    {
        return new Dictionary<string, object?>();
    }
}

public interface ISerializeSettings
{
    Dictionary<string, object?> SerializeSettings();
}