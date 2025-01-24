namespace ECharts.Blazor;

public class BarSeries<T, TValue> : Series<T, TValue>
{
    protected override SeriesTypes Type { get; } = SeriesTypes.Bar;
}