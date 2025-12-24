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
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// A Shape that draws a clock hand that resembles a distorted diamond.
    /// </summary>
    [Shape("67304439-3fcd-49cd-9aca-fcea79eed26a")]
    public class DiamondHandShape : PolygonHandShape
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string DefaultName = "Diamond Hand Shape";

        /// <summary>
        /// The default value of the <see cref="Width"/>.
        /// </summary>
        public const float DefaultWidth = 5f;

        /// <summary>
        /// The default value of the <see cref="TailLength"/>.
        /// </summary>
        public const float DefaultTailLength = 6f;


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
            get { return tailLength; }
            set
            {
                tailLength = value;
                InvalidateLayout();
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
        [DefaultValue(DefaultWidth)]
        [Description("The width of the hand.")]
        public virtual float Width
        {
            get { return width; }
            set
            {
                width = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHandShape"/> class with
        /// default values.
        /// </summary>
        public DiamondHandShape()
            : this(Color.Empty, Color.RoyalBlue, DefaultHeight, DefaultWidth, DefaultTailLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        public DiamondHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, DefaultHeight, DefaultWidth, DefaultTailLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        /// <param name="height">The length of the hour hand for a clock with the diameter of 100px.</param>
        /// <param name="tailLength">The width of the hand.</param>
        /// <param name="width">The length of the the tail that is drawn behind the pin.</param>
        public DiamondHandShape(Color outlineColor, Color fillColor, float height, float width, float tailLength)
            : base(null, outlineColor, fillColor, height, DefaultLineWidth)
        {
            Name = DefaultName;
            this.tailLength = tailLength;
            this.width = width;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            float halfWidth = width / 2f;

            points = new PointF[]
            {
                new PointF(0f, tailLength),
                new PointF(-halfWidth, 0f),
                new PointF(0F, -length),
                new PointF(halfWidth, 0f)
            };
        }
    }
}
