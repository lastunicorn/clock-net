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
using System.Net;

namespace DustInTheWind.ClockNet.Core.Shapes.Basic
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the numbers representing the hours.
    /// </summary>
    [Shape("fdc94554-15c6-4f2a-9033-9349f1471013")]
    public class StringRim : VectorialRimBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "String Rim";

        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float DefaultPositionOffset = 7f;

        /// <summary>
        /// Specifies the text format used to draw the text.
        /// </summary>
        protected StringFormat stringFormat;

        /// <summary>
        /// The default font used to draw the text.
        /// </summary>
        public static Font DefaultFont = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);

        private string[] texts = { "•" };
        private Font font;

        /// <summary>
        /// Gets or sets the array of texts that are draw.
        /// </summary>
        [Category("Appearance")]
        [Description("The array of texts that are draw.")]
        public string[] Texts
        {
            get => texts;
            set
            {
                texts = value ?? throw new ArgumentNullException("value");
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets the font used to draw the texts.
        /// </summary>
        [Category("Appearance")]
        [Description("The font used to draw the texts.")]
        public Font Font
        {
            get => font;
            set
            {
                font = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringRim"/> class with
        /// default values.
        /// </summary>
        public StringRim()
            : this(Color.Black, DefaultFont, DefaultPositionOffset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringRim"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="font">The font to be used to draw the numbers.</param>
        /// <param name="distanceFromEdge">The position offset relativelly to the edge of the dial.</param>
        public StringRim(Color color, Font font, float distanceFromEdge)
            : base(Color.Empty, color, DefaultOutlineWidth, DefaultAngle, DefaultRepeat, distanceFromEdge)
        {
            Name = DefaultName;
            this.font = font ?? DefaultFont;

            stringFormat = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            if (font == null)
                return false;

            if (texts == null || texts.Length == 0)
                return false;

            if (FillColor.IsEmpty)
                return false;

            return base.OnBeforeDraw(context);
        }

        /// <summary>
        /// Draws the item at the specified index onto the provided graphics surface.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw the item.</param>
        /// <param name="index">The zero-based index of the item to be drawn.</param>
        protected override void DrawItem(Graphics g, int index)
        {
            int actualIndex = index % texts.Length;

            string text = texts[actualIndex];

            if (text != null && text.Length > 0)
            {
                SizeF textSize = g.MeasureString(text, font, int.MaxValue, stringFormat);
                
                float textX = -textSize.Width / 2f;
                float textY = -textSize.Height / 2f;
                PointF textPosition = new PointF(textX, textY);

                try
                {
                    RectangleF layoutRectangle = new RectangleF(textPosition, textSize);
                    g.DrawString(text, font, Brush, layoutRectangle, stringFormat);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    // When the dimension of the clock is less then 0, this exception is raised.
                    // I do not understend the reason.
                    // I just ignore it. The text will not be displayed, but at the size of one pixel, it is not visible, so, no problem.
                    // I hope this exception will not be thrown in some other situations.
                }
            }
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
                if (stringFormat != null)
                    stringFormat.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
