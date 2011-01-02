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
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text;

namespace DustInTheWind.Clock.Shapes.Default
{
    public class DigitalHandShape : VectorialHandShapeBase
    {
        public static Font FONT = new Font("Arial", 3, FontStyle.Regular, GraphicsUnit.Point);

        /// <summary>
        /// The default vertical location of the text.
        /// </summary>
        public const float VERTICAL_LOCATION = 12f;


        /// <summary>
        /// Formats the text displayed by the current instance.
        /// </summary>
        protected StringFormat stringFormat;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Digital Text Shape"; }
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
                OnChanged(EventArgs.Empty);
            }
        }


        private float verticalLocation;

        [Category("Layout")]
        [DefaultValue(VERTICAL_LOCATION)]
        public float VerticalLocation
        {
            get { return verticalLocation; }
            set
            {
                verticalLocation = value;
                OnChanged(EventArgs.Empty);
            }

        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalHandShape"/> class with
        /// default values.
        /// </summary>
        public DigitalHandShape()
            : this(FILL_COLOR, FONT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalHandShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the text.</param>
        public DigitalHandShape(Color color)
            : this(color, FONT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalHandShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the text.</param>
        /// <param name="font">The font used to draw the text.</param>
        public DigitalHandShape(Color color, Font font)
            : base(OUTLINE_COLOR, color)
        {
            this.font = font;
            this.verticalLocation = VERTICAL_LOCATION;

            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;
        }

        #endregion


        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && font != null && !fillColor.IsEmpty;
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
            CreateBrushIfNull();

            StringBuilder sb = new StringBuilder();
            string prepend = string.Empty;

            string format = "HH:mm:ss";

            //if ((componentToDisplay & TimeComponent.Hour) == TimeComponent.Hour)
            //{
            //    sb.Append(prepend);
            //    sb.Append("HH");
            //    prepend = ":";
            //}
            //if ((componentToDisplay & TimeComponent.Minute) == TimeComponent.Minute)
            //{
            //    sb.Append(prepend);
            //    sb.Append("mm");
            //    prepend = ":";
            //}
            //if ((componentToDisplay & TimeComponent.Second) == TimeComponent.Second)
            //{
            //    sb.Append(prepend);
            //    sb.Append("ss");
            //    prepend = ":";
            //}

            string text = new DateTime(time.Ticks).ToString(format);

            if (text.Length > 0)
            {
                SizeF textSize = g.MeasureString(text, font);
                PointF textLocation = new PointF(-textSize.Width / 2F, verticalLocation);
                RectangleF textRectangle = new RectangleF(textLocation, textSize);

                g.DrawString(text, font, brush, textRectangle, stringFormat);
            }
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
