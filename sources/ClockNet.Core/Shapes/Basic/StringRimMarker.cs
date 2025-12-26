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

namespace DustInTheWind.ClockNet.Shapes.Basic
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the numbers representing the hours.
    /// </summary>
    [Shape("fdc94554-15c6-4f2a-9033-9349f1471013")]
    public class StringRimMarker : VectorialRimMarkerBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "String Rim Marker";

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
        /// Gets the font used to draw the numbers.
        /// </summary>
        [Category("Appearance")]
        [Description("The font used to draw the numbers.")]
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
        /// Initializes a new instance of the <see cref="StringRimMarker"/> class with
        /// default values.
        /// </summary>
        public StringRimMarker()
            : this(Color.Black, DefaultFont, DefaultPositionOffset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringRimMarker"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="font">The font to be used to draw the numbers.</param>
        /// <param name="distanceFromEdge">The position offset relativelly to the edge of the dial.</param>
        public StringRimMarker(Color color, Font font, float distanceFromEdge)
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
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() &&
                font != null &&
                texts != null &&
                texts.Length > 0 &&
                !FillColor.IsEmpty;
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
            if (Index == 0)
                return;

            int actualIndex = (Index -1) % texts.Length;

            string number = texts[actualIndex];

            if (number != null && number.Length > 0)
            {
                SizeF numberSize = g.MeasureString(number, font, int.MaxValue, stringFormat);
                PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

                try
                {
                    g.DrawString(number, font, Brush, new RectangleF(numberPosition, numberSize), stringFormat);
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
