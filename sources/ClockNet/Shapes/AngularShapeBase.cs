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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the ticks that mark the seconds.
    /// </summary>
    public abstract class AngularShapeBase : ShapeBase, IAngularShape
    {
        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float POSITION_OFFSET = 0f;

        /// <summary>
        /// The default value of the angle.
        /// </summary>
        public const float ANGLE = 6f;

        /// <summary>
        /// The default value of the repeat.
        /// </summary>
        public const bool REPEAT = true;


        /// <summary>
        /// The position offset relativelly to the edge of the dial.
        /// </summary>
        protected float positionOffset = POSITION_OFFSET;

        /// <summary>
        /// Gets or sets the position offset relativelly to the edge of the dial.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(POSITION_OFFSET)]
        [Description("The position offset relativelly to the edge of the dial.")]
        public virtual float PositionOffset
        {
            get { return positionOffset; }
            set
            {
                positionOffset = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// The angle between two consecutive drawns of the shape.
        /// </summary>
        protected float angle;

        /// <summary>
        /// Gets or sets the angle between two consecutive drawns of the shape.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The angle between two consecutive drawns of the shape should be a positive number.</exception>
        [Category("Appearance")]
        [DefaultValue(ANGLE)]
        [Description("The angle between two consecutive drawns of the shape.")]
        public float Angle
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
        /// A value specifying if the shape should be repeated all around the clock's dial.
        /// </summary>
        protected bool repeat;

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated all around the clock's dial.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(REPEAT)]
        [Description("Specifies if the shape should be repeated all around the clock's dial.")]
        public bool Repeat
        {
            get { return repeat; }
            set
            {
                repeat = value;
                OnChanged(EventArgs.Empty);
            }
        }

        protected int index = 0;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        protected AngularShapeLocation angularLocation = AngularShapeLocation.EveryMinute;
        public AngularShapeLocation AngularLocation
        {
            get { return angularLocation; }
            set
            {
                angularLocation = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }

        protected AngularShapeLocation exceptionLocation = AngularShapeLocation.None;
        public AngularShapeLocation ExceptionLocation
        {
            get { return exceptionLocation; }
            set
            {
                exceptionLocation = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class with
        /// default values.
        /// </summary>
        public AngularShapeBase()
            : this(ANGLE, REPEAT, POSITION_OFFSET)
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

            CalculateDimensions();
        }

        #endregion

        protected virtual void CalculateDimensions() { }

        /// <summary>
        /// Draws one tick using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        /// <remarks>
        /// Before calling this method, the origin should be already moved to the edje of the dial,
        /// in the place where the tick should be drawn.
        /// </remarks>
        public override void Draw(Graphics g)
        {
            if (visible)
            {
                try
                {
                    if (index == 0)
                        return;

                    switch (angularLocation)
                    {
                        case AngularShapeLocation.None:
                            return;

                        default:
                        case AngularShapeLocation.EveryMinute:
                            break;

                        case AngularShapeLocation.EveryHour:
                            if (index % 5 != 0) return;
                            break;

                        case AngularShapeLocation.Cross:
                            if (index % 15 != 0) return;
                            break;

                        case AngularShapeLocation.Vertical:
                            if (index % 30 != 0) return;
                            break;

                        case AngularShapeLocation.Horizontal:
                            if (index != 15 && index != 45) return;
                            break;

                        case AngularShapeLocation.North:
                            if (index != 60) return;
                            break;

                        case AngularShapeLocation.East:
                            if (index != 15) return;
                            break;

                        case AngularShapeLocation.South:
                            if (index != 30) return;
                            break;

                        case AngularShapeLocation.West:
                            if (index != 45) return;
                            break;
                    }

                    switch (exceptionLocation)
                    {
                        default:
                        case AngularShapeLocation.None:
                            break;

                        case AngularShapeLocation.EveryMinute:
                            return;

                        case AngularShapeLocation.EveryHour:
                            if (index % 5 == 0) return;
                            break;

                        case AngularShapeLocation.Cross:
                            if (index % 15 == 0) return;
                            break;

                        case AngularShapeLocation.Vertical:
                            if (index % 30 == 0) return;
                            break;

                        case AngularShapeLocation.Horizontal:
                            if (index == 15 || index == 45) return;
                            break;

                        case AngularShapeLocation.North:
                            if (index == 60) return;
                            break;

                        case AngularShapeLocation.East:
                            if (index == 15) return;
                            break;

                        case AngularShapeLocation.South:
                            if (index == 30) return;
                            break;

                        case AngularShapeLocation.West:
                            if (index == 45) return;
                            break;
                    }

                    DrawInternal(g);
                }
                finally
                {
                    index++;
                }
            }
        }

        protected abstract void DrawInternal(Graphics g);
        
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
