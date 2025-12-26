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

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// Specifies a component of a time value.
    /// </summary>
    [Flags]
    public enum TimeComponent
    {
        /// <summary>
        /// Represents no component of the time value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents the hour component of the time value.
        /// </summary>
        Hour = 1,

        /// <summary>
        /// Represents the minute component of the time value.
        /// </summary>
        Minute = 2,

        /// <summary>
        /// Represents the second component of the time value.
        /// </summary>
        Second = 4,

        /// <summary>
        /// Represents all components, hour, minute, second of the time value.
        /// </summary>
        All = 7
    }
}
