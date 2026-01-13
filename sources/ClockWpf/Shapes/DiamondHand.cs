using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class DiamondHand : Shape
{
    public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
        nameof(Length),
        typeof(double),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(95.0));

    public double Length
    {
        get => (double)GetValue(LengthProperty);
        set => SetValue(LengthProperty, value);
    }

    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
        nameof(Width),
        typeof(double),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(5.0));

    public double Width
    {
        get => (double)GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }

    public static readonly DependencyProperty TailLengthProperty = DependencyProperty.Register(
        nameof(TailLength),
        typeof(double),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(6.0));

    public double TailLength
    {
        get => (double)GetValue(TailLengthProperty);
        set => SetValue(TailLengthProperty, value);
    }

    public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
        nameof(Time),
        typeof(TimeSpan),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(TimeSpan.Zero));

    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
        nameof(Fill),
        typeof(Brush),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(Brushes.Black));

    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
        nameof(Stroke),
        typeof(Brush),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(Brushes.Black));

    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
        nameof(StrokeThickness),
        typeof(double),
        typeof(DiamondHand),
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
        double tailLength = radiusAtAngle * (TailLength / 100.0);
        double halfWidth = radiusAtAngle * (Width / 100.0) / 2.0;

        Point center = new(bounds.Width / 2, bounds.Height / 2);
        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        Pen pen = StrokeThickness > 0 && Stroke != null
            ? new Pen(Stroke, StrokeThickness)
            : null;

        PathFigure diamondFigure = new()
        {
            StartPoint = new Point(center.X, center.Y + tailLength),
            IsClosed = true
        };

        diamondFigure.Segments.Add(new LineSegment(new Point(center.X - halfWidth, center.Y), true));
        diamondFigure.Segments.Add(new LineSegment(new Point(center.X, center.Y - handLength), true));
        diamondFigure.Segments.Add(new LineSegment(new Point(center.X + halfWidth, center.Y), true));

        PathGeometry diamondGeometry = new();
        diamondGeometry.Figures.Add(diamondFigure);

        drawingContext.DrawGeometry(Fill, pen, diamondGeometry);

        drawingContext.Pop();
    }
}
