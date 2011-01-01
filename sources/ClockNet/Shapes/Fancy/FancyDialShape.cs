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
using TTRider.UI;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the background of the dial.
    /// </summary>
    public class FancyDialShape : VectorialGroundShapeBase
    {
        /// <summary>
        /// The default value of the outer rim width.
        /// </summary>
        public const float OUTER_RIM_WIDTH = 5f;

        /// <summary>
        /// The default value of the inner rim width.
        /// </summary>
        public const float INNER_RIM_WIDTH = 1f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Fancy Dial Shape"; }
        }


        ///// <summary>
        ///// Gets or sets the color used to draw the dial's background.
        ///// </summary>
        //[DefaultValue(typeof(Color), "Empty")]
        //[Description("The color used to draw the dial's background.")]
        //public override Color OutlineColor
        //{
        //    get { return base.OutlineColor; }
        //    set { base.OutlineColor = value; }
        //}


        ///// <summary>
        ///// Gets or sets the color used to draw the border of the dial.
        ///// </summary>
        //[DefaultValue(typeof(Color), "Empty")]
        //[Description("The color used to draw the border of the dial.")]
        //public override Color FillColor
        //{
        //    get { return base.FillColor; }
        //    set { base.FillColor = value; }
        //}


        /// <summary>
        /// The width of the outer-most rim.
        /// </summary>
        private float outerRimWidth;

        /// <summary>
        /// Gets or sets the width of the outer-most rim.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(OUTER_RIM_WIDTH)]
        [Description("The width of the outer-most rim.")]
        public float OuterRimWidth
        {
            get { return outerRimWidth; }
            set
            {
                outerRimWidth = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The width of the second rim.
        /// </summary>
        private float innerRimWidth;

        /// <summary>
        /// Gets or sets the width of the second rim.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(INNER_RIM_WIDTH)]
        [Description("The width of the second rim.")]
        public float InnerRimWidth
        {
            get { return innerRimWidth; }
            set
            {
                innerRimWidth = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FancyDialShape"/> class with
        /// default values.
        /// </summary>
        public FancyDialShape()
            : this(FILL_COLOR, OUTER_RIM_WIDTH, INNER_RIM_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancyDialShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        public FancyDialShape(Color fillColor)
            : this(fillColor, OUTER_RIM_WIDTH, INNER_RIM_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FancyDialShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        /// <param name="innerRimWidth">The width of the outer-most rim.</param>
        /// <param name="outerRimWidth">The width of the second rim.</param>
        public FancyDialShape(Color fillColor, float outerRimWidth, float innerRimWidth)
            : base(OUTLINE_COLOR, fillColor, LINE_WIDTH)
        {
            this.outerRimWidth = outerRimWidth;
            this.innerRimWidth = innerRimWidth;

            CalculateDimensions();
        }

        #endregion


        /// <summary>
        /// Creates a new <see cref="Pen"/> object if it does not exist already.
        /// The pen will have an Inset alignment.
        /// </summary>
        protected override void CreatePenIfNull()
        {
            if (pen == null)
            {
                pen = new Pen(outlineColor, lineWidth);
                pen.Alignment = PenAlignment.Inset;
            }
        }

        protected override void CreateBrushIfNull()
        {
            if (brush == null)
            {
                outerRimBrush = new LinearGradientBrush(outerRimRectangle, HSBColor.ShiftBrighness(fillColor, 100f), HSBColor.ShiftBrighness(fillColor, -100f), 45f);
                innerRimBrush = new LinearGradientBrush(innerRimRectangle, HSBColor.ShiftBrighness(fillColor, -100f), HSBColor.ShiftBrighness(fillColor, 100f), 45f);
                Color faceColor = HSBColor.ShiftSaturation(fillColor, 50f);
                brush = new LinearGradientBrush(faceRectangle, HSBColor.ShiftBrighness(faceColor, 100f), HSBColor.ShiftBrighness(faceColor, -150f), 45f);
            }
        }

        private LinearGradientBrush outerRimBrush;
        private LinearGradientBrush innerRimBrush;

        private RectangleF outerRimRectangle;
        private RectangleF innerRimRectangle;
        private RectangleF faceRectangle;


        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateDimensions()
        {
            outerRimRectangle = new RectangleF(-50f, -50f, 100, 100);
            innerRimRectangle = RectangleF.Inflate(outerRimRectangle, -outerRimWidth, -outerRimWidth);
            faceRectangle = RectangleF.Inflate(innerRimRectangle, -innerRimWidth, -innerRimWidth);
        }


        /// <summary>
        /// Decides if the Shape should be drawn.
        /// If this method returns false, the <see cref="IShape.Draw"/> method returns immediatelly,
        /// without doing anythig.
        /// </summary>
        /// <returns>true if the <see cref="IShape.Draw"/> method is allowed to be executed; false otherwise.</returns>
        protected override bool AllowToDraw()
        {
            return base.AllowToDraw() && !fillColor.IsEmpty;
        }

        /// <summary>
        /// Draws the dial's background using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dial.</param>
        protected override void DrawInternal(Graphics g)
        {
            CreateBrushIfNull();

            //g.FillEllipse(brush, locationX, locationY, diameter, diameter);
            g.FillEllipse(outerRimBrush, outerRimRectangle);
            g.FillEllipse(innerRimBrush, innerRimRectangle);
            g.FillEllipse(brush, faceRectangle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the current instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">Speifies if the managed resources should be disposed, too.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (outerRimBrush != null)
                    outerRimBrush.Dispose();

                if (innerRimBrush != null)
                    innerRimBrush.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
