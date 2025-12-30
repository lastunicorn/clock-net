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

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Defines methods for serializing and deserializing the properties of a shape.
    /// </summary>
    public interface ISerializable
    {
        /// <summary>
        /// Serializes the properties of the shape into a dictionary of string key-value pairs.
        /// </summary>
        /// <returns>A dictionary containing the serialized property names and their values.</returns>
        Dictionary<string, string> Serialize();

        /// <summary>
        /// Deserializes the shape properties from a dictionary of string key-value pairs.
        /// </summary>
        /// <param name="properties">A dictionary containing the property names and their serialized values.</param>
        void Deserialize(Dictionary<string, string> properties);
    }
}
