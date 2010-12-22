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
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Angular Shape"; }
        }


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


        protected float angle = 6f;
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                OnChanged(EventArgs.Empty);
            }
        }

        protected bool repeat = true;
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
            : this(POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngularShapeBase"/> class.
        /// </summary>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public AngularShapeBase(float positionOffset)
            : base()
        {
            this.positionOffset = positionOffset;

            CalculateDimensions();
        }

        #endregion

        protected virtual void CalculateDimensions()
        {
        }

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


        public void Reset()
        {
            index = 0;
        }
    }
}
