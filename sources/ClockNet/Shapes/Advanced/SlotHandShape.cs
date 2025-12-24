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
using System.Drawing.Drawing2D;
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// Draws a clock hand that is a slot carved inside a disk. By default the disk is big as the clock.
    /// </summary>
    public class SlotHandShape : PathHandShape
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string DefaultName = "Slot Hand Shape";

        /// <summary>
        /// The default length of the width of the hand.
        /// </summary>
        public const float DefaultWidth = 5f;

        /// <summary>
        /// The default length of the radius of the opaque disk.
        /// </summary>
        public const float DefaultRadius = 50f;

        /// <summary>
        /// The default length of the tail of the hand.
        /// </summary>
        public const float DefaultTailLength = 6f;


        /// <summary>
        /// The width of the slot carved inside the disk.
        /// </summary>
        protected float width;

        /// <summary>
        /// Gets or sets the width of the slot carved inside the disk.
        /// </summary>
        [DefaultValue(DefaultWidth)]
        [Description("The width of the slot carved inside the disk.")]
        public virtual float Width
        {
            get { return width; }
            set
            {
                width = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The rasius of the opaque disk.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the rasius of the opaque disk.
        /// </summary>
        [DefaultValue(DefaultRadius)]
        [Description("The rasius of the opaque disk.")]
        public virtual float Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The length of the the hand's tail.
        /// </summary>
        protected float tailLength;

        /// <summary>
        /// Gets or sets the length of the tail of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultTailLength)]
        [Description("The length of the tail of the hand.")]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHandShape"/> class with
        /// default values.
        /// </summary>
        public SlotHandShape()
            : base(new GraphicsPath(), DefaultOutlineColor, DefaultFillColor, DefaultHeight, DefaultLineWidth)
        {
            Name = DefaultName;
            radius = DefaultRadius;
            width = DefaultWidth;
            tailLength = DefaultTailLength;
        }

        /// <summary>
        /// Performs all the necessary calculations based on the public parameters, before drawing the shape.
        /// </summary>
        protected override void CalculateLayout()
        {
            path.Reset();

            path.AddEllipse(-radius, -radius, radius * 2f, radius * 2f);
            path.AddRectangle(new RectangleF(-width / 2f, -length, width, length + tailLength));
        }
    }
}
