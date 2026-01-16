using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

/// <summary>
/// A clock hand rendered as a dot (disk) at a specified distance from the center.
/// </summary>
public class DotHand : HandBase
{
    #region Radius DependencyProperty

    public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
        nameof(Radius),
        typeof(double),
        typeof(DotHand),
        new FrameworkPropertyMetadata(5.0));

    public double Radius
    {
        get => (double)GetValue(RadiusProperty);
        set => SetValue(RadiusProperty, value);
    }

    #endregion

    public override void DoRender(ClockDrawingContext context)
    {
        context.DrawingContext.CreateDrawingPlan()
            .WithTransform(() =>
            {
                double angleDegrees = CalculateHandAngle(context.Time);
                return new RotateTransform(angleDegrees, 0, 0);
            })
            .Draw(dc =>
            {
                if (Fill == null && StrokePen == null)
                    return;

                if (Radius <= 0 || Length <= 0)
                    return;

                double clockRadius = context.ClockDiameter / 2;
                double handLength = clockRadius * (Length / 100.0);
                double dotRadius = clockRadius * (Radius / 100.0);

                Point center = new(0, -handLength);

                dc.DrawEllipse(Fill, StrokePen, center, dotRadius, dotRadius);
            });
    }
}
