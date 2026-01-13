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

    public override void DoRender(DrawingContext drawingContext, double diameter)
    {
        double angleDegrees = CalculateHandAngle();

        RotateTransform rotateTransform = new(angleDegrees, 0, 0);
        drawingContext.WithTransform(rotateTransform, () =>
        {
            Pen pen = StrokeThickness > 0 && Stroke != null
                ? new Pen(Stroke, StrokeThickness)
                : null;

            PathGeometry diamondGeometry = CreateDiamondGeometry(diameter);

            drawingContext.DrawGeometry(Fill, pen, diamondGeometry);
        });
    }

    private PathGeometry CreateDiamondGeometry(double diameter)
    {
        double radius = diameter / 2;
        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);
        double halfWidth = radius * (Width / 100.0) / 2.0;

        PathFigure diamondFigure = new()
        {
            StartPoint = new Point(0, tailLength),
            IsClosed = true
        };

        diamondFigure.Segments.Add(new LineSegment(new Point(-halfWidth, 0), true));
        diamondFigure.Segments.Add(new LineSegment(new Point(0, -handLength), true));
        diamondFigure.Segments.Add(new LineSegment(new Point(halfWidth, 0), true));

        PathGeometry diamondGeometry = new();
        diamondGeometry.Figures.Add(diamondFigure);

        return diamondGeometry;
    }
}
