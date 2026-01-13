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

    public override void Render(DrawingContext drawingContext, Rect bounds)
    {
        double angleDegrees = CalculateAngle();
        double radiusAtAngle = MathUtils.CalculateRadius(bounds, angleDegrees - 90.0);
        double handLength = radiusAtAngle * (Length / 100.0);
        double tailLength = radiusAtAngle * (TailLength / 100.0);

        Point center = new(bounds.Width / 2, bounds.Height / 2);
        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        Pen pen = new(Stroke, StrokeThickness);

        Point startPoint = new(center.X, center.Y + tailLength);
        Point endPoint = new(center.X, center.Y - handLength);

        drawingContext.DrawLine(pen, startPoint, endPoint);

        drawingContext.Pop();
    }
}
