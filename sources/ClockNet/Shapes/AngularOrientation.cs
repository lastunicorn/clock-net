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
    /// Specifies the orientation of the numbers that marks the hours.
    /// </summary>
    public enum AngularOrientation
    {
        /// <summary>
        /// The numbers are displayed as normal text, oriented up-down.
        /// </summary>
        Normal,

        /// <summary>
        /// The numbers are displayed oriented to the center of the clock.
        /// </summary>
        FaceCenter,

        /// <summary>
        /// The numbers are displayed oriented to the outside of the clock.
        /// </summary>
        FaceOut
    }
}
