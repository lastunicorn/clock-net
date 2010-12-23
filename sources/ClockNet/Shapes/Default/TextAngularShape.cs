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
                if (value == null)
                    throw new ArgumentNullException("value");

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
        //[DefaultValue(typeof(Font), "Arial; 7pt")]
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
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class with
        /// default values.
        /// </summary>
        public TextAngularShape()
            : this(Color.Black, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAngularShape"/> class.
        /// </summary>
        public TextAngularShape(Color color)
            : this(color, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), POSITION_OFFSET)
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
            this.font = font == null ? new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point) : font;
            this.positionOffset = positionOffset;

            numbersStringFormat = new StringFormat(StringFormatFlags.NoWrap);
            numbersStringFormat.Alignment = StringAlignment.Center;
            numbersStringFormat.LineAlignment = StringAlignment.Center;
        }

        #endregion

        protected override void DrawInternal(Graphics g)
        {
            if (font != null && numbers != null && !fillColor.IsEmpty)
            {
                if (index > 0 && index <= numbers.Length)
                {
                    string number = numbers[index - 1];

                    if (number != null && number.Length > 0)
                    {
                        CreateBrushIfNull();

                        SizeF numberSize = g.MeasureString(number, font, int.MaxValue, numbersStringFormat);
                        PointF numberPosition = new PointF(-numberSize.Width / 2f, -numberSize.Height / 2f);

                        Matrix originalMatrix;

                        switch (orientation)
                        {
                            case TextAngularOrientation.FaceCenter:
                                originalMatrix = g.Transform;
                                g.TranslateTransform(0, numberSize.Height / 2f);
                                break;

                            case TextAngularOrientation.FaceOut:
                                originalMatrix = g.Transform;
                                g.TranslateTransform(0, numberSize.Height / 2f);
                                g.RotateTransform(180);
                                break;

                            default:
                            case TextAngularOrientation.Normal:
                                float ang = -(this.angle * index);
                                originalMatrix = g.Transform;
                                g.TranslateTransform(0, numberSize.Height / 2f);
                                g.RotateTransform(ang);
                                break;
                        }

                        g.DrawString(number, font, brush, new RectangleF(numberPosition, numberSize), numbersStringFormat);

                        g.Transform = originalMatrix;
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
