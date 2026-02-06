using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides a predefined clock template with a black-themed design, including default background, angular, and hand
    /// shapes.
    /// </summary>
    /// <remarks>Use this class to create a clock template with a standard set of shapes and styles suitable
    /// for a black or dark-themed clock face. The template initializes the BackgroundShapes, AngularShapes, and
    /// HandShapes properties with default values representing a complete analog clock layout.</remarks>
    public class SharpTemplate : TemplateBase
    {
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FancyBackground
            {
                Name = "Fancy Background",
                FillColor = Color.Black
            };

            yield return new Ticks
            {
                Name = "Minute Ticks",
                DistanceFromEdge = 16.5f,
                Angle = 6f,
                OffsetAngle = 6f,
                SkipIndex = 5,
                OutlineWidth = 0.3f
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                DistanceFromEdge = 16.5f,
                Angle = 30f,
                OffsetAngle = 30f,
                OutlineColor = Color.White,
                OutlineWidth = 1f
            };

            yield return new HourNumerals
            {
                Name = "Hour Numerals",
                DistanceFromEdge = 32f,
                FillColor = Color.LightGray,
                Font = new Font("Vivaldi", 12.5f, FontStyle.Italic)
            };

            yield return new TextRim
            {
                Name = "Minute Numerals",
                Angle = 30f,
                OffsetAngle = 30f,
                DistanceFromEdge = 5.5f,
                FillColor = Color.DarkGray,
                Font = new Font("Arial", 4.4f),
                Texts = Enumerable.Range(1, 12)
                    .Select(x => (x * 5).ToString())
                    .ToArray()
            };

            yield return new DiamondHand
            {
                Name = "Hour Hand",
                TimeComponent = TimeComponent.Hour,
                FillColor = Color.RoyalBlue,
                Length = 50f,
                Width = 10f,
                TailLength = 8f,
                OutlineWidth = 0f
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand",
                TimeComponent = TimeComponent.Minute,
                FillColor = Color.LimeGreen,
                Length = 76f,
                Width = 8f,
                TailLength = 8f,
                OutlineWidth = 0f
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                TimeComponent = TimeComponent.Second,
                Length = 86f,
                TailLength = 14f,
                OutlineColor = Color.Red,
                OutlineWidth = 0.3f
            };

            yield return new Pin
            {
                Name = "Pin",
                Diameter = 2f,
                FillColor = Color.Red
            };
        }
    }
}
