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

namespace DustInTheWind.ClockNet.Shapes
{
    /// <summary>
    /// The base implementation of the <see cref="IAngularShape"/> interface.
    /// Provides common functionality for all the Angular Shapes.
    /// </summary>
    public abstract class AngularShapeBase : ShapeBase, IAngularShape
    {
        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float DefaultDistanceFromEdge = 0f;

        /// <summary>
        /// The default value of the angle.
        /// </summary>
        public const float DefaultAngle = 6f;

        /// <summary>
        /// The default value of the offset angle.
        /// </summary>
        public const float DefaultOffsetAngle = 6f;

        /// <summary>
        /// The default value of the skip index.
        /// </summary>
        public const int DefaultSkipIndex = 0;

        /// <summary>
        /// The default value of the repeat.
        /// </summary>
        public const bool DefaultRepeat = true;

        /// <summary>
        /// The default value of the shape's orientation.
        /// </summary>
        public const AngularOrientation DefaultOrientation = AngularOrientation.FaceCenter;


        /// <summary>
        /// The position offset relativelly to the edge of the dial.
        /// </summary>
        protected float distanceFromEdge;

        /// <summary>
        /// Gets or sets the position offset relativelly to the edge of the dial.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultDistanceFromEdge)]
        [Description("The position offset relativelly to the edge of the dial.")]
        public virtual float DistanceFromEdge
        {
            get => distanceFromEdge;
            set
            {
                distanceFromEdge = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        protected float offsetAngle = DefaultOffsetAngle;

        /// <summary>
        /// Gets or sets the angle, in degrees, by which the layout is offset from its default orientation.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The offset angle should be a number greater or equal with zero.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultOffsetAngle)]
        public virtual float OffsetAngle
        {
            get => offsetAngle;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The offset angle should be a number greater or equal with zero.");

                offsetAngle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The angle between two consecutive instances of the shape.
        /// </summary>
        protected float angle;

        /// <summary>
        /// Gets or sets the angle between two consecutive instances of the shape.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive instances of the shape should be a positive number.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultAngle)]
        [Description("The angle between two consecutive instances of the shape.")]
        public virtual float Angle
        {
            get => angle;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "The angle between two consecutive instances of the shape should be a positive number.");

                angle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The index and its multiples that should be skipped from beeing drawn.
        /// </summary>
        protected int skipIndex;

        /// <summary>
        /// Gets or sets the index and its multiples that should be skipped from beeing drawn.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultSkipIndex)]
        [Description("The index and its multiples that should be skipped from beeing drawn.")]
        public virtual int SkipIndex
        {
            get => skipIndex;
            set
            {
                skipIndex = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// A value specifying if the shape should be repeated all around the clock's dial.
        /// </summary>
        protected bool repeat;

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated all around the clock's dial.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultRepeat)]
        [Description("Specifies if the shape should be repeated all around the clock's dial.")]
        public virtual bool Repeat
        {
            get => repeat;
            set
            {
                repeat = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The orientation of the shape.
        /// </summary>
        protected AngularOrientation orientation;

        /// <summary>
        /// Geta or sets the orientation of the shape.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultOrientation)]
        [Description("Specifies the orientation of the shape.")]
        public virtual AngularOrientation Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The index that should be drawn by the <see cref="IShape.Draw"/> method next time it is call.
        /// </summary>
        protected int index = 0;

        /// <summary>
        /// Gets or sets the index that should be drawn by the <see cref="IShape.Draw"/> method next time it is call.
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get => index;
            set => index = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class with
        /// default values.
        /// </summary>
        public AngularShapeBase()
            : this(DefaultAngle, DefaultRepeat, DefaultDistanceFromEdge)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class.
        /// </summary>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="DistanceFromEdge">The position offset relativelly to the edge of the dial.</param>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        public AngularShapeBase(float angle, bool repeat, float DistanceFromEdge)
            : base()
        {
            if (angle <= 0)
                throw new ArgumentOutOfRangeException("angle", "The angle between two consecutive drawns of the shape should be a positive number.");

            this.angle = angle;
            this.repeat = repeat;
            distanceFromEdge = DistanceFromEdge;
            orientation = DefaultOrientation;
        }

        /// <summary>
        /// Draws one tick using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        protected override bool OnBeforeDraw(Graphics g)
        {
            bool allowToDraw = base.OnBeforeDraw(g);

            if (!allowToDraw)
                return false;

            //if (index == 0)
            //    return false;

            if (skipIndex > 0 && index % skipIndex == 0)
                return false;

            if (distanceFromEdge != 0)
                g.TranslateTransform(0, distanceFromEdge);

            switch (orientation)
            {
                case AngularOrientation.FaceCenter:
                    break;

                case AngularOrientation.FaceOut:
                    g.RotateTransform(180);
                    break;

                default:
                case AngularOrientation.Normal:
                    float totalAngle = -(angle * index);
                    g.RotateTransform(totalAngle);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Performs additional processing after the control has completed its drawing operations.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> object used to draw the control's content.</param>
        protected override void OnAfterDraw(Graphics g)
        {
            index++;
            base.OnAfterDraw(g);
        }

        /// <summary>
        /// Resets the index of the shape that will be drawn next.
        /// This method is called by the clock before every paint.
        /// </summary>
        public void Reset()
        {
            index = 0;
        }
    }
}
