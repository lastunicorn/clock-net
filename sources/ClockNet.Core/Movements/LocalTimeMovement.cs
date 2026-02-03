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
    /// Provides the system's local time.
    /// </summary>
    public class LocalTimeMovement : MovementBase
    {
        /// <summary>
        /// Returns the system's local time from the moment of the request.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/> object containing the time value.</returns>
        protected override TimeSpan GetTime()
        {
            return DateTime.Now.TimeOfDay;
        }
    }
}
