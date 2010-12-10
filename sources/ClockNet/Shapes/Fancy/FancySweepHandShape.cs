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
    //    /// <summary>
    //    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    //    /// </summary>
    //    public class SweepHandShape : VectorialShapeBase
    //    {
    //        public const float HEIGHT = 42.5f;
    //        public const float CIRCLE_RADIUS = 3.5f;
    //        public const float CIRCLE_OFFSET = 12f;
    //        public const float TAIL_LENGTH = 5f;

    //        GraphicsPath path;

    //        public override string Name
    //        {
    //            get { return "Default Sweep Hand Shape"; }
    //        }

    //        /// <summary>
    //        /// The length of the sweep hand. For a clock with the diameter of 100px.
    //        /// </summary>
    //        protected float height;

    //        /// <summary>
    //        /// Gets or sets the length of the sweep hand. For a clock with the diameter of 100px.
    //        /// </summary>
    //        [Category("Appearance")]
    //        [DefaultValue(HEIGHT)]
    //        [Description("The length of the sweep hand. For a clock with the diameter of 100px.")]
    //        public virtual float Height
    //        {
    //            get { return height; }
    //            set
    //            {
    //                height = value;
    //                CalculateDimensions();
    //                OnChanged(EventArgs.Empty);
    //            }
    //        }

    //        protected float circleRadius = CIRCLE_RADIUS;

    //        [Category("Appearance")]
    //        [DefaultValue(CIRCLE_RADIUS)]
    //        public virtual float CircleRadius
    //        {
    //            get { return circleRadius; }
    //            set
    //            {
    //                circleRadius = value;
    //                CalculateDimensions();
    //                OnChanged(EventArgs.Empty);
    //            }
    //        }

    //        protected float circleOffset = CIRCLE_OFFSET;

    //        [Category("Appearance")]
    //        [DefaultValue(CIRCLE_OFFSET)]
    //        public virtual float CircleOffset
    //        {
    //            get { return circleOffset; }
    //            set
    //            {
    //                circleOffset = value;
    //                CalculateDimensions();
    //                OnChanged(EventArgs.Empty);
    //            }
    //        }

    //        private float tailLength = TAIL_LENGTH;

    //        [Category("Appearance")]
    //        [DefaultValue(TAIL_LENGTH)]
    //        public virtual float TailLength
    //        {
    //            get { return tailLength; }
    //            set
    //            {
    //                tailLength = value;
    //                CalculateDimensions();
    //                OnChanged(EventArgs.Empty);
    //            }
    //        }

    //        /// <summary>
    //        /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
    //        /// default values.
    //        /// </summary>
    //        public SweepHandShape()
    //            : this(Color.Red, Color.Empty, HEIGHT)
    //        {
    //        }

    //        public SweepHandShape(Color outlineColor, Color fillColor, float height)
    //            : base(outlineColor, fillColor)
    //        {
    //            this.height = height;
    //            this.lineWidth = 0.1f;
    //            this.path = new GraphicsPath();
    //            CalculateDimensions();
    //        }

    //        private void CalculateDimensions()
    //        {
    //            path.Reset();

    //            float circleCenterX = -height + circleOffset;

    //            path.AddLine(new PointF(0f, tailLength), new PointF(0f, circleCenterX + circleRadius));
    //            path.AddEllipse(-circleRadius, circleCenterX - circleRadius, circleRadius * 2f, circleRadius * 2f);
    //            path.AddLine(new PointF(0f, circleCenterX - circleRadius), new PointF(0f, -height));
    //        }

    //        public override void Draw(Graphics g)
    //        {
    //            if (!fillColor.IsEmpty)
    //            {
    //                CreateBrushIfNull();

    //                g.FillPath(brush, path);

    //                //path.AddLine(new PointF(0f, 4.72f), new PointF(0f, -27f));
    //                //g.DrawEllipse(pen, -3.33f, -33.33, 7, 7);
    //                //g.DrawLine(pen, new PointF(0f, -33.33f), new PointF(0f, -42.5f));

    //                //g.DrawLine(pen, new PointF(0f, 14.16f), new PointF(0f, -80f));
    //                //g.DrawEllipse(pen, -10, -100, 20, 20);
    //                //g.DrawLine(pen, new PointF(0f, -100f), new PointF(0f, -127.5f));
    //            }

    //            if (!outlineColor.IsEmpty)
    //            {
    //                CreatePenIfNull();

    //                g.DrawPath(pen, path);

    //                //path.AddLine(new PointF(0f, 4.72f), new PointF(0f, -27f));
    //                //g.DrawEllipse(pen, -3.33f, -33.33, 7, 7);
    //                //g.DrawLine(pen, new PointF(0f, -33.33f), new PointF(0f, -42.5f));

    //                //g.DrawLine(pen, new PointF(0f, 14.16f), new PointF(0f, -80f));
    //                //g.DrawEllipse(pen, -10, -100, 20, 20);
    //                //g.DrawLine(pen, new PointF(0f, -100f), new PointF(0f, -127.5f));
    //            }
    //        }

    //        protected override void Dispose(bool disposing)
    //        {
    //            if (disposing)
    //            {
    //                if (path != null)
    //                    path.Dispose();
    //            }

    //            base.Dispose(disposing);
    //        }
    //    }


    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class FancySweepHandShape : PathShape
    {
        public const float HEIGHT = 42.5f;
        public const float CIRCLE_RADIUS = 3.5f;
        public const float CIRCLE_OFFSET = 12f;
        public const float TAIL_LENGTH = 5f;
        public const float LINE_WIDTH = 0.1f;

       public override string Name
        {
            get { return "Fancy Sweep Hand Shape"; }
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
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        protected float circleRadius = CIRCLE_RADIUS;

        [Category("Appearance")]
        [DefaultValue(CIRCLE_RADIUS)]
        public virtual float CircleRadius
        {
            get { return circleRadius; }
            set
            {
                circleRadius = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        protected float circleOffset = CIRCLE_OFFSET;

        [Category("Appearance")]
        [DefaultValue(CIRCLE_OFFSET)]
        public virtual float CircleOffset
        {
            get { return circleOffset; }
            set
            {
                circleOffset = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        private float tailLength = TAIL_LENGTH;

        [Category("Appearance")]
        [DefaultValue(TAIL_LENGTH)]
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
        /// Initializes a new instance of the <see cref="FancySweepHandShape"/> class with
        /// default values.
        /// </summary>
        public FancySweepHandShape()
            : this(Color.Red, Color.Empty, HEIGHT)
        {
        }

        public FancySweepHandShape(Color outlineColor, Color fillColor, float height)
            : base(outlineColor, fillColor, LINE_WIDTH, new GraphicsPath())
        {
            this.height = height;
            CalculateDimensions();
        }

        #endregion


        private void CalculateDimensions()
        {
            path.Reset();

            float circleCenterX = -height + circleOffset;

            path.AddLine(new PointF(0f, tailLength), new PointF(0f, circleCenterX + circleRadius));
            path.AddEllipse(-circleRadius, circleCenterX - circleRadius, circleRadius * 2f, circleRadius * 2f);
            path.AddLine(new PointF(0f, circleCenterX - circleRadius), new PointF(0f, -height));
        }

        //public override void Draw(Graphics g)
        //{
        //    if (!fillColor.IsEmpty)
        //    {
        //        CreateBrushIfNull();

        //        g.FillPath(brush, path);

        //        //path.AddLine(new PointF(0f, 4.72f), new PointF(0f, -27f));
        //        //g.DrawEllipse(pen, -3.33f, -33.33, 7, 7);
        //        //g.DrawLine(pen, new PointF(0f, -33.33f), new PointF(0f, -42.5f));

        //        //g.DrawLine(pen, new PointF(0f, 14.16f), new PointF(0f, -80f));
        //        //g.DrawEllipse(pen, -10, -100, 20, 20);
        //        //g.DrawLine(pen, new PointF(0f, -100f), new PointF(0f, -127.5f));
        //    }

        //    if (!outlineColor.IsEmpty)
        //    {
        //        CreatePenIfNull();

        //        g.DrawPath(pen, path);

        //        //path.AddLine(new PointF(0f, 4.72f), new PointF(0f, -27f));
        //        //g.DrawEllipse(pen, -3.33f, -33.33, 7, 7);
        //        //g.DrawLine(pen, new PointF(0f, -33.33f), new PointF(0f, -42.5f));

        //        //g.DrawLine(pen, new PointF(0f, 14.16f), new PointF(0f, -80f));
        //        //g.DrawEllipse(pen, -10, -100, 20, 20);
        //        //g.DrawLine(pen, new PointF(0f, -100f), new PointF(0f, -127.5f));
        //    }
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (path != null)
        //            path.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}
    }
}
