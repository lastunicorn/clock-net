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
using DustInTheWind.ClockNet.Core.Serialization.Converters;

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Manages a collection of value converters and provides methods to convert values to and from strings.
    /// </summary>
    public class ValueConverterRegistry
    {
        private readonly List<IValueConverter> converters = new List<IValueConverter>();

        /// <summary>
        /// Gets the default instance of the registry with all standard converters registered.
        /// </summary>
        public static ValueConverterRegistry Default { get; } = CreateDefault();

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueConverterRegistry"/> class.
        /// </summary>
        public ValueConverterRegistry()
        {
        }

        /// <summary>
        /// Creates the default registry with all standard converters.
        /// </summary>
        /// <returns>A new registry with standard converters registered.</returns>
        private static ValueConverterRegistry CreateDefault()
        {
            ValueConverterRegistry registry = new ValueConverterRegistry();

            registry.Register(new PrimitiveValueConverter());
            registry.Register(new EnumValueConverter());
            registry.Register(new TimeSpanValueConverter());
            registry.Register(new ColorValueConverter());
            registry.Register(new PointFValueConverter());
            registry.Register(new SizeFValueConverter());
            registry.Register(new RectangleFValueConverter());
            registry.Register(new FontValueConverter());
            registry.Register(new PointFArrayValueConverter());
            registry.Register(new StringArrayValueConverter());

            return registry;
        }

        /// <summary>
        /// Registers a converter with the registry.
        /// </summary>
        /// <param name="converter">The converter to register.</param>
        public void Register(IValueConverter converter)
        {
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));

            converters.Add(converter);
        }

        /// <summary>
        /// Gets a converter that can handle the specified type.
        /// </summary>
        /// <param name="type">The type to find a converter for.</param>
        /// <returns>A converter that can handle the type, or <c>null</c> if none is found.</returns>
        public IValueConverter GetConverter(Type type)
        {
            foreach (IValueConverter converter in converters)
            {
                if (converter.CanConvert(type))
                    return converter;
            }

            return null;
        }

        /// <summary>
        /// Converts a value to its string representation using the appropriate converter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The string representation, or <c>null</c> if no converter is found.</returns>
        public string ConvertToString(object value)
        {
            if (value == null)
                return null;

            Type valueType = value.GetType();
            IValueConverter converter = GetConverter(valueType);

            if (converter != null)
                return converter.ConvertToString(value);

            return value.ToString();
        }

        /// <summary>
        /// Converts a string representation to a value of the specified type.
        /// </summary>
        /// <param name="serializedValue">The string representation.</param>
        /// <param name="targetType">The target type to convert to.</param>
        /// <returns>The deserialized value, or the original string if no converter is found.</returns>
        public object ConvertFromString(string serializedValue, Type targetType)
        {
            if (serializedValue == null)
                return null;

            IValueConverter converter = GetConverter(targetType);

            if (converter != null)
                return converter.ConvertFromString(serializedValue, targetType);

            return serializedValue;
        }
    }
}
