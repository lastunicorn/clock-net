using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public abstract class RimBase : Shape
{
    public static readonly DependencyProperty DistanceFromEdgeProperty = DependencyProperty.Register(
        nameof(DistanceFromEdge),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(0.0));

    public double DistanceFromEdge
    {
        get => (double)GetValue(DistanceFromEdgeProperty);
        set => SetValue(DistanceFromEdgeProperty, value);
    }

    public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
        nameof(Angle),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(30.0));

    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }

    public static readonly DependencyProperty OffsetAngleProperty = DependencyProperty.Register(
        nameof(OffsetAngle),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(0.0));

    public double OffsetAngle
    {
        get => (double)GetValue(OffsetAngleProperty);
        set => SetValue(OffsetAngleProperty, value);
    }

    public override void DoRender(DrawingContext drawingContext, double diameter)
    {
        int index = 0;
        double angleDegrees = OffsetAngle + (index * Angle);

        while (angleDegrees >= 0 && angleDegrees <= 360)
        {
            RotateTransform rotateTransform = new(angleDegrees, 0, 0);
            drawingContext.WithTransform(rotateTransform, () =>
            {
                RenderItem(drawingContext, index);
            });

            index++;
            angleDegrees = OffsetAngle + (index * Angle);
        }
    }

    protected abstract void RenderItem(DrawingContext drawingContext, int index);
}