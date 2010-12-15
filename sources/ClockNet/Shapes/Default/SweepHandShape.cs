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

using System.Drawing;
using DustInTheWind.Clock.Shapes.Basic;

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    /// </summary>
    public class SweepHandShape : LineHandShape
    {
        public const string NAME = "Default Sweep Hand Shape";

        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return NAME; }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
        /// default values.
        /// </summary>
        public SweepHandShape()
            : base(Color.Red)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        public SweepHandShape(Color color)
            : base(color)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
        /// </summary>
        public SweepHandShape(Color color, float height, float width, float tailLength)
            : base(color, height, width, tailLength)
        {
        }

        #endregion


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
            base.Draw(g);
        }
    }


    ///// <summary>
    ///// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the sweep hand.
    ///// </summary>
    //public class SweepHandShape : VectorialShapeBase
    //{
    //    /// <summary>
    //    /// The default value of the hand length from the pin to the top.
    //    /// </summary>
    //    public const float HEIGHT = 42.5f;

    //    /// <summary>
    //    /// The default value of the hand width.
    //    /// </summary>
    //    public new const float LINE_WIDTH = 0.3f;

    //    protected PointF[] path;

    //    /// <summary>
    //    /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
    //    /// </summary>
    //    public override string Name
    //    {
    //        get { return "Default Sweep Hand Shape"; }
    //    }

    //    [DefaultValue(LINE_WIDTH)]
    //    public override float LineWidth
    //    {
    //        get { return base.LineWidth; }
    //        set { base.LineWidth = value; }
    //    }

    //    [DefaultValue(typeof(Color), "Red")]
    //    public override Color OutlineColor
    //    {
    //        get { return base.OutlineColor; }
    //        set { base.OutlineColor = value; }
    //    }

    //    [DefaultValue(typeof(Color), "Empty")]
    //    public override Color FillColor
    //    {
    //        get { return base.FillColor; }
    //        set { base.FillColor = value; }
    //    }

    //    //[DefaultValue(typeof(VectorialDrawMode), "Outline")]
    //    //public override VectorialDrawMode DrawMode
    //    //{
    //    //    get { return base.DrawMode; }
    //    //    set { base.DrawMode = value; }
    //    //}

    //    /// <summary>
    //    /// The length of the sweep hand. For a clock with the diameter of 100px.
    //    /// </summary>
    //    protected float height;

    //    /// <summary>
    //    /// Gets or sets the length of the sweep hand. For a clock with the diameter of 100px.
    //    /// </summary>
    //    [Category("Appearance")]
    //    [DefaultValue(HEIGHT)]
    //    [Description("The length of the sweep hand. For a clock with the diameter of 100px.")]
    //    public virtual float Height
    //    {
    //        get { return height; }
    //        set
    //        {
    //            height = value;
    //            OnChanged(EventArgs.Empty);
    //        }
    //    }

    //    #region Constructors

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="SweepHandShape"/> class with
    //    /// default values.
    //    /// </summary>
    //    public SweepHandShape()
    //        : this(Color.Red, Color.Empty, HEIGHT)
    //    {
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
    //    /// </summary>
    //    /// <param name="outlineColor">The color used to draw the outline of the sweep hand.</param>
    //    /// <param name="fillColor">The color used to draw the background of the sweep hand.</param>
    //    public SweepHandShape(Color outlineColor, Color fillColor)
    //        : this(outlineColor, fillColor, HEIGHT)
    //    {
    //    }

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="SweepHandShape"/> class.
    //    /// </summary>
    //    /// <param name="outlineColor">The color used to draw the outline of the sweep hand.</param>
    //    /// <param name="fillColor">The color used to draw the background of the sweep hand.</param>
    //    /// <param name="height">The length of the sweep hand for a clock with the diameter of 100px.</param>
    //    public SweepHandShape(Color outlineColor, Color fillColor, float height)
    //        : base(outlineColor, fillColor)
    //    {
    //        path = new PointF[] { new PointF(0f, 4.72f), new PointF(0f, -42.5f) };
    //        this.height = height;
    //        this.lineWidth = LINE_WIDTH;
    //        CalculateDimensions();
    //    }

    //    #endregion

    //    protected float pathHeight;

    //    private void CalculateDimensions()
    //    {
    //        float h = 0;

    //        foreach (PointF point in path)
    //        {
    //            if (point.Y < h)
    //                h = point.Y;
    //        }

    //        pathHeight = Math.Abs(h);
    //    }

    //    /// <summary>
    //    /// Draws the sweep hand using the provided <see cref="Graphics"/> object.
    //    /// </summary>
    //    /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
    //    /// <remarks>
    //    /// The hand is drawn in vertical position from the origin of the coordinate system.
    //    /// Before this method beeng called, the coordinate system has to be rotated in the corect position.
    //    /// </remarks>
    //    public override void Draw(Graphics g)
    //    {
    //        Matrix originalTransformMatrix = null;

    //        if (height > 0)
    //        {
    //            originalTransformMatrix = g.Transform;

    //            float scaleFactor = height / pathHeight;
    //            g.ScaleTransform(scaleFactor, scaleFactor);
    //        }

    //        if (!fillColor.IsEmpty)
    //        {
    //            CreateBrushIfNull();

    //            g.FillPolygon(brush, path);
    //        }

    //        if (!outlineColor.IsEmpty)
    //        {
    //            CreatePenIfNull();

    //            g.DrawPolygon(pen, path);
    //        }

    //        if (originalTransformMatrix != null)
    //        {
    //            g.Transform = originalTransformMatrix;
    //        }
    //    }
    //}
}
