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
using System.ComponentModel;
using System.Drawing;

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// A Shape class that draws a ellipse.
    /// </summary>
    [Shape("8447c9ee-3aae-45ec-8f73-ac9900d192d3")]
    public class EllipseGroundShape : VectorialGroundShapeBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Ellipse Ground Shape";

        ///// <summary>
        ///// The default horizontal radius of the ellipse.
        ///// </summary>
        //public const float DefaultRadiusX = 15f;

        ///// <summary>
        ///// The default vertical radius of the ellipse.
        ///// </summary>
        //public const float DefaultRadiusY = 10f;

        ///// <summary>
        ///// The default x coordinate of the center of the ellipse.
        ///// </summary>
        //public const float DefaultCenterX = 0f;

        ///// <summary>
        ///// The default y coordinate of the center of the ellipse.
        ///// </summary>
        //public const float DefaultCenterY = -5f;

        /// <summary>
        /// The rectangle defining the ellipse that is drawn.
        /// </summary>
        private RectangleF rectangle;

        ///// <summary>
        ///// The radius of the ellipse.
        ///// </summary>
        //protected float radiusX;

        ///// <summary>
        ///// Gets or sets the horizontal radius of the ellipse.
        ///// </summary>
        ///// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        //[Category("Appearance")]
        //[DefaultValue(DefaultRadiusX)]
        //[Description("The radius of the dial.")]
        //public virtual float RadiusX
        //{
        //    get => radiusX;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

        //        radiusX = value;
        //        InvalidateLayout();
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

        ///// <summary>
        ///// The radius of the ellipse.
        ///// </summary>
        //protected float radiusY;

        ///// <summary>
        ///// Gets or sets the vertical radius of the ellipse.
        ///// </summary>
        ///// <exception cref="ArgumentOutOfRangeException">The radius can not be a negative value.</exception>
        //[Category("Appearance")]
        //[DefaultValue(DefaultRadiusY)]
        //[Description("The radius of the dial.")]
        //public virtual float RadiusY
        //{
        //    get => radiusY;
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

        //        radiusY = value;
        //        InvalidateLayout();
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

        ///// <summary>
        ///// The x coordinate of the center of the ellipse.
        ///// </summary>
        //protected float centerX;

        ///// <summary>
        ///// Gets or sets the y coordinate of the center of the ellipse.
        ///// </summary>
        //[Category("Appearance")]
        //[DefaultValue(DefaultCenterX)]
        //[Description("The x coordinate of the center of the ellipse.")]
        //public virtual float CenterX
        //{
        //    get => centerX;
        //    set
        //    {
        //        centerX = value;
        //        InvalidateLayout();
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

        ///// <summary>
        ///// The y coordinate of the center of the ellipse.
        ///// </summary>
        //protected float centerY;

        ///// <summary>
        ///// Gets or sets the y coordinate of the center of the ellipse.
        ///// </summary>
        //[Category("Appearance")]
        //[DefaultValue(DefaultCenterY)]
        //[Description("The y coordinate of the center of the ellipse.")]
        //public virtual float CenterY
        //{
        //    get => centerY;
        //    set
        //    {
        //        centerY = value;
        //        InvalidateLayout();
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

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
        /// Initializes a new instance of the <see cref="EllipseGroundShape"/> class with
        /// default values.
        /// </summary>
        public EllipseGroundShape()
            : this(RectangleF.Empty, DefaultOutlineColor, DefaultFillColor, DefaultLineWidth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseGroundShape"/> class.
        /// </summary>
        /// <param name="rectangle">The rectangle defining the ellipse that will be drawn.</param>
        /// <param name="outlineColor">The color used to draw the outline of the ellipse.</param>
        /// <param name="fillColor">The color used to fill the ellipse's interior.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public EllipseGroundShape(RectangleF rectangle, Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.Name = DefaultName;
            this.Rectangle = rectangle;

            //centerX = DefaultCenterX;
            //centerY = DefaultCenterY;

            //radiusX = DefaultRadiusX;
            //radiusY = DefaultRadiusY;
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            //float rectX = centerX - radiusX;
            //float rectY = centerY - radiusY;

            //float rectWidth = radiusX * 2;
            //float rectHeight = radiusY * 2;

            //Rectangle = new RectangleF(rectX, rectY, rectWidth, rectHeight);
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
            if (!fillColor.IsEmpty)
                g.FillEllipse(Brush, Rectangle);

            if (!outlineColor.IsEmpty)
                g.DrawEllipse(Pen, Rectangle);
        }
    }
}
