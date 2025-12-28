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
                Font = new Font("Arial", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
                Location = new PointF(0F, 15F)
            };
        }

        protected override IEnumerable<IRimMarker> EnumerateRimMarkers()
        {
            yield return new Ticks
            {
                Name = "Minute Ticks",
                DistanceFromEdge = 7F,
                SkipIndex = 5
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                Angle = 30F,
                DistanceFromEdge = 7F,
                OutlineColor = Color.White,
                OutlineWidth = 1F
            };

            yield return new Hours
            {
                Name = "Hours",
                DistanceFromEdge = 15F,
                FillColor = Color.LightGray,
                Font = new Font("Vivaldi", 6.25F, FontStyle.Italic)
            };

            yield return new StringRimMarker
            {
                Name = "Minutes",
                Angle = 30F,
                DistanceFromEdge = 2.7F,
                FillColor = Color.DarkGray,
                Font = new Font("Arial", 2.2F),
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
                Length = 25F
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.LimeGreen,
                Length = 38F,
                TailLength = 4F,
                Width = 4F
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 43F,
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
