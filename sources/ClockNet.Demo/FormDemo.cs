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
using System.Reflection;
using System.Windows.Forms;
using DustInTheWind.ClockNet.Core.TimeProviders;
using DustInTheWind.ClockNet.Templates;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();

            nullableDateTimePickerUtcOffset.DateTimePicker.Format = DateTimePickerFormat.Time;
            nullableDateTimePickerUtcOffset.DateTimePicker.ShowUpDown = true;

            comboBoxClockTemplates.Items.Add(typeof(DefaultTemplate));
            comboBoxClockTemplates.Items.Add(typeof(BlackTemplate));
            comboBoxClockTemplates.Items.Add(typeof(BlueTemplate));
            comboBoxClockTemplates.Items.Add(typeof(PandaTemplate));
            comboBoxClockTemplates.Items.Add(typeof(FancyTemplate));
            comboBoxClockTemplates.Items.Add(typeof(WhiteFancyTemplate));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Time Value
            dateTimePickerTime.Value = DateTime.Now.Date.Add(analogClockDemo.Time);
            
            TimeSpan? utcOffset = GetUtcOffsetFromTimeProvider();
            nullableDateTimePickerUtcOffset.Value = utcOffset == null
                ? (DateTime?)null
                : DateTime.Now.Date.Add(utcOffset.Value);
            checkBoxTimeProviderPresent.Checked = analogClockDemo.TimeProvider != null;

            // Timer
            checkBoxUseExternalTimer.Checked = analogClockDemo.TimeProvider != null && analogClockDemo.TimeProvider.IsRunning;

            // Miscellaneous

            labelBackgroundColor.BackColor = analogClockDemo.BackColor;

            numericUpDownPaddingLeft.Value = analogClockDemo.Padding.Left;
            numericUpDownPaddingTop.Value = analogClockDemo.Padding.Top;
            numericUpDownPaddingRight.Value = analogClockDemo.Padding.Right;
            numericUpDownPaddingBottom.Value = analogClockDemo.Padding.Bottom;

            textBoxTextFont.Text = analogClockDemo.Font.ToString();

            checkBoxKeepProportions.Checked = analogClockDemo.KeepProportions;

            // Backgrounds
            backgroundsEditor1.AnalogClock = analogClockDemo;

            // Rim Markers
            rimMarkersEditor1.AnalogClock = analogClockDemo;

            // Hands
            handsEditor1.AnalogClock = analogClockDemo;

            // Time Provider
            timeProvidersEditor1.AnalogClock = analogClockDemo;
        }

        private TimeSpan? GetUtcOffsetFromTimeProvider()
        {
            if (analogClockDemo.TimeProvider is UtcTimeProvider utcTimeProvider)
                return utcTimeProvider.UtcOffset;
            return null;
        }

        private void labelBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelBackgroundColor.BackColor = colorDialog1.Color;
                analogClockDemo.BackColor = colorDialog1.Color;
            }
        }

        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.Time = dateTimePickerTime.Value.TimeOfDay;
        }

        private void checkBoxUseExternalTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (analogClockDemo.TimeProvider == null)
                return;

            if (checkBoxUseExternalTimer.Checked)
            {
                analogClockDemo.TimeProvider.Start();
            }
            else
            {
                analogClockDemo.TimeProvider.Stop();
            }
        }

        private void numericUpDownPaddingLeft_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingTop_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingRight_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingBottom_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void checkBoxKeepProportions_CheckedChanged(object sender, EventArgs e)
        {
            analogClockDemo.KeepProportions = checkBoxKeepProportions.Checked;
        }

        private void buttonBrowseTextFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = analogClockDemo.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxTextFont.Text = fontDialog1.Font.ToString();
                analogClockDemo.Font = fontDialog1.Font;
            }
        }

        private void buttonExamples_Click(object sender, EventArgs e)
        {
            using (FormExamples form = new FormExamples())
                form.ShowDialog();
        }

        private void dateTimePickerUtcOffset_ValueChanged(object sender, EventArgs e)
        {
            if (analogClockDemo.TimeProvider is UtcTimeProvider utcTimeProvider)
            {
                utcTimeProvider.UtcOffset = nullableDateTimePickerUtcOffset.Value == null 
                    ? TimeSpan.Zero 
                    : nullableDateTimePickerUtcOffset.Value.Value.TimeOfDay;
            }
        }

        private void comboBoxClockTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClockTemplates.SelectedItem != null)
            {
                Type type = (Type)comboBoxClockTemplates.SelectedItem;

                ConstructorInfo constructorInfo = type.GetConstructor(new Type[0]);
                TemplateBase clockTemplate = (TemplateBase)constructorInfo.Invoke(null);

                if (clockTemplate != null)
                    analogClockDemo.ApplyTemplate(clockTemplate);
            }
        }

        private void analogClockDemo_TimeProviderChanged(object sender, EventArgs e)
        {
            checkBoxTimeProviderPresent.Checked = analogClockDemo.TimeProvider != null;
            nullableDateTimePickerUtcOffset.Enabled = analogClockDemo.TimeProvider is UtcTimeProvider;
            checkBoxUseExternalTimer.Checked = analogClockDemo.TimeProvider != null && analogClockDemo.TimeProvider.IsRunning;
        }
    }
}
