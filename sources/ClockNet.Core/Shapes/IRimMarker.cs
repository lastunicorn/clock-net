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
using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Shapes
{
    /// <summary>
    /// Represents a <see cref="IShape"/> that is drawn repeatedly around the dial at equal angles between instances.
    /// The angles are measured from the 12 o'clock hour. The clock decides the angle and then asks the <see cref="IShape"/> to draw itself.
    /// The first shape is drawn in the first position after the 12 o'clock hour. The 12 o'clock hour position is drawn last.
    /// </summary>
    public interface IRimMarker : IShape
    {
        /// <summary>
        /// Gets or sets the angle at which the shape should be drawn.
        /// </summary>
        float Angle { get; set; }

        /// <summary>
        /// Gets or sets a value specifying if the shape should be repeated or it is drawn a single time.
        /// </summary>
        bool Repeat { get; set; }

        /// <summary>
        /// Gets or sets the index of the shape that will be drawn next.
        /// This value is automatically incremented after a call of the <see cref="IShape.Draw(Graphics)"/> method.
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Resets the rendering series. The <see cref="Index"/> is set ot sero.
        /// This method is called by the clock before the paint starts.
        /// </summary>
        void Reset();
    }
}
