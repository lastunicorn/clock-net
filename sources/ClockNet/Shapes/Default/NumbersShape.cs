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
    public class NumbersShape : VectorialShapeBase, INumbersShape
    {
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
        [DefaultValue(typeof(Font), "Microsoft Sans Serif; 8.25pt")]
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

        private float positionOffset = 20f;

        [Category("Appearance")]
        [DefaultValue(20f)]
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
        /// The index of the number to be drown.
        /// </summary>
        protected int currentIndex;

        /// <summary>
        /// Gets or sets the index of the number to be drown.
        /// </summary>
        [Browsable(false)]
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (value < 0 || value >= numbers.Length)
                    throw new IndexOutOfRangeException("The specified index is out of the range of the array numbers.");

                currentIndex = value;
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
        public NumbersShape()
            : this(Color.Black, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape(Font font)
            : this(Color.Black, font)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumbersShape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="font">The font to be used to draw the numbers.</param>
        public NumbersShape(Color color, Font font)
            : base(color, VectorialDrawMode.Fill)
        {
            this.font = font;

            numbersStringFormat = new StringFormat(StringFormatFlags.NoWrap);
            numbersStringFormat.Alignment = StringAlignment.Center;
            numbersStringFormat.LineAlignment = StringAlignment.Center;
            
            CalculateDimensions();
        }

        #endregion


        protected override void OnClockWidthChanged()
        {
            base.OnClockWidthChanged();
            CalculateDimensions();
        }

        #region Calculated Values

        //private float _locationX;
        //private float _locationY;
        //private volatile float _radius;

        private void CalculateDimensions()
        {
            //_radius = radius * clockWidth / 100;
            //_locationX = -_radius / 2f;
            //_locationY = -_radius / 2f;
        }

        #endregion

        /// <summary>
        /// Draws the current number using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the number.</param>
        public override void Draw(Graphics g)
        {
            if (font != null && numbers != null && currentIndex >= 0 && currentIndex < numbers.Length)
            {
                string number = numbers[currentIndex];

                if (number != null && number.Length > 0)
                {
                    if (brush == null)
                        brush = new SolidBrush(outlineColor);

                    SizeF numberSize = g.MeasureString(number, font);
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
                            float angle = -(30 * (currentIndex + 1));
                            originalMatrix = g.Transform;
                            g.TranslateTransform(0, positionOffset + numberSize.Height / 2f);
                            g.RotateTransform(angle);
                            break;
                    }


                    g.DrawString(number, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);

                    if (originalMatrix != null)
                        g.Transform = originalMatrix;
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
