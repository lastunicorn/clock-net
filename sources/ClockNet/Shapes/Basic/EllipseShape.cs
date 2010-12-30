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
    /// A Shape class that draws a ellipse.
    /// </summary>
    public class EllipseShape : VectorialShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Ellipse Shape"; }
        }


        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        protected RectangleF rectangle;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseShape"/> class with
        /// default values.
        /// </summary>
        public EllipseShape()
            : this(RectangleF.Empty, Color.Empty, Color.Empty, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseShape"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the ellipse.</param>
        /// <param name="fillColor">The color used to fill the ellipse's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public EllipseShape(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.rectangle = rectangle;
        }

        #endregion


        /// <summary>
        /// Draws the rectangle using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the rectangle.</param>
        public override void Draw(Graphics g)
        {
            if (visible && !rectangle.IsEmpty)
            {
                if (!fillColor.IsEmpty)
                {
                    CreateBrushIfNull();

                    g.FillEllipse(brush, rectangle);
                }

                if (!outlineColor.IsEmpty)
                {
                    CreatePenIfNull();

                    g.DrawEllipse(pen, rectangle);
                }
            }
        }
    }
}
