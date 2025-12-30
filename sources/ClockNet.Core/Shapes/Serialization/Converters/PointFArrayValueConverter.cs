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
using System.Linq;

namespace DustInTheWind.ClockNet.Core.Shapes.Serialization.Converters
{
    /// <summary>
    /// Converts <see cref="PointF"/> array values to and from their string representation.
    /// </summary>
    public class PointFArrayValueConverter : ValueConverterBase<PointF[]>
    {
        /// <summary>
        /// Serializes a <see cref="PointF"/> array to its string representation.
        /// Format: "X1,Y1;X2,Y2;..."
        /// </summary>
        /// <param name="value">The PointF array to serialize.</param>
        /// <returns>The string representation.</returns>
        protected override string Serialize(PointF[] value)
        {
            if (value == null || value.Length == 0)
                return string.Empty;

            return string.Join(";", value.Select(x => string.Format("{0},{1}", x.X, x.Y)));
        }

        /// <summary>
        /// Deserializes a string to a <see cref="PointF"/> array.
        /// </summary>
        /// <param name="serializedValue">The string to deserialize.</param>
        /// <returns>The deserialized PointF array.</returns>
        protected override PointF[] Deserialize(string serializedValue)
        {
            if (string.IsNullOrEmpty(serializedValue))
                return new PointF[0];

            string[] pointStrings = serializedValue.Split(';');

            return pointStrings
                .Select(x =>
                {
                    string[] parts = x.Split(',');
                    return new PointF(float.Parse(parts[0]), float.Parse(parts[1]));
                })
                .ToArray();
        }
    }
}
