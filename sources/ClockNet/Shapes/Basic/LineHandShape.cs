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
        /// The default name for the Shape.
        /// </summary>
        public const string NAME = "Line Hand Shape";

        /// <summary>
        /// The default value of the hand's tail length.
        /// </summary>
        public const float TAIL_LENGTH = 7f;


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
            this.Name = NAME;
            this.tailLength = tailLength;

            CalculateDimensions();
        }

        #endregion


        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateDimensions()
        {
            startPoint = new PointF(0f, tailLength);
            endPoint = new PointF(0f, -height);
        }

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
