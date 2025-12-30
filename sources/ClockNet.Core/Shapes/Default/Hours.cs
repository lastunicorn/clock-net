using System.Drawing;
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Core.Shapes.Default
{
    [Shape("6fd89cdf-88f0-4417-960c-c1c78c782d26")]
    public class Hours : StringRimMarker
    {
        public Hours()
        {
            Name = "Hours";
            Texts = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            Font = new Font("Arial", 6.25f, FontStyle.Regular, GraphicsUnit.Point);
            DistanceFromEdge = 15f;
            Angle = 30f;
            Orientation = RimMarkerOrientation.Normal;
        }
    }
}
