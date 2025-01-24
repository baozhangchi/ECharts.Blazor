namespace ECharts.Blazor;

internal interface ISeries : ISerializeSettings
{

}
public enum SeriesSymbols
{
    EmptyCircle,
    Circle,
    Rect,
    RoundRect,
    Triangle,
    Diamond,
    Pin,
    Arrow,
    None
}

public enum SeriesColorBy
{
    Series,
    Data
}

public enum SeriesTypes
{
    Line,
    Bar,
    Pie,
    Gauge
}