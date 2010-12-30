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
    /// An Angular Shape class that draws a polygon.
    /// </summary>
    public class PolygonAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Polygon Angular Shape"; }
        }


        /// <summary>
        /// The points that defines the polygon.
        /// </summary>
        protected PointF[] points;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonAngularShape"/> class with
        /// default values.
        /// </summary>
        public PolygonAngularShape()
            : this(null, Color.Empty, Color.Empty, LINE_WIDTH, ANGLE, REPEAT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonAngularShape"/> class.
        /// </summary>
        /// <param name="points">The points defining the polygon that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public PolygonAngularShape(PointF[] points, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.points = points;
        }

        #endregion


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
