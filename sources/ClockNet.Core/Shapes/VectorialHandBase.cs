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

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// Base class for a clock hand shape that is drawn using vectorial tools.
    /// </summary>
    public abstract class VectorialHandBase : HandBase
    {
        #region OutlineColor Property

        private Color outlineColor;

        /// <summary>
        /// The default value of the <see cref="OutlineColor"/>.
        /// </summary>
        public static Color DefaultOutlineColor = Color.Empty;

        /// <summary>
        /// Gets or sets the color used to draw the outline of the shape.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Empty")]
        [Description("Gets or sets the color used to draw the outline of the shape.")]
        public virtual Color OutlineColor
        {
            get => outlineColor;
            set
            {
                outlineColor = value;
                DisposeDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region FillColor Property

        /// <summary>
        /// The default value of the <see cref="FillColor"/>.
        /// </summary>
        public static Color DefaultFillColor = Color.Black;

        private Color fillColor;

        /// <summary>
        /// Gets or sets the color used to draw the background of the shape.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        [Description("Gets or sets the color used to draw the background of the shape.")]
        public virtual Color FillColor
        {
            get => fillColor;
            set
            {
                fillColor = value;
                DisposeDrawingTools();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region OutlineWidth Property

        /// <summary>
        /// The default width of the line used to draw the shape.
        /// </summary>
        public const float DefaultOutlineWidth = 0.3f;

        private float outlineWidth = DefaultOutlineWidth;

        /// <summary>
        /// Gets or sets the width of the outline.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultOutlineWidth)]
        [Description("The width of the outline.")]
        public virtual float OutlineWidth
        {
            get => outlineWidth;
            set
            {
                outlineWidth = value;

                if (Pen != null)
                    Pen.Width = outlineWidth;

                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Brush Property (protected)

        private Brush brush;

        /// <summary>
        /// The brush used to fill the shape.
        /// </summary>
        [Browsable(false)]
        protected Brush Brush
        {
            get
            {
                if (brush == null)
                    brush = CreateBrush();

                return brush;
            }
            private set => brush = value;
        }

        protected virtual SolidBrush CreateBrush()
        {
            return new SolidBrush(fillColor);

            //System.Drawing.Drawing2D..::.HatchBrush
            //System.Drawing.Drawing2D..::.LinearGradientBrush
            //System.Drawing.Drawing2D..::.PathGradientBrush
            //System.Drawing..::.SolidBrush
            //System.Drawing..::.TextureBrush
        }

        #endregion

        #region Pen Property (protected)

        private Pen pen;

        /// <summary>
        /// The pen used to draw the outline of the shape.
        /// </summary>
        [Browsable(false)]
        protected Pen Pen
        {
            get
            {
                if (pen == null)
                    pen = CreatePen();

                return pen;
            }

            private set => pen = value;
        }

        protected virtual Pen CreatePen()
        {
            return new Pen(outlineColor, outlineWidth);
        }

        #endregion

        protected VectorialHandBase()
            : this(DefaultOutlineColor, DefaultFillColor, DefaultOutlineWidth, DefaultLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialHandBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        public VectorialHandBase(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, DefaultOutlineWidth, DefaultLength)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialHandBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        /// <param name="outlineWidth">The width of the outline.</param>
        /// <param name="length">The length of the hand. This value is given in pixels for a clock with the diameter of 100px.</param>
        public VectorialHandBase(Color outlineColor, Color fillColor, float outlineWidth, float length)
        {
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineWidth = outlineWidth;
            Length = length;
        }

        /// <summary>
        /// Determines whether the object is eligible to be drawn based on its fill and outline color states.
        /// </summary>
        /// <remarks>Drawing is permitted only if at least one of the colors (fill or outline) is set.</remarks>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing is allowed; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (fillColor.IsEmpty && outlineColor.IsEmpty)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Disposes all the classes used in the drawing process.
        /// </summary>
        protected override void DisposeDrawingTools()
        {
            if (Pen != null)
            {
                Pen.Dispose();
                Pen = null;
            }

            if (Brush != null)
            {
                Brush.Dispose();
                Brush = null;
            }

            base.DisposeDrawingTools();
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
                Pen?.Dispose();
                Brush?.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
