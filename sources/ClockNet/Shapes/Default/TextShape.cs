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

        /// <summary>
        /// The default vertical location of the text.
        /// </summary>
        public const float VERTICAL_LOCATION = 12f;

        /// <summary>
        /// The maximum width of the rectangle where the text should be drawn.
        /// </summary>
        public const float MAX_WIDTH = 50f;


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
        protected string text;

        /// <summary>
        /// Gets or sets the text that is drawn.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TEXT)]
        [Description("The text that is drawn.")]
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
        [Category("Appearance")]
        [DefaultValue(MAX_WIDTH)]
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


        private float verticalLocation;

        [DefaultValue(VERTICAL_LOCATION)]
        public float VerticalLocation
        {
            get { return verticalLocation; }
            set
            {
                verticalLocation = value;
                recalculateNeeded = true;
                OnChanged(EventArgs.Empty);
            }

        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class with
        /// default values.
        /// </summary>
        public TextShape()
            : this(TEXT, Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class.
        /// </summary>
        /// <param name="text">The text that should be drawn.</param>
        public TextShape(string text)
            : this(text, Color.Black, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class.
        /// </summary>
        /// <param name="text">The text that should be drawn.</param>
        /// <param name="color">The color used to draw the text.</param>
        public TextShape(string text, Color color)
            : this(text, color, new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextShape"/> class.
        /// </summary>
        /// <param name="text">The text that should be drawn.</param>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="font">The font used to draw the text.</param>
        public TextShape(string text, Color color, Font font)
            : base(Color.Empty, color)
        {
            this.text = text;
            this.font = font;
            this.verticalLocation = VERTICAL_LOCATION;

            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
        }

        #endregion

        #region Calculated Values

        private bool recalculateNeeded = true;
        private RectangleF textRectangle;

        private void CalculateDimensions(Graphics g)
        {
            SizeF textSize = g.MeasureString(text, font, (int)maxWidth);
            //PointF textLocation = new PointF(-textSize.Width / 2F, maxWidth / 5F);
            PointF textLocation = new PointF(-textSize.Width / 2F, verticalLocation);
            textRectangle = new RectangleF(textLocation, textSize);

            recalculateNeeded = false;
        }

        #endregion


        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && font != null && text != null && text.Length > 0 && !fillColor.IsEmpty;
        }

        /// <summary>
        /// Draws the pin using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the pin.</param>
        protected override void DrawInternal(Graphics g)
        {
            CreateBrushIfNull();

            if (recalculateNeeded)
                CalculateDimensions(g);

            g.DrawString(text, font, brush, textRectangle, stringFormat);
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
