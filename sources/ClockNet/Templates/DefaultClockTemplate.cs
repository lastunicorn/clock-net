// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides the default visual template for rendering a clock, including standard background, tick marks, and hand
    /// shapes.
    /// </summary>
    /// <remarks>This template supplies a conventional analog clock appearance with predefined shapes for the
    /// dial, tick marks, and hands. It can be used as a base or reference for custom clock templates. The default
    /// configuration includes hour, minute, and second hands, as well as standard tick marks and background
    /// elements.</remarks>
    public class DefaultClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective default values. Use this constructor to create a clock template with the
        /// standard set of shapes.</remarks>
        public DefaultClockTemplate()
        {
            BackgroundShapes = EnumerateBackgroundShapes().ToArray();
            AngularShapes = EnumerateAngularShapes().ToArray();
            HandShapes = EnumerateHandShapes().ToArray();
        }

        private static IEnumerable<IBackground> EnumerateBackgroundShapes()
        {
            yield return new ClockBackground
            {
                FillColor = Color.LightGray
            };

            yield return new StringBackground
            {
                Location = new PointF(0, 15),
                Font = new Font("Arial", 2.5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.DarkSlateGray,
                Text = "Dust in the Wind",
            };
        }

        private static IEnumerable<IRimMarker> EnumerateAngularShapes()
        {
            // Ticks for minutes
            yield return new Ticks
            {
                OutlineWidth = 0.3f,
                DistanceFromEdge = 2f,
                Length = 4f,
                Angle = 6f,
                SkipIndex = 5
            };

            // Ticks for hours
            yield return new Ticks
            {
                OutlineWidth = 1f,
                DistanceFromEdge = 2f,
                Length = 3f,
                Angle = 30f
            };

            // Hour numbers
            yield return new StringRimMarker
            {
                Angle = 30f,
                DistanceFromEdge = 13.5f,
                Orientation = RimMarkerOrientation.Normal,
                Repeat = true
            };
        }

        private static IEnumerable<IHand> EnumerateHandShapes()
        {
            // Hour hand
            yield return new DiamondHand(Color.Empty, Color.RoyalBlue, 24f, 5f, 6f)
            {
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand
            yield return new DiamondHand(Color.Empty, Color.LimeGreen, 37f, 4f, 4f)
            {
                ComponentToDisplay = TimeComponent.Minute
            };

            // Second hand
            yield return new LineHand
            {
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.Red
            };

            // Center pin
            yield return new Pin
            {
                FillColor = Color.Red
            };
        }
    }
}
