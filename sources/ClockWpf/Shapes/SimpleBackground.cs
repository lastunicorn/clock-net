using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class SimpleBackground : Shape
{
    public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
        nameof(Fill),
        typeof(Brush),
        typeof(SimpleBackground),
        new FrameworkPropertyMetadata(Brushes.White));

    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
        nameof(Stroke),
        typeof(Brush),
        typeof(SimpleBackground),
        new FrameworkPropertyMetadata(Brushes.Black));

    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
        nameof(StrokeThickness),
        typeof(double),
        typeof(SimpleBackground),
        new FrameworkPropertyMetadata(1.0));

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public override void Render(DrawingContext drawingContext, Rect bounds)
    {
        Pen pen = new(Stroke, StrokeThickness);

        Point center = new(bounds.Width / 2, bounds.Height / 2);
        double radiusX = bounds.Width / 2;
        double radiusY = bounds.Height / 2;

        drawingContext.DrawEllipse(Fill, pen, center, radiusX, radiusY);
    }
}
