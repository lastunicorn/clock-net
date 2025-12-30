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

namespace DustInTheWind.ClockNet.Core.Shapes.Serialization.Converters
{
    /// <summary>
    /// Converts <see cref="RectangleF"/> values to and from their string representation.
    /// </summary>
    public class RectangleFValueConverter : ValueConverterBase<RectangleF>
    {
        /// <summary>
        /// Serializes a <see cref="RectangleF"/> to its string representation.
        /// Format: "X,Y,Width,Height"
        /// </summary>
        /// <param name="value">The RectangleF to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(RectangleF value)
        {
            return string.Format("{0},{1},{2},{3}", value.X, value.Y, value.Width, value.Height);
        }

        /// <summary>
        /// Deserializes a string to a <see cref="RectangleF"/>.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized RectangleF.</returns>
        protected override RectangleF Deserialize(string serializedValue)
        {
            string[] parts = serializedValue.Split(',');

            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);
            float width = float.Parse(parts[2]);
            float height = float.Parse(parts[3]);

            return new RectangleF(x, y, width, height);
        }
    }
}
