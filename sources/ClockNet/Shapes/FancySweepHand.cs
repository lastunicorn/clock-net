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
using DustInTheWind.ClockNet.Core.Shapes;
using DustInTheWind.ClockNet.Core.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// Draws a sweep hand as a line with a circle near its top.
    /// </summary>
    [Shape("230ab218-4d4f-42a0-a019-1fc2a804bcea")]
    public class FancySweepHand : PathHand
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string DefaultName = "Fancy Sweep Hand";

        #region CircleRadius Property

        /// <summary>
        /// The default radius of the circle from the middle (or not so middle) of the hand.
        /// </summary>
        public const float DefaultCircleRadius = 7f;

        private float circleRadius = DefaultCircleRadius;

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

        #endregion

        #region CircleOffset Property

        /// <summary>
        /// The default offset position of the center of the circle from the top of the hand.
        /// </summary>
        public const float DefaultCircleOffset = 24f;

        private float circleOffset = DefaultCircleOffset;

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

        #endregion

        #region TailLength Property

        /// <summary>
        /// The default length of the tail of the hand.
        /// </summary>
        public const float DefaultTailLength = 14f;

        private float tailLength = DefaultTailLength;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="FancySweepHand"/> class with
        /// default values.
        /// </summary>
        public FancySweepHand()
        {
            Name = DefaultName;
            tailLength = DefaultTailLength;
            OutlineColor = Color.Red;
            FillColor = Color.Empty;
        }

        /// <summary>
        /// Calculates additional values and creates the <see cref="GraphicsPath"/> that will be displayed
        /// by the <see cref="IShape.Draw"/> method.
        /// </summary>
        protected override void CalculateCache()
        {
            path.Reset();

            float diameter = 200f;
            float radius = diameter / 2;
            float actualLength = radius * (Length / 100f);
            float actualCircleOffset = radius * (CircleOffset / 100f);
            float actualCircleRadius = radius * (CircleRadius / 100f);
            float actualTailLength = radius * (TailLength / 100f);

            float actualCircleCenterX = -actualLength + actualCircleOffset;

            // Base Line

            PointF baseLineStartPoint = new PointF(0f, actualTailLength);
            PointF baseLineEndPoint = new PointF(0f, actualCircleCenterX + actualCircleRadius);
            path.AddLine(baseLineStartPoint, baseLineEndPoint);

            // Circle

            float circleX = -actualCircleRadius;
            float circleY = actualCircleCenterX - actualCircleRadius;
            float actualCircleDiameter = actualCircleRadius * 2f;
            path.AddEllipse(circleX, circleY, actualCircleDiameter, actualCircleDiameter);

            // Tip Line

            PointF tipLineStartPoint = new PointF(0f, actualCircleCenterX - actualCircleRadius);
            PointF tipLineEndPoint = new PointF(0f, -actualLength);
            path.AddLine(tipLineStartPoint, tipLineEndPoint);
        }
    }
}
