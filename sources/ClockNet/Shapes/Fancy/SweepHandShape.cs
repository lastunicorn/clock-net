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

namespace DustInTheWind.Clock.Shapes.Fancy
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class SweepHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 42.5f;

        public override string Name
        {
            get { return "Default Sweep Hand Shape"; }
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

        public SweepHandShape(Color outlineColor, Color fillColor, float height)
            : base(outlineColor, fillColor, VectorialDrawMode.Outline)
        {
            this.height = height;
            CalculateDimensions();
        }

        protected float pathHeight = 127.5f;

        private void CalculateDimensions()
        {
            //float h = 0;

            //foreach (PointF point in path)
            //{
            //    if (point.Y < h)
            //        h = point.Y;
            //}

            //pathHeight = h;
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

            if ((drawMode & VectorialDrawMode.Outline) == VectorialDrawMode.Outline)
            {
                CreatePenIfNull();

                //g.DrawLines(pen, path);

                g.DrawLine(pen, new PointF(0f, 14.16f), new PointF(0f, -80f));
                g.DrawEllipse(pen, -10, -100, 20, 20);
                g.DrawLine(pen, new PointF(0f, -100f), new PointF(0f, -127.5f));
            }

            if (originalTransformMatrix != null)
            {
                g.Transform = originalTransformMatrix;
            }
        }
    }
}
