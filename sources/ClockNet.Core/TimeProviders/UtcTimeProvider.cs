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

namespace DustInTheWind.ClockNet.TimeProviders
{
    /// <summary>
    /// Provides the UTC time. Optionally, an offset may be provided.
    /// </summary>
    public class UtcTimeProvider : TimeProviderBase
    {
        /// <summary>
        /// The offset time used to decalates the system's UTC time value provided.
        /// </summary>
        private TimeSpan utcOffset;

        /// <summary>
        /// Gets or sets the offset time used to decalates the system's UTC time value provided.
        /// </summary>
        [Category("Value")]
        [DefaultValue(typeof(TimeSpan), "0")]
        [Description("The offset time used to decalates the system's UTC time value provided.")]
        public TimeSpan UtcOffset
        {
            get => utcOffset;
            set
            {
                utcOffset = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Returns the system's UTC time added with the offset value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        public override TimeSpan GetTime()
        {
            return utcOffset == TimeSpan.Zero
                ? DateTime.UtcNow.TimeOfDay
                : DateTime.UtcNow.TimeOfDay.Add(utcOffset);
        }
    }
}
