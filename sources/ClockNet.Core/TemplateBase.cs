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


using System.Collections.Generic;
using System.Linq;
using DustInTheWind.ClockNet.Core.Shapes;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Keeps a collection of Shapes that can be applied to the <see cref="AnalogClock"/> all at once.
    /// </summary>
    public abstract class TemplateBase
    {
        /// <summary>
        /// Gets or sets the array of Shapes.
        /// </summary>
        public List<IShape> Shapes { get; }

        protected TemplateBase()
        {
            Shapes = EnumerateShapes().ToList();
        }

        /// <summary>
        /// When implemented in a derived class, returns an enumerable collection of shapes to initialize the current template.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{IShape}"/> containing the available shapes. The collection may be empty
        /// if no shapes are defined.</returns>
        protected abstract IEnumerable<IShape> EnumerateShapes();
    }
}
