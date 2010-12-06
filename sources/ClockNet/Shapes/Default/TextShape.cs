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
        private const float RADIUS = 1.33f;
        protected StringFormat stringFormat;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Text Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Red")]
        [Description("The color used to draw the pin.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        private string text;

        [Category("Appearance")]
        [DefaultValue("")]
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private Font font;

        [Category("Appearance")]
        public Font Font
        {
            get { return font; }
            set
            {
                font = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private float maxWidth = 50;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PinShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the pin.</param>
        /// <param name="fill">A value specifying if the pin should be filled with color.</param>
        /// <param name="radiusPercentage">The radius of the pin as percentage from the width of the clock.</param>
        public TextShape(Color color, Font font, VectorialDrawMode drawMode)
            : base(Color.Empty, color, drawMode)
        {
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
            if (font != null && text != null && text.Length > 0)
            {
                if ((drawMode & VectorialDrawMode.Fill) == VectorialDrawMode.Fill)
                {
                    CreateBrushIfNull();

                    SizeF textSize = g.MeasureString(text, font, (int)maxWidth);
                    PointF textLocation = new PointF(-textSize.Width / 2F, maxWidth / 5F);

                    g.DrawString(text, font, brush, new RectangleF(textLocation, textSize), stringFormat);
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
