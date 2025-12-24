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
    [Shape("3950244f-9e48-4484-bdc9-1d0a39c4a8f6")]
    public class DotHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Dot Hand Shape";

        /// <summary>
        /// The default value of the dot's radius.
        /// </summary>
        public const float DefaultRadius = 5f;


        /// <summary>
        /// The radius of the dot.
        /// </summary>
        protected float radius;

        /// <summary>
        /// Gets or sets the radius of the dot.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        [Category("Appearance")]
        [DefaultValue(DefaultRadius)]
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

        /// <summary>
        /// Initializes a new instance of the <see cref="DotHandShape"/> class with
        /// default values.
        /// </summary>
        public DotHandShape()
            : base(Color.Empty, Color.Black, DefaultLineWidth, DefaultHeight)
        {
            Name = DefaultName;
            radius = DefaultRadius;
        }

        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        private RectangleF dotRectangle;

        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() &&
                radius > 0 && length > 0;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            float x = -radius;
            float y = -length - radius;

            float width = radius * 2;
            float height = radius * 2;

            dotRectangle = new RectangleF(x, y, width, height);
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
                g.FillEllipse(Brush, dotRectangle);

            if (!outlineColor.IsEmpty)
                g.DrawEllipse(Pen, dotRectangle);
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
