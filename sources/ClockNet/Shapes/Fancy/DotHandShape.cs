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
    public class DotHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 27.5f;
        public const float RADIUS = 10f;

        public override string Name
        {
            get { return "Fancy Hour Hand Shape"; }
        }

        /// <summary>
        /// The length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                OnChanged(EventArgs.Empty);
            }
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
                OnChanged(EventArgs.Empty);
            }
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public DotHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT, RADIUS)
        {
        }

        public DotHandShape(Color fillColor, float height, float radius)
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
        public DotHandShape(Color outlineColor, Color fillColor, float height, float radius)
            : base(outlineColor, fillColor)
        {
            this.height = height;
            this.radius = radius;
        }

        #endregion

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
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillEllipse(brush, -radius, -height - radius, radius, radius);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawEllipse(pen, -radius, -height - radius, radius, radius);
            }
        }
    }
}
