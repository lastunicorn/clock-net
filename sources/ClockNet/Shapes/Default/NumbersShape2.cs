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
    public class NumbersShape2 : VectorialShapeBase, IAngularShape
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

        protected string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        [Category("Appearance")]
        public string[] Numbers
        {
            get { return numbers; }
            set
            {
                if (numbers == null)
                    throw new ArgumentNullException("value");

                if (numbers.Length != 12)
                    throw new ArgumentException("12 numbers should be provided. No more, no less.", "value");

                numbers = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the color used to draw the numbers that marks the hours.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the numbers that marks the hours.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
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

        private float positionOffset;

        [Category("Appearance")]
        [DefaultValue(POSITION_OFFSET)]
        public float PositionOffset
        {
            get { return positionOffset; }
            set
            {
                positionOffset = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The orientation of the numbers.
        /// </summary>
        private NumberOrientation orientation;

        /// <summary>
        /// Geta or sets the orientation of the numbers.
        /// </summary>
        [DefaultValue(typeof(NumberOrientation), "Normal")]
        [Description("Specifies the orientation of the numbers.")]
        public NumberOrientation Orientation
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
        /// Initializes a new instance of the <see cref="NumbersShape"/> class with
        /// default values.
        /// </summary>
        public NumbersShape2()
            : this(Color.Empty, Color.Black, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape2(Color color)
            : this(Color.Empty, color, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape2(Color color, Font font)
            : this(Color.Empty, color, font, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape2(Color color, Font font, float positionOffset)
            : this(Color.Empty, color, font, positionOffset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape2(Color outlineColor, Color fillColor, Font font, float positionOffset)
            : base(outlineColor, fillColor)
        {
            this.font = font == null ? new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point) : font;
            this.positionOffset = positionOffset;

            numbersStringFormat = new StringFormat(StringFormatFlags.NoWrap);
            numbersStringFormat.Alignment = StringAlignment.Center;
            numbersStringFormat.LineAlignment = StringAlignment.Center;
        }

        #endregion


        /// <summary>
        /// Draws the current number using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the number.</param>
        public override void Draw(Graphics g)
        {
            if (visible && font != null && numbers != null && index >= 0 && index < numbers.Length && !fillColor.IsEmpty)
            {
                string number = numbers[index];

                if (number != null && number.Length > 0)
                {
                    CreateBrushIfNull();

                    SizeF numberSize = g.MeasureString(number, font, int.MaxValue, numbersStringFormat);
                    PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

                    Matrix originalMatrix = null;

                    switch (orientation)
                    {
                        case NumberOrientation.FaceCenter:
                            originalMatrix = g.Transform;
                            g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                            break;

                        case NumberOrientation.FaceOut:
                            originalMatrix = g.Transform;
                            g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                            g.RotateTransform(180);
                            break;

                        default:
                        case NumberOrientation.Normal:
                            float ang = -(this.angle * (index + 1));
                            originalMatrix = g.Transform;
                            g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                            g.RotateTransform(ang);
                            break;
                    }

                    //g.DrawRectangle(Pens.Black, new Rectangle((int)numberPosition.X, (int)numberPosition.Y, (int)numberSize.Width, (int)numberSize.Height));
                    g.DrawString(number, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);

                    if (originalMatrix != null)
                        g.Transform = originalMatrix;
                }
            }

            index++;
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

        private float angle = 30f;
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private bool repeat = true;
        public bool Repeat
        {
            get { return repeat; }
            set
            {
                repeat = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private int index = 0;
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                OnChanged(EventArgs.Empty);
            }
        }

        public void Reset()
        {
            index = 0;
            OnChanged(EventArgs.Empty);
        }
    }
}
