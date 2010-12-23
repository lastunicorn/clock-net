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
    public class PolygonShape : VectorialShapeBase
    {
        protected PointF[] points;

        public override string Name
        {
            get { return "Polygon Shape"; }
        }

        public PolygonShape()
            : this(null, Color.Empty, Color.Empty)
        {
        }

        public PolygonShape(PointF[] points, Color outlineColor, Color fillColor)
            : base(outlineColor, fillColor)
        {
            this.points = points;
        }


        /// <summary>
        /// Draws the polygon using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the polygon.</param>
        public override void Draw(Graphics g)
        {
            if (visible)
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
}
