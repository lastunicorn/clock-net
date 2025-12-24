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

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// An Angular Shape class that draws a line between two points.
    /// </summary>
    [Shape("52d7515b-c6c6-44af-bf84-ffdd82238d31")]
    public class LineAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Line Angular Shape";

        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;


        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false)]
        public override Color FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineAngularShape"/> class with
        /// default values.
        /// </summary>
        public LineAngularShape()
            : this(PointF.Empty, PointF.Empty, Color.Black, DefaultLineWidth, DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineAngularShape"/> class.
        /// </summary>
        /// <param name="startPoint">The point from where the line starts.</param>
        /// <param name="endPoint">The point where the line ends.</param>
        /// <param name="color">The color that will be used to draw the line.</param>
        /// <param name="lineWidth">The width of the line.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public LineAngularShape(PointF startPoint, PointF endPoint, Color color, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(color, Color.Empty, lineWidth, angle, repeat, positionOffset)
        {
            Name = DefaultName;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
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
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void OnDraw(Graphics g)
        {
            g.DrawLine(Pen, startPoint, endPoint);
        }
    }
}
