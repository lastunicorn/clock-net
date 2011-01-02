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

namespace DustInTheWind.Clock
{
    public class TimeSpanEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService frmsvr = null;
            frmsvr = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (frmsvr != null)
            {
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

                using (NullableDateTimePicker dtp = new NullableDateTimePicker())
                {
                    dtp.Value = time;
                    dtp.DateTimePicker.Format = DateTimePickerFormat.Time;
                    dtp.DateTimePicker.ShowUpDown = true;
                    dtp.Width = 200;

                    frmsvr.DropDownControl(dtp);
                    if (dtp.IsNull)
                        value = (TimeSpan?)null;
                    else
                        value = (TimeSpan?)dtp.Value.Value.TimeOfDay;
                }
            }

            return value;
        }
    }
}
