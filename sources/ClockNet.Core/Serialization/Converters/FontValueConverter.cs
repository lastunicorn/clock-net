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
using System.Drawing;
using System.Globalization;

namespace DustInTheWind.ClockNet.Core.Serialization.Converters
{
    /// <summary>
    /// Converts <see cref="Font"/> values to and from their string representation.
    /// </summary>
    public class FontValueConverter : ValueConverterBase<Font>
    {
        /// <summary>
        /// Serializes a <see cref="Font"/> to its string representation.
        /// Format: "FontFamily,Size,Style"
        /// </summary>
        /// <param name="value">The Font to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(Font value)
        {
            string familyName = value.FontFamily.Name;
            float size = value.Size;
            FontStyle style = value.Style;

            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", familyName, size, style);
        }

        /// <summary>
        /// Deserializes a string to a <see cref="Font"/>.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized Font.</returns>
        protected override Font Deserialize(string serializedValue)
        {
            string[] parts = serializedValue.Split(',');

            string fontFamily = parts[0];
            float size = float.Parse(parts[1], CultureInfo.InvariantCulture);
            FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), parts[2]);

            return new Font(fontFamily, size, style);
        }
    }
}
