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

using System.Drawing;

namespace DustInTheWind.ClockNet.Core.Serialization.Converters
{
    /// <summary>
    /// Converts <see cref="Color"/> values to and from their string representation.
    /// </summary>
    public class ColorValueConverter : ValueConverterBase<Color>
    {
        /// <summary>
        /// Serializes a <see cref="Color"/> to its string representation.
        /// Named colors are serialized by name; others are serialized as ARGB integer.
        /// </summary>
        /// <param name="value">The Color to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(Color value)
        {
            return value.IsNamedColor
                ? value.Name
                : value.ToArgb().ToString();
        }

        /// <summary>
        /// Deserializes a string to a <see cref="Color"/>.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized Color.</returns>
        protected override Color Deserialize(string serializedValue)
        {
            if (int.TryParse(serializedValue, out int argb))
                return Color.FromArgb(argb);

            return Color.FromName(serializedValue);
        }
    }
}
