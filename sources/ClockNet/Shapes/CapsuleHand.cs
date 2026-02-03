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

using System;
using System.ComponentModel;
using System.Drawing;
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    [Shape("f7a3e2c1-8b4d-4f9a-a5c6-3d2e1b0f8a7c")]
    public class CapsuleHand : PathHand
    {
        public new const string DefaultName = "Capsule Hand";

        public const float DefaultWidth = 4f;

        public const float DefaultTailLength = 2f;

        public const float DefaultLength = 43;

        private float width = DefaultWidth;
        private float tailLength = DefaultTailLength;

        [Category("Appearance")]
        [DefaultValue(DefaultWidth)]
        [Description("The width of the capsule hand.")]
        public float Width
        {
            get => width;
            set
            {
                width = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(DefaultTailLength)]
        [Description("The length of the tail of the hand.")]
        public float TailLength
        {
            get => tailLength;
            set
            {
                tailLength = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        public CapsuleHand()
        {
            Name = DefaultName;
            Length = DefaultLength;
            FillColor = Color.DimGray;
            OutlineColor = Color.FromArgb(224, 224, 224);
        }

        protected override void CalculateCache()
        {
            path.Reset();

            float halfWidth = width / 2f;
            float topY = -Length + halfWidth;
            float bottomY = tailLength - halfWidth;

            // Top semicircle (pointing upward)
            path.AddArc(-halfWidth, -Length, width, width, 180f, 180f);

            // Right side of the rectangle
            path.AddLine(halfWidth, topY, halfWidth, bottomY);

            // Bottom semicircle (pointing downward)
            path.AddArc(-halfWidth, tailLength - width, width, width, 0f, 180f);

            // Left side of the rectangle
            path.AddLine(-halfWidth, bottomY, -halfWidth, topY);

            path.CloseFigure();
        }
    }
}
