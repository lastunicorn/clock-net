using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class DiamondHand : HandBase
{
    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
        nameof(Width),
        typeof(double),
        typeof(DiamondHand),
        new FrameworkPropertyMetadata(5.0));

    public new double Width
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

    public override void Render(DrawingContext drawingContext, double diameter)
    {
        double angleDegrees = CalculateAngle();
        Point center = new(diameter / 2, diameter / 2);

        RotateTransform rotateTransform = new(angleDegrees, center.X, center.Y);
        drawingContext.PushTransform(rotateTransform);

        Pen pen = StrokeThickness > 0 && Stroke != null
            ? new Pen(Stroke, StrokeThickness)
            : null;

        double radius = diameter / 2;
        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);
        double halfWidth = radius * (Width / 100.0) / 2.0;

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
