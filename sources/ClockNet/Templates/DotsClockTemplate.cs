using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// 
    /// </summary>
    public class DotsClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlueClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective default values. Use this constructor to create a clock template with the
        /// standard set of shapes.</remarks>
        public DotsClockTemplate()
        {
            BackgroundShapes = EnumerateBackgroundShapes().ToArray();
            AngularShapes = EnumerateAngularShapes().ToArray();
            HandShapes = EnumerateHandShapes().ToArray();
        }

        private static IEnumerable<IGroundShape> EnumerateBackgroundShapes()
        {
            yield return new DialShape
            {
                FillColor = Color.Black
            };

            yield return new DialShape
            {
                FillColor = Color.White,
                Radius = 48f
            };
        }

        private static IEnumerable<IAngularShape> EnumerateAngularShapes()
        {
            return Enumerable.Empty<IAngularShape>();
        }

        private static IEnumerable<IHandShape> EnumerateHandShapes()
        {
            // Hour hand
            yield return new DotHandShape
            {
                FillColor = Color.Black,
                Length = 20f,
                Radius = 7f,
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand
            yield return new DotHandShape
            {
                FillColor = Color.Black,
                Length = 38f,
                Radius = 5f,
                ComponentToDisplay = TimeComponent.Minute
            };

            // Center pin
            yield return new PinShape
            {
                FillColor = Color.Black,
                Diameter = 2f
            };
        }
    }
}
