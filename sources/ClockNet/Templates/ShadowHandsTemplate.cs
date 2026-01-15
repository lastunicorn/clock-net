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
                Location = new PointF(0f, 15f),
                Font = new Font("Arial", 2.25f, FontStyle.Regular, GraphicsUnit.Point),
                FillColor = Color.DarkSlateGray,
                Text = "Dust in the Wind",
            };
        }

        protected override IEnumerable<IRimMarker> EnumerateRimMarkers()
        {
            yield return new Ticks
            {
                Name = "Minute Ticks",
                OutlineWidth = 0.3f,
                DistanceFromEdge = 3f,
                Angle = 6f,
                OffsetAngle = 6f,
                SkipIndex = 5
            };

            yield return new Ticks
            {
                Name = "Hour Ticks",
                OutlineWidth = 1f,
                DistanceFromEdge = 3f,
                Angle = 30f,
                OffsetAngle = 30f
            };

            yield return new Hours
            {
                Name = "Hours",
                DistanceFromEdge = 13f
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
                Length = 24f,
                Width = 5f,
                TailLength = 6f,
                IntegralValue = true
            };

            yield return new DiamondHand
            {
                Name = "Hour Hand",
                ComponentToDisplay = TimeComponent.Hour,
                FillColor = Color.RoyalBlue,
                Length = 24f,
                Width = 5f,
                TailLength = 6f
            };

            yield return new DiamondHand(Color.Empty, Color.LimeGreen, 37f, 4f, 4f)
            {
                Name = "Minute Hand Shadow",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.Empty,
                OutlineColor = Color.DarkGray,
                Length = 37f,
                Width = 4f,
                TailLength = 4f,
                IntegralValue = true
            };

            yield return new DiamondHand(Color.Empty, Color.LimeGreen, 37f, 4f, 4f)
            {
                Name = "Minute Hand",
                ComponentToDisplay = TimeComponent.Minute,
                FillColor = Color.LimeGreen,
                Length = 37f,
                Width = 4f,
                TailLength = 4f
            };

            yield return new LineHand
            {
                Name = "Second Hand Shadow",
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.DarkGray,
                Length = 42.5f,
                IntegralValue = true
            };

            yield return new LineHand
            {
                Name = "Second Hand",
                ComponentToDisplay = TimeComponent.Second,
                OutlineColor = Color.Red,
                Length = 42.5f
            };

            yield return new Pin
            {
                Name = "Pin",
                FillColor = Color.Red
            };
        }
    }
}
