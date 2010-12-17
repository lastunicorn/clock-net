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
    /// A shape that draws a simple straight line.
    /// </summary>
    public class LineShape : VectorialShapeBase
    {
        /// <summary>
        /// The default value of the hand width.
        /// </summary>
        public new const float LINE_WIDTH = 0.3f;


        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Line Shape"; }
        }


        /// <summary>
        /// Get or sets the width of the line that is drawn by the current instance.
        /// </summary>
        [DefaultValue(LINE_WIDTH)]
        public override float LineWidth
        {
            get { return base.LineWidth; }
            set { base.LineWidth = value; }
        }


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
        /// Draws the line using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the line.</param>
        public override void Draw(Graphics g)
        {
            if (visible && !outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawLine(pen, startPoint, endPoint);
            }
        }
    }
}
