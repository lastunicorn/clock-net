using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class SimpleHand : HandBase
{
    public static readonly DependencyProperty TailLengthProperty = DependencyProperty.Register(
        nameof(TailLength),
        typeof(double),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(0.0));

    public double TailLength
    {
        get => (double)GetValue(TailLengthProperty);
        set => SetValue(TailLengthProperty, value);
    }

    public static readonly DependencyProperty PinDiameterProperty = DependencyProperty.Register(
        nameof(PinDiameter),
        typeof(double),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(2.66));

    public double PinDiameter
    {
        get => (double)GetValue(PinDiameterProperty);
        set => SetValue(PinDiameterProperty, value);
    }

    public override void DoRender(DrawingContext drawingContext, double diameter)
    {
        drawingContext.CreateDrawingPlan()
            .WithTransform(() =>
            {
                double angleDegrees = CalculateHandAngle();
                return new RotateTransform(angleDegrees, 0, 0);
            })
            .Draw(dc =>
            {
                double radius = diameter / 2;

                DrawHandLine(dc, radius);
                DrawPin(dc, radius);
            });
    }

    private void DrawHandLine(DrawingContext drawingContext, double radius)
    {
        if (StrokePen == null)
            return;

        if (Length <= 0 && TailLength <= 0)
            return;

        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);

        Point startPoint = new(0, tailLength);
        Point endPoint = new(0, -handLength);

        drawingContext.DrawLine(StrokePen, startPoint, endPoint);
    }

    private void DrawPin(DrawingContext drawingContext, double radius)
    {
        if (Stroke == null)
            return;

        if (PinDiameter <= 0)
            return;

        double pinRadius = radius * (PinDiameter / 100.0) / 2;

        Point center = new(0, 0);
        drawingContext.DrawEllipse(Stroke, null, center, pinRadius, pinRadius);
    }
}
