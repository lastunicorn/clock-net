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

using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// A Hand Shape that draws an ellipse.
    /// </summary>
    [Shape("c0af87a2-fbec-4ab5-8dea-9197550f87e6")]
    public class EllipseHand : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Ellipse Hand";

        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        protected RectangleF rectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseHand"/> class with
        /// default values.
        /// </summary>
        public EllipseHand()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultLength, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseHand"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the ellipse.</param>
        public EllipseHand(Color fillColor, float height)
            : this(RectangleF.Empty, DefaultOutlineColor, fillColor, height, DefaultOutlineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseHand"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to draw the background of the hand.</param>
        /// <param name="height">The distance between the pin and the center of the circle.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public EllipseHand(RectangleF rectangle, Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height)
        {
            this.Name = DefaultName;
            this.rectangle = rectangle;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !rectangle.IsEmpty;
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
                g.FillEllipse(Brush, rectangle);

            if (!OutlineColor.IsEmpty)
                g.DrawEllipse(Pen, rectangle);
        }

        public override bool HitTest(PointF point)
        {
            return false;
        }
    }
}
