using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class Ticks : RimBase
{
    static Ticks()
    {
        AngleProperty.OverrideMetadata(typeof(Ticks), new FrameworkPropertyMetadata(6.0));
        OffsetAngleProperty.OverrideMetadata(typeof(Ticks), new FrameworkPropertyMetadata(6.0));
        DistanceFromEdgeProperty.OverrideMetadata(typeof(Ticks), new FrameworkPropertyMetadata(6.0));
    }

    public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
        nameof(Length),
        typeof(double),
        typeof(Ticks),
        new FrameworkPropertyMetadata(5.0));

    public double Length
    {
        get => (double)GetValue(LengthProperty);
        set => SetValue(LengthProperty, value);
    }

    private double radius;

    protected override bool OnRendering(double diameter)
    {
        radius = diameter / 2;
        return base.OnRendering(diameter);
    }

    protected override void RenderItem(DrawingContext drawingContext, int index)
    {
        double startY = -(radius - DistanceFromEdge);
        double endY = startY + Length;

        Point startPoint = new(0, startY);
        Point endPoint = new(0, endY);

        Pen pen = new(Stroke, StrokeThickness);
        drawingContext.DrawLine(pen, startPoint, endPoint);
    }
}
