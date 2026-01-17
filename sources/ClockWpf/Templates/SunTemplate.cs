using System.Windows.Media;
using DustInTheWind.ClockWpf.Shapes;

namespace DustInTheWind.ClockWpf.Templates;

public class SunTemplate : ClockTemplate
{
    protected override IEnumerable<Shape> CreateShapes()
    {
        yield return new FancyBackground
        {
            OuterRimWidth = 14,
            InnerRimWidth = 46
        };

        // Minutes
        yield return new TextRim
        {
            Texts = Enumerable.Range(1, 60)
                .Select(x => x.ToString())
                .ToArray(),
            Angle = 6,
            OffsetAngle = 6,
            DistanceFromEdge = 7,
            FontFamily = new FontFamily("Arial"),
            FontSize = 4.4,
            FillBrush = Brushes.Black
        };

        // Hours
        yield return new TextRim
        {
            Texts = Enumerable.Range(1, 12)
                .Select(x => x.ToString())
                .ToArray(),
            Angle = 30,
            OffsetAngle = 30,
            DistanceFromEdge = 37,
            FontFamily = new FontFamily("Arial"),
            FontSize = 17,
            Orientation = RimItemOrientation.Normal,
            FillBrush = Brushes.Black
        };

        // Hour Hand
        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 63,
            FillBrush = null,
            StrokeBrush = Brushes.Black,
            StrokeThickness = 1,
            Radius = 14,
            IntegralValue = true
        };

        // Minute Hand
        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 93,
            FillBrush = null,
            StrokeBrush = Brushes.Black,
            StrokeThickness = 1,
            Radius = 6,
            IntegralValue = true
        };

        // Second Hand
        yield return new DotHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 93,
            FillBrush = null,
            StrokeBrush = Brushes.Black,
            StrokeThickness = 0.5,
            Radius = 6
        };
    }
}
