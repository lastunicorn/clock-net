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
    /// An Angular Shape class that draws a ellipse.
    /// </summary>
    public class EllipseAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string NAME = "Ellipse Angular Shape";


        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        protected RectangleF rectangle;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseAngularShape"/> class with
        /// default values.
        /// </summary>
        public EllipseAngularShape()
            : this(RectangleF.Empty, OUTLINE_COLOR, FILL_COLOR, LINE_WIDTH, ANGLE, REPEAT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseAngularShape"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the ellipse.</param>
        /// <param name="fillColor">The color used to fill the ellipse's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public EllipseAngularShape(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(outlineColor, fillColor, lineWidth, angle, repeat, positionOffset)
        {
            this.Name = NAME;
            this.rectangle = rectangle;
        }

        #endregion

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
        /// coordinate's system if necessary the and then calls <see cref="DrawInternal"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void DrawInternal(Graphics g)
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
