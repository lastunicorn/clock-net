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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the minute hand.
    /// </summary>
    public class MinuteHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 37f;
        public const float TAIL_LENGTH = 4f;

        protected PointF[] path;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Minute Hand Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the minute hand.
        /// </summary>
        [DefaultValue(typeof(Color), "LimeGreen")]
        [Description("The color used to draw the minute hand.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// The length of the minute hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the minute hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour minute. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        private float tailLength = TAIL_LENGTH;

        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        public virtual float TailLength
        {
            get { return tailLength; }
            set
            {
                tailLength = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class with
        /// default values.
        /// </summary>
        public MinuteHandShape()
            : this(Color.Empty, Color.LimeGreen, HEIGHT)
        {
        }

        public MinuteHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="color">The color of the hand.</param>
        /// <param name="fill">A value specifying if the background or the outline of the hand should be drawn.</param>
        /// <param name="height">The height of the hend for a clock of 300px.</param>
        public MinuteHandShape(Color outlineColor, Color fillColor, float height)
            : base(outlineColor, fillColor)
        {
            //path = new PointF[] { new PointF(0f, 4f), new PointF(-2f, 0f), new PointF(0f, -40f), new PointF(2f, 0f) };
            this.height = height;
            CalculateDimensions();
        }

        #endregion


        private void CalculateDimensions()
        {
            path = new PointF[] { new PointF(0f, tailLength), new PointF(-2f, 0f), new PointF(0f, -height), new PointF(2f, 0f) };
        }

        /// <summary>
        /// Draws the minute hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        public override void Draw(Graphics g)
        {
            if (!fillColor.IsEmpty)
            {
                CreateBrushIfNull();

                g.FillPolygon(brush, path);
            }

            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawPolygon(pen, path);
            }
        }
    }
}
