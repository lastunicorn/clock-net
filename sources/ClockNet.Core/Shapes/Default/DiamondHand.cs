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

namespace DustInTheWind.ClockNet.Core.Shapes.Advanced
{
    /// <summary>
    /// A Shape that draws a clock hand that resembles a distorted diamond.
    /// </summary>
    [Shape("67304439-3fcd-49cd-9aca-fcea79eed26a")]
    public class DiamondHand : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Diamond Hand";

        private PointF[] points;

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
                InvalidateCache();
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
                InvalidateCache();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DiamondHand"/> class with
        /// default values.
        /// </summary>
        public DiamondHand()
        {
            Name = DefaultName;

            FillColor = Color.RoyalBlue;
            Width = DefaultWidth;
            TailLength = DefaultTailLength;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateCache(ClockDrawingContext context)
        {
            float diameter = context.Diameter;
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

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            if (points == null || points.Length < 2)
                return;

            if (!FillColor.IsEmpty)
                context.Graphics.FillPolygon(Brush, points);

            if (!OutlineColor.IsEmpty)
                context.Graphics.DrawPolygon(Pen, points);
        }

        public override bool HitTest(PointF point, TimeSpan time)
        {
            PointF clickLocation;

            using (Matrix matrix = new Matrix())
            {
                float angle = GetRotationDegrees(time);
                matrix.Rotate(-angle);

                PointF[] points = new PointF[] { point };
                matrix.TransformPoints(points);
                clickLocation = points[0];
            }

            return IsPointInsidePolygon(clickLocation, points);
        }

        private bool IsPointInsidePolygon(PointF point, PointF[] polygon)
        {
            int j = polygon.Length - 1;
            bool oddNodes = false;

            for (int i = 0; i < points.Length; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }
    }
}
