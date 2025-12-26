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

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Hand Shape that draws a simple straight line.
    /// </summary>
    [Shape("8e8a0b29-16a5-48ed-b5a8-431a4520ffa4")]
    public class LineHand : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Line Hand";

        /// <summary>
        /// The default value of the hand's tail length.
        /// </summary>
        public const float DefaultTailLength = 7f;


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
        [DefaultValue(DefaultTailLength)]
        [Description("The length of the hand's tail that is drawn on the other side of the pin.")]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHand"/> class with
        /// default values.
        /// </summary>
        public LineHand()
            : this(Color.Black, DefaultHeight, DefaultOutlineWidth, DefaultTailLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHand"/> class.
        /// </summary>
        public LineHand(Color color)
            : this(color, DefaultHeight, DefaultOutlineWidth, DefaultTailLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHand"/> class.
        /// </summary>
        public LineHand(Color color, float height, float width, float tailLength)
            : base(color, Color.Empty, width, height)
        {
            Name = DefaultName;
            this.tailLength = tailLength;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            startPoint = new PointF(0f, tailLength);
            endPoint = new PointF(0f, -length);
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

        public override bool HitTest(PointF point)
        {
            return false;
        }
    }
}
