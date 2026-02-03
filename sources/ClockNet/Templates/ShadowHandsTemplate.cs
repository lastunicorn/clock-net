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

namespace DustInTheWind.ClockNet.Templates
{
    public class ShadowHandsTemplate : TemplateBase
    {
        protected override IEnumerable<IBackground> EnumerateBackgrounds()
        {
            yield return new FlatBackground
            {
                FillColor = Color.Gainsboro
            };

            yield return new StringBackground
            {
                Name = "Title",
                Location = new PointF(0f, 30f),
                Font = new Font("Arial", 4f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.DarkSlateGray,
                Text = "Dust in the Wind",
            };
        }

        protected override IEnumerable<IRim> EnumerateRims()
        {
            yield return new Ticks
            {
                Name = "Minute Ticks",
                OutlineWidth = 0.3f,
                DistanceFromEdge = 6f,
                Angle = 6f,
                OffsetAngle = 6f,
                SkipIndex = 5
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                OutlineWidth = 1f,
                DistanceFromEdge = 6f,
                Angle = 30f,
                OffsetAngle = 30f
            };

            yield return new HourNumerals
            {
                Name = "Hours",
                DistanceFromEdge = 26f
            };
        }

        protected override IEnumerable<IHand> EnumerateHands()
        {
            yield return new DiamondHand
            {
                Name = "Hour Hand Shadow",
                ComponentToDisplay = TimeComponent.Hour,
                FillColor = Color.Empty,
                OutlineColor = Color.DarkGray,
                Length = 48f,
                Width = 10f,
                TailLength = 12f,
                IntegralValue = true
            };

            yield return new DiamondHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                FillColor = Color.RoyalBlue,
                Length = 48f,
                Width = 10f,
                TailLength = 12f
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand Shadow",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.Empty,
                OutlineColor = Color.DarkGray,
                Length = 74f,
                Width = 8f,
                TailLength = 8f,
                IntegralValue = true
            };

            yield return new DiamondHand
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.LimeGreen,
                Length = 74f,
                Width = 8f,
                TailLength = 8f
            };

            yield return new LineHand
            {
                Name = "Second Hand Shadow",
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.DarkGray,
                Length = 85f,
                IntegralValue = true
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.Red,
                Length = 85f
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Red
            };
        }
    }
}
