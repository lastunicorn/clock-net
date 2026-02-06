using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Core.Shapes.Default
{
    [Shape("6fd89cdf-88f0-4417-960c-c1c78c782d26")]
    public class HourNumerals : TextRim
    {
        public HourNumerals()
        {
            Name = "Hour Numerals";
            Texts = Enumerable.Range(1, 12)
                .Select(x => x.ToString())
                .ToArray();
            Font = new Font("Arial", 12.5f, FontStyle.Regular, GraphicsUnit.Point);
            DistanceFromEdge = 26f;
            Angle = 30f;
            OffsetAngle = 30f;
            Orientation = RimItemOrientation.Normal;
        }
    }
}
