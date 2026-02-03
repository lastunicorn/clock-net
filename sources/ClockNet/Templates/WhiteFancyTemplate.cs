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
        protected override IEnumerable<IShape> EnumerateShapes()
        {
            yield return new FlatBackground
            {
                Name = "Background",
                FillColor = Color.Black
            };

            yield return new HourNumerals
            {
                Name = "Hours",
                FillColor = Color.White,
                Font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point),
                DistanceFromEdge = 46f
            };

            yield return new SlotHand
            {
                Name = "Hour Hand",
                FillColor = Color.White,
                Radius = 98f,
                Length = 72f,
                Width = 16f,
                ComponentToDisplay = TimeComponent.Hour
            };

            yield return new LineHand
            {
                Name = "Minute Hand",
                OutlineColor = Color.Black,
                Length = 90f,
                OutlineWidth = 3f,
                TailLength = 0f,
                ComponentToDisplay = TimeComponent.Minute
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                OutlineColor = Color.Black,
                Length = 90f,
                OutlineWidth = 1f,
                TailLength = 30f,
                ComponentToDisplay = TimeComponent.Second
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Black,
                Diameter = 20f,
                OutlineColor = Color.FromArgb(0x64, 0x64, 0x64)
            };
        }
    }
}
