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
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    /// <summary>
    /// Draws a clock hand that is a slot carved inside a disk. By default the disk is big as the clock.
    /// </summary>
    public class SlotHandShape : PathHandShape
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string NAME = "Slot Hand Shape";

        /// <summary>
        /// The default length of the width of the hand.
        /// </summary>
        public const float WIDTH = 5f;

        /// <summary>
        /// The default length of the radius of the opaque disk.
        /// </summary>
        public const float RADIUS = 50f;

        /// <summary>
        /// The default length of the tail of the hand.
        /// </summary>
        public const float TAIL_LENGTH = 6f;


        /// <summary>
        /// The width of the slot carved inside the disk.
        /// </summary>
        protected float width;

        /// <summary>
        /// Gets or sets the width of the slot carved inside the disk.
        /// </summary>
        [DefaultValue(WIDTH)]
        [Description("The width of the slot carved inside the disk.")]
        public virtual float Width
        {
            get { return width; }
            set
            {
                width = value;
                CalculateDimensions();
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
        [DefaultValue(RADIUS)]
        [Description("The rasius of the opaque disk.")]
        public virtual float Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                CalculateDimensions();
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
        [DefaultValue(TAIL_LENGTH)]
        [Description("The length of the tail of the hand.")]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHandShape"/> class with
        /// default values.
        /// </summary>
        public SlotHandShape()
            : this(OUTLINE_COLOR, FILL_COLOR, RADIUS, HEIGHT, WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHandShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to fill the opaqu disk.</param>
        /// <param name="radius">The radius of the opaque disk.</param>
        /// <param name="height">The length of the carving from the pin to the its top.</param>
        /// <param name="width">The width of the carving.</param>
        public SlotHandShape(Color fillColor, float radius, float height, float width)
            : this(OUTLINE_COLOR, fillColor, radius, height, width)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to fill the opaqu disk.</param>
        /// <param name="radius">The radius of the opaque disk.</param>
        /// <param name="height">The length of the carving from the pin to the its top.</param>
        /// <param name="width">The width of the carving.</param>
        public SlotHandShape(Color outlineColor, Color fillColor, float radius, float height, float width)
            : base(new GraphicsPath(), outlineColor, fillColor, height, LINE_WIDTH)
        {
            this.Name = NAME;
            this.radius = radius;
            this.width = width;
            tailLength = TAIL_LENGTH;

            CalculateDimensions();
        }

        #endregion

        /// <summary>
        /// Performs all the necessary calculations based on the public parameters, before drawing the shape.
        /// </summary>
        protected override void CalculateDimensions()
        {
            path.Reset();

            path.AddEllipse(-radius, -radius, radius * 2f, radius * 2f);
            path.AddRectangle(new RectangleF(-width / 2f, -height, width, height + tailLength));
        }
    }
}
