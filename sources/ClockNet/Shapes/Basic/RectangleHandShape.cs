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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// A Hand Shape that draws a rectangle.
    /// </summary>
    public class RectangleHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Rectangle Hand Shape"; }
        }


        /// <summary>
        /// The rectangle defining the rectangle that is drawn.
        /// </summary>
        protected RectangleF rectangle;

        /// <summary>
        /// The same rectangle rounded to integer coordinates. It is necessary for the
        /// <see cref="Graphics.DrawRectangle(Pen, Rectangle)"/> method that does not accepts a <see cref="RectangleF"/>.
        /// </summary>
        protected Rectangle roundedRectangle;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHandShape"/> class with
        /// default values.
        /// </summary>
        public RectangleHandShape()
            : this(RectangleF.Empty, Color.Empty, Color.RoyalBlue, HEIGHT, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHandShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the ellipse.</param>
        public RectangleHandShape(Color fillColor, float height)
            : this(RectangleF.Empty, Color.Empty, fillColor, height, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleHandShape"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the rectangle.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public RectangleHandShape(RectangleF rectangle, Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            this.rectangle = rectangle;
            this.roundedRectangle = Rectangle.Round(rectangle);
        }

        #endregion


        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !rectangle.IsEmpty;
        }

        /// <summary>
        /// Draws the hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dot.</param>
        protected override void DrawInternal(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillRectangle(brush, rectangle);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawRectangle(pen, roundedRectangle);
            }
        }
    }
}
