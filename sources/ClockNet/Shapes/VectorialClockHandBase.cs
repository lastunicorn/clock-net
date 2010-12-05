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

namespace DustInTheWind.Clock.Shapes
{
    public abstract class VectorialClockHandBase : ClockHandBase
    {
        /// <summary>
        /// The brush used to fill the shape.
        /// </summary>
        protected Brush brush;

        /// <summary>
        /// The pen used to draw the outline of the shape
        /// </summary>
        protected Pen pen;

        /// <summary>
        /// The color used to draw the shape.
        /// </summary>
        protected Color color;

        /// <summary>
        /// Gets or sets the color used to draw the shape.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        [Description("Gets or sets the color used to draw the shape.")]
        public virtual Color Color
        {
            get { return color; }
            set
            {
                color = value;
                InvalidateDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// A value specifying if the vectorial shape should be filled with color.
        /// </summary>
        protected bool fill;

        /// <summary>
        /// Gets or sets a value specifying if the vectorial shape should be filled with color.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("Specifies if the vectorial shape should be filled with color.")]
        public virtual bool Fill
        {
            get { return fill; }
            set
            {
                fill = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorShapeBase"/> class.
        /// </summary>
        /// <param name="color">The color to be used when drawing the shape.</param>
        public VectorialClockHandBase(Color color, bool fill, float height)
            : base(height)
        {
            this.color = color;
            this.fill = fill;
        }

        protected override void InvalidateDrawingTools()
        {
            if (pen != null)
            {
                pen.Dispose();
                pen = null;
            }

            if (brush != null)
            {
                brush.Dispose();
                brush = null;
            }

            base.InvalidateDrawingTools();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pen != null)
                    pen.Dispose();

                if (brush != null)
                    brush.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
