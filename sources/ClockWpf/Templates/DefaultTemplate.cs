using System.Windows.Media;
using DustInTheWind.ClockWpf.Shapes;

namespace DustInTheWind.ClockWpf.Templates;

public class DefaultTemplate : ClockTemplate
{
    protected override IEnumerable<Shape> CreateShapes()
    {
        yield return new FlatBackground();

        yield return new Ticks
        {
            SkipIndex = 5,
        };

        yield return new Ticks
        {
            Angle = 30,
            OffsetAngle = 30,
            StrokeThickness = 2
        };

        yield return new Hours();

        yield return new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 48,
            Width = 10,
            TailLength = 12,
            StrokeThickness = 0,
            FillBrush = Brushes.RoyalBlue
        };

        yield return new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 74,
            Width = 8,
            TailLength = 8,
            StrokeThickness = 0,
            FillBrush = Brushes.LimeGreen
        };

        yield return new SimpleHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 85,
            TailLength = 14,
            StrokeBrush = Brushes.Red,
            StrokeThickness = 1
        };
    }
}
