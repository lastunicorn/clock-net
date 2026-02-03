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
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    ///  Provides a type converter to convert <see cref="PointF"/> to and from string representation.
    /// </summary>
    public class PointFConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] v = ((string)value).Split(new char[] { ';' });
                return new PointF(float.Parse(v[0], culture), float.Parse(v[1], culture));
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            //if (destinationType == typeof(InstanceDescriptor))
            //    return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((PointF)value).X + ";" + ((PointF)value).Y;
            }

            //if (destinationType == typeof(InstanceDescriptor) && value is PointF)
            //{
            //    PointF pt = (PointF)value;

            //    ConstructorInfo ctor = typeof(PointF).GetConstructor(new Type[] { typeof(float), typeof(float) });
            //    if (ctor != null)
            //    {
            //        return new InstanceDescriptor(ctor, new object[] { pt.X, pt.Y });
            //    }
            //}

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
