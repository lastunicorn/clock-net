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
        public const float DefaultPositionOffset = 0f;

        /// <summary>
        /// The default value of the angle.
        /// </summary>
        public const float DefaultAngle = 6f;

        ///// <summary>
        ///// The default value of the offset angle.
        ///// </summary>
        //public const float OFFSET_ANGLE = 6f;

        /// <summary>
        /// The default value of the exception index.
        /// </summary>
        public const int DefaultExceptionIndex = 0;

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
        protected float positionOffset;

        /// <summary>
        /// Gets or sets the position offset relativelly to the edge of the dial.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(DefaultPositionOffset)]
        [Description("The position offset relativelly to the edge of the dial.")]
        public virtual float DistanceFromEdge
        {
            get { return positionOffset; }
            set
            {
                positionOffset = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }


        //protected float offsetAngle;

        ///// <exception cref="ArgumentOutOfRangeException">The offset angle should be a number greater or equal with zero.</exception>
        //[Category("Layout")]
        //[DefaultValue(OFFSET_ANGLE)]
        //public virtual float OffsetAngle
        //{
        //    get { return offsetAngle; }
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentOutOfRangeException("value", "The offset angle should be a number greater or equal with zero.");

        //        offsetAngle = value;
        //        OnChanged(EventArgs.Empty);
        //    }
        //}


        /// <summary>
        /// The angle between two consecutive drawns of the shape.
        /// </summary>
        protected float angle;

        /// <summary>
        /// Gets or sets the angle between two consecutive drawns of the shape.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        [Category("Layout")]
        [DefaultValue(DefaultAngle)]
        [Description("The angle between two consecutive drawns of the shape.")]
        public virtual float Angle
        {
            get { return angle; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "The angle between two consecutive drawns of the shape should be a positive number.");

                angle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The index and its multiples that should be skipped from beeing drawn.
        /// </summary>
        protected int exceptionIndex;

        /// <summary>
        /// Gets or sets the index and its multiples that should be skipped from beeing drawn.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultExceptionIndex)]
        [Description("The index and its multiples that should be skipped from beeing drawn.")]
        public virtual int ExceptionIndex
        {
            get { return exceptionIndex; }
            set
            {
                exceptionIndex = value;
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
            get { return repeat; }
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
            get { return orientation; }
            set
            {
                orientation = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The index that should be drawn by the <see cref="Draw"/> method next time it is call.
        /// </summary>
        protected int index = 0;

        /// <summary>
        /// Gets or sets the index that should be drawn by the <see cref="Draw"/> method next time it is call.
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class with
        /// default values.
        /// </summary>
        public AngularShapeBase()
            : this(DefaultAngle, DefaultRepeat, DefaultPositionOffset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class.
        /// </summary>
        /// <param name="angle">The angle between two consecutive drawns of the shape.</param>
        /// <param name="repeat">A value specifying if the shape should be repeated all around the clock's dial.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        public AngularShapeBase(float angle, bool repeat, float positionOffset)
            : base()
        {
            if (angle <= 0)
                throw new ArgumentOutOfRangeException("angle", "The angle between two consecutive drawns of the shape should be a positive number.");

            this.angle = angle;
            this.repeat = repeat;
            this.positionOffset = positionOffset;
            orientation = DefaultOrientation;
        }

        #endregion


        /// <summary>
        /// Draws one tick using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        protected override bool OnBeforeDraw(Graphics g)
        {
            bool allowToDraw = base.OnBeforeDraw(g);

            if (!allowToDraw)
                return false;

            if (index == 0)
                return false;

            if (exceptionIndex > 0 && index % exceptionIndex == 0)
                return false;

            if (positionOffset != 0)
                g.TranslateTransform(0, positionOffset);

            switch (orientation)
            {
                case AngularOrientation.FaceCenter:
                    break;

                case AngularOrientation.FaceOut:
                    g.RotateTransform(180);
                    break;

                default:
                case AngularOrientation.Normal:
                    float ang = -(this.angle * index);
                    g.RotateTransform(ang);
                    break;
            }

            return true;
        }

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
