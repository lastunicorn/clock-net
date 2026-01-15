using System.Windows;
using System.Windows.Media;
using DustInTheWind.ClockWpf;
using DustInTheWind.ClockWpf.Shapes;
using DustInTheWind.ClockWpf.Templates;
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

        CreateShapesFor(analogClock1);

        analogClock3.ApplyClockTemplate(new CapsuleClockTemplate());

        LocalTimeProvider localTimeProvider = new();
        localTimeProvider.Start();

        analogClock1.TimeProvider = localTimeProvider;
        analogClock2.TimeProvider = localTimeProvider;
        analogClock3.TimeProvider = localTimeProvider;
    }

    private void CreateShapesFor(AnalogClock analogClock)
    {
        analogClock.Shapes.Add(new FlatBackground());

        analogClock.Shapes.Add(new Hours
        {
            Orientation = RimItemOrientation.Normal
        });
        analogClock.Shapes.Add(new Ticks
        {
            Orientation = RimItemOrientation.FaceCenter
        });

        analogClock.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 48,
            Width = 10,
            TailLength = 12,
            StrokeThickness = 0,
            Fill = Brushes.RoyalBlue
        });

        analogClock.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 74,
            Width = 8,
            TailLength = 8,
            StrokeThickness = 0,
            Fill = Brushes.LimeGreen
        });

        analogClock.Shapes.Add(new SimpleHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 85,
            TailLength = 14,
            Stroke = Brushes.Red,
            StrokeThickness = 1
        });
    }
}