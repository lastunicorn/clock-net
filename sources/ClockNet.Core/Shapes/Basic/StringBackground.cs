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
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the text displayed on the background of the dial.
    /// </summary>
    [Shape("2702ec4a-dde3-441a-bc60-436b2a24b36b")]
    public class StringBackground : VectorialBackgroundBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "String Background";

        /// <summary>
        /// The default text drawn.
        /// </summary>
        public const string DefaultText = "Dust in the Wind";

        /// <summary>
        /// The default font used to draw the text.
        /// </summary>
        public static Font DefaultFont = new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// The default vertical location of the text.
        /// </summary>
        public static PointF DefaultLocation = new PointF(0f, 0f);

        /// <summary>
        /// The maximum width of the rectangle where the text should be drawn.
        /// </summary>
        public const float DefaultMaxWidth = 50f;


        /// <summary>
        /// Formats the text displayed by the current instance.
        /// </summary>
        protected StringFormat stringFormat;


        /// <summary>
        /// The text that is drawn.
        /// </summary>
        protected string text;

        /// <summary>
        /// Gets or sets the text that is drawn.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultText)]
        [Description("The text that is drawn.")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public virtual string Text
        {
            get { return text; }
            set
            {
                text = value;
                recalculateNeeded = true;
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The font used to draw the text.
        /// </summary>
        protected Font font;

        /// <summary>
        /// Gets or sets the font used to draw the text.
        /// </summary>
        [Category("Appearance")]
        [Description("The font used to draw the text.")]
        public virtual Font Font
        {
            get { return font; }
            set
            {
                font = value;
                recalculateNeeded = true;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The maximum width of the rectangle where the text should be drawn.
        /// </summary>
        protected float maxWidth = 50;

        /// <summary>
        /// Gets or sets the maximum width of the rectangle where the text should be drawn.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultMaxWidth)]
        [Description("The maximum width of the rectangle where the text should be drawn.")]
        public virtual float MaxWidth
        {
            get { return maxWidth; }
            set
            {
                maxWidth = value;
                recalculateNeeded = true;
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The location where the text is drawn.
        /// </summary>
        private PointF location;

        /// <summary>
        /// Gets or sets the location where the text is drawn.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(typeof(PointF), "0;0")]
        [TypeConverter(typeof(PointFConverter))]
        [Description("The location where the text is drawn.")]
        public PointF Location
        {
            get { return location; }
            set
            {
                location = value;
                recalculateNeeded = true;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringBackground"/> class with
        /// default values.
        /// </summary>
        public StringBackground()
        {
            Name = DefaultName;

            text = DefaultText;
            font = DefaultFont;
            location = DefaultLocation;

            stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.None
            };
        }

        private bool recalculateNeeded = true;
        private RectangleF textRectangle;

        private void CalculateDimensions(Graphics g)
        {
            SizeF textSize = g.MeasureString(text, font, (int)maxWidth);
            PointF textLocation = new PointF(location.X - textSize.Width / 2F, location.Y - textSize.Height / 2F);
            textRectangle = new RectangleF(textLocation, textSize);

            recalculateNeeded = false;
        }

        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && font != null && text != null && text.Length > 0 && !FillColor.IsEmpty;
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
            if (recalculateNeeded)
                CalculateDimensions(g);

            g.DrawString(text, font, Brush, textRectangle, stringFormat);
        }

        #region Dispose

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Specifies if the managed resources should be disposed, too.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (stringFormat != null)
                    stringFormat.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
