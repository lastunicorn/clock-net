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
using DustInTheWind.ClockNet.Shapes.Basic;

namespace DustInTheWind.ClockNet.Shapes.Advanced
{
    /// <summary>
    /// Draws a fancy clock hand that resambles to a nib.
    /// </summary>
    public class NibHandShape : PathHandShape
    {
        /// <summary>
        /// The default name for the Shape.
        /// </summary>
        public new const string NAME = "Nib Hand Shape";

        /// <summary>
        /// The default length of the width of the hand.
        /// </summary>
        public const float WIDTH = 5f;


        /// <summary>
        /// The width of the slot carved inside the disk.
        /// </summary>
        protected float width;

        /// <summary>
        /// Gets or sets the width of the slot carved inside the disk.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(WIDTH)]
        [Description("The width of the slot carved inside the disk.")]
        public virtual float Width
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
        /// Initializes a new instance of the <see cref="NibHandShape"/> class with
        /// default values.
        /// </summary>
        public NibHandShape()
            : this(OUTLINE_COLOR, FILL_COLOR, HEIGHT, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NibHandShape"/> class.
        /// </summary>
        /// <param name="fillColor">The color used to fill the opaqu disk.</param>
        /// <param name="height">The length of the hour hand.</param>
        public NibHandShape(Color fillColor, float height)
            : this(OUTLINE_COLOR, fillColor, height, LINE_WIDTH)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NibHandShape"/> class.
        /// </summary>
        /// <param name="outlineColor">The color used to draw the outline of the hand.</param>
        /// <param name="fillColor">The color used to fill the opaqu disk.</param>
        /// <param name="height">The length of the hour hand.</param>
        /// <param name="lineWidth">The width of the outline.</param>
        public NibHandShape(Color outlineColor, Color fillColor, float height, float lineWidth)
            : base(new GraphicsPath(), outlineColor, fillColor, height, lineWidth)
        {
            this.Name = NAME;
            CalculateDimensions();
        }

        #endregion


        /// <summary>
        /// Calculates additional values that are necessary by the drawing process, but that remain constant for every
        /// successive draw if no parameter is changed.
        /// This method should be called every time when is set a property that changes the physical dimensions.
        /// </summary>
        protected override void CalculateDimensions()
        {
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
        }

        /// <summary>
        /// Specifies if the hand should keep its proportions when its length is changed.
        /// </summary>
        protected bool keepProportions = true;


        /// <summary>
        /// Draws the hour hand using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the dot.</param>
        /// <remarks>
        /// The hand is drawn in vertical position from the origin of the coordinate system.
        /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
        /// </remarks>
        protected override void DrawInternal(Graphics g)
        {
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

            base.DrawInternal(g);
        }

        public override bool HitTest(PointF point)
        {
            PointF clickLocation;
            
            using (Matrix m = new Matrix())
            {
                if (keepProportions && height > 0)
                {
                    float scaleFactorY = height / 280f;
                    m.Scale(1 / scaleFactorY, 1 / scaleFactorY);
                }
                else
                {
                    float scaleFactorY = height > 0 ? height / 280f : 1f;
                    float scaleFactorX = width > 0 ? width / 30f : 1f;
                    m.Scale(1 / scaleFactorX, 1 / scaleFactorY);
                }

                PointF[] points = new PointF[] { point };
                m.TransformPoints(points);
                clickLocation = points[0];
            }

            return base.HitTest(clickLocation);
        }
    }
}
