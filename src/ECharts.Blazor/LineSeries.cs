using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public class LineSeries<T, TValue> : Series<T, TValue>
{
    protected override SeriesTypes Type { get; } = SeriesTypes.Line;
    [Parameter] public bool Smooth { get; set; }
    [Parameter] public SeriesSymbols Symbol { get; set; } = SeriesSymbols.EmptyCircle;

    [Parameter] public bool ShowSymbol { get; set; } = true;

    public override Dictionary<string, object?> SerializeSettings()
    {
        var settings = base.SerializeSettings();
        settings.Add("smooth", Smooth);
        settings.Add("symbol", Symbol.ToString().ToLower());
        settings.Add("showSymbol", ShowSymbol);
        return settings;
    }
}