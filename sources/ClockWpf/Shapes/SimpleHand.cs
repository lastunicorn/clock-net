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
        double angleDegrees = CalculateAngle();

        Point center = new(diameter / 2, diameter / 2);
        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        DrawHandLine(drawingContext, diameter, angleDegrees, center);
        DrawPin(drawingContext, diameter, center);

        drawingContext.Pop();
    }

    private void DrawHandLine(DrawingContext drawingContext, double diameter, double angleDegrees, Point center)
    {
        Pen pen = new(Stroke, StrokeThickness);

        double radius = diameter / 2;
        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);

        Point startPoint = new(center.X, center.Y + tailLength);
        Point endPoint = new(center.X, center.Y - handLength);

        drawingContext.DrawLine(pen, startPoint, endPoint);
    }

    private void DrawPin(DrawingContext drawingContext, double diameter, Point center)
    {
        double radiusX = diameter / 2;
        double radiusY = diameter / 2;

        double pinRadiusX = radiusX * (PinDiameter / 100.0) / 2;
        double pinRadiusY = radiusY * (PinDiameter / 100.0) / 2;

        drawingContext.DrawEllipse(Stroke, null, center, pinRadiusX, pinRadiusY);
    }
}
