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
    public class StringAngularShape : AngularShapeBase
    {
        public const float POSITION_OFFSET = 7f;

        protected StringFormat numbersStringFormat;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Numbers Shape"; }
        }

        protected string text;

        [Category("Appearance")]
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private Color color;

        /// <summary>
        /// Gets or sets the color used to draw the numbers that marks the hours.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the numbers that marks the hours.")]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The font used to draw the numbers.
        /// </summary>
        protected Font font;

        /// <summary>
        /// Gets the font used to draw the numbers.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Font), "Arial; 7pt")]
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

        /// <summary>
        /// The orientation of the numbers.
        /// </summary>
        private TextAngularOrientation orientation;

        /// <summary>
        /// Geta or sets the orientation of the numbers.
        /// </summary>
        [DefaultValue(typeof(TextAngularOrientation), "Normal")]
        [Description("Specifies the orientation of the numbers.")]
        public TextAngularOrientation Orientation
        {
            get { return orientation; }
            set
            {
                orientation = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAngularShape"/> class with
        /// default values.
        /// </summary>
        public StringAngularShape()
            : this(Color.Black, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), ANGLE, REPEAT, POSITION_OFFSET, TextAngularOrientation.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAngularShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public StringAngularShape(Color color)
            : this(color, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), ANGLE, REPEAT, POSITION_OFFSET, TextAngularOrientation.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAngularShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public StringAngularShape(Color color, Font font)
            : this(color, font, ANGLE, REPEAT, POSITION_OFFSET, TextAngularOrientation.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAngularShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public StringAngularShape(Color color, Font font, float positionOffset)
            : this(color, font, ANGLE, REPEAT, positionOffset, TextAngularOrientation.Normal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringAngularShape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public StringAngularShape(Color color, Font font, float angle, bool repeat, float positionOffset, TextAngularOrientation orientation)
            : base(angle, repeat, positionOffset)
        {
            this.color = color;
            this.font = font == null ? new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point) : font;
            this.orientation = orientation;

            numbersStringFormat = new StringFormat(StringFormatFlags.NoWrap);
            numbersStringFormat.Alignment = StringAlignment.Center;
            numbersStringFormat.LineAlignment = StringAlignment.Center;
        }

        #endregion


        ///// <summary>
        ///// Draws the current number using the provided <see cref="Graphics"/> object.
        ///// </summary>
        ///// <param name="g">The <see cref="Graphics"/> on which to draw the number.</param>
        //public override void Draw(Graphics g)
        //{
        //    if (visible && font != null && numbers != null && !fillColor.IsEmpty)
        //    {
        //        if (index > 0 && index <= numbers.Length)
        //        {
        //            string number = numbers[index - 1];

        //            if (number != null && number.Length > 0)
        //            {
        //                CreateBrushIfNull();

        //                SizeF numberSize = g.MeasureString(number, font, int.MaxValue, numbersStringFormat);
        //                PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

        //                Matrix originalMatrix = null;

        //                switch (orientation)
        //                {
        //                    case NumberOrientation.FaceCenter:
        //                        originalMatrix = g.Transform;
        //                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
        //                        break;

        //                    case NumberOrientation.FaceOut:
        //                        originalMatrix = g.Transform;
        //                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
        //                        g.RotateTransform(180);
        //                        break;

        //                    default:
        //                    case NumberOrientation.Normal:
        //                        float ang = -(this.angle * index);
        //                        originalMatrix = g.Transform;
        //                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
        //                        g.RotateTransform(ang);
        //                        break;
        //                }

        //                //g.DrawRectangle(Pens.Black, new Rectangle((int)numberPosition.X, (int)numberPosition.Y, (int)numberSize.Width, (int)numberSize.Height));
        //                g.DrawString(number, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);

        //                if (originalMatrix != null)
        //                    g.Transform = originalMatrix;
        //            }
        //        }

        //        index++;
        //    }
        //}

        protected override void DrawInternal(Graphics g)
        {
            if (font != null && text != null && text.Length > 0 && !color.IsEmpty)
            {
                CreateBrushIfNull();

                SizeF numberSize = g.MeasureString(text, font, int.MaxValue, numbersStringFormat);
                PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

                Matrix originalMatrix = null;

                switch (orientation)
                {
                    case TextAngularOrientation.FaceCenter:
                        originalMatrix = g.Transform;
                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                        break;

                    case TextAngularOrientation.FaceOut:
                        originalMatrix = g.Transform;
                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                        g.RotateTransform(180);
                        break;

                    default:
                    case TextAngularOrientation.Normal:
                        float ang = -(this.angle * index);
                        originalMatrix = g.Transform;
                        g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                        g.RotateTransform(ang);
                        break;
                }

                //g.DrawRectangle(Pens.Black, new Rectangle((int)numberPosition.X, (int)numberPosition.Y, (int)numberSize.Width, (int)numberSize.Height));
                g.DrawString(text, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);

                if (originalMatrix != null)
                    g.Transform = originalMatrix;
            }
        }

        /// <summary>
        /// The brush used to fill the shape.
        /// </summary>
        protected Brush brush;

        /// <summary>
        /// Creates a new <see cref="Brush"/> object only if it does not already exist.
        /// </summary>
        protected virtual void CreateBrushIfNull()
        {
            if (brush == null)
                brush = new SolidBrush(color);

            //System.Drawing.Drawing2D..::.HatchBrush
            //System.Drawing.Drawing2D..::.LinearGradientBrush
            //System.Drawing.Drawing2D..::.PathGradientBrush
            //System.Drawing..::.SolidBrush
            //System.Drawing..::.TextureBrush
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
                if (brush != null)
                    brush.Dispose();

                if (numbersStringFormat != null)
                    numbersStringFormat.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
