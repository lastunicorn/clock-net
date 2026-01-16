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
    /// A Rim Shape class that draws ellipse items.
    /// </summary>
    [Shape("840bf574-faff-4bc8-a660-90af9a66b71f")]
    public class EllipseRim : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Ellipse Rim";

        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        protected RectangleF rectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseRim"/> class with
        /// default values.
        /// </summary>
        public EllipseRim()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseRim"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the ellipse.</param>
        /// <param name="fillColor">The color used to fill the ellipse's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public EllipseRim(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            Name = DefaultName;
            this.rectangle = rectangle;
        }

        /// <summary>
        /// Determines whether drawing should proceed based on the current rectangle state.
        /// </summary>
        /// <param name="g">The graphics context to use for drawing operations.</param>
        /// <returns>true if the rectangle is not empty and drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(Graphics g)
        {
            if (rectangle.IsEmpty)
                return false;

            return base.OnBeforeDraw(g);
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            if (!FillColor.IsEmpty)
                g.FillEllipse(Brush, rectangle);

            if (!OutlineColor.IsEmpty)
                g.DrawEllipse(Pen, rectangle);
        }
    }
}
