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

using System.ComponentModel;
using System.Drawing;

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a simple straight line.
    /// </summary>
    public class LineShape : VectorialGroundShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Line Shape"; }
        }


        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LineShape"/> class with
        /// default values.
        /// </summary>
        public LineShape()
            : this(PointF.Empty, PointF.Empty, Color.Black, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineShape"/> class.
        /// </summary>
        /// <param name="color">The color that will be used to draw the line.</param>
        /// <param name="lineWidth">The width of the line.</param>
        public LineShape(Color color, float lineWidth)
            : this(PointF.Empty, PointF.Empty, color, lineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineShape"/> class.
        /// </summary>
        /// <param name="startPoint">The point from where the line starts.</param>
        /// <param name="endPoint">The point where the line ends.</param>
        /// <param name="color">The color that will be used to draw the line.</param>
        /// <param name="lineWidth">The width of the line.</param>
        public LineShape(PointF startPoint, PointF endPoint, Color color, float lineWidth)
            : base(color, Color.Empty, lineWidth)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        #endregion

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !outlineColor.IsEmpty;
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
            CreatePenIfNull();

            g.DrawLine(pen, startPoint, endPoint);
        }
    }
}
