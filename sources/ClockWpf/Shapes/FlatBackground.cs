using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class FlatBackground : BackgroundBase
{
    static FlatBackground()
    {
        FillProperty.OverrideMetadata(typeof(FlatBackground), new FrameworkPropertyMetadata(Brushes.WhiteSmoke));
        StrokeThicknessProperty.OverrideMetadata(typeof(FlatBackground), new FrameworkPropertyMetadata(0.0));
    }

    public override void DoRender(ClockDrawingContext context)
    {
        if (Fill == null && StrokePen == null)
            return;

        Point center = new(0, 0);
        double radius = (context.ClockDiameter - StrokeThickness) / 2;

        context.DrawingContext.DrawEllipse(Fill, StrokePen, center, radius, radius);
    }
}
