using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using DustInTheWind.ClockWpf.Templates;
using DustInTheWind.ClockWpf.TimeProviders;

namespace DustInTheWind.ClockWpf.ClearClock;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool areControlsVisible = false;

    public MainWindow()
    {
        InitializeComponent();

        analogClock1.ApplyClockTemplate(new SunClockTemplate());

        LocalTimeProvider timeProvider = new();
        timeProvider.Start();

        analogClock1.TimeProvider = timeProvider;
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }

    private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        areControlsVisible = !areControlsVisible;

        CloseButton.Visibility = areControlsVisible
            ? Visibility.Visible
            : Visibility.Collapsed;

        ResizeGrip.Visibility = areControlsVisible
            ? Visibility.Visible
            : Visibility.Collapsed;

        e.Handled = true;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ResizeGrip_DragDelta(object sender, DragDeltaEventArgs e)
    {
        double newWidth = analogClock1.Width + e.HorizontalChange;
        double newHeight = analogClock1.Height + e.VerticalChange;

        double minSize = 100;
        double maxSize = 1000;

        double size = Math.Min(newWidth, newHeight);

        if (size >= minSize && size <= maxSize)
        {
            analogClock1.Width = size;
            analogClock1.Height = size;
        }
    }
}