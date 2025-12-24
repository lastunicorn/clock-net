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

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the background of the dial.
    /// </summary>
    public class DialShape : VectorialGroundShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Dial Shape";

        /// <summary>
        /// The default radius of the Dial Shape.
        /// </summary>
        public const float DefaultRadius = 5f;

        /// <summary>
        /// The radius of the dial.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the radius of the dial.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        [Category("Appearance")]
        [DefaultValue(DefaultRadius)]
        [Description("The radius of the dial.")]
        public virtual float Radius
        {
            get => radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

                radius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class with
        /// default values.
        /// </summary>
        public DialShape()
            : this(OUTLINE_COLOR, Color.Black, DefaultRadius, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        public DialShape(Color fillColor)
            : this(OUTLINE_COLOR, fillColor, DefaultRadius, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        /// <param name="radius">The radius of the dial.</param>
        public DialShape(Color fillColor, float radius)
            : this(OUTLINE_COLOR, fillColor, radius, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the dial.</param>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        /// <param name="radius">The radius of the dial.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public DialShape(Color outlineColor, Color fillColor, float radius, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = DefaultName;
            this.radius = radius;
        }

        /// <summary>
        /// Creates a new <see cref="Pen"/> object if it does not exist already.
        /// The pen will have an Inset alignment.
        /// </summary>
        protected override void CreatePenIfNull()
        {
            if (pen == null)
            {
                pen = new Pen(outlineColor, lineWidth)
                {
                    Alignment = PenAlignment.Inset
                };
            }
        }

        /// <summary>
        /// The rectangle defining the circle that is drawn.
        /// </summary>
        private RectangleF rect;

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            rect = new RectangleF(-radius, -radius, radius * 2, radius * 2);
        }


        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void OnDraw(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();
                g.FillEllipse(brush, rect);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
