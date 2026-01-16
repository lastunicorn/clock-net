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
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Core.Shapes.Advanced
{
    /// <summary>
    /// A Shape that draws a clock hand that resembles a distorted diamond.
    /// </summary>
    [Shape("67304439-3fcd-49cd-9aca-fcea79eed26a")]
    public class DiamondHand : PolygonHand
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string DefaultName = "Diamond Hand";

        #region TailLength Property

        /// <summary>
        /// The default value of the <see cref="TailLength"/>.
        /// </summary>
        public const float DefaultTailLength = 12f;

        private float tailLength;

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

        #endregion

        #region Width Property

        /// <summary>
        /// The default value of the <see cref="Width"/>.
        /// </summary>
        public const float DefaultWidth = 10f;

        private float width;

        /// <summary>
        /// Gets or sets the width of the hand.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultWidth)]
        [Description("The width of the hand.")]
        public virtual float Width
        {
            get => width;
            set
            {
                width = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHand"/> class with
        /// default values.
        /// </summary>
        public DiamondHand()
            : this(Color.Empty, Color.RoyalBlue, DefaultLength, DefaultWidth, DefaultTailLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHand"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline.</param>
        /// <param name="fillColor">The color used to fill the shape.</param>
        /// <param name="length">The length of the hour hand for a clock with the diameter of 100px.</param>
        /// <param name="tailLength">The width of the hand.</param>
        /// <param name="width">The length of the the tail that is drawn behind the pin.</param>
        public DiamondHand(Color outlineColor, Color fillColor, float length, float width, float tailLength)
            : base(null, outlineColor, fillColor, length, DefaultOutlineWidth)
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
            float diameter = 200f;
            float radius = diameter / 2;
            float actualLength = radius * (Length / 100f);
            float actualTailLength = radius * (TailLength / 100f);
            float actualWidth = radius * (Width / 100f);
            float actualHalfWidth = actualWidth / 2f;

            points = new PointF[]
            {
                new PointF(0f, actualTailLength),
                new PointF(-actualHalfWidth, 0f),
                new PointF(0F, -actualLength),
                new PointF(actualHalfWidth, 0f)
            };
        }
    }
}
