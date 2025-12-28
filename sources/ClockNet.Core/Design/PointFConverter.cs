// ClockControl
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace DustInTheWind.ClockNet.Core.Design
{
    public class PointFConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string text)
            {
                string[] parts = text.Split(culture.TextInfo.ListSeparator[0]);

                if (parts.Length == 2)
                {
                    float x = float.Parse(parts[0].Trim(), culture);
                    float y = float.Parse(parts[1].Trim(), culture);

                    return new PointF(x, y);
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is PointF point)
            {
                if (destinationType == typeof(string))
                {
                    string separator = culture.TextInfo.ListSeparator + " ";
                    return string.Join(separator, point.X, point.Y);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    System.Reflection.ConstructorInfo ctor = typeof(PointF).GetConstructor(new[] { typeof(float), typeof(float) });
                    return new InstanceDescriptor(ctor, new object[] { point.X, point.Y });
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(PointF), attributes);
            return properties.Sort(new[] { "X", "Y" });
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            float x = (float)propertyValues["X"];
            float y = (float)propertyValues["Y"];

            return new PointF(x, y);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
