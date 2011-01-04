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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a polygon.
    /// </summary>
    public class PolygonGroundShape : VectorialGroundShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string NAME = "Polygon Ground Shape";


        /// <summary>
        /// The points that defines the polygon.
        /// </summary>
        protected PointF[] points;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonGroundShape"/> class with
        /// default values.
        /// </summary>
        public PolygonGroundShape()
            : this(null, OUTLINE_COLOR, FILL_COLOR, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonGroundShape"/> class.
        /// </summary>
        /// <param name="points">The points defining the polygon that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public PolygonGroundShape(PointF[] points, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = NAME;
            this.points = points;
        }

        #endregion


        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && points != null && points.Length >= 2;
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="DrawInternal"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void DrawInternal(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillPolygon(brush, points);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawPolygon(pen, points);
            }
        }
    }
}
