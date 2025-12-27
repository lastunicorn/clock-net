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
using System.Windows.Forms.Design;
using DustInTheWind.ClockNet.Templates;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides design time behavior for the <see cref="AnalogClock"/> control.
    /// </summary>
    public class AnalogClockDesigner : ControlDesigner
    {
        /// <summary>
        /// Initializes the <see cref="AnalogClock"/> control.
        /// </summary>
        /// <param name="defaultValues"></param>
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            DescribeSizeProperty();
            DescribeTimeProperty();

            DefaultTemplate defaultTemplate = new DefaultTemplate();
            (Component as AnalogClock).ApplyTemplate(defaultTemplate);
        }

        private void DescribeSizeProperty()
        {
            PropertyDescriptor sizeDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Size)];

            if (sizeDescriptor != null && sizeDescriptor.PropertyType == typeof(Size) && !sizeDescriptor.IsReadOnly && sizeDescriptor.IsBrowsable)
            {
                sizeDescriptor.SetValue(Component, new Size(250, 250));
            }
        }

        private void DescribeTimeProperty()
        {
            PropertyDescriptor timeDescriptor = TypeDescriptor.GetProperties(Component)[nameof(AnalogClock.Time)];

            if (timeDescriptor != null && timeDescriptor.PropertyType == typeof(TimeSpan) && !timeDescriptor.IsReadOnly && timeDescriptor.IsBrowsable)
            {
                timeDescriptor.SetValue(Component, TimeSpan.Zero);
            }
        }
    }
}
