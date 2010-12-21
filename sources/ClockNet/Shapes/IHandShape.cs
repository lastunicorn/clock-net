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

using System.ComponentModel;

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Represents a clock hand that is drawn on the clock in the <see cref="AnalogClock"/> control.
    /// </summary>
    [TypeConverter(typeof(ShapeConverter))]
    public interface IHandShape : IShape
    {
        /// <summary>
        /// When implemented in a derived class, gets or sets the height of the hand from the pin to the top.
        /// </summary>
        float Height { get; set; }

        ///// <summary>
        ///// When implemented in a derived class, gets or sets the length of the tail.
        ///// </summary>
        //float TailLength { get; set; }
    }
}
