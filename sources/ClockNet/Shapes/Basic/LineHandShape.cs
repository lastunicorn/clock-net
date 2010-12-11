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

namespace DustInTheWind.Clock.Shapes.Basic
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class LineHandShape : LineShape, IHandShape
    {
        /// <summary>
        /// The default value of the hand length from the pin to the top.
        /// </summary>
        public const float HEIGHT = 42.5f;

        /// <summary>
        /// The default value of the hand width.
        /// </summary>
        public new const float LINE_WIDTH = 0.3f;

        /// <summary>
        /// The default value of the hand's tail length.
        /// </summary>
        public const float TAIL_LENGTH = 4.5f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Line Hand Shape"; }
        }


        [DefaultValue(LINE_WIDTH)]
        public override float LineWidth
        {
            get { return base.LineWidth; }
            set { base.LineWidth = value; }
        }

        [DefaultValue(typeof(Color), "Red")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }

        [DefaultValue(typeof(Color), "Empty")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// The length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hand. For a clock with the diameter of 100px.")]
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

        /// <summary>
        /// The length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        private float tailLength;

        /// <summary>
        /// Gets or set the length of the hand's tail that is drawn on the other side of the pin.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
        [Description("The length of the hand's tail that is drawn on the other side of the pin.")]
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
        /// Initializes a new instance of the <see cref="LineHandShape"/> class with
        /// default values.
        /// </summary>
        public LineHandShape()
            : this(Color.Black, HEIGHT, LINE_WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHandShape"/> class.
        /// </summary>
        public LineHandShape(Color color)
            : this(color, HEIGHT, LINE_WIDTH, TAIL_LENGTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineHandShape"/> class.
        /// </summary>
        public LineHandShape(Color color, float height, float width, float tailLength)
            : base(color, width)
        {
            this.height = height;
            this.lineWidth = width;
            this.tailLength = tailLength;

            CalculateDimensions();
        }

        #endregion


        private void CalculateDimensions()
        {
            startPoint = new PointF(0f, tailLength);
            endPoint = new PointF(0f, -height);
        }

        ///// <summary>
        ///// Draws the hand hand using the provided <see cref="Graphics"/> object.
        ///// </summary>
        ///// <param name="g">The <see cref="Graphics"/> on which to draw the hand.</param>
        ///// <remarks>
        ///// The hand is drawn in vertical position from the origin of the coordinate system.
        ///// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        ///// </remarks>
        //public override void Draw(Graphics g)
        //{
        //    if (!outlineColor.IsEmpty)
        //    {
        //        CreatePenIfNull();

        //        g.DrawLine(pen, startPoint, endPoint);
        //    }
        //}
    }
}
