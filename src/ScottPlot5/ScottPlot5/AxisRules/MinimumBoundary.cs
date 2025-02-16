namespace ScottPlot.AxisRules;

public class MinimumBoundary(IXAxis xAxis, IYAxis yAxis, AxisLimits limits) : IAxisRule
{
    readonly IXAxis XAxis = xAxis;
    readonly IYAxis YAxis = yAxis;
    public AxisLimits Limits { get; set; } = limits;

    public void Apply(RenderPack rp, bool beforeLayout)
    {
        double horizontalSpan = Math.Max(Math.Abs(XAxis.Range.Span), Limits.XRange.Span);
        double verticalSpan = Math.Max(Math.Abs(YAxis.Range.Span), Limits.YRange.Span);
        
        if (XAxis.Range.Max < Limits.XRange.Max)
        {
            XAxis.Range.Max = Limits.XRange.Max;
            XAxis.Range.Min = Limits.XRange.Max - horizontalSpan;
        }

        if (XAxis.Range.Min > Limits.XRange.Min)
        {
            XAxis.Range.Min = Limits.XRange.Min;
            XAxis.Range.Max = Limits.XRange.Min + horizontalSpan;
        }

        if (YAxis.Range.Max < Limits.YRange.Max)
        {
            YAxis.Range.Max = Limits.YRange.Max;
            YAxis.Range.Min = Limits.YRange.Max - verticalSpan;
        }

        if (YAxis.Range.Min > Limits.YRange.Min)
        {
            YAxis.Range.Min = Limits.YRange.Min;
            YAxis.Range.Max = Limits.YRange.Min + verticalSpan;
        }
    }
}
