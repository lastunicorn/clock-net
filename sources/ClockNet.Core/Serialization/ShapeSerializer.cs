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
using System.Collections.Generic;
using System.Reflection;

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Provides serialization and deserialization capabilities for shape objects.
    /// </summary>
    public class ShapeSerializer
    {
        private readonly ValueConverterRegistry converterRegistry;
        private readonly PropertyFilter propertyFilter;

        /// <summary>
        /// Gets the default instance using the default converter registry and property filter.
        /// </summary>
        public static ShapeSerializer Default { get; } = new ShapeSerializer(ValueConverterRegistry.Default, PropertyFilter.Default);

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeSerializer"/> class.
        /// </summary>
        /// <param name="converterRegistry">The registry of value converters to use.</param>
        /// <param name="propertyFilter">The property filter to determine which properties to serialize.</param>
        public ShapeSerializer(ValueConverterRegistry converterRegistry, PropertyFilter propertyFilter)
        {
            this.converterRegistry = converterRegistry ?? throw new ArgumentNullException(nameof(converterRegistry));
            this.propertyFilter = propertyFilter ?? throw new ArgumentNullException(nameof(propertyFilter));
        }

        /// <summary>
        /// Serializes the properties of a shape into a dictionary.
        /// </summary>
        /// <param name="shape">The shape to serialize.</param>
        /// <returns>A dictionary containing the serialized property names and values.</returns>
        public Dictionary<string, string> SerializeProperties(object shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Dictionary<string, string> properties = new Dictionary<string, string>();
            Type shapeType = shape.GetType();
            PropertyInfo[] propertyInfos = shapeType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!propertyFilter.ShouldSerialize(propertyInfo))
                    continue;

                object value = propertyInfo.GetValue(shape);

                if (value != null)
                {
                    string serializedValue = converterRegistry.ConvertToString(value);

                    if (serializedValue != null)
                        properties[propertyInfo.Name] = serializedValue;
                }
            }

            return properties;
        }

        /// <summary>
        /// Deserializes properties from a dictionary and applies them to a shape.
        /// </summary>
        /// <param name="shape">The shape to apply the properties to.</param>
        /// <param name="properties">The dictionary of property names and serialized values.</param>
        public void DeserializeProperties(object shape, Dictionary<string, string> properties)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            if (properties == null)
                return;

            Type shapeType = shape.GetType();

            foreach (KeyValuePair<string, string> kvp in properties)
            {
                string propertyName = kvp.Key;
                string serializedValue = kvp.Value;

                PropertyInfo propertyInfo = shapeType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo == null || !propertyInfo.CanWrite)
                    continue;

                try
                {
                    object value = converterRegistry.ConvertFromString(serializedValue, propertyInfo.PropertyType);
                    propertyInfo.SetValue(shape, value);
                }
                catch
                {
                    // Skip properties that fail to deserialize
                }
            }
        }
    }
}
