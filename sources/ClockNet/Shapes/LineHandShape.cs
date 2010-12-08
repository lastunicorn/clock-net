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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class LineHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 42.5f;
        public const float LINE_WIDTH = 0.3f;

        protected PointF startPoint;
        protected PointF endPoint;

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Sweep Hand Shape"; }
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

        //[DefaultValue(typeof(VectorialDrawMode), "Outline")]
        //public override VectorialDrawMode DrawMode
        //{
        //    get { return base.DrawMode; }
        //    set { base.DrawMode = value; }
        //}

        /// <summary>
        /// The length of the sweep hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the sweep hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the sweep hand. For a clock with the diameter of 100px.")]
        public virtual float Height
        {
            get { return height; }
            set
            {
                height = value;
                OnChanged(EventArgs.Empty);
            }
        }

        private float tailLength;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
        /// default values.
        /// </summary>
        public LineHandShape()
            : this(Color.Black, HEIGHT, 1, 4.5f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the sweep hand.</param>
        /// <param name="fillColor">The color used to draw the background of the sweep hand.</param>
        public LineHandShape(Color color)
            : this(color, HEIGHT, LINE_WIDTH, 4.5f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the sweep hand.</param>
        /// <param name="fillColor">The color used to draw the background of the sweep hand.</param>
        /// <param name="height">The length of the sweep hand for a clock with the diameter of 100px.</param>
        public LineHandShape(Color color, float height, float width, float tailLength)
            : base(color, Color.Empty)
        {
            this.height = height;
            this.lineWidth = width;
            this.tailLength = tailLength;

            CalculateDimensions();
        }

        #endregion

        //protected float pathHeight;

        private void CalculateDimensions()
        {
            startPoint = new PointF(0f, tailLength);
            endPoint = new PointF(0f, -height);
            //float h = 0;

            //foreach (PointF point in path)
            //{
            //    if (point.Y < h)
            //        h = point.Y;
            //}

            //pathHeight = Math.Abs(h);
        }

        /// <summary>
        /// Draws the sweep hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        public override void Draw(Graphics g)
        {
            if (!outlineColor.IsEmpty)
            {
                CreatePenIfNull();

                g.DrawLine(pen, startPoint, endPoint);
            }
        }
    }
}
