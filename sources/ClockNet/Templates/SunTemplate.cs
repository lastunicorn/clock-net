using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    public class SunTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FancyBackground
            {
                Name = "Fancy Dial",
                FillColor = Color.Chocolate,
                InnerRimWidth = 23f,
                OuterRimWidth = 7f
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new DotHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                IntegralValue = true,
                Length = 31f,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                FillColor = Color.Empty,
                Radius = 7f
            };

            yield return new DotHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                IntegralValue = true,
                Length = 46.5f,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                FillColor = Color.Empty,
                Radius = 3f
            };

            yield return new DotHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 46.5f,
                OutlineColor = Color.Black,
                FillColor = Color.Empty,
                Radius = 3f
            };
        }

        protected override IEnumerable<IRimMarker> EnumerateRimMarkers()
        {
            yield return new StringRimMarker
            {
                Name = "Hours",
                Angle = 30f,
                DistanceFromEdge = 20f,
                Font = new Font("Arial", 6.25f),
                Orientation = RimMarkerOrientation.Normal,
                Texts = Enumerable.Range(1, 12)
                    .Select(x => x.ToString())
                    .ToArray()
            };

            yield return new StringRimMarker
            {
                Name = "Minutes",
                DistanceFromEdge = 4f,
                Font = new Font("Arial", 2.2f),
                Texts = Enumerable.Range(1, 60)
                    .Select(x => x.ToString())
                    .ToArray()
            };
        }
    }
}
