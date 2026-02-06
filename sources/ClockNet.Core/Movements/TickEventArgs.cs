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

namespace DustInTheWind.ClockNet.Core.Movements
{
    /// <summary>
    /// Contains the event data for the <see cref="IMovement.Tick"/> event.
    /// </summary>
    public class TickEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the time value.
        /// </summary>
        public TimeSpan Time { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TickEventArgs"/> class.
        /// </summary>
        /// <param name="time">The time value.</param>
        public TickEventArgs(TimeSpan time)
        {
            Time = time;
        }
    }
}
