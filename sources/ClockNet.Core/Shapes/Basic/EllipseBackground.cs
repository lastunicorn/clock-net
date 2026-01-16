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
using DustInTheWind.ClockNet.Core.Design;

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
        private PointF location;
        private SizeF size;

        /// <summary>
        /// Gets or sets the center location of the ellipse.
        /// </summary>
        [Category("Appearance")]
        [Description("The center location of the ellipse.")]
        [TypeConverter(typeof(PointFConverter))]
        public PointF Location
        {
            get => location;
            set
            {
                if (location == value)
                    return;

                location = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the size (width and height) of the ellipse.
        /// </summary>
        [Category("Appearance")]
        [Description("The size (width and height) of the ellipse.")]
        public SizeF Size
        {
            get => size;
            set
            {
                if (size == value)
                    return;

                size = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseBackground"/> class with
        /// default values.
        /// </summary>
        public EllipseBackground()
            : base()
        {
            Name = DefaultName;
            Location = new PointF(0f, 0f);
            Size = new SizeF(15f, 10f);
        }

        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateLayout()
        {
            float x = location.X - size.Width / 2;
            float y = location.Y - size.Height / 2;

            rectangle = new RectangleF(x, y, size.Width, size.Height);
        }

        /// <summary>
        /// Determines whether drawing should proceed based on the current state and the provided graphics context.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (size.IsEmpty)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Renders the shape onto the specified graphics surface, filling and outlining the ellipse as configured.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override void OnDraw(ClockDrawingContext context)
        {
            if (!FillColor.IsEmpty)
                context.Graphics.FillEllipse(Brush, rectangle);

            if (!OutlineColor.IsEmpty)
                context.Graphics.DrawEllipse(Pen, rectangle);
        }
    }
}
