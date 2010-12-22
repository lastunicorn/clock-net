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

namespace DustInTheWind.Clock.Shapes.Default
{
    /// <summary>
    /// The <see cref="IShape"/> class used by default in <see cref="AnalogClock"/> to draw the ticks that mark the seconds.
    /// </summary>
    public class TicksShape : VectorialAngularShapeBase
    {
        /// <summary>
        /// The default value of the length.
        /// </summary>
        public const float LENGTH = 2.5f;

        /// <summary>
        /// The default value of the thickness.
        /// </summary>
        public const float THICKNESS = 0.25f;

        /// <summary>
        /// The default value of the position offset.
        /// </summary>
        public const float POSITION_OFFSET = 0f;


        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        public override string Name
        {
            get { return "Default Ticks Shape"; }
        }


        /// <summary>
        /// Gets or sets the color used to draw the ticks that mark the seconds.
        /// </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color used to draw the ticks that mark the seconds.")]
        public override Color OutlineColor
        {
            get { return base.OutlineColor; }
            set { base.OutlineColor = value; }
        }


        /// <summary>
        /// The length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        protected float length = LENGTH;

        /// <summary>
        /// Gets or sets the length of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(LENGTH)]
        [Description("The length of the 1 second ticks. This value is given for a clock with diameter of 100px.")]
        public virtual float Length
        {
            get { return length; }
            set
            {
                length = value;
                CalculateDimensions();
                OnChanged(EventArgs.Empty);
            }
        }


        /// <summary>
        /// Gets or sets the width of the 1 second ticks. This value is given for a clock with diameter of 100px.
        /// </summary>
        [DefaultValue(THICKNESS)]
        [Description("The width of the 1 second ticks. This value is given for a clock with diameter of 100px.")]
        public override float LineWidth
        {
            get { return base.LineWidth; }
            set { base.LineWidth = value; }
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


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TicksShape"/> class with
        /// default values.
        /// </summary>
        public TicksShape()
            : this(Color.Black, LENGTH, THICKNESS, POSITION_OFFSET)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicksShape"/> class.
        /// </summary>
        /// <param name="color">The color used to draw the tick shapes.</param>
        /// <param name="length">The length of the ticks.</param>
        /// <param name="lineWidth">The width of the ticks.</param>
        /// <param name="positionOffset">The position offset relativelly to the edge of the dial.</param>
        public TicksShape(Color color, float length, float lineWidth, float positionOffset)
            : base(color, Color.Empty)
        {
            this.length = length;
            this.lineWidth = lineWidth;
            this.positionOffset = positionOffset;

            CalculateDimensions();
        }

        #endregion

        private AngularShapeLocation angularLocation = AngularShapeLocation.EveryMinute;
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

        private AngularShapeLocation exceptionLocation = AngularShapeLocation.None;
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

        PointF startPoint;
        PointF endPoint;

        private void CalculateDimensions()
        {
            startPoint = new PointF(0, positionOffset);
            endPoint = new PointF(0, length + positionOffset);
        }

        ///// <summary>
        ///// Draws one tick using the provided <see cref="Graphics"/> object.
        ///// </summary>
        ///// <param name="g">The <see cref="Graphics"/> on which to draw the image.</param>
        ///// <remarks>
        ///// Before calling this method, the origin should be already moved to the edje of the dial,
        ///// in the place where the tick should be drawn.
        ///// </remarks>
        //public override void Draw(Graphics g)
        //{
        //    if (visible && length > 0 && lineWidth > 0 && !outlineColor.IsEmpty)
        //    {
        //        try
        //        {
        //            if (index == 0)
        //                return;

        //            switch (angularLocation)
        //            {
        //                case AngularShapeLocation.None:
        //                    return;

        //                default:
        //                case AngularShapeLocation.EveryMinute:
        //                    break;

        //                case AngularShapeLocation.EveryHour:
        //                    if (index % 5 != 0) return;
        //                    break;

        //                case AngularShapeLocation.Cross:
        //                    if (index % 15 != 0) return;
        //                    break;

        //                case AngularShapeLocation.Vertical:
        //                    if (index % 30 != 0) return;
        //                    break;

        //                case AngularShapeLocation.Horizontal:
        //                    if (index != 15 && index != 45) return;
        //                    break;

        //                case AngularShapeLocation.North:
        //                    if (index != 60) return;
        //                    break;

        //                case AngularShapeLocation.East:
        //                    if (index != 15) return;
        //                    break;

        //                case AngularShapeLocation.South:
        //                    if (index != 30) return;
        //                    break;

        //                case AngularShapeLocation.West:
        //                    if (index != 45) return;
        //                    break;
        //            }

        //            switch (exceptionLocation)
        //            {
        //                default:
        //                case AngularShapeLocation.None:
        //                    break;

        //                case AngularShapeLocation.EveryMinute:
        //                    return;

        //                case AngularShapeLocation.EveryHour:
        //                    if (index % 5 == 0) return;
        //                    break;

        //                case AngularShapeLocation.Cross:
        //                    if (index % 15 == 0) return;
        //                    break;

        //                case AngularShapeLocation.Vertical:
        //                    if (index % 30 == 0) return;
        //                    break;

        //                case AngularShapeLocation.Horizontal:
        //                    if (index == 15 || index == 45) return;
        //                    break;

        //                case AngularShapeLocation.North:
        //                    if (index == 60) return;
        //                    break;

        //                case AngularShapeLocation.East:
        //                    if (index == 15) return;
        //                    break;

        //                case AngularShapeLocation.South:
        //                    if (index == 30) return;
        //                    break;

        //                case AngularShapeLocation.West:
        //                    if (index == 45) return;
        //                    break;
        //            }

        //            CreatePenIfNull();

        //            g.DrawLine(pen, startPoint, endPoint);
        //        }
        //        finally
        //        {
        //            index++;
        //        }
        //    }
        //}

        protected override void DrawInternal(Graphics g)
        {
            CreatePenIfNull();
            g.DrawLine(pen, startPoint, endPoint);
        }


        //private float angle = 6f;
        //public float Angle
        //{
        //    get { return angle; }
        //    set
        //    {
        //        angle = value;
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

        //private bool repeat = true;
        //public bool Repeat
        //{
        //    get { return repeat; }
        //    set
        //    {
        //        repeat = value;
        //        OnChanged(EventArgs.Empty);
        //    }
        //}

        //private int index = 0;
        //public int Index
        //{
        //    get { return index; }
        //    set { index = value; }
        //}

        //public void Reset()
        //{
        //    index = 0;
        //}
    }
}
