using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class SimpleBackground : Shape
{
    static SimpleBackground()
    {
        FillProperty.OverrideMetadata(typeof(SimpleBackground), new FrameworkPropertyMetadata(Brushes.WhiteSmoke));
        StrokeThicknessProperty.OverrideMetadata(typeof(SimpleBackground), new FrameworkPropertyMetadata(0.0));
    }

    public override void Render(DrawingContext drawingContext, double diameter)
    {
        Pen pen = StrokeThickness > 0
            ? new(Stroke, StrokeThickness)
            : null;

        Point center = new(diameter / 2, diameter / 2);
        double radiusX = diameter / 2 - StrokeThickness / 2;
        double radiusY = diameter / 2 - StrokeThickness / 2;

        drawingContext.DrawEllipse(Fill, pen, center, radiusX, radiusY);
    }
}
