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
    /// Represents a graphic element displayed in the <see cref="AnalogClock"/>.
    /// </summary>
    [TypeConverter(typeof(ShapeConverter))]
    public interface IShape : IComponent //, IDisposable
    {
        /// <summary>
        /// An user friendly name. Used only to be displayed to the user. Does not influence the way the shape is rendered.
        /// </summary>
        [Browsable(false)]
        string Name { get; }

        /// <summary>
        /// Gets or sets a value specifying if the shape should be drawn or not.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Event raised when the shape's parameters are changed and it should be redrawn.
        /// </summary>
        event EventHandler Changed;

        /// <summary>
        /// Draws the shape using the provided <see cref="Graphics"/> object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> on which to draw the shape.</param>
        void Draw(Graphics g);
    }
}
