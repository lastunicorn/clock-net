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

namespace DustInTheWind.ClockNet.Shapes
{
    /// <summary>
    /// An attribute that uniquely identifies a shape class.
    /// This attribute should be applied to all instantiable (non-abstract) shape classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ShapeAttribute : Attribute
    {
        /// <summary>
        /// Gets the unique identifier for the shape type.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeAttribute"/> class.
        /// </summary>
        /// <param name="id">A string representation of the GUID that uniquely identifies this shape type.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="id"/> is not a valid GUID format.</exception>
        public ShapeAttribute(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Id = Guid.Parse(id);
        }
    }
}
