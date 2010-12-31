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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// An Hand Shape that draws a simple straight line.
    /// </summary>
    public class LineHandShape : VectorialHandShapeBase
    {
        /// <summary>
        /// The default value of the hand's tail length.
        /// </summary>
        public const float TAIL_LENGTH = 7f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Line Hand Shape"; }
        }


        /// <summary>
        /// The location of the tail tip.
        /// </summary>
        protected PointF startPoint;

        /// <summary>
        /// The lcation of the hand top.
        /// </summary>
        protected PointF endPoint;


        /// <summary>
        /// The length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        protected float tailLength;

        /// <summary>
        /// Gets or set the length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        [Description("The length of the hand's tail that is drawn on the other side of the pin.")]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHandShape"/> class with
        /// default values.
        /// </summary>
        public LineHandShape()
            : this(Color.Black, HEIGHT, LINE_WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHandShape"/> class.
        /// </summary>
        public LineHandShape(Color color)
            : this(color, HEIGHT, LINE_WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHandShape"/> class.
        /// </summary>
        public LineHandShape(Color color, float height, float width, float tailLength)
            : base(color, Color.Empty, width, height)
        {
            this.tailLength = tailLength;

            CalculateDimensions();
        }

        #endregion


        protected override void CalculateDimensions()
        {
            startPoint = new PointF(0f, tailLength);
            endPoint = new PointF(0f, -height);
        }

        /// <summary>
        /// Draws the hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the hand.</param>
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
