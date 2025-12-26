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

using System.Drawing;

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// A Background Shape representing a line.
    /// </summary>
    [Shape("8dccd001-47d8-4b7b-9330-7d832c262858")]
    public class LineBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Line Background";

        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineBackground"/> class with
        /// default values.
        /// </summary>
        public LineBackground()
            : this(PointF.Empty, PointF.Empty, Color.Black, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineBackground"/> class.
        /// </summary>
        /// <param name="color">The color that will be used to draw the line.</param>
        /// <param name="lineWidth">The width of the line.</param>
        public LineBackground(Color color, float lineWidth)
            : this(PointF.Empty, PointF.Empty, color, lineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineBackground"/> class.
        /// </summary>
        /// <param name="startPoint">The point from where the line starts.</param>
        /// <param name="endPoint">The point where the line ends.</param>
        /// <param name="color">The color that will be used to draw the line.</param>
        /// <param name="lineWidth">The width of the line.</param>
        public LineBackground(PointF startPoint, PointF endPoint, Color color, float lineWidth)
            : base(color, Color.Empty, lineWidth)
        {
            this.Name = DefaultName;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !OutlineColor.IsEmpty;
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
            g.DrawLine(Pen, startPoint, endPoint);
        }
    }
}
