using Microsoft.AspNetCore.Components;

namespace ECharts.Blazor;

public class PieSeries<T, TValue> : Series<T, TValue>
{
    private double? _minAngle;
    private double? _minShowLabelAngle;
    private double? _padAngle;
    private double _startAngle = 30d;

    [Parameter] public bool Clockwise { get; set; } = true;

    [Parameter]
    public double StartAngle
    {
        get => _startAngle;
        set
        {
            value = Math.Min(360, Math.Max(0, value));
            _startAngle = value;
        }
    }

    [Parameter]
    public double? MinAngle
    {
        get => _minAngle;
        set
        {
            if (value.HasValue) value = Math.Min(360, Math.Max(0, value.Value));

            _minAngle = value;
        }
    }

    [Parameter]
    public double? PadAngle
    {
        get => _padAngle;
        set
        {
            if (value.HasValue) value = Math.Min(360, Math.Max(0, value.Value));

            _padAngle = value;
        }
    }

    [Parameter]
    public double? MinShowLabelAngle
    {
        get => _minShowLabelAngle;
        set
        {
            if (value.HasValue) value = Math.Min(360, Math.Max(0, value.Value));

            _minShowLabelAngle = value;
        }
    }

    [Parameter] public bool RoseType { get; set; }

    [Parameter] public bool AvoidLabelOverlap { get; set; } = true;

    [Parameter] public bool StillShowZeroSum { get; set; } = true;

    [Parameter] public uint PercentPrecision { get; set; } = 2;

    [Parameter] public bool ShowEmptyCircle { get; set; } = true;

    protected override SeriesTypes Type => SeriesTypes.Pie;

    public override Dictionary<string, object?> SerializeSettings()
    {
        var settings = base.SerializeSettings();
        settings.Add("clockwise", Clockwise);
        settings.Add("startAngle", StartAngle);
        settings.Add("minAngle", MinAngle);
        settings.Add("padAngle", PadAngle);
        settings.Add("minShowLabelAngle", MinShowLabelAngle);
        settings.Add("roseType", RoseType);
        settings.Add("avoidLabelOverlap", AvoidLabelOverlap);
        settings.Add("stillShowZeroSum", StillShowZeroSum);
        settings.Add("percentPrecision", PercentPrecision);
        settings.Add("showEmptyCircle", ShowEmptyCircle);
        return settings;
    }
}