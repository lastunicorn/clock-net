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
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the hour hand.
    /// </summary>
    public class HourHandShape : VectorialShapeBase
    {
        public const float HEIGHT = 24.2f;

        protected PointF[] path;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PointF[] Path
        {
            get { return path; }
            set
            {
                path = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        public override string Name
        {
            get { return "Default Hour Hand Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the hour hand.
        /// </summary>
        [DefaultValue(typeof(Color), "RoyalBlue")]
        [Description("The color used to draw the hour hand.")]
        public override Color FillColor
        {
            get { return base.FillColor; }
            set { base.FillColor = value; }
        }

        /// <summary>
        /// The length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hour hand. For a clock with the diameter of 100px.")]
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
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public HourHandShape()
            : this(Color.RoyalBlue, Color.RoyalBlue, VectorialDrawMode.Fill, HEIGHT)
        {
        }

        public HourHandShape(Color outlineColor, Color fillColor, VectorialDrawMode drawMode)
            : this(outlineColor, fillColor, drawMode, HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fill"></param>
        /// <param name="height"></param>
        public HourHandShape(Color outlineColor, Color fillColor, VectorialDrawMode drawMode, float height)
            : base(outlineColor, fillColor, drawMode)
        {
            path = new PointF[] { new PointF(0f, 6f), new PointF(-3f, 0f), new PointF(0F, -24.2f), new PointF(3f, 0f) };
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
