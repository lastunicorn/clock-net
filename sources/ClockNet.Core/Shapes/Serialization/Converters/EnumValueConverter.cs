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

namespace DustInTheWind.ClockNet.Core.Shapes.Serialization.Converters
{
    /// <summary>
    /// Converts enum types to and from their string representation.
    /// </summary>
    public class EnumValueConverter : IValueConverter
    {
        /// <summary>
        /// Gets the type that this converter handles. Returns null as this converter handles multiple enum types.
        /// </summary>
        public Type TargetType => null;

        /// <summary>
        /// Determines whether this converter can handle the specified type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if the type is an enum; otherwise, <c>false</c>.</returns>
        public bool CanConvert(Type type)
        {
            return type.IsEnum;
        }

        /// <summary>
        /// Converts an enum value to its string representation.
        /// </summary>
        /// <param name="value">The enum value to convert.</param>
        /// <returns>The string representation of the enum value.</returns>
        public string ConvertToString(object value)
        {
            return value?.ToString();
        }

        /// <summary>
        /// Converts a string representation back to the enum value.
        /// </summary>
        /// <param name="serializedValue">The string representation.</param>
        /// <param name="targetType">The enum type to convert to.</param>
        /// <returns>The deserialized enum value.</returns>
        public object ConvertFromString(string serializedValue, Type targetType)
        {
            if (serializedValue == null)
                return null;

            return Enum.Parse(targetType, serializedValue);
        }
    }
}
