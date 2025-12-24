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
    /// Provides a predefined clock template with a blue-themed design, including default background, angular, and hand
    /// shapes.
    /// </summary>
    /// <remarks>Use this class to create a clock face with a standard set of shapes and colors suitable for
    /// blue-themed or modern clock displays. The template initializes its shape collections with default values
    /// representing a typical analog clock layout.</remarks>
    public class BlueClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlueClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective default values. Use this constructor to create a clock template with the
        /// standard set of shapes.</remarks>
        public BlueClockTemplate()
        {
            BackgroundShapes = EnumerateBackgroundShapes().ToArray();
            AngularShapes = EnumerateAngularShapes().ToArray();
            HandShapes = EnumerateHandShapes().ToArray();
        }

        private static IEnumerable<IGroundShape> EnumerateBackgroundShapes()
        {
            yield return new DialShape
            {
                FillColor = Color.LightBlue
            };

            yield return new StringGroundShape
            {
                Location = new PointF(0, 15),
                Font = new Font("Arial", 2.5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.DarkSlateGray,
                Text = "Blue",
            };
        }

        private static IEnumerable<IAngularShape> EnumerateAngularShapes()
        {
            // Ticks for minutes
            yield return new TicksShape
            {
                OutlineColor = Color.RoyalBlue,
                LineWidth = 0.75f,
                DistanceFromEdge = 5f,
                Length = 7.5f,
                Angle = 6f,
                SkipIndex = 5
            };

            // Ticks for hours
            yield return new TicksShape
            {
                OutlineColor = Color.Navy,
                LineWidth = 5f,
                DistanceFromEdge = 5f,
                Length = 5f,
                Angle = 30f
            };

            // Hour numbers
            yield return new StringAngularShape
            {
                FillColor = Color.Navy,
                Angle = 30f,
                DistanceFromEdge = 20f,
                Orientation = AngularOrientation.Normal,
                Repeat = true
            };
        }

        private static IEnumerable<IHandShape> EnumerateHandShapes()
        {
            // Hour hand
            yield return new DiamondHandShape
            {
                FillColor = Color.Navy,
                Length = 24f,
                Width = 5f,
                TailLength = 6f,
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand
            yield return new DiamondHandShape(Color.Empty, Color.LimeGreen, 37f, 4f, 4f)
            {
                FillColor = Color.RoyalBlue,
                Length = 37f,
                Width = 4f,
                TailLength = 4f,
                ComponentToDisplay = TimeComponent.Minute
            };

            // Second hand
            yield return new LineHandShape
            {
                OutlineColor = Color.DeepSkyBlue,
                ComponentToDisplay = TimeComponent.Second
            };

            // Center pin
            yield return new PinShape
            {
                FillColor = Color.Navy
            };
        }
    }
}
