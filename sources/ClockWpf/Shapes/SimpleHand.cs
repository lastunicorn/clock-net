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

    public override void Render(DrawingContext drawingContext, double diameter)
    {
        double angleDegrees = CalculateHandAngle();

        RotateTransform rotateTransform = new(angleDegrees, 0, 0);
        drawingContext.WithTransform(rotateTransform, () =>
        {
            double radius = diameter / 2;

            DrawHandLine(drawingContext, radius);
            DrawPin(drawingContext, radius);
        });
    }

    private void DrawHandLine(DrawingContext drawingContext, double radius)
    {
        Pen pen = new(Stroke, StrokeThickness);

        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);

        Point startPoint = new(0, tailLength);
        Point endPoint = new(0, -handLength);

        drawingContext.DrawLine(pen, startPoint, endPoint);
    }

    private void DrawPin(DrawingContext drawingContext, double radius)
    {
        double pinRadius = radius * (PinDiameter / 100.0) / 2;

        Point center = new(0, 0);
        drawingContext.DrawEllipse(Stroke, null, center, pinRadius, pinRadius);
    }
}
