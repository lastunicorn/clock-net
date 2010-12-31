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
    /// <summary>
    /// Base class for a clock hand shape that is drawn using vectorial tools.
    /// </summary>
    public abstract class VectorialHandShapeBase : HandShapeBase
    {
        /// <summary>
        /// The default width of the line used to draw the shape.
        /// </summary>
        public const float LINE_WIDTH = 0.3f;


        /// <summary>
        /// The brush used to fill the shape.
        /// </summary>
        protected Brush brush;

        /// <summary>
        /// The pen used to draw the outline of the shape
        /// </summary>
        protected Pen pen;


        /// <summary>
        /// The color used to draw the outline of the shape.
        /// </summary>
        protected Color outlineColor;

        /// <summary>
        /// Gets or sets the color used to draw the outline of the shape.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Empty")]
        [Description("Gets or sets the color used to draw the outline of the shape.")]
        public virtual Color OutlineColor
        {
            get { return outlineColor; }
            set
            {
                outlineColor = value;
                InvalidateDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The color used to draw the background of the shape.
        /// </summary>
        protected Color fillColor;

        /// <summary>
        /// Gets or sets the color used to draw the background of the shape.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        [Description("Gets or sets the color used to draw the background of the shape.")]
        public virtual Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                InvalidateDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The width of the outline.
        /// </summary>
        protected float lineWidth = LINE_WIDTH;

        /// <summary>
        /// Gets or sets the width of the outline.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(LINE_WIDTH)]
        [Description("The width of the outline.")]
        public virtual float LineWidth
        {
            get { return lineWidth; }
            set
            {
                lineWidth = value;
                if (pen != null)
                    pen.Width = lineWidth;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialHandShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        public VectorialHandShapeBase(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, LINE_WIDTH, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialHandShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="height">The length of the hand. This value is given in pixels for a clock with the diameter of 100px.</param>
        public VectorialHandShapeBase(Color outlineColor, Color fillColor, float lineWidth, float height)
            : base(height)
        {
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.lineWidth = lineWidth;
        }

        #endregion


        /// <summary>
        /// Disposes all the classes used in the drawing process.
        /// </summary>
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

        /// <summary>
        /// Creates a new <see cref="Brush"/> object only if it does not already exist.
        /// </summary>
        protected virtual void CreateBrushIfNull()
        {
            if (brush == null)
                brush = new SolidBrush(fillColor);

            //System.Drawing.Drawing2D..::.HatchBrush
            //System.Drawing.Drawing2D..::.LinearGradientBrush
            //System.Drawing.Drawing2D..::.PathGradientBrush
            //System.Drawing..::.SolidBrush
            //System.Drawing..::.TextureBrush
        }

        /// <summary>
        /// Creates a new <see cref="Pen"/> object only if it does not already exist.
        /// </summary>
        protected virtual void CreatePenIfNull()
        {
            if (pen == null)
                pen = new Pen(outlineColor, lineWidth);
        }

        #region Dispose

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Speifies if the managed resources should be disposed, too.</param>
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

        #endregion
    }
}
