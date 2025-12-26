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
    /// Provides a fancy visual template for rendering a clock, featuring nib-style hands and a decorative sweep hand.
    /// </summary>
    /// <remarks>This template supplies an elegant analog clock appearance with nib-style hour and minute hands,
    /// a fancy sweep hand for seconds, and standard tick marks and background elements.</remarks>
    public class FancyClockTemplate : ClockTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FancyClockTemplate"/> class with default background, angular, and hand
        /// shapes.
        /// </summary>
        /// <remarks>This constructor populates the BackgroundShapes, AngularShapes, and HandShapes
        /// properties with their respective fancy values. Use this constructor to create a clock template with the
        /// fancy set of shapes.</remarks>
        public FancyClockTemplate()
        {
            BackgroundShapes = EnumerateBackgroundShapes().ToArray();
            AngularShapes = EnumerateAngularShapes().ToArray();
            HandShapes = EnumerateHandShapes().ToArray();
        }

        private static IEnumerable<IBackground> EnumerateBackgroundShapes()
        {
            yield return new ClockBackground
            {
                FillColor = Color.White
            };

            yield return new StringBackground
            {
                Location = new PointF(0, 15),
                Font = new Font("Arial", 2.5f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.FromArgb(0x60, 0x60, 0x60),
                Text = "Fancy",
            };
        }

        private static IEnumerable<IRimMarker> EnumerateAngularShapes()
        {
            // Ticks for minutes (every 6 degrees, skip every 5th)
            yield return new Ticks
            {
                OutlineColor = Color.Black,
                Length = 3f,
                OutlineWidth = 0.3f,
                DistanceFromEdge = 0f,
                Angle = 6f,
                SkipIndex = 5
            };

            // Ticks for hours (every 30 degrees)
            yield return new Ticks
            {
                OutlineColor = Color.Black,
                Length = 3f,
                OutlineWidth = 1f,
                Angle = 30f
            };

            // Hour numbers
            yield return new StringRimMarker
            {
                Angle = 30f,
                DistanceFromEdge = 10f,
                Orientation = RimMarkerOrientation.Normal
            };
        }

        private static IEnumerable<IHand> EnumerateHandShapes()
        {
            // Hour hand - Nib style
            yield return new NibHand
            {
                FillColor = Color.Black,
                Length = 30f,
                ComponentToDisplay = TimeComponent.Hour,
                Width = 5f,
                OutlineColor = Color.FromArgb(0x60, 0x60, 0x60),
                OutlineWidth = 1.5f
            };

            // Minute hand - Nib style
            yield return new NibHand
            {
                ComponentToDisplay = TimeComponent.Minute,
                OutlineColor = Color.FromArgb(0x60, 0x60, 0x60),
                OutlineWidth = 1.5f
            };

            // Second hand - Fancy sweep style
            yield return new FancySweepHand
            {
                ComponentToDisplay = TimeComponent.Second
            };

            // Center pin
            yield return new Pin
            {
                FillColor = Color.FromArgb(0x60, 0x60, 0x60)
            };
        }
    }
}
