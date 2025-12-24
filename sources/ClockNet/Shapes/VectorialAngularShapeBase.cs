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

namespace DustInTheWind.ClockNet.Shapes
{
    /// <summary>
    /// Provides common functionality for a vectorial shape.
    /// </summary>
    public abstract class VectorialAngularShapeBase : AngularShapeBase
    {
        /// <summary>
        /// The default width of the line used to draw the shape.
        /// </summary>
        public const float DefaultLineWidth = 0.3f;

        /// <summary>
        /// The default value of the <see cref="FillColor"/>.
        /// </summary>
        public static Color DefaultFillColor = Color.Black;

        /// <summary>
        /// The default value of the <see cref="OutlineColor"/>.
        /// </summary>
        public static Color DefaultOutlineColor = Color.Empty;


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
        [DefaultValue(typeof(Color), "Black")]
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
        protected float lineWidth = DefaultLineWidth;

        /// <summary>
        /// Gets or sets the width of the outline.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultLineWidth)]
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

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialAngularShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        public VectorialAngularShapeBase(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, DefaultLineWidth, DefaultAngle, DefaultRepeat, DefaultPositionOffset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VectorialAngularShapeBase"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the shape.</param>
        /// <param name="fillColor">The color used to draw the background of the shape.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public VectorialAngularShapeBase(Color outlineColor, Color fillColor, float lineWidth, float angle, bool repeat, float positionOffset)
            : base(angle, repeat, positionOffset)
        {
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.lineWidth = lineWidth;
        }

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
