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

namespace DustInTheWind.ClockNet.Shapes
{
    /// <summary>
    /// Specifies angular locations on the clock.
    /// </summary>
    public enum AngularShapeLocation
    {
        /// <summary>
        /// The shape is never drawn.
        /// </summary>
        None,

        /// <summary>
        /// The shape is drawn for every minute position. (Every 6 degrees.)
        /// </summary>
        EveryMinute,

        /// <summary>
        /// The shape is drawn for every hour position. That means every 5 minutes. (Every 30 degrees.)
        /// </summary>
        EveryHour,

        /// <summary>
        /// The shape is drawn four times: at the 12, 3, 6 and 9 o'clock positions. (Every 90 degrees.)
        /// </summary>
        Cross,

        /// <summary>
        /// The shape is drawn only at the 12 and 6 o'clock positions.
        /// </summary>
        Vertical,

        /// <summary>
        /// The shape is drawn only at the 3 and 9 o'clock positions.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The shape is drawn only at the 12 o'clock position.
        /// </summary>
        North,

        /// <summary>
        /// The shape is drawn only at the 3 o'clock position.
        /// </summary>
        East,

        /// <summary>
        /// The shape is drawn only at the 6 o'clock position.
        /// </summary>
        South,

        /// <summary>
        /// The shape is drawn only at the 9 o'clock position.
        /// </summary>
        West
    }
}
