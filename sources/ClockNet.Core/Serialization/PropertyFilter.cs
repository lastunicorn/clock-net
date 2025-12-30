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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace DustInTheWind.ClockNet.Core.Serialization
{
    /// <summary>
    /// Determines which properties should be included or excluded during serialization.
    /// </summary>
    public class PropertyFilter
    {
        private readonly HashSet<string> excludedPropertyNames = new HashSet<string>
        {
            "Changed",
            "Disposed"
        };

        private readonly HashSet<Type> excludedPropertyTypes = new HashSet<Type>
        {
            typeof(EventHandler),
            typeof(Brush),
            typeof(Pen),
            typeof(Graphics),
            typeof(GraphicsPath)
        };

        /// <summary>
        /// Gets the default instance of the property filter.
        /// </summary>
        public static PropertyFilter Default { get; } = new PropertyFilter();

        /// <summary>
        /// Determines whether the specified property should be serialized.
        /// </summary>
        /// <param name="propertyInfo">The property to evaluate.</param>
        /// <returns><c>true</c> if the property should be serialized; otherwise, <c>false</c>.</returns>
        public bool ShouldSerialize(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                return false;

            if (!propertyInfo.CanRead || !propertyInfo.CanWrite)
                return false;

            if (excludedPropertyNames.Contains(propertyInfo.Name))
                return false;

            if (excludedPropertyTypes.Contains(propertyInfo.PropertyType))
                return false;

            return true;
        }

        /// <summary>
        /// Adds a property name to the exclusion list.
        /// </summary>
        /// <param name="propertyName">The property name to exclude.</param>
        public void ExcludeProperty(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
                excludedPropertyNames.Add(propertyName);
        }

        /// <summary>
        /// Adds a property type to the exclusion list.
        /// </summary>
        /// <param name="type">The type to exclude.</param>
        public void ExcludeType(Type type)
        {
            if (type != null)
                excludedPropertyTypes.Add(type);
        }
    }
}
