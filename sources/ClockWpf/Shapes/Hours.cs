using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class Hours : TextRim
{
    static Hours()
    {
        DistanceFromEdgeProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(15.0));
        FontFamilyProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(new FontFamily("Arial")));
        FontSizeProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(26.0));
        FontWeightProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(FontWeights.Normal));
        TextsProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(Enumerable.Range(1, 12)
            .Select(x => x.ToString())
            .ToArray()));
        AngleProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(30.0));
        OffsetAngleProperty.OverrideMetadata(typeof(Hours), new FrameworkPropertyMetadata(30.0));
    }
}
