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
using DustInTheWind.Clock.Shapes;

namespace DustInTheWind.Clock
{
    /// <summary>
    /// Provides data for <see cref="AnalogClock.BackgroundShapeAdded"/> and <see cref="AnalogClock.AngularShapeAdded"/> events.
    /// </summary>
    public class ShapeAddedEventArgs : EventArgs
    {
        /// <summary>
        /// The index where the Shape was added into the list.
        /// </summary>
        private int index;

        /// <summary>
        /// Gets the index where the Shape was added into the list.
        /// </summary>
        public int Index
        {
            get { return index; }
        }

        /// <summary>
        /// The Shape that was added to the list.
        /// </summary>
        private IShape shape;

        /// <summary>
        /// Gets the Shape that was added to the list.
        /// </summary>
        public IShape Shape
        {
            get { return shape; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeAddedEventArgs"/> class.
        /// </summary>
        /// <param name="index">The index where the Shape was added into the list.</param>
        /// <param name="shape">The Shape that was added to the list.</param>
        public ShapeAddedEventArgs(int index, IShape shape)
        {
            this.index = index;
            this.shape = shape;
        }
    }
}
