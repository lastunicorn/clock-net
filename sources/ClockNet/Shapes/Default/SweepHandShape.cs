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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class SweepHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 42.5f;
        public const float LINE_WIDTH = 0.3f;

        protected PointF[] path;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
        /// default values.
        /// </summary>
        public SweepHandShape()
            : this(Color.Red, Color.Red, HEIGHT)
        {
        }

        public SweepHandShape(Color outlineColor, Color fillColor)
            : this(outlineColor, fillColor, HEIGHT)
        {
        }

        public SweepHandShape(Color outlineColor, Color fillColor, float height)
            : base(outlineColor, fillColor, VectorialDrawMode.Fill)
        {
            path = new PointF[] { new PointF(0f, 4.72f), new PointF(0f, -42.5f) };
            this.height = height;
            this.lineWidth = LINE_WIDTH;
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
