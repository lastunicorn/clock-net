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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the ticks that mark the seconds.
    /// </summary>
    [Shape("2350ba42-86a9-4562-a392-e3c66c973bed")]
    public class Ticks : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Ticks";

        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public new const float DefaultDistanceFromEdge = 8f;

        private PointF StartPoint;
        private PointF EndPoint;

        /// <summary>
        /// Not used.
        /// </summary>
        [Browsable(false)]
        public override Color FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        #region Length Property

        /// <summary>
        /// The default value of the length.
        /// </summary>
        public const float DefaultLength = 5f;

        private float length = DefaultLength;

        /// <summary>
        /// Gets or sets the length of the ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultLength)]
        [Description("The length of the ticks as a percentage from the clock's radius.")]
        public virtual float Length
        {
            get => length;
            set
            {
                length = value;
                InvalidateCache();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticks"/> class with
        /// default values.
        /// </summary>
        public Ticks()
        {
            Name = DefaultName;
            OutlineColor = Color.Black;
            OutlineWidth = DefaultOutlineWidth;
            DistanceFromEdge = DefaultDistanceFromEdge;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw validation.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (OutlineColor.IsEmpty || Length <= 0)
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
            float diameter = context.Diameter;
            float radius = diameter / 2;
            float actualLength = radius * (Length / 100f);

            StartPoint = new PointF(0, -actualLength / 2);
            EndPoint = new PointF(0, actualLength / 2);
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            g.DrawLine(Pen, StartPoint, EndPoint);
        }
    }
}
