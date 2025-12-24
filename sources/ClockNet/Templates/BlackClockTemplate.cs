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
    /// Provides a predefined clock template with a black-themed design, including default background, angular, and hand
    /// shapes.
    /// </summary>
    /// <remarks>Use this class to create a clock template with a standard set of shapes and styles suitable
    /// for a black or dark-themed clock face. The template initializes the BackgroundShapes, AngularShapes, and
    /// HandShapes properties with default values representing a complete analog clock layout.</remarks>
    public class BlackClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlackClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective default values. Use this constructor to create a clock template with the
        /// standard set of shapes.</remarks>
        public BlackClockTemplate()
        {
            BackgroundShapes = EnumerateBackgroundShapes().ToArray();
            AngularShapes = EnumerateAngularShapes().ToArray();
            HandShapes = EnumerateHandShapes().ToArray();
        }

        private static IEnumerable<IGroundShape> EnumerateBackgroundShapes()
        {
            yield return new FancyDialShape
            {
                FillColor = Color.Black
            };

            yield return new StringGroundShape
            {
                Location = new PointF(0, 15),
                Font = new Font("Arial", 2.5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.LightGray,
                Text = "Black",
            };
        }

        private static IEnumerable<IAngularShape> EnumerateAngularShapes()
        {
            // Ticks for minutes
            yield return new TicksShape
            {
                LineWidth = 0.3f,
                DistanceFromEdge = 8f,
                Length = 3f,
                Angle = 6f,
                ExceptionIndex = 5
            };

            // Ticks for hours
            yield return new TicksShape
            {
                LineWidth = 1f,
                DistanceFromEdge = 8f,
                Length = 3f,
                Angle = 30f
            };

            // Hour numbers
            yield return new StringAngularShape
            {
                Font = new Font("Arial", 5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.WhiteSmoke,
                Angle = 30f,
                DistanceFromEdge = 17f,
                Orientation = AngularOrientation.Normal
            };

            // Minute numbers
            yield return new StringAngularShape
            {
                Font = new Font("Arial", 2.2f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.WhiteSmoke,
                Angle = 30f,
                DistanceFromEdge = 3f,
                Texts = new string[] { "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60" }
            };
        }

        private static IEnumerable<IHandShape> EnumerateHandShapes()
        {
            // Hour hand
            yield return new DiamondHandShape(Color.Empty, Color.RoyalBlue, 24f, 5f, 6f)
            {
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand
            yield return new DiamondHandShape(Color.Empty, Color.LimeGreen, 37f, 4f, 4f)
            {
                ComponentToDisplay = TimeComponent.Minute
            };

            // Second hand
            yield return new LineHandShape
            {
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.Red,
                Length = 42f
            };

            // Center pin
            yield return new PinShape
            {
                FillColor = Color.Red
            };
        }
    }
}
