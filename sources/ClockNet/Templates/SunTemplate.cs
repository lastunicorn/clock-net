using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    public class SunTemplate : TemplateBase
    {
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FancyBackground
            {
                Name = "Background",
                FillColor = Color.Chocolate,
                OuterRimWidth = 14f,
                InnerRimWidth = 46f
            };

            yield return new HourNumerals
            {
                Name = "Hour Numerals",
                Orientation = RimItemOrientation.Normal,
                DistanceFromEdge = 37f,
                Font = new Font("Arial", 12.5f),
                FillColor = Color.Black
            };

            yield return new TextRim
            {
                Name = "Minute Numerals",
                Texts = Enumerable.Range(1, 60)
                    .Select(x => x.ToString())
                    .ToArray(),
                Angle = 6f,
                OffsetAngle = 6f,
                DistanceFromEdge = 8f,
                Font = new Font("Arial", 4f),
                FillColor = Color.Black
            };

            yield return new DotHand
            {
                Name = "Hour Hand",
                TimeComponent = TimeComponent.Hour,
                Length = 63f,
                FillColor = Color.Empty,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                Radius = 14f,
                IntegralValue = true
            };

            yield return new DotHand
            {
                Name = "Minute Hand",
                TimeComponent = TimeComponent.Minute,
                Length = 93f,
                FillColor = Color.Empty,
                OutlineColor = Color.Black,
                OutlineWidth = 1f,
                Radius = 6f,
                IntegralValue = true
            };

            yield return new DotHand
            {
                Name = "Second Hand",
                TimeComponent = TimeComponent.Second,
                Length = 93f,
                FillColor = Color.Empty,
                OutlineColor = Color.Black,
                OutlineWidth = 0.5f,
                Radius = 6f
            };
        }
    }
}
