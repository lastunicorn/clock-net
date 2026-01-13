using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class SimpleHand : Shape
{
    public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
        nameof(Length),
        typeof(double),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(95.0));

    public double Length
    {
        get => (double)GetValue(LengthProperty);
        set => SetValue(LengthProperty, value);
    }

    public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
        nameof(Time),
        typeof(TimeSpan),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(TimeSpan.Zero));

    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
        nameof(Fill),
        typeof(Brush),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(Brushes.Black));

    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
        nameof(Stroke),
        typeof(Brush),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(Brushes.Black));

    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
        nameof(StrokeThickness),
        typeof(double),
        typeof(SimpleHand),
        new FrameworkPropertyMetadata(1.0));

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public override void Render(DrawingContext drawingContext, Rect bounds)
    {
        double totalSeconds = Time.Seconds;

        double angleDegrees = (totalSeconds / 60.0) * 360.0;
        double radiusAtAngle = MathUtils.CalculateRadius(bounds, angleDegrees - 90.0);
        double handLength = radiusAtAngle * (Length / 100.0);

        Point center = new(bounds.Width / 2, bounds.Height / 2);
        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        Pen pen = new(Stroke, StrokeThickness);

        Point startPoint = center;
        Point endPoint = new(center.X, center.Y - handLength);

        drawingContext.DrawLine(pen, startPoint, endPoint);

        drawingContext.Pop();
    }
}
