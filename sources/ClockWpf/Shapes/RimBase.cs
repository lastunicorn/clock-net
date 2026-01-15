using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

/// <summary>
/// The base class for rim shape that display items around the clock face.
/// </summary>
/// <remarks>
/// When inherinting this class, overwrite the <see cref="RenderItem"/> method to draw an item.
/// This method is called for each item that must be drawn around the clock face.
/// The position and orientation of the item is already set when this method is called.
/// The item should be drawn centered at the point (0,0).
/// </remarks>
public abstract class RimBase : Shape
{
    #region DistanceFromEdge DependencyProperty

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

    #endregion

    #region Angle DependencyProperty

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

    #endregion

    #region OffsetAngle DependencyProperty

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

    #endregion

    #region MaxCoverageCount DependencyProperty

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

    #endregion

    #region MaxCoverageAngle DependencyProperty

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

    #endregion

    #region Orientation DependencyProperty

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

    #endregion

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

            drawingContext.CreateDrawingPlan()
                .WithTransform(() => new RotateTransform(angleDegrees, 0, 0))
                .WithTransform(() => new TranslateTransform(0, -itemRadius))
                .WithTransform(() => CreateOrientationTransform(index))
                .Draw(cd => RenderItem(cd, index));

            index++;
            angleDegrees = OffsetAngle + (index * Angle);
        }
    }

    private RotateTransform CreateOrientationTransform(int index)
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

    /// <summary>
    /// Draws the item at the specified index using the provided drawing context.
    /// </summary>
    /// <remarks>
    /// This method is called once for each item that must be drawn around the clock face.
    /// The position and orientation of the item is already set when this method is called.
    /// The item should be drawn centered at the point (0,0).
    /// </remarks>
    /// <param name="drawingContext">The drawing context to use for rendering the item.</param>
    /// <param name="index">The zero-based index of the item to render.</param>
    protected abstract void RenderItem(DrawingContext drawingContext, int index);
}