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

namespace DustInTheWind.ClockNet.Core.Shapes.Advanced
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the pin from the center of the dial.
    /// </summary>
    [Shape("da32532e-8aa5-4361-9235-5298d6657882")]
    public class Pin : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Pin";

        private float centerX;
        private float centerY;

        #region Diameter Property

        /// <summary>
        /// The default value of the diameter.
        /// </summary>
        public const float DefaultDiameter = 1.33f;

        /// <summary>
        /// The diameter of the pin.
        /// </summary>
        protected float diameter;

        /// <summary>
        /// Gets or sets the diameter of the pin.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [Category("Appearance")]
        [DefaultValue(DefaultDiameter)]
        [Description("The diameter of the pin.")]
        public float Diameter
        {
            get => diameter;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The diameter can not be a negative value.");

                diameter = value;
                InvalidateCache();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Length Property (protected)

        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false)]
        public override float Length
        {
            get => base.Length;
            set => base.Length = value;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Pin"/> class with
        /// default values.
        /// </summary>
        public Pin()
            : base(Color.Empty, Color.Black)
        {
            Name = DefaultName;
            diameter = DefaultDiameter;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (diameter <= 0)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateCache(ClockDrawingContext context)
        {
            centerX = -diameter / 2f;
            centerY = -diameter / 2f;
        }

        /// <summary>
        /// Internal method that draws the shape.
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            if (!FillColor.IsEmpty)
                context.Graphics.FillEllipse(Brush, centerX, centerY, diameter, diameter);

            if (!OutlineColor.IsEmpty)
                context.Graphics.DrawEllipse(Pen, centerX, centerY, diameter, diameter);
        }

        public override bool HitTest(PointF point, TimeSpan time)
        {
            return false;
        }
    }
}
