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
using System.Drawing;
using System.Drawing.Drawing2D;
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Fancy
{
    public class BigNibHandShape : PathHandShape
    {
        protected float width;

        public float Width
        {
            get { return width; }
            set
            {
                width = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BigNibHandShape"/> class with
        /// default values.
        /// </summary>
        public BigNibHandShape()
            : this(Color.Empty, Color.Black, 45f, LINE_WIDTH)
        {
        }

        public BigNibHandShape(Color fillColor, float height)
            : this(Color.Empty, fillColor, height, LINE_WIDTH)
        {
        }

        public BigNibHandShape(Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(outlineColor, fillColor, lineWidth, height, CreatePath())
        {
            CalculateDimensions();
        }

        #endregion

        private static GraphicsPath CreatePath()
        {
            GraphicsPath path = new GraphicsPath();

            path.Reset();

            path.AddArc(new RectangleF(-12f, 43f, 24f, 24f), -60f, 300f);

            path.AddCurve(new PointF[] {
                //new PointF(-10f * (float)Math.Cos(Math.PI / 3f), 41f * (float)Math.Sin(Math.PI / 3f)),
                new PointF(-4f, 39f),
                new PointF(-8f, 35f)
            });

            path.AddCurve(new PointF[] {
                new PointF(-8f, 35f),
                new PointF(-4f, 29f),
                new PointF(-2f, 11f)
            });

            path.AddArc(new RectangleF(-12f, -13f, 24, 24), 90, 90);

            path.AddCurve(new PointF[] {
                //new PointF(-12f, -1f),
                new PointF(-12f, -7f),
                new PointF(-2f, -59f),
                new PointF(-10f, -119f)
            });

            path.AddCurve(new PointF[] {
                new PointF(-10f, -119f),
                new PointF(-5f, -124f),
                new PointF(-3f, -129f)
            });

            path.AddArc(new RectangleF(-15f, -159f, 30f, 30f), 90f, 90f);

            path.AddCurve(new PointF[] {
                //new PointF(-15f, -144f),
                new PointF(-14f, -151f),
                new PointF(-3f, -199f),
                new PointF(-1f, -249f)
            });

            path.AddLine(new PointF(-1f, -249f), new PointF(-1f, -280f));

            // <- center

            path.AddLine(new PointF(1f, -280f), new PointF(1f, -249f));

            path.AddCurve(new PointF[] {
                new PointF(1f, -249f),
                new PointF(3f, -199f),
                new PointF(14f, -151f)
                //new PointF(15f, -144f)
            });

            path.AddArc(new RectangleF(-15f, -159f, 30f, 30f), 0f, 90f);

            path.AddCurve(new PointF[] {
                new PointF(3f, -129f),
                new PointF(5f, -124f),
                new PointF(10f, -119f)
            });

            path.AddCurve(new PointF[] {
                new PointF(10f, -119f),
                new PointF(2f, -59f),
                new PointF(12f, -7f)
                //new PointF(12f, -1f)
            });

            path.AddArc(new RectangleF(-12f, -13f, 24f, 24f), 0f, 90f);

            path.AddCurve(new PointF[] {
                new PointF(2f, 11f),
                new PointF(4f, 29f),
                new PointF(8f, 35f)
            });

            path.AddCurve(new PointF[] {
                new PointF(8f, 35f),
                new PointF(4f, 39f),
                new PointF(10f * (float)Math.Cos(Math.PI / 3f), 41f * (float)Math.Sin(Math.PI / 3f))
            });

            return path;
        }

        protected bool keepProportions = true;

        public override void Draw(Graphics g)
        {
            Matrix initialMatrix = g.Transform;

            if (keepProportions && height > 0)
            {
                float scaleFactorY = height / 280f;
                g.ScaleTransform(scaleFactorY, scaleFactorY);
            }
            else
            {
                float scaleFactorY = height > 0 ? height / 280f : 1f;
                float scaleFactorX = width > 0 ? width / 30f : 1f;
                g.ScaleTransform(scaleFactorX, scaleFactorY);
            }
            base.Draw(g);

            g.Transform = initialMatrix;
        }
    }
}
