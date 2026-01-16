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
    /// An Angular Shape class that draws a rectangle.
    /// </summary>
    [Shape("0808673f-f263-4540-817c-0f131ece871a")]
    public class RectangleRim : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Rectangle Rim";

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
        /// Initializes a new instance of the <see cref="RectangleRim"/> class with
        /// default values.
        /// </summary>
        public RectangleRim()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleRim"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the rectangle.</param>
        /// <param name="fillColor">The color used to fill the rectangle's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public RectangleRim(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.Name = DefaultName;
            this.rectangle = rectangle;
            this.roundedRectangle = Rectangle.Round(rectangle);
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context to use for drawing operations. Cannot be null.</param>
        /// <param name="time">The time to be displayed by the shape.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(Graphics g, TimeSpan time)
        {
            if (rectangle.IsEmpty)
                return false;

            return base.OnBeforeDraw(g, time);
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            if (!FillColor.IsEmpty)
                g.FillRectangle(Brush, rectangle);

            if (!OutlineColor.IsEmpty)
                g.DrawRectangle(Pen, roundedRectangle);
        }
    }
}
