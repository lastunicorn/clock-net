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

namespace DustInTheWind.Clock.TimeProviders
{
    /// <summary>
    /// Provides time values from a time coordinate that is n time faster then the real one.
    /// </summary>
    public class BrokenTimeProvider : TimeProviderBase
    {
        /// <summary>
        /// The default value of the time multiplier.
        /// </summary>
        public const float TIME_MULTIPLIER = 10;


        /// <summary>
        /// The last value of the time provided by the current instance.
        /// </summary>
        private TimeSpan lastValue;

        /// <summary>
        /// Gets or sets the last value of the time provided by the current instance.
        /// When this value is set, it is considered a reference for the next time value
        /// returned by the current instance.
        /// </summary>
        [DefaultValue(typeof(TimeSpan), "00:00:00")]
        [Description("The last value of the time provided by the current instance.")]
        public TimeSpan LastValue
        {
            get { return lastValue; }
            set
            {
                lastValue = value;
                lastQueryTime = DateTime.Now;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// The real time when the current instance provided the last time value.
        /// </summary>
        private DateTime lastQueryTime;


        /// <summary>
        /// The time multiplier that specifies how much faster the time measured by the current instance
        /// flows compared to the real one.
        /// </summary>
        private float timeMultiplier;

        /// <summary>
        /// Gets or sets the time multiplier that specifies how much faster is the provided time compared to the real one.
        /// </summary>
        [DefaultValue(TIME_MULTIPLIER)]
        [Description("Specifies how much faster is the provided time compared to the real one.")]
        public float TimeMultiplier
        {
            get { return timeMultiplier; }
            set
            {
                timeMultiplier = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomTimeProvider"/> class with
        /// default values.
        /// </summary>
        public BrokenTimeProvider()
            : this(TIME_MULTIPLIER)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomTimeProvider"/> class.
        /// </summary>
        /// <param name="multiplier">Specifies how much faster is the provided time compared to the real one.</param>
        public BrokenTimeProvider(float multiplier)
            : this(multiplier, TimeSpan.Zero)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomTimeProvider"/> class.
        /// </summary>
        /// <param name="timeMultiplier">Specifies how much faster is the provided time compared to the real one.</param>
        /// <param name="initialValue">The value of the time measured by the new instance at the moment of its creation.</param>
        public BrokenTimeProvider(float timeMultiplier, TimeSpan initialValue)
            : base()
        {
            this.timeMultiplier = timeMultiplier;
            lastQueryTime = DateTime.Now;
            lastValue = initialValue;
        }

        /// <summary>
        /// Returns a new time value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        public override TimeSpan GetTime()
        {
            DateTime currentQueryTime = DateTime.Now;
            TimeSpan diffTime = currentQueryTime - lastQueryTime;
            double deltaTimeTicks = diffTime.Ticks * timeMultiplier;
            TimeSpan deltaTime = new TimeSpan((int)deltaTimeTicks); // By rounding here, small amounts of time are lost every time.
            TimeSpan newValue = lastValue + deltaTime;
            if (newValue.Days > 0)
                newValue = newValue.Subtract(TimeSpan.FromDays(newValue.Days));
            lastValue = newValue;
            lastQueryTime = currentQueryTime;

            return newValue;
        }
    }
}
