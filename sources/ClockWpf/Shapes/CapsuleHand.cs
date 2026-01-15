using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

/// <summary>
/// A capsule shaped clock hand with rounded ends, customizable width and tail length.
/// </summary>
public class CapsuleHand : HandBase
{
    #region Width DependencyProperty

    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
        nameof(Width),
        typeof(double),
        typeof(CapsuleHand),
        new FrameworkPropertyMetadata(4.0));

    public double Width
    {
        get => (double)GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }

    #endregion

    #region TailLength DependencyProperty

    public static readonly DependencyProperty TailLengthProperty = DependencyProperty.Register(
        nameof(TailLength),
        typeof(double),
        typeof(CapsuleHand),
        new FrameworkPropertyMetadata(2.0));

    public double TailLength
    {
        get => (double)GetValue(TailLengthProperty);
        set => SetValue(TailLengthProperty, value);
    }

    #endregion

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
                if (Fill == null && StrokePen == null)
                    return;

                PathGeometry capsuleGeometry = CreateCapsuleGeometry(diameter);

                drawingContext.DrawGeometry(Fill, StrokePen, capsuleGeometry);
            });
    }

    private PathGeometry CreateCapsuleGeometry(double diameter)
    {
        double radius = diameter / 2;
        double handLength = radius * (Length / 100.0);
        double tailLength = radius * (TailLength / 100.0);
        double halfWidth = radius * (Width / 100.0) / 2.0;

        double topY = -handLength + halfWidth;
        double bottomY = tailLength - halfWidth;

        PathFigure capsuleFigure = new()
        {
            StartPoint = new Point(-halfWidth, topY),
            IsClosed = true
        };

        // Top semicircle (pointing upward)
        capsuleFigure.Segments.Add(new ArcSegment(
            new Point(halfWidth, topY),
            new Size(halfWidth, halfWidth),
            0,
            false,
            SweepDirection.Clockwise,
            true));

        // Right side of the rectangle
        capsuleFigure.Segments.Add(new LineSegment(new Point(halfWidth, bottomY), true));

        // Bottom semicircle (pointing downward)
        capsuleFigure.Segments.Add(new ArcSegment(
            new Point(-halfWidth, bottomY),
            new Size(halfWidth, halfWidth),
            0,
            false,
            SweepDirection.Clockwise,
            true));

        // Left side of the rectangle (closes back to start point)
        capsuleFigure.Segments.Add(new LineSegment(new Point(-halfWidth, topY), true));

        PathGeometry capsuleGeometry = new();
        capsuleGeometry.Figures.Add(capsuleFigure);

        return capsuleGeometry;
    }
}
