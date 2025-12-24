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
    /// An Hend Shape that draws a polygonal clock hand.
    /// </summary>
    [Shape("26357157-e6a8-4a58-977c-eb472c012905")]
    public class PolygonHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Polygon Hand Shape";

        /// <summary>
        /// The points of the polygon.
        /// </summary>
        protected PointF[] points;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonHandShape"/> class with
        /// default values.
        /// </summary>
        public PolygonHandShape()
            : this(null, DefaultOutlineColor, DefaultFillColor, DefaultHeight, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonHandShape"/> class.
        /// </summary>
        /// <param name="points">The points defining the polygon that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the path.</param>
        /// <param name="fillColor">The color used to fill the path's interior.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public PolygonHandShape(PointF[] points, Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            Name = DefaultName;
            this.points = points;
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
                g.FillPolygon(Brush, points);

            if (!outlineColor.IsEmpty)
                g.DrawPolygon(Pen, points);
        }

        public override bool HitTest(PointF point)
        {
            PointF clickLocation;

            using (Matrix matrix = new Matrix())
            {
                float angle = GetRotationDegrees();
                matrix.Rotate(-angle);

                PointF[] points = new PointF[] { point };
                matrix.TransformPoints(points);
                clickLocation = points[0];
            }

            return PointInPolygon(clickLocation, points);
        }

        private bool PointInPolygon(PointF point, PointF[] polygon)
        {
            int j = polygon.Length - 1;
            bool oddNodes = false;

            for (int i = 0; i < points.Length; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }
    }
}
