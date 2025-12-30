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

using System.Linq;

namespace DustInTheWind.ClockNet.Core.Serialization.Converters
{
    /// <summary>
    /// Converts string array values to and from their string representation.
    /// </summary>
    public class StringArrayValueConverter : ValueConverterBase<string[]>
    {
        /// <summary>
        /// Serializes a string array to its string representation.
        /// Format: "value1;value2;..."
        /// </summary>
        /// <param name="value">The string array to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(string[] value)
        {
            if (value == null || value.Length == 0)
                return string.Empty;

            return string.Join(";", value);
        }

        /// <summary>
        /// Deserializes a string to a string array.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized string array.</returns>
        protected override string[] Deserialize(string serializedValue)
        {
            if (string.IsNullOrEmpty(serializedValue))
                return new string[0];

            return serializedValue.Split(';');
        }
    }
}
