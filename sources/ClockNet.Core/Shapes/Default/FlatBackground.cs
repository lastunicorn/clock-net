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

namespace DustInTheWind.ClockNet.Core.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the background of the dial.
    /// </summary>
    [Shape("ac17028b-424c-4b91-b961-72b9f0b4733a")]
    public class FlatBackground : VectorialBackgroundBase
    {
        private RectangleF rect;

        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Background Shape";

        #region Radius Property

        /// <summary>
        /// The default radius of the Dial Shape.
        /// </summary>
        public const float DefaultRadius = 100f;

        private float radius;

        /// <summary>
        /// Gets or sets the radius of the dial.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        [Category("Appearance")]
        [DefaultValue(DefaultRadius)]
        [Description("The radius of the dial.")]
        public virtual float Radius
        {
            get => radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

                radius = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatBackground"/> class with
        /// default values.
        /// </summary>
        public FlatBackground()
            : this(DefaultOutlineColor, Color.Black, DefaultRadius, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatBackground"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        public FlatBackground(Color fillColor)
            : this(DefaultOutlineColor, fillColor, DefaultRadius, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatBackground"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        /// <param name="radius">The radius of the dial.</param>
        public FlatBackground(Color fillColor, float radius)
            : this(DefaultOutlineColor, fillColor, radius, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatBackground"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the dial.</param>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        /// <param name="radius">The radius of the dial.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public FlatBackground(Color outlineColor, Color fillColor, float radius, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            Name = DefaultName;
            this.radius = radius;
        }

        /// <summary>
        /// Creates a new <see cref="Pen"/> object if it does not exist already.
        /// The pen will have an Inset alignment.
        /// </summary>
        protected override Pen CreatePen()
        {
            return new Pen(OutlineColor, OutlineWidth)
            {
                Alignment = PenAlignment.Inset
            };
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateCache()
        {
            rect = new RectangleF(-radius, -radius, radius * 2, radius * 2);
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw validation using the specified graphics
        /// context.
        /// </summary>
        /// <remarks>This method is typically called before rendering to ensure that all preconditions for
        /// drawing are met. Overrides should return false to cancel the draw operation if necessary.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (radius <= 0)
                return false;

            return base.OnBeforeDraw(context);
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
            if (!FillColor.IsEmpty)
                context.Graphics.FillEllipse(Brush, rect);

            if (!OutlineColor.IsEmpty)
                context.Graphics.DrawEllipse(Pen, rect);
        }
    }
}
