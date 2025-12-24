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
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Advanced;
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides a white fancy visual template for rendering a clock, featuring a slot-style hour hand and elegant design.
    /// </summary>
    /// <remarks>This template supplies a distinctive analog clock appearance with a slot-carved hour hand,
    /// line-style minute and second hands, and standard tick marks on a black dial background.</remarks>
    public class WhiteFancyClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhiteFancyClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective white fancy values. Use this constructor to create a clock template with the
        /// white fancy set of shapes.</remarks>
        public WhiteFancyClockTemplate()
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
        }

        private static IEnumerable<IAngularShape> EnumerateAngularShapes()
        {
            // Hour numbers
            yield return new StringAngularShape
            {
                FillColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point),
                DistanceFromEdge = 23f,
                Angle = 30f,
                Orientation = AngularOrientation.Normal
            };
        }

        private static IEnumerable<IHandShape> EnumerateHandShapes()
        {
            // Hour hand - Slot style
            yield return new SlotHandShape
            {
                FillColor = Color.White,
                Radius = 49f,
                Length = 36f,
                Width = 8f,
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand - Line style
            yield return new LineHandShape
            {
                OutlineColor = Color.Black,
                Length = 45f,
                LineWidth = 3f,
                TailLength = 0f,
                ComponentToDisplay = TimeComponent.Minute
            };

            // Second hand - Line style
            yield return new LineHandShape
            {
                OutlineColor = Color.Black,
                Length = 45f,
                LineWidth = 1f,
                TailLength = 15f,
                ComponentToDisplay = TimeComponent.Second
            };

            // Center pin
            yield return new PinShape
            {
                FillColor = Color.Black,
                Diameter = 9f
            };
        }
    }
}
