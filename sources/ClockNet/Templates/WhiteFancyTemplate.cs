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
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Advanced;
using DustInTheWind.ClockNet.Core.Shapes.Basic;
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides a white fancy visual template for rendering a clock, featuring a slot-style hour hand and elegant design.
    /// </summary>
    /// <remarks>This template supplies a distinctive analog clock appearance with a slot-carved hour hand,
    /// line-style minute and second hands, and standard tick marks on a black dial background.</remarks>
    public class WhiteFancyTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FlatBackground
            {
                FillColor = Color.Black
            };
        }

        protected override IEnumerable<IRimMarker> EnumerateRimMarkers()
        {
            // Hour numbers
            yield return new Hours
            {
                Name = "Hours",
                FillColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point),
                DistanceFromEdge = 23f
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            // Hour hand - Slot style
            yield return new SlotHand
            {
                Name = "Hour Hand",
                FillColor = Color.White,
                Radius = 49f,
                Length = 36f,
                Width = 8f,
                ComponentToDisplay = TimeComponent.Hour
            };

            // Minute hand - Line style
            yield return new LineHand
            {
                Name = "Minute Hand",
                OutlineColor = Color.Black,
                Length = 45f,
                OutlineWidth = 3f,
                TailLength = 0f,
                ComponentToDisplay = TimeComponent.Minute
            };

            // Second hand - Line style
            yield return new LineHand
            {
                Name = "Second Hand",
                OutlineColor = Color.Black,
                Length = 45f,
                OutlineWidth = 1f,
                TailLength = 15f,
                ComponentToDisplay = TimeComponent.Second
            };

            // Center pin
            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Black,
                Diameter = 10f,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64)
            };
        }
    }
}
