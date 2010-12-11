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

namespace DustInTheWind.Clock.Shapes.Fancy
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class FancySweepHandShape : PathShape, IHandShape
    {
        /// <summary>
        /// The default height of the hand, from the pin to the top.
        /// </summary>
        public const float HEIGHT = 42.5f;

        /// <summary>
        /// The default radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        public const float CIRCLE_RADIUS = 3.5f;

        /// <summary>
        /// The default offset position of the center of the circle from the top of the hand.
        /// </summary>
        public const float CIRCLE_OFFSET = 12f;

        /// <summary>
        /// The default length of the tail of the hand.
        /// </summary>
        public const float TAIL_LENGTH = 5f;

        /// <summary>
        /// The default width of the line used to draw the hand.
        /// </summary>
        public new const float LINE_WIDTH = 0.1f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Fancy Sweep Hand Shape"; }
        }


        /// <summary>
        /// The length of the sweep hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the sweep hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the sweep hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        protected float circleRadius = CIRCLE_RADIUS;

        /// <summary>
        /// Gets or sets the radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(CIRCLE_RADIUS)]
        [Description("The radius of the circle from the middle (or not so middle) of the hand.")]
        public virtual float CircleRadius
        {
            get { return circleRadius; }
            set
            {
                circleRadius = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The offset position of the center of the circle from the top of the hand.
        /// </summary>
        protected float circleOffset = CIRCLE_OFFSET;

        /// <summary>
        /// Gets or sets the offset position of the center of the circle from the top of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(CIRCLE_OFFSET)]
        public virtual float CircleOffset
        {
            get { return circleOffset; }
            set
            {
                circleOffset = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The length of the tail of the hand.
        /// </summary>
        private float tailLength = TAIL_LENGTH;

        /// <summary>
        /// Gets or sets the length of the tail of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        [Description("The length of the tail of the hand.")]
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
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class with
        /// default values.
        /// </summary>
        public FancySweepHandShape()
            : this(Color.Red, Color.Empty, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the hand.</param>
        /// <param name="fillColor">The callor used to fill the circle from the middle pf the hand. <see cref="Color.Empty"/> will let the circle transparent.</param>
        /// <param name="height"></param>
        public FancySweepHandShape(Color outlineColor, Color fillColor, float height)
            : base(outlineColor, fillColor, LINE_WIDTH, new GraphicsPath())
        {
            this.height = height;
            CalculateDimensions();
        }

        #endregion


        /// <summary>
        /// Calculates additional values and creates the <see cref="GraphicsPath"/> that will be displayed by the <see cref="Draw"/> method.
        /// </summary>
        protected virtual void CalculateDimensions()
        {
            path.Reset();

            float circleCenterX = -height + circleOffset;

            path.AddLine(new PointF(0f, tailLength), new PointF(0f, circleCenterX + circleRadius));
            path.AddEllipse(-circleRadius, circleCenterX - circleRadius, circleRadius * 2f, circleRadius * 2f);
            path.AddLine(new PointF(0f, circleCenterX - circleRadius), new PointF(0f, -height));
        }
    }
}
