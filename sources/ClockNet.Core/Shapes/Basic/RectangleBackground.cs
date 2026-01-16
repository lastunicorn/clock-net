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

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a rectangle.
    /// </summary>
    [Shape("caae1fad-f84a-4ae1-99ed-fcc97377da46")]
    public class RectangleBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Rectangle Background";

        /// <summary>
        /// The rectangle that is drawn.
        /// </summary>
        protected RectangleF rectangle;

        /// <summary>
        /// The same rectangle rounded to integer coordinates. It is necessary for the
        /// <see cref="Graphics.DrawRectangle(Pen, Rectangle)"/> method that does not accepts a <see cref="RectangleF"/>.
        /// </summary>
        protected Rectangle roundedRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleBackground"/> class with
        /// default values.
        /// </summary>
        public RectangleBackground()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleBackground"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the rectangle.</param>
        /// <param name="fillColor">The color used to fill the rectangle's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public RectangleBackground(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = DefaultName;
            this.rectangle = rectangle;
            this.roundedRectangle = Rectangle.Round(rectangle);
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (rectangle.IsEmpty)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            if (!FillColor.IsEmpty)
                context.Graphics.FillRectangle(Brush, rectangle);

            if (!OutlineColor.IsEmpty)
                context.Graphics.DrawRectangle(Pen, roundedRectangle);
        }
    }
}
