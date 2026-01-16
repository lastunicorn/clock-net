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
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// Represents a digital clock hand that displays the current time as text.
    /// </summary>
    /// <remarks>The <see cref="DigitalHand"/> class provides properties to customize the appearance and
    /// layout of the time display, including font, color, vertical position, and time format. It is typically used in
    /// graphical clock controls or vector drawing environments to render a digital time readout. The class inherits
    /// from <see cref="VectorialHandBase"/>, and supports resource management via <see cref="IDisposable"/>. Thread
    /// safety is not guaranteed; access from multiple threads should be synchronized by the caller.</remarks>
    [Shape("4b95231b-9675-4851-b0b9-1ec9c029d46c")]
    public class DigitalHand : VectorialHandBase
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public const string DefaultName = "Digital Hand";

        /// <summary>
        /// The default font used to draw the time.
        /// </summary>
        public static Font DefaultFont = new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// The default vertical location of the text.
        /// </summary>
        public const float DefaultVerticalLocation = 12f;

        /// <summary>
        /// The default value of the time format.
        /// </summary>
        public const string DefaultFormat = "HH:mm:ss";

        private StringFormat stringFormat;
        private Font font;
        private float verticalLocation;
        private string format;

        /// <summary>
        /// Gets or sets the color used to draw the text.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the text.")]
        public override Color FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        /// <summary>
        /// Gets or sets the font used to draw the text.
        /// </summary>
        [Category("Appearance")]
        [Description("The font used to draw the text.")]
        public virtual Font Font
        {
            get => font;
            set
            {
                if (font == value)
                    return;

                font = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the vertical location where the text is drawn.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultVerticalLocation)]
        [Description("The vertical location where the text is drawn.")]
        public float VerticalLocation
        {
            get => verticalLocation;
            set
            {
                if (verticalLocation == value)
                    return;

                verticalLocation = value;
                OnChanged(EventArgs.Empty);
            }

        }

        /// <summary>
        /// Gets or sets the format in which the time is displayed.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultFormat)]
        [Description("The format in which the time is displayed.")]
        public string Format
        {
            get { return format; }
            set
            {
                format = value;
                OnChanged(EventArgs.Empty);
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalHand"/> class with
        /// default values.
        /// </summary>
        public DigitalHand()
            : this(DefaultFillColor, DefaultFont)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalHand"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="font">The font used to draw the text.</param>
        public DigitalHand(Color color, Font font)
            : base(DefaultOutlineColor, color)
        {
            this.Name = DefaultName;
            this.font = font;
            //this.verticalLocation = DefaultVerticalLocation;
            this.format = DefaultFormat;

            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
        }

        /// <summary>
        /// Determines whether drawing should proceed by performing pre-draw checks using the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context to use for drawing operations. Cannot be null.</param>
        /// <param name="time">The time to be displayed by the shape.</param>
        /// <returns>true if drawing should continue; otherwise, false.</returns>
        protected override bool OnBeforeDraw(Graphics g, TimeSpan time)
        {
            if (font == null)
                return false;

            if (FillColor.IsEmpty)
                return false;

            return base.OnBeforeDraw(g, time);
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="OnDraw"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        /// <param name="time">The time to be displayed by the shape.</param>
        protected override void OnDraw(Graphics g, TimeSpan time)
        {
            string text = time.Ticks < 0
                ? "-"
                : string.Empty;

            text += new DateTime(time.Duration().Ticks).ToString(format);

            if (text.Length > 0)
            {
                SizeF textSize = g.MeasureString(text, font);
                PointF textLocation = new PointF(-textSize.Width / 2F, VerticalLocation);
                RectangleF textRectangle = new RectangleF(textLocation, textSize);

                g.DrawString(text, font, Brush, textRectangle, stringFormat);
            }
        }

        /// <summary>
        /// Tests if the specified point is contained by the Shape.
        /// </summary>
        /// <param name="point">The point to be ferified.</param>
        /// <param name="time">The time displayed by the hand.</param>
        /// <returns>true if the specified point is contained by the Shape; false otherwise.</returns>
        public override bool HitTest(PointF point, TimeSpan time)
        {
            return false;
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
