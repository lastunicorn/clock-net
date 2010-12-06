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
        public const float HEIGHT = 37.2f;

        protected PointF[] path;

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
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class with
        /// default values.
        /// </summary>
        public MinuteHandShape()
            : this(Color.LimeGreen, Color.LimeGreen, VectorialDrawMode.Fill, HEIGHT)
        {
        }

        public MinuteHandShape(Color outlineColor, Color fillColor, VectorialDrawMode drawMode)
            : this(outlineColor, fillColor, drawMode, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="color">The color of the hand.</param>
        /// <param name="fill">A value specifying if the background or the outline of the hand should be drawn.</param>
        /// <param name="height">The height of the hend for a clock of 300px.</param>
        public MinuteHandShape(Color outlineColor, Color fillColor, VectorialDrawMode drawMode, float height)
            : base(outlineColor, fillColor, drawMode)
        {
            path = new PointF[] { new PointF(0f, 4f), new PointF(-2f, 0f), new PointF(0f, -40f), new PointF(2f, 0f) };
            this.height = height;
            CalculateDimensions();
        }

        protected float pathHeight;

        private void CalculateDimensions()
        {
            float h = 0;

            foreach (PointF point in path)
            {
                if (point.Y < h)
                    h = point.Y;
            }

            pathHeight = h;
        }

        public override void Draw(Graphics g)
        {
            Matrix originalTransformMatrix = null;

            if (height > 0)
            {
                originalTransformMatrix = g.Transform;

                float scaleFactor = height / pathHeight;
                g.ScaleTransform(scaleFactor, scaleFactor);
            }

            if ((drawMode & VectorialDrawMode.Fill) == VectorialDrawMode.Fill)
            {
                CreateBrushIfNull();

                g.FillPolygon(brush, path);
            }

            if ((drawMode & VectorialDrawMode.Outline) == VectorialDrawMode.Outline)
            {
                CreatePenIfNull();

                g.DrawPolygon(pen, path);
            }

            if (originalTransformMatrix != null)
            {
                g.Transform = originalTransformMatrix;
            }
        }
    }
}
