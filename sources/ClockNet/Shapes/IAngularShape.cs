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

namespace DustInTheWind.Clock.Shapes
{
    /// <summary>
    /// Represents a shape that is drawn repeatedly at different angles on the clock.
    /// The angles are measured from the 12 o'clock hour. The decides the angle and then asks the shape to draw itself.
    /// The first shape is drawn in the first position after the 12 o'clock hour. The 12 o'clock hour position is drawn last.
    /// </summary>
    public interface IAngularShape : IShape
    {
        /// <summary>
        /// Gets or sets the angle at which the shape should be drawn.
        /// </summary>
        float Angle { get; set; }

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated at regular angle intervals.
        /// </summary>
        bool Repeat { get; set; }

        /// <summary>
        /// Gets or sets the index of the shape that will be drawn next.
        /// This value is automatically incremented after a coll of the <see cref="Draw"/> method.
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Resets the index of the shape that will be drawn next.
        /// This method is called by the clock before every paint.
        /// </summary>
        void Reset();
    }
}
