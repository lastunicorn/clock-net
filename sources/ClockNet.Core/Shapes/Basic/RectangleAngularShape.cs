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

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// An Angular Shape class that draws a rectangle.
    /// </summary>
    [Shape("0808673f-f263-4540-817c-0f131ece871a")]
    public class RectangleAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Rectangle Angular Shape";

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
        /// Initializes a new instance of the <see cref="RectangleAngularShape"/> class with
        /// default values.
        /// </summary>
        public RectangleAngularShape()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultLineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleAngularShape"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the rectangle.</param>
        /// <param name="fillColor">The color used to fill the rectangle's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public RectangleAngularShape(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.Name = DefaultName;
            this.rectangle = rectangle;
            this.roundedRectangle = Rectangle.Round(rectangle);
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !rectangle.IsEmpty;
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
                g.FillRectangle(Brush, rectangle);

            if (!outlineColor.IsEmpty)
                g.DrawRectangle(Pen, roundedRectangle);
        }
    }
}
