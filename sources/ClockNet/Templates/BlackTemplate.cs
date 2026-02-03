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
    public class BlackTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FancyBackground
            {
                Name = "Fancy Background",
                FillColor = Color.Black
            };

            yield return new StringBackground
            {
                Name = "Title",
                FillColor = Color.LightGray,
                Font = new Font("Arial", 4f, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new PointF(0F, 30f)
            };
        }

        protected override IEnumerable<IRim> EnumerateRims()
        {
            yield return new Ticks
            {
                Name = "Minute Ticks",
                DistanceFromEdge = 16.5f,
                Angle = 6f,
                OffsetAngle = 6f,
                SkipIndex = 5
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
                Name = "Hours",
                DistanceFromEdge = 32f,
                FillColor = Color.LightGray,
                Font = new Font("Vivaldi", 12.5f, FontStyle.Italic)
            };

            yield return new StringRim
            {
                Name = "Minutes",
                Angle = 30f,
                OffsetAngle = 30f,
                DistanceFromEdge = 5.5f,
                FillColor = Color.DarkGray,
                Font = new Font("Arial", 4.4f),
                Texts = Enumerable.Range(1, 12)
                    .Select(x => (x * 5).ToString())
                    .ToArray()
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new DiamondHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                FillColor = Color.RoyalBlue,
                Length = 50f,
                Width = 10f,
                TailLength = 8f
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.LimeGreen,
                Length = 76f,
                Width = 8f,
                TailLength = 8f
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 86f,
                OutlineColor = Color.Red
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Red
            };
        }
    }
}
