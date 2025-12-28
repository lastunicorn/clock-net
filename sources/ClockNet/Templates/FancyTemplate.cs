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
using DustInTheWind.ClockNet.Core.Shapes.Default;
using DustInTheWind.ClockNet.Shapes.Advanced;

namespace DustInTheWind.ClockNet.Templates
{
    /// <summary>
    /// Provides a fancy visual template for rendering a clock, featuring nib-style hands and a decorative sweep hand.
    /// </summary>
    /// <remarks>This template supplies an elegant analog clock appearance with nib-style hour and minute hands,
    /// a fancy sweep hand for seconds, and standard tick marks and background elements.</remarks>
    public class FancyTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FlatBackground
            {
                Name = "Background",
                FillColor = Color.White
            };
        }

        protected override IEnumerable<IRimMarker> EnumerateRimMarkers()
        {
            yield return new Ticks
            {
                Name = "Minute Ticks",
                OutlineColor = Color.Black,
                Length = 3f,
                OutlineWidth = 0.3f,
                DistanceFromEdge = 3f,
                Angle = 6f,
                SkipIndex = 5
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                OutlineColor = Color.Black,
                Length = 3f,
                OutlineWidth = 1f,
                Angle = 30f
            };

            yield return new Hours
            {
                Name = "Hours",
                DistanceFromEdge = 13f
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new NibHand
            {
                Name = "Hour Hand",
                FillColor = Color.Black,
                Length = 30f,
                ComponentToDisplay = TimeComponent.Hour,
                Width = 5f,
                OutlineColor = Color.FromArgb(0x60, 0x60, 0x60),
                OutlineWidth = 1.5f
            };

            yield return new NibHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                OutlineColor = Color.FromArgb(0x60, 0x60, 0x60),
                OutlineWidth = 1.5f,
                Length = 43f
            };

            yield return new FancySweepHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                Length = 43f
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.FromArgb(0x64, 0x64, 0x64)
            };
        }
    }
}
