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
using DustInTheWind.ClockNet.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides data for <see cref="AnalogClock.BackgroundShapeRemoved"/> and <see cref="AnalogClock.AngularShapeRemoved"/> events.
    /// </summary>
    public class ShapeRemovedEventArgs : EventArgs
    {
        /// <summary>
        /// The Shape that was removed from the list.
        /// </summary>
        private IShape shape;

        /// <summary>
        /// Gets the Shape that was removed from the list.
        /// </summary>
        public IShape Shape
        {
            get { return shape; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeRemovedEventArgs"/> class.
        /// </summary>
        /// <param name="shape">The Shape that was removed from the list.</param>
        public ShapeRemovedEventArgs(IShape shape)
        {
            this.shape = shape;
        }
    }
}
