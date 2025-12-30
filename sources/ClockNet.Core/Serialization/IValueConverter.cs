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

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Defines methods for converting values to and from their serialized string representation.
    /// </summary>
    public interface IValueConverter
    {
        /// <summary>
        /// Gets the type that this converter handles.
        /// </summary>
        Type TargetType { get; }

        /// <summary>
        /// Determines whether this converter can handle the specified type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><c>true</c> if this converter can handle the type; otherwise, <c>false</c>.</returns>
        bool CanConvert(Type type);

        /// <summary>
        /// Converts an object value to its string representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The string representation of the value.</returns>
        string ConvertToString(object value);

        /// <summary>
        /// Converts a string representation back to the object value.
        /// </summary>
        /// <param name="serializedValue">The string representation.</param>
        /// <param name="targetType">The target type to convert to.</param>
        /// <returns>The deserialized object value.</returns>
        object ConvertFromString(string serializedValue, Type targetType);
    }
}
