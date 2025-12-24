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
    /// A Hand Shape that draws a dot at the specified distance from the pin.
    /// </summary>
    public class DotHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Dot Hand Shape";

        /// <summary>
        /// The default value of the dot's radius.
        /// </summary>
        public const float RADIUS = 5f;


        /// <summary>
        /// The radius of the dot.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the radius of the dot.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        [Category("Appearance")]
        [DefaultValue(RADIUS)]
        [Description("The radius of the dot.")]
        public virtual float Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

                radius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class with
        /// default values.
        /// </summary>
        public DotHandShape()
            : this(Color.Empty, Color.Black, DefaultHeight, DefaultLineWidth, RADIUS)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the ellipse.</param>
        /// <param name="radius">The radius of the dot.</param>
        public DotHandShape(Color fillColor, float height, float radius)
            : this(Color.Empty, fillColor, height, DefaultLineWidth, radius)
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
            Name = DefaultName;
            this.radius = radius;
        }

        #endregion

        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        private RectangleF dotRectangle;

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
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
        protected override void OnDraw(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                //g.FillEllipse(brush, -radius, -height - radius, radius * 2, radius);
                g.FillEllipse(Brush, dotRectangle);
            }

            if (!outlineColor.IsEmpty)
            {
                //g.DrawEllipse(pen, -radius, -height - radius, radius, radius);
                g.DrawEllipse(Pen, dotRectangle);
            }
        }

        public override bool HitTest(PointF point)
        {
            Point dotCenter = new Point((int)(dotRectangle.X + radius), (int)(dotRectangle.Y + radius));

            using (Matrix m = new Matrix())
            {
                float angle = GetRotationDegrees();
                m.Rotate(angle);

                Point[] points = new Point[] { dotCenter };
                m.TransformPoints(points);

                float centerX = points[0].X;
                float centerY = points[0].Y;

                float alphaX = point.X - centerX;
                float alphaY = point.Y - centerY;

                float dist = (float)Math.Sqrt(alphaX * alphaX + alphaY * alphaY);

                return dist <= radius;
            }
        }
    }
}
