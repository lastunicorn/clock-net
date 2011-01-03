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
    /// The base implementation of the <see cref="IHandShape"/> interface.
    /// Provides common functionality for all the Hand Shapes.
    /// </summary>
    public abstract class HandShapeBase : ShapeBase, IHandShape
    {
        /// <summary>
        /// The default value of the height.
        /// </summary>
        public const float HEIGHT = 45f;

        /// <summary>
        /// The default value of the <see cref="IntegralValue"/>.
        /// </summary>
        public const bool INTEGRAL_VALUE = false;

        /// <summary>
        /// The length of the hand from the pin to the its top. For a clock with the diameter of 100px.
        /// </summary>
        protected float height;

        /// <summary>
        /// Gets or sets the length of the hand from the pin to the its top. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(HEIGHT)]
        [Description("The length of the hand from the pin to the its top. For a clock with the diameter of 100px.")]
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


        /// <summary>
        /// The time that the current instance should represent.
        /// </summary>
        protected TimeSpan time;

        /// <summary>
        /// Gets or sets the time that the current instance should represent.
        /// </summary>
        [Browsable(false)]
        public virtual TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// Specifies the component that is displayed from the time value.
        /// </summary>
        protected TimeComponent componentToDisplay;

        /// <summary>
        /// Gets or sets a value that specifies the component that is displayed from the time value.
        /// </summary>
        [DefaultValue(typeof(TimeComponent), "None")]
        [Category("Behavior")]
        [Description("Specifies the component that is displayed from the time value.")]
        public virtual TimeComponent ComponentToDisplay
        {
            get { return componentToDisplay; }
            set
            {
                componentToDisplay = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// A value that specifies if the hand will hide the fractional part of the value that it displayes.
        /// </summary>
        protected bool integralValue;

        /// <summary>
        /// Gets or set a value that specifies if the hand will hide the fractional part of the value that it displayes.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(INTEGRAL_VALUE)]
        [Description("Specifies if the hand will hide the fractional part of the value that it displayes.")]
        public virtual bool IntegralValue
        {
            get { return integralValue; }
            set
            {
                integralValue = value;
                OnChanged(EventArgs.Empty);
            }
        }


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HandShapeBase"/> class with
        /// default values.
        /// </summary>
        public HandShapeBase()
            : this(HEIGHT)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandShapeBase"/> class.
        /// </summary>
        /// <param name="height">The length of the hour hand for a clock with the diameter of 100px.</param>
        public HandShapeBase(float height)
            : base()
        {
            this.height = height;
            this.integralValue = INTEGRAL_VALUE;
        }

        #endregion


        /// <summary>
        /// Returns the degrees by which the hand should be rotated from the vertical position (12 o'clock hour).
        /// </summary>
        /// <returns>The degrees by which the hand should be rotated from the vertical position (12 o'clock hour).</returns>
        protected float GetRotationDegrees()
        {
            switch (componentToDisplay)
            {
                case TimeComponent.Hour:
                    {
                        if (integralValue)
                            return (float)((time.Hours % 12) * 30);
                        else
                            return (float)((time.Hours % 12 + time.Minutes / 60F) * 30);
                    }

                case TimeComponent.Minute:
                    {
                        if (integralValue)
                            return (float)(time.Minutes * 6);
                        else
                            return (float)((time.Minutes + time.Seconds / 60F) * 6);
                    }

                case TimeComponent.Second:
                    {
                        if (integralValue)
                            return (float)(time.Seconds * 6);
                        else
                            return (float)((time.Seconds + time.Milliseconds / 1000F) * 6);
                    }

                default:
                    return 0;
            }
        }

        /// <summary>
        /// Draws the shape using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        public override void Draw(Graphics g)
        {
            if (AllowToDraw())
            {
                float degrees = GetRotationDegrees();

                if (degrees != 0)
                    g.RotateTransform(degrees);

                DrawInternal(g);
            }
        }
    }
}
