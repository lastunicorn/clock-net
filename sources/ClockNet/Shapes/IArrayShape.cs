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
using System.Drawing;

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Represents a shape that contains an array of items to de drawn.
    /// </summary>
    public interface IArrayShape: IShape
    {
        /// <summary>
        /// Gets or sets the index of the item to be drawn.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        [Browsable(false)]
        int CurrentIndex { get; set; }
    }
}
