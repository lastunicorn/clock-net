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
    /// <summary>
    /// A clock's hand that is actually a big disk with a rectangle slot carved in it through
    /// which the user can see whatever is under the disk. Usually, the hours would be visible under the slot.
    /// </summary>
    [Shape("d605fe8f-cda0-4ba5-954d-be7266c04e2d")]
    public class SlotHand : PathHand
    {
        /// <summary>
        /// The default name for the hand.
        /// </summary>
        public new const string DefaultName = "Slot Hand";

        /// <summary>
        /// The default length of the slot in the disk.
        /// </summary>
        public const float DefaultWidth = 10f;

        /// <summary>
        /// The default radius of the opaque disk.
        /// </summary>
        public const float DefaultRadius = 100f;

        /// <summary>
        /// The default length of the tail of the hand.
        /// The tail is the length of the rectangle that extends in the other direction beyond the center of the disk.
        /// </summary>
        public const float DefaultTailLength = 12f;

        private float width;
        private float radius;
        private float tailLength;

        /// <summary>
        /// Gets or sets the width of the slot carved inside the disk.
        /// </summary>
        [DefaultValue(DefaultWidth)]
        [Description("The width of the slot carved inside the disk.")]
        public float Width
        {
            get => width;
            set
            {
                if (width == value)
                    return;

                width = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the radius of the opaque disk.
        /// </summary>
        [DefaultValue(DefaultRadius)]
        [Description("The radius of the opaque disk.")]
        public float Radius
        {
            get => radius;
            set
            {
                if (radius == value)
                    return;

                radius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the length of the tail of the hand.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHand"/> class with
        /// default values.
        /// </summary>
        public SlotHand()
        {
            Name = DefaultName;
            radius = DefaultRadius;
            width = DefaultWidth;
            tailLength = DefaultTailLength;
        }

        /// <summary>
        /// Performs all the necessary calculations based on the public parameters, before drawing the shape.
        /// </summary>
        protected override void CalculateCache(ClockDrawingContext context)
        {
            path.Reset();

            float diameter = context.Diameter;
            float radius = diameter / 2;
            float actualLength = radius * (Length / 100f);
            float actualTailLength = radius * (TailLength / 100f);
            float actualWidth = radius * (Width / 100f);
            float actualHandRadius = radius * (Radius / 100f);

            // The circular disk

            float ellipseX = -actualHandRadius;
            float ellipseY = -actualHandRadius;

            float ellipseWidth = actualHandRadius * 2f;
            float ellipseHeight = actualHandRadius * 2f;

            path.AddEllipse(ellipseX, ellipseY, ellipseWidth, ellipseHeight);

            // The rectangle slot

            float rectangleX = -actualWidth / 2f;
            float rectangleY = -actualLength;

            float rectangleWidth = actualWidth;
            float rectangleHeight = actualLength + actualTailLength;

            RectangleF rect = new RectangleF(rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            path.AddRectangle(rect);
        }
    }
}
