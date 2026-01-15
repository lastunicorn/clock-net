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

    public override void DoRender(DrawingContext drawingContext, double diameter)
    {
        if (Fill == null && StrokePen == null)
            return;

        Point center = new(0, 0);
        double radius = (diameter - StrokeThickness) / 2;

        drawingContext.DrawEllipse(Fill, StrokePen, center, radius, radius);
    }
}
