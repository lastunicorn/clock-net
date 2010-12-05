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
    public class HourHandShape : VectorialClockHandBase
    {
        protected PointF[] path;

        public PointF[] Path
        {
            get { return path; }
            set
            {
                path = value;
                OnChanged(EventArgs.Empty);
            }
        }

        protected float pathHeight;

        public override string Name
        {
            get { return "Default Hour Hand Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the hour hand.
        /// </summary>
        [DefaultValue(typeof(Color), "RoyalBlue")]
        [Description("The color used to draw the hour hand.")]
        public override Color Color
        {
            get { return base.Color; }
            set { base.Color = value; }
        }

        /// <summary>
        /// Gets or sets the length of the hour hand. For a clock with the diameter of 300px.
        /// </summary>
        [DefaultValue(82.5f)]
        [Description("The length of the hour hand. For a clock with the diameter of 300px.")]
        public override float Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class with
        /// default values.
        /// </summary>
        public HourHandShape()
            : this(Color.RoyalBlue, true, 82.5f)
        {
        }

        public HourHandShape(Color color, bool fill)
            : this(color, fill, 82.5f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourHandShape"/> class.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fill"></param>
        /// <param name="height"></param>
        public HourHandShape(Color color, bool fill, float height)
            : base(color, fill, height)
        {
            path = new PointF[] { new PointF(0f, 12f), new PointF(-6f, 0f), new PointF(0F, -82.5f), new PointF(6f, 0f) };
            pathHeight = 82.5f;
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

            if (fill)
            {
                if (brush == null)
                    brush = new SolidBrush(color);

                g.FillPolygon(brush, path);
            }
            else
            {
                if (pen == null)
                    pen = new Pen(color);

                g.DrawPolygon(pen, path);
            }

            if (originalTransformMatrix != null)
            {
                g.Transform = originalTransformMatrix;
            }
        }
    }
}
