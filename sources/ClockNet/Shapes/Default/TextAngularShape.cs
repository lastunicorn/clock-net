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
using System.Drawing.Drawing2D;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the numbers representing the hours.
    /// </summary>
    public class TextAngularShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public new const float POSITION_OFFSET = 7f;

        public new const float ANGLE = 30f;

        protected StringFormat numbersStringFormat;

        public static Font FONT = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Numbers Shape"; }
        }

        protected string[] texts = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        [Category("Appearance")]
        public string[] Texts
        {
            get { return texts; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                texts = value;
                OnChanged(EventArgs.Empty);
            }
        }

        ///// <summary>
        ///// Gets or sets the color used to draw the numbers that marks the hours.
        ///// </summary>
        //[DefaultValue(typeof(Color), "Black")]
        //[Description("The color used to draw the numbers that marks the hours.")]
        //public override Color OutlineColor
        //{
        //    get { return base.OutlineColor; }
        //    set { base.OutlineColor = value; }
        //}

        /// <summary>
        /// The font used to draw the numbers.
        /// </summary>
        protected Font font;

        /// <summary>
        /// Gets the font used to draw the numbers.
        /// </summary>
        [Category("Appearance")]
        [Description("The font used to draw the numbers.")]
        public Font Font
        {
            get { return font; }
            set
            {
                font = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class with
        /// default values.
        /// </summary>
        public TextAngularShape()
            : this(Color.Black, FONT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class.
        /// </summary>
        public TextAngularShape(Color color)
            : this(color, FONT, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public TextAngularShape(Color color, Font font)
            : this(color, font, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public TextAngularShape(Color color, Font font, float positionOffset)
            : base(Color.Empty, color, LINE_WIDTH, ANGLE, REPEAT, positionOffset)
        {
            this.font = font == null ? FONT : font;

            numbersStringFormat = new StringFormat(StringFormatFlags.NoWrap);
            numbersStringFormat.Alignment = StringAlignment.Center;
            numbersStringFormat.LineAlignment = StringAlignment.Center;
        }

        #endregion


        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig. Not even incrementing the index.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && font != null && texts != null && !fillColor.IsEmpty;
        }

        /// <summary>
        /// Internal method that draws the Shape unconditioned. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IShape.Draw"/> method checks if the Shape should be drawn or not, transforms the
        /// coordinate's system if necessary the and then calls <see cref="DrawInternal"/> method.
        /// </remarks>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        protected override void DrawInternal(Graphics g)
        {
            if (index > 0 && index <= texts.Length)
            {
                string number = texts[index - 1];

                if (number != null && number.Length > 0)
                {
                    CreateBrushIfNull();

                    SizeF numberSize = g.MeasureString(number, font, int.MaxValue, numbersStringFormat);
                    PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

                    try
                    {
                        g.DrawString(number, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);
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
                if (numbersStringFormat != null)
                    numbersStringFormat.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
