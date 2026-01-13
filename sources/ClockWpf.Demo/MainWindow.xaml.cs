using System.Windows;
using System.Windows.Media;
using DustInTheWind.ClockWpf.Shapes;
using DustInTheWind.ClockWpf.TimeProviders;

namespace ClockWpf.Demo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        analogClock1.KeepProportions = false;

        analogClock1.Shapes.Add(new SimpleBackground());

        analogClock1.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 48,
            Width = 10,
            TailLength = 12,
            StrokeThickness = 0,
            Fill = Brushes.RoyalBlue
        });

        analogClock1.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 74,
            Width = 8,
            TailLength = 8,
            StrokeThickness = 0,
            Fill = Brushes.LimeGreen
        });

        analogClock1.Shapes.Add(new SimpleHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 85,
            TailLength = 14,
            Stroke = Brushes.Red,
            StrokeThickness = 1
        });

        LocalTimeProvider localTimeProvider = new();
        localTimeProvider.Start();

        analogClock1.TimeProvider = localTimeProvider;
    }
}