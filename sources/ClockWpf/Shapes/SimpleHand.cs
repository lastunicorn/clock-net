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

    public override void Render(DrawingContext drawingContext, Rect bounds)
    {
        double angleDegrees = CalculateAngle();

        Point center = new(bounds.Width / 2, bounds.Height / 2);
        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        DrawHandLine(drawingContext, bounds, angleDegrees, center);
        DrawPin(drawingContext, bounds, center);

        drawingContext.Pop();
    }

    private void DrawHandLine(DrawingContext drawingContext, Rect bounds, double angleDegrees, Point center)
    {
        Pen pen = new(Stroke, StrokeThickness);

        double radiusAtAngle = MathUtils.CalculateRadius(bounds, angleDegrees - 90.0);
        double handLength = radiusAtAngle * (Length / 100.0);
        double tailLength = radiusAtAngle * (TailLength / 100.0);

        Point startPoint = new(center.X, center.Y + tailLength);
        Point endPoint = new(center.X, center.Y - handLength);

        drawingContext.DrawLine(pen, startPoint, endPoint);
    }

    private void DrawPin(DrawingContext drawingContext, Rect bounds, Point center)
    {
        double radiusX = bounds.Width / 2;
        double radiusY = bounds.Height / 2;

        double pinRadiusX = radiusX * (PinDiameter / 100.0) / 2;
        double pinRadiusY = radiusY * (PinDiameter / 100.0) / 2;

        drawingContext.DrawEllipse(Stroke, null, center, pinRadiusX, pinRadiusY);
    }
}
