using System.Windows.Media;
using DustInTheWind.ClockWpf.Shapes;

namespace DustInTheWind.ClockWpf.Templates;

public class SunClockTemplate : ClockTemplate
{
    protected override IEnumerable<Shape> CreateShapes()
    {
        yield return new FancyBackground
        {
            InnerRimWidth = 46,
            OuterRimWidth = 14
        };

        yield return new TextRim
        {
            Texts = Enumerable.Range(1, 12)
                .Select(x => x.ToString())
                .ToArray(),
            Angle = 30,
            OffsetAngle = 30,
            DistanceFromEdge = 38.5,
            FontFamily = new FontFamily("Arial"),
            FontSize = 17,
            Orientation = RimItemOrientation.Normal,
            Fill = Brushes.Black
        };

        yield return new TextRim
        {
            Texts = Enumerable.Range(1, 60)
                .Select(x => x.ToString())
                .ToArray(),
            Angle = 6,
            OffsetAngle = 6,
            DistanceFromEdge = 7.5,
            FontFamily = new FontFamily("Arial"),
            FontSize = 4.4,
            Fill = Brushes.Black
        };

        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 62,
            Fill = null,
            Stroke = Brushes.Black,
            StrokeThickness = 1,
            Radius = 14,
            IntegralValue = true
        };

        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 93,
            Fill = null,
            Stroke = Brushes.Black,
            StrokeThickness = 1,
            Radius = 6,
            IntegralValue = true
        };

        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 93,
            Fill = null,
            Stroke = Brushes.Black,
            StrokeThickness = 0.5,
            Radius = 6
        };
    }
}
