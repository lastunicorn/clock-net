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
using System.Drawing.Drawing2D;
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// Draws a sweep hand as a line with a circle near its top.
    /// </summary>
    public class FancySweepHandShape : PathHandShape
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string DefaultName = "Fancy Sweep Hand Shape";

        /// <summary>
        /// The default radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        public const float DefaultCircleRadius = 3.5f;

        /// <summary>
        /// The default offset position of the center of the circle from the top of the hand.
        /// </summary>
        public const float DefaultCircleOffset = 12f;

        /// <summary>
        /// The default length of the tail of the hand.
        /// </summary>
        public const float DefaultTailLength = 7f;


        /// <summary>
        /// The radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        protected float circleRadius = DefaultCircleRadius;

        /// <summary>
        /// Gets or sets the radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultCircleRadius)]
        [Description("The radius of the circle from the middle (or not so middle) of the hand.")]
        public virtual float CircleRadius
        {
            get => circleRadius;
            set
            {
                circleRadius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The offset position of the center of the circle from the top of the hand.
        /// </summary>
        protected float circleOffset = DefaultCircleOffset;

        /// <summary>
        /// Gets or sets the offset position of the center of the circle from the top of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultCircleOffset)]
        public virtual float CircleOffset
        {
            get => circleOffset;
            set
            {
                circleOffset = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The length of the the hand's tail.
        /// </summary>
        protected float tailLength;

        /// <summary>
        /// Gets or sets the length of the tail of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultTailLength)]
        [Description("The length of the tail of the hand.")]
        public virtual float TailLength
        {
            get => tailLength;
            set
            {
                tailLength = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class with
        /// default values.
        /// </summary>
        public FancySweepHandShape()
            : this(Color.Red, Color.Empty, DefaultHeight, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        public FancySweepHandShape(Color outlineColor)
            : this(outlineColor, Color.Empty, DefaultHeight, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        public FancySweepHandShape(Color outlineColor, float height)
            : this(outlineColor, Color.Empty, height, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        public FancySweepHandShape(Color outlineColor, float height, float lineWidth)
            : this(outlineColor, Color.Empty, height, lineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to fill the circle from the middle of the hand. <see cref="Color.Empty"/> will let the circle transparent.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="height">The length of the hand from the pin to the its top.</param>
        public FancySweepHandShape(Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(new GraphicsPath(), outlineColor, fillColor, height, lineWidth)
        {
            Name = DefaultName;
            tailLength = DefaultTailLength;
        }

        /// <summary>
        /// Calculates additional values and creates the <see cref="GraphicsPath"/> that will be displayed
        /// by the <see cref="IShape.Draw"/> method.
        /// </summary>
        protected override void CalculateLayout()
        {
            path.Reset();

            float circleCenterX = -length + circleOffset;

            path.AddLine(new PointF(0f, tailLength), new PointF(0f, circleCenterX + circleRadius));
            path.AddEllipse(-circleRadius, circleCenterX - circleRadius, circleRadius * 2f, circleRadius * 2f);
            path.AddLine(new PointF(0f, circleCenterX - circleRadius), new PointF(0f, -length));
        }
    }
}
