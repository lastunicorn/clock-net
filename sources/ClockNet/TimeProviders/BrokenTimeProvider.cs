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
        public const float MULTIPLIER = 10;

        private TimeSpan lastValue;
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

        private DateTime lastQueryTime;

        /// <summary>
        /// The time multiplier that specifies how much faster is the provided time compared to the real one.
        /// </summary>
        private float multiplier;

        /// <summary>
        /// Gets or sets the time multiplier that specifies how much faster is the provided time compared to the real one.
        /// </summary>
        [DefaultValue(MULTIPLIER)]
        [Description("Specifies how much faster is the provided time compared to the real one.")]
        public float Multiplier
        {
            get { return multiplier; }
            set
            {
                multiplier = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomTimeProvider"/> class with
        /// default values.
        /// </summary>
        public BrokenTimeProvider()
            : this(MULTIPLIER)
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
        /// <param name="multiplier">Specifies how much faster is the provided time compared to the real one.</param>
        public BrokenTimeProvider(float multiplier, TimeSpan initialValue)
            : base()
        {
            this.multiplier = multiplier;
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
            double deltaTimeTicks = diffTime.Ticks * multiplier;
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
