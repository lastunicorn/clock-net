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

namespace DustInTheWind.Clock.Shapes.Fancy
{
    /// <summary>
    /// A Hand Shape that draws a dot at the specified distance from the pin.
    /// </summary>
    public class DotHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default value of the dot's radius.
        /// </summary>
        public const float RADIUS = 5f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Dot Hand Shape"; }
        }


        /// <summary>
        /// The radius of the dot.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the radius of the dot.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(RADIUS)]
        [Description("The radius of the dot.")]
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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class with
        /// default values.
        /// </summary>
        public DotHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT, LINE_WIDTH, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the ellipse.</param>
        /// <param name="radius">The radius of the dot.</param>
        public DotHandShape(Color fillColor, float height, float radius)
            : this(Color.Empty, fillColor, height, LINE_WIDTH, radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the dot.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="radius">The radius of the dot.</param>
        public DotHandShape(Color outlineColor, Color fillColor, float height, float lineWidth, float radius)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            this.radius = radius;

            CalculateDimensions();
        }

        #endregion

        private RectangleF dotRectangle;

        protected override void CalculateDimensions()
        {
            dotRectangle = new RectangleF(-radius, -height - radius, radius * 2, radius * 2);
        }


        /// <summary>
        /// Draws the hour hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dot.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        protected override void DrawInternal(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                //g.FillEllipse(brush, -radius, -height - radius, radius * 2, radius);
                g.FillEllipse(brush, dotRectangle);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                //g.DrawEllipse(pen, -radius, -height - radius, radius, radius);
                g.DrawEllipse(pen, dotRectangle);
            }
        }
    }
}
