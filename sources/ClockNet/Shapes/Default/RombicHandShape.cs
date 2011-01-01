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
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Default
{
    public class RombicHandShape : PolygonHandShape
    {
        /// <summary>
        /// The default value of the <see cref="Width"/>.
        /// </summary>
        public new const float WIDTH = 5f;

        /// <summary>
        /// The default value of the <see cref="TailLength"/>.
        /// </summary>
        public const float TAIL_LENGTH = 6f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Rombic Hand Shape"; }
        }

        /// <summary>
        /// The length of the the hand's tail.
        /// </summary>
        protected float tailLength;

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

        /// <summary>
        /// The width of the hand.
        /// </summary>
        protected float width;

        /// <summary>
        /// Gets or sets the width of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(WIDTH)]
        [Description("The width of the hand.")]
        public virtual float Width
        {
            get { return width; }
            set
            {
                width = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RombicHandShape"/> class with
        /// default values.
        /// </summary>
        public RombicHandShape()
            : this(Color.Empty, Color.RoyalBlue, HEIGHT, WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RombicHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        public RombicHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT, WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RombicHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        /// <param name="height">The length of the hour hand for a clock with the diameter of 100px.</param>
        public RombicHandShape(Color outlineColor, Color fillColor, float height, float width, float tailLength)
            : base(null, outlineColor, fillColor, height, LINE_WIDTH)
        {
            this.tailLength = tailLength;
            this.width = width;

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
            float halfWidth = width / 2f;
            points = new PointF[] { new PointF(0f, tailLength), new PointF(-halfWidth, 0f), new PointF(0F, -height), new PointF(halfWidth, 0f) };
        }
    }
}
