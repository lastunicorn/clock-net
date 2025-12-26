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


using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Keeps a collection of Shapes that can be applied to the <see cref="AnalogClock"/> all at once.
    /// </summary>
    public class ClockTemplate
    {
        /// <summary>
        /// Gets or sets the array of Shapes that are drawn on the background of the clock.
        /// </summary>
        public IBackground[] BackgroundShapes { get; set; }

        /// <summary>
        /// Gets or sets the array of Shapes that are drawn repetitively around the clock.
        /// </summary>
        public IRimMarker[] AngularShapes { get; set; }

        /// <summary>
        /// Gets or sets the array of Shapes that represents hands on the clock.
        /// </summary>
        public IHand[] HandShapes { get; set; }
    }
}
