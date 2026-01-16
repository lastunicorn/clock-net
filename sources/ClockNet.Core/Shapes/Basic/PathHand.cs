// ClockControl
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// An Shape that draws a complex vectorial clock hand defined by a <see cref="GraphicsPath"/> object.
    /// </summary>
    [Shape("a22d7691-ea25-481e-a9ef-8a40bb4478cf")]
    public class PathHand : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Path Hand";

        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHand"/> class with
        /// default values.
        /// </summary>
        public PathHand()
            : this(new GraphicsPath(), DefaultOutlineColor, DefaultFillColor, DefaultLength, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHand"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        public PathHand(GraphicsPath path, Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            Name = DefaultName;
            this.path = path;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context to use for drawing operations. Cannot be null.</param>
        /// <param name="time">The time to be displayed by the shape.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(Graphics g, TimeSpan time)
        {
            if (path == null)
                return false;

            return base.OnBeforeDraw(g, time);
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        /// <param name="time">The time to be displayed by the shape.</param>
        protected override void OnDraw(Graphics g, TimeSpan time)
        {
            if (!FillColor.IsEmpty)
                g.FillPath(Brush, path);

            if (!OutlineColor.IsEmpty)
                g.DrawPath(Pen, path);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Speifies if the managed resources should be disposed, too.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                path?.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Tests if the specified point is contained by the Shape.
        /// </summary>
        /// <param name="point">The point to be ferified.</param>
        /// <param name="time">The time displayed by the hand.</param>
        /// <returns>true if the specified point is contained by the Shape; false otherwise.</returns>
        public override bool HitTest(PointF point, TimeSpan time)
        {
            using (Matrix matrix = new Matrix())
            {
                float angle = GetRotationDegrees(time);
                matrix.Rotate(-angle);

                PointF[] points = new PointF[] { point };
                matrix.TransformPoints(points);
                PointF clickLocation = points[0];

                return path.IsVisible(point);
            }
        }
    }
}
