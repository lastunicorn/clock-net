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
    /// Converts <see cref="PointF"/> values to and from their string representation.
    /// </summary>
    public class PointFValueConverter : ValueConverterBase<PointF>
    {
        /// <summary>
        /// Serializes a <see cref="PointF"/> to its string representation.
        /// Format: "X,Y"
        /// </summary>
        /// <param name="value">The PointF to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(PointF value)
        {
            return string.Format("{0},{1}", value.X, value.Y);
        }

        /// <summary>
        /// Deserializes a string to a <see cref="PointF"/>.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized PointF.</returns>
        protected override PointF Deserialize(string serializedValue)
        {
            string[] parts = serializedValue.Split(',');

            float x = float.Parse(parts[0]);
            float y = float.Parse(parts[1]);

            return new PointF(x, y);
        }
    }
}
