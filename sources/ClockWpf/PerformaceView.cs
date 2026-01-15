using System.Globalization;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace DustInTheWind.ClockWpf;

public class PerformaceView : Control
{
    private PerformanceInfo currentPerformanceInfo;

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.Property == DataContextProperty)
        {
            if (currentPerformanceInfo != null)
                currentPerformanceInfo.PropertyChanged -= OnPerformanceInfoChanged;

            currentPerformanceInfo = DataContext as PerformanceInfo;

            if (currentPerformanceInfo != null)
                currentPerformanceInfo.PropertyChanged += OnPerformanceInfoChanged;
        }
    }

    private void OnPerformanceInfoChanged(object sender, PropertyChangedEventArgs e)
    {
        InvalidateVisual();
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        if (DataContext is PerformanceInfo performanceInfo)
        {
            string performanceText = performanceInfo.ToString();
            FormattedText formattedText = new(
                performanceText,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                12,
                Brushes.Black,
                1.0);

            drawingContext.DrawText(formattedText, new Point(5, 5));
        }
    }
}