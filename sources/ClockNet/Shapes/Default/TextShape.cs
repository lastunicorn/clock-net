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

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the text displayed on the background of the dial.
    /// </summary>
    public class TextShape : VectorialShapeBase
    {
        /// <summary>
        /// The default text drawn.
        /// </summary>
        public const string TEXT = "Dust in the Wind";

        protected StringFormat stringFormat;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Text Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the text.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the text.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// The text that is drawn.
        /// </summary>
        private string txt;

        /// <summary>
        /// Gets or sets the text that is drawn.
        /// </summary>
        [DefaultValue(TEXT)]
        [Description("The text that is drawn.")]
        public virtual string Txt
        {
            get { return txt; }
            set
            {
                txt = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private Font font;

        [Category("Appearance")]
        public virtual Font Font
        {
            get { return font; }
            set
            {
                font = value;
                OnChanged(EventArgs.Empty);
            }
        }

        protected float maxWidth = 50;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class with
        /// default values.
        /// </summary>
        public TextShape()
            : this(TEXT, Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        public TextShape(string text)
            : this(text, Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        public TextShape(string text, Color color)
            : this(text, color, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the pin.</param>
        /// <param name="fill">A value specifying if the pin should be filled with color.</param>
        /// <param name="radiusPercentage">The radius of the pin as percentage from the width of the clock.</param>
        public TextShape(string text, Color color, Font font)
            : base(Color.Empty, color)
        {
            this.txt = text;
            this.font = font;

            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
        }

        #endregion


        #region Calculated Values

        //private SizeF textSize;
        //private PointF textLocation;

        //private void CalculateDimensions()
        //{
        //    textSize = g.MeasureString(text, font, (int)maxWidth);
        //    textLocation = new PointF(-textSize.Width / 2F, maxWidth / 5F);
        //}

        #endregion

        /// <summary>
        /// Draws the pin using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the pin.</param>
        public override void Draw(Graphics g)
        {
            if (font != null && txt != null && txt.Length > 0)
            {
                if (!fillColor.IsEmpty)
                {
                    CreateBrushIfNull();

                    SizeF textSize = g.MeasureString(txt, font, (int)maxWidth);
                    PointF textLocation = new PointF(-textSize.Width / 2F, maxWidth / 5F);

                    g.DrawString(txt, font, brush, new RectangleF(textLocation, textSize), stringFormat);
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
