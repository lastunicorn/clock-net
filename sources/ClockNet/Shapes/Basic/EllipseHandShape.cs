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

namespace DustInTheWind.Clock.Shapes
{
    public class EllipseHandShape : VectorialHandShapeBase
    {
        public const float HEIGHT = 27.5f;
        public const float RADIUS = 10f;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Dot Hand Shape"; }
        }

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return base.Height; }
            set { Height = value; }
        }

        protected float radius;

        [Category("Appearance")]
        [DefaultValue(RADIUS)]
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
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public EllipseHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT, RADIUS)
        {
        }

        public EllipseHandShape(Color fillColor, float height, float radius)
            : this(Color.Empty, fillColor, height, radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor"></param>
        /// <param name="fillColor"></param>
        /// <param name="drawMode"></param>
        /// <param name="height"></param>
        public EllipseHandShape(Color outlineColor, Color fillColor, float height, float radius)
            : base(outlineColor, fillColor)
        {
            this.height = height;
            this.radius = radius;
            CalculateDimensions();
        }

        #endregion

        RectangleF circleRect;

        protected void CalculateDimensions()
        {
            circleRect = new RectangleF(-radius, -height - radius, radius * 2, radius * 2);
        }

        /// <summary>
        /// Draws the hour hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dot.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        public override void Draw(Graphics g)
        {
            if (visible)
            {
                if (!fillColor.IsEmpty)
                {
                    CreateBrushIfNull();

                    //g.FillEllipse(brush, -radius, -height - radius, radius * 2, radius);
                    g.FillEllipse(brush, circleRect);
                }

                if (!outlineColor.IsEmpty)
                {
                    CreatePenIfNull();

                    //g.DrawEllipse(pen, -radius, -height - radius, radius, radius);
                    g.DrawEllipse(pen, circleRect);
                }
            }
        }
    }
}
