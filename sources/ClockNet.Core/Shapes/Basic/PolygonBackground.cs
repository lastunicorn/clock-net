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

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a polygon.
    /// </summary>
    [Shape("f649d1a0-bec4-4bbb-85d1-4e5342e1cfa3")]
    public class PolygonBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Polygon Background";

        /// <summary>
        /// The points that defines the polygon.
        /// </summary>
        protected PointF[] points;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonBackground"/> class with
        /// default values.
        /// </summary>
        public PolygonBackground()
            : this(null, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonBackground"/> class.
        /// </summary>
        /// <param name="points">The points defining the polygon that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public PolygonBackground(PointF[] points, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = DefaultName;
            this.points = points;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context to use for drawing operations. Cannot be null.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(Graphics g)
        {
            if (points == null || points.Length < 2)
                return false;

            return base.OnBeforeDraw(g);
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
            if (!FillColor.IsEmpty)
                g.FillPolygon(Brush, points);

            if (!OutlineColor.IsEmpty)
                g.DrawPolygon(Pen, points);
        }
    }
}
