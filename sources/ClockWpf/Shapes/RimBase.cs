using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public abstract class RimBase : Shape
{
    public static readonly DependencyProperty DistanceFromEdgeProperty = DependencyProperty.Register(
        nameof(DistanceFromEdge),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(0.0));

    public double DistanceFromEdge
    {
        get => (double)GetValue(DistanceFromEdgeProperty);
        set => SetValue(DistanceFromEdgeProperty, value);
    }

    public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
        nameof(Angle),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(30.0));

    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }

    public static readonly DependencyProperty OffsetAngleProperty = DependencyProperty.Register(
        nameof(OffsetAngle),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(0.0));

    public double OffsetAngle
    {
        get => (double)GetValue(OffsetAngleProperty);
        set => SetValue(OffsetAngleProperty, value);
    }

    public static readonly DependencyProperty MaxCoverageCountProperty = DependencyProperty.Register(
        nameof(MaxCoverageCount),
        typeof(uint),
        typeof(RimBase),
        new FrameworkPropertyMetadata(uint.MaxValue));

    public uint MaxCoverageCount
    {
        get => (uint)GetValue(MaxCoverageCountProperty);
        set => SetValue(MaxCoverageCountProperty, value);
    }

    public static readonly DependencyProperty MaxCoverageAngleProperty = DependencyProperty.Register(
        nameof(MaxCoverageAngle),
        typeof(uint),
        typeof(RimBase),
        new FrameworkPropertyMetadata((uint)360));

    public uint MaxCoverageAngle
    {
        get => (uint)GetValue(MaxCoverageAngleProperty);
        set => SetValue(MaxCoverageAngleProperty, value);
    }

    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
        nameof(Orientation),
        typeof(RimItemOrientation),
        typeof(RimBase),
        new FrameworkPropertyMetadata(RimItemOrientation.FaceCenter));

    public RimItemOrientation Orientation
    {
        get => (RimItemOrientation)GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public override void DoRender(DrawingContext drawingContext, double diameter)
    {
        double radius = diameter / 2;
        double actualDistanceFromEdge = radius * DistanceFromEdge / 100.0;
        double itemRadius = radius - actualDistanceFromEdge;

        int index = 0;
        double angleDegrees = OffsetAngle + (index * Angle);

        while (angleDegrees >= 0)
        {
            if (MaxCoverageCount > 0 && index >= MaxCoverageCount)
                break;

            if (MaxCoverageAngle > 0 && angleDegrees - OffsetAngle >= MaxCoverageAngle)
                break;

            RotateTransform rotateTransform = new(angleDegrees, 0, 0);
            drawingContext.WithTransform(rotateTransform, () =>
            {
                TranslateTransform translateTransform = new(0, -itemRadius);
                drawingContext.WithTransform(translateTransform, () =>
                {
                    Transform orientationTransform = CreateOrientationTransform(index);

                    if (orientationTransform != null)
                    {
                        drawingContext.WithTransform(orientationTransform, () =>
                        {
                            RenderItem(drawingContext, index);
                        });
                    }
                    else
                    {
                        RenderItem(drawingContext, index);
                    }
                });
            });

            index++;
            angleDegrees = OffsetAngle + (index * Angle);
        }
    }

    private Transform CreateOrientationTransform(int index)
    {
        switch (Orientation)
        {
            case RimItemOrientation.Normal:
                {
                    double totalAngle = -(OffsetAngle + Angle * index);
                    RotateTransform rotateTransform = new(totalAngle, 0, 0);
                    return rotateTransform;
                }

            case RimItemOrientation.FaceOut:
                {
                    RotateTransform rotateTransform = new(180, 0, 0);
                    return rotateTransform;
                }

            case RimItemOrientation.FaceCenter:
            default:
                return null;
        }
    }

    protected abstract void RenderItem(DrawingContext drawingContext, int index);
}