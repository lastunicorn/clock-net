using System.Windows.Media;
using DustInTheWind.ClockWpf.Shapes;

namespace DustInTheWind.ClockWpf.Templates;

public class DefaultClockTemplate : ClockTemplate
{
    public DefaultClockTemplate()
    {
        Items.Add(new FlatBackground());

        Items.Add(new Hours
        {
            Orientation = RimItemOrientation.Normal
        });
        Items.Add(new Ticks
        {
            Orientation = RimItemOrientation.FaceCenter
        });

        Items.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 48,
            Width = 10,
            TailLength = 12,
            StrokeThickness = 0,
            Fill = Brushes.RoyalBlue
        });

        Items.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 74,
            Width = 8,
            TailLength = 8,
            StrokeThickness = 0,
            Fill = Brushes.LimeGreen
        });

        Items.Add(new SimpleHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 85,
            TailLength = 14,
            Stroke = Brushes.Red,
            StrokeThickness = 1
        });
    }
}
