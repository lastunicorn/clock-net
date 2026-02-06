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

namespace DustInTheWind.ClockNet.Core.Movements
{
    /// <summary>
    /// Provides time values from a time coordinate that is n time faster then the real one.
    /// </summary>
    public class SpeedyMovement : MovementBase
    {
        private DateTime initialRealTime = DateTime.UtcNow;

        #region InitialTime Property

        private TimeSpan initialTime = DateTime.Now.TimeOfDay;

        /// <summary>
        /// Gets or sets the last value of the time provided by the current instance.
        /// When this value is set, it is considered a reference for the next time value
        /// returned by the current instance.
        /// </summary>
        [DefaultValue(typeof(TimeSpan), "00:00:00")]
        [Description("The last value of the time provided by the current instance.")]
        public TimeSpan InitialTime
        {
            get => initialTime;
            set
            {
                Stop();
                initialTime = value;
                initialRealTime = DateTime.UtcNow;
                Start();
            }
        }

        #endregion

        #region TimeMultiplier Property

        /// <summary>
        /// The default value of the time multiplier.
        /// </summary>
        public const float DefaultTimeMultiplier = 10;

        private float timeMultiplier = DefaultTimeMultiplier;

        /// <summary>
        /// Gets or sets the time multiplier that specifies how much faster is the provided time
        /// compared to the real one.
        /// </summary>
        [DefaultValue(DefaultTimeMultiplier)]
        [Description("Specifies how much faster is the provided time compared to the real one.")]
        public float TimeMultiplier
        {
            get => timeMultiplier;
            set
            {
                if (timeMultiplier == value)
                    return;

                initialTime = GenerateNewTime();
                initialRealTime = DateTime.UtcNow;

                timeMultiplier = value;
                OnModified();

                ForceTick();
            }
        }

        #endregion

        /// <summary>
        /// Returns a new time value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        protected override TimeSpan GenerateNewTime()
        {
            DateTime currentRealTime = DateTime.UtcNow;
            long realDeltaTicks = currentRealTime.Ticks - initialRealTime.Ticks;
            double fakeDeltaTicks = realDeltaTicks * TimeMultiplier;
            TimeSpan fakeDelta = TimeSpan.FromTicks((long)fakeDeltaTicks);
            TimeSpan fakeTime = initialTime + fakeDelta;

            return fakeTime.Days > 0
                ? fakeTime.Subtract(TimeSpan.FromDays(fakeTime.Days))
                : fakeTime;
        }
    }
}
