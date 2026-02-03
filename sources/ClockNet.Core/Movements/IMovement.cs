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
    /// Provides the time to be displayed by the a clock. The time is provided as <see cref="TimeSpan"/> objects.
    /// </summary>
    public interface IMovement : IComponent
    {
        /// <summary>
        /// Event raised when the time provider produces a new time value.
        /// </summary>
        event EventHandler<TimeChangedEventArgs> TimeChanged;

        /// <summary>
        /// Gets or sets the interval in milliseconds at which the time provider generates time values.
        /// </summary>
        int Interval { get; set; }

        /// <summary>
        /// Gets a value indicating whether the time provider is currently running.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Starts the time provider. The time provider will begin generating time values.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the time provider. The time provider will stop generating time values.
        /// </summary>
        void Stop();
    }
}
