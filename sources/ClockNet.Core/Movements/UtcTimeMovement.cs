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
    /// Provides the UTC time. Optionally, an offset may be provided.
    /// </summary>
    public class UtcTimeMovement : MovementBase
    {
        private TimeSpan utcOffset;

        /// <summary>
        /// Gets or sets the offset time used to adjust the system's UTC time value.
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(typeof(TimeSpan), "00:00:00")]
        [Description("The offset time used to adjust the system's UTC time value.")]
        public TimeSpan UtcOffset
        {
            get => utcOffset;
            set
            {
                if (utcOffset == value)
                    return;

                utcOffset = value;
                OnModified();
                ForceTick();
            }
        }

        /// <summary>
        /// Returns the system's UTC time added with the offset value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        protected override TimeSpan GenerateNewTime()
        {
            return UtcOffset == TimeSpan.Zero
                ? DateTime.UtcNow.TimeOfDay
                : DateTime.UtcNow.TimeOfDay.Add(UtcOffset);
        }
    }
}
