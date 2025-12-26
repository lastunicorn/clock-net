using System.Drawing;
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Basic;

namespace ClockNet.Core.Shapes.Default
{
    public class Hours : StringRimMarker
    {
        public Hours()
        {
            Name = "Hours";
            Texts = new string[] { "1", "2", "3", "4", "5", "6" };
            Font = new Font("Arial", 6.25f, FontStyle.Regular, GraphicsUnit.Point);
            DistanceFromEdge = 13f;
            Angle = 30f;
            Orientation = RimMarkerOrientation.Normal;
        }
    }
}
