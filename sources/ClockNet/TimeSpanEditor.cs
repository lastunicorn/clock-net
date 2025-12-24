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
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DustInTheWind.ClockNet
{
    /// <summary>
    /// Provides an UI for editing <see cref="TimeSpan"/> and a nullable TimeSpan values.
    /// </summary>
    public class TimeSpanEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService == null)
                return value;

            DateTime? time;

            if (value == null)
            {
                time = null;
            }
            else if (value.GetType() == typeof(TimeSpan?))
            {
                time = DateTime.Today.Add(((TimeSpan?)value).Value);
            }
            else if (value.GetType() == typeof(TimeSpan))
            {
                time = DateTime.Today.Add((TimeSpan)value);
            }
            else
            {
                return value;
            }

            using (NullableDateTimePicker nullableDateTimePicker = new NullableDateTimePicker())
            {
                nullableDateTimePicker.Value = time;
                nullableDateTimePicker.DateTimePicker.Format = DateTimePickerFormat.Time;
                nullableDateTimePicker.DateTimePicker.ShowUpDown = true;
                nullableDateTimePicker.Width = 200;

                editorService.DropDownControl(nullableDateTimePicker);

                if (nullableDateTimePicker.IsNull)
                    value = (TimeSpan?)null;
                else
                    value = (TimeSpan?)nullableDateTimePicker.Value.Value.TimeOfDay;
            }

            return value;
        }
    }
}
