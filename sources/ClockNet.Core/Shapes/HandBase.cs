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

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// The base implementation of the <see cref="IHand"/> interface.
    /// Provides common functionality for all the Hand Shapes.
    /// </summary>
    public abstract class HandBase : ShapeBase, IHand
    {
        #region Length Property

        /// <summary>
        /// The default value of the length of the clock's hand..
        /// </summary>
        public const float DefaultLength = 90f;

        private float length;

        /// <summary>
        /// Gets or sets the length of the hand from the pin to the its top. For a clock with the diameter of 100px.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(DefaultLength)]
        [Description("The length of the hand from the pin to the its top. For a clock with the diameter of 100px.")]
        public virtual float Length
        {
            get => length;
            set
            {
                if (value == length)
                    return;

                length = value;
                InvalidateLayout();
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region ComponentToDisplay Property

        private TimeComponent componentToDisplay;

        /// <summary>
        /// Gets or sets a value that specifies the component that is displayed from the time value.
        /// </summary>
        [DefaultValue(typeof(TimeComponent), "None")]
        [Category("Behavior")]
        [Description("Specifies the component that is displayed from the time value.")]
        public TimeComponent ComponentToDisplay
        {
            get => componentToDisplay;
            set
            {
                if (value == componentToDisplay)
                    return;

                componentToDisplay = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region IntegralValue Property

        /// <summary>
        /// The default value of the <see cref="IntegralValue"/>.
        /// </summary>
        public const bool DefaultIntegralValue = false;

        private bool integralValue;

        /// <summary>
        /// Gets or set a value that specifies if the hand will hide the fractional part of the value that it displayes.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(DefaultIntegralValue)]
        [Description("Specifies if the hand will display only the integral part of the value.")]
        public bool IntegralValue
        {
            get => integralValue;
            set
            {
                if (value == integralValue)
                    return;

                integralValue = value;
                OnChanged(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="HandBase"/> class with
        /// default values.
        /// </summary>
        public HandBase()
        {
            length = DefaultLength;
            integralValue = DefaultIntegralValue;
        }

        /// <summary>
        /// Returns the degrees by which the hand should be rotated from the vertical position (12 o'clock hour).
        /// </summary>
        /// <param name="time">The time value to calculate rotation from.</param>
        /// <returns>The degrees by which the hand should be rotated from the vertical position (12 o'clock hour).</returns>
        protected float GetRotationDegrees(TimeSpan time)
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
        /// Draws the shape using the provided <see cref="ClockDrawingContext"/>.
        /// </summary>
        /// <param name="context">The <see cref="ClockDrawingContext"/> containing the graphics context and time information.</param>
        protected override bool OnBeforeDraw(ClockDrawingContext context)
        {
            bool allowToDraw = base.OnBeforeDraw(context);

            if (!allowToDraw)
                return false;

            float degrees = GetRotationDegrees(context.Time);

            if (degrees != 0)
                context.Graphics.RotateTransform(degrees);

            return true;
        }

        /// <summary>
        /// Tests if the specified point is contained by the Shape.
        /// </summary>
        /// <param name="point">The point to be ferified.</param>
        /// <param name="time">The time displayed by the hand.</param>
        /// <returns>true if the specified point is contained by the Shape; false otherwise.</returns>
        public abstract bool HitTest(PointF point, TimeSpan time);
    }
}
