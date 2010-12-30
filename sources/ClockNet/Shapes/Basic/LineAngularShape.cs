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

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// An Angular Shape class that draws a line.
    /// </summary>
    public class LineAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Line Angular Shape"; }
        }


        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LineAngularShape"/> class with
        /// default values.
        /// </summary>
        public LineAngularShape()
            : this(PointF.Empty, PointF.Empty, Color.Black, LINE_WIDTH, ANGLE, REPEAT, POSITION_OFFSET)
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
            this.startPoint = startPoint;
            this.endPoint = endPoint;

            CalculateDimensions();
        }

        #endregion


        protected override void DrawInternal(Graphics g)
        {
            CreatePenIfNull();
            g.DrawLine(pen, startPoint, endPoint);
        }
    }
}
