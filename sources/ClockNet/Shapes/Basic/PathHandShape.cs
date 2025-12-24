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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// An Shape that draws a complex vectorial clock hand defined by a <see cref="GraphicsPath"/> object.
    /// </summary>
    public class PathHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Path Hand Shape";

        /// <summary>
        /// The path that is drawn.
        /// </summary>
        protected GraphicsPath path;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHandShape"/> class with
        /// default values.
        /// </summary>
        public PathHandShape()
            : this(new GraphicsPath(), DefaultOutlineColor, DefaultFillColor, DefaultHeight, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHandShape"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        public PathHandShape(GraphicsPath path, Color outlineColor, Color fillColor)
            : this(path, outlineColor, fillColor, DefaultHeight, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathHandShape"/> class.
        /// </summary>
        /// <param name="path">The path that should be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        public PathHandShape(GraphicsPath path, Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            this.Name = DefaultName;
            this.path = path;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && path != null;
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
                g.FillPath(Brush, path);

            if (!outlineColor.IsEmpty)
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
        /// <returns>true if the specified point is contained by the Shape; false otherwise.</returns>
        public override bool HitTest(PointF point)
        {
            using (Matrix matrix = new Matrix())
            {
                float angle = GetRotationDegrees();
                matrix.Rotate(-angle);

                PointF[] points = new PointF[] { point };
                matrix.TransformPoints(points);
                PointF clickLocation = points[0];

                return path.IsVisible(point);
            }
        }
    }
}
