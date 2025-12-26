// ClockControl
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
using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Background Shape representing an ellipse.
    /// </summary>
    [Shape("8447c9ee-3aae-45ec-8f73-ac9900d192d3")]
    public class EllipseBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Ellipse Background";

        private RectangleF rectangle;

        /// <summary>
        /// Get or sets the rectangle defining the ellipse that is drawn.
        /// </summary>
        protected RectangleF Rectangle
        {
            get => rectangle;
            set
            {
                rectangle = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseBackground"/> class with
        /// default values.
        /// </summary>
        public EllipseBackground()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseBackground"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the ellipse.</param>
        /// <param name="fillColor">The color used to fill the ellipse's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public EllipseBackground(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            Name = DefaultName;
            Rectangle = rectangle;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !Rectangle.IsEmpty;
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void OnDraw(Graphics g)
        {
            if (!FillColor.IsEmpty)
                g.FillEllipse(Brush, Rectangle);

            if (!OutlineColor.IsEmpty)
                g.DrawEllipse(Pen, Rectangle);
        }
    }
}
