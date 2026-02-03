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
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FancyBackground
            {
                Name = "Fancy Dial",
                FillColor = Color.Chocolate,
                InnerRimWidth = 46f,
                OuterRimWidth = 14f
            };

            yield return new DotHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                IntegralValue = true,
                Length = 62f,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                FillColor = Color.Empty,
                Radius = 14f
            };

            yield return new DotHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                IntegralValue = true,
                Length = 93f,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                FillColor = Color.Empty,
                Radius = 6f
            };

            yield return new DotHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 93f,
                OutlineColor = Color.Black,
                FillColor = Color.Empty,
                Radius = 6f
            };

            yield return new StringRim
            {
                Name = "Hours",
                Angle = 30f,
                OffsetAngle = 30f,
                DistanceFromEdge = 40f,
                Font = new Font("Arial", 12.5f),
                Orientation = RimItemOrientation.Normal,
                Texts = Enumerable.Range(1, 12)
                    .Select(x => x.ToString())
                    .ToArray()
            };

            yield return new StringRim
            {
                Name = "Minutes",
                DistanceFromEdge = 8f,
                Font = new Font("Arial", 4f),
                Texts = Enumerable.Range(1, 60)
                    .Select(x => x.ToString())
                    .ToArray()
            };
        }
    }
}
