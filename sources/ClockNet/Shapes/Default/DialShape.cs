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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the background of the dial.
    /// </summary>
    public class DialShape : VectorialShapeBase
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Dial Shape"; }
        }
        

        protected float radius;

        [Category("Appearance")]
        public virtual float Radius
        {
            get { return radius; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The radius can not be a negative value.");

                radius = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class with
        /// default values.
        /// </summary>
        public DialShape()
            : this(Color.Empty, Color.Black, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        public DialShape(Color fillColor)
            : this(Color.Empty, fillColor, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the dial.</param>
        /// <param name="fillColor">The color used to draw the dial's background.</param>
        public DialShape(Color outlineColor, Color fillColor, float lineWidth)
            : base(outlineColor, fillColor, lineWidth)
        {
            this.radius = 50;

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

        //private float locationX = -50;
        //private float locationY = -50;
        //private float diameter = 100;
        private RectangleF rect;

        protected override void CalculateDimensions()
        {
            rect = new RectangleF(-radius, -radius, radius * 2, radius * 2);
        }


        /// <summary>
        /// Draws the dial's background using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dial.</param>
        protected override void DrawInternal(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillEllipse(brush, rect);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawEllipse(pen, rect);
            }
        }
    }
}
