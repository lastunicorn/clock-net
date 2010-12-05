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

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the minute hand.
    /// </summary>
    public class MinuteHandShape : VectorialClockHandBase
    {
        protected PointF[] path;
        protected float pathHeight;

        public override string Name
        {
            get { return "Default Minute Hand Shape"; }
        }

        /// <summary>
        /// Gets or sets the color used to draw the minute hand.
        /// </summary>
        [DefaultValue(typeof(Color), "LimeGreen")]
        [Description("The color used to draw the minute hand.")]
        public override Color Color
        {
            get { return base.Color; }
            set { base.Color = value; }
        }

        /// <summary>
        /// Gets or sets the length of the minute hand. For a clock with the diameter of 300px.
        /// </summary>
        [DefaultValue(112.5f)]
        [Description("The length of the minute hand. For a clock with the diameter of 300px.")]
        public override float Height
        {
            get { return base.Height; }
            set { base.Height = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class with
        /// default values.
        /// </summary>
        public MinuteHandShape()
            : this(Color.LimeGreen, true, 112.5f)
        {
        }

        public MinuteHandShape(Color color, bool fill)
            : this(color, fill, 112.5f)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandShape"/> class.
        /// </summary>
        /// <param name="color">The color of the hand.</param>
        /// <param name="fill">A value specifying if the background or the outline of the hand should be drawn.</param>
        /// <param name="height">The height of the hend for a clock of 300px.</param>
        public MinuteHandShape(Color color, bool fill, float height)
            : base(color, fill, height)
        {
            //path = new PointF[] { new PointF(0f, 7.98f), new PointF(-3.99f, 0f), new PointF(0f, -112.5f), new PointF(3.99f, 0f) };
            path = new PointF[] { new PointF(0f, 7.98f), new PointF(-3.99f, 0f), new PointF(0f, -120f), new PointF(3.99f, 0f) };
            pathHeight = 112.5f;
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
