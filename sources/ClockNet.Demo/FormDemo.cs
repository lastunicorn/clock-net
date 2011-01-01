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
using System.Windows.Forms;
using DustInTheWind.Clock.TimeProviders;

namespace DustInTheWind.Clock.Demo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();
            comboBoxTimeProviders.Items.Add(new KeyValuePair<string, ITimeProvider>("Local Time Provider", new LocalTimeProvider()));
            comboBoxTimeProviders.Items.Add(new KeyValuePair<string, ITimeProvider>("UTC Time Provider", new UtcTimeProvider()));
            comboBoxTimeProviders.Items.Add(new KeyValuePair<string, ITimeProvider>("Offset UTC Time Provider", new UtcOffsetTimeProvider()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Timer
            numericUpDownTimerInterval.Value = timer1.Interval;

            // Value
            dateTimePickerTime.Value = DateTime.Now.Date.Add(analogClockDemo.Time);
            //dateTimePickerUtcOffset.Value = DateTime.Now.Date.Add(analogClock1.UtcOffset);

            // Timer
            checkBoxUseExternalTimer.Checked = analogClockDemo.Timer != null;

            // Time Provider
            propertyGridTimeProvider.SelectedObject = analogClockDemo.TimeProvider;

            // Miscellaneous

            // >> Background
            labelBackgroundColor.BackColor = analogClockDemo.BackColor;

            // >> Padding
            numericUpDownPaddingLeft.Value = analogClockDemo.Padding.Left;
            numericUpDownPaddingTop.Value = analogClockDemo.Padding.Top;
            numericUpDownPaddingRight.Value = analogClockDemo.Padding.Right;
            numericUpDownPaddingBottom.Value = analogClockDemo.Padding.Bottom;

            // >> Text
            textBoxText.Text = analogClockDemo.Text;
            //propertyGridText.SelectedObject = analogClock1.TextShape;

            // >> Font
            textBoxTextFont.Text = analogClockDemo.Font.ToString();

            // >> Keep Proportions
            checkBoxKeepProportions.Checked = analogClockDemo.KeepProportions;
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
            if (checkBoxUseExternalTimer.Checked)
            {
                analogClockDemo.Timer = timer1;
                timer1.Start();
            }
            else
            {
                analogClockDemo.Timer = null;
                timer1.Stop();
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

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            analogClockDemo.Text = textBoxText.Text;
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

        private void comboBoxTimeProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeProviders.SelectedItem != null)
            {
                analogClockDemo.TimeProvider = ((KeyValuePair<string, ITimeProvider>)comboBoxTimeProviders.SelectedItem).Value;
            }
            else
            {
                analogClockDemo.TimeProvider = null;
            }
        }

        private void analogClock1_TimeProviderChanged(object sender, EventArgs e)
        {
            propertyGridTimeProvider.SelectedObject = analogClockDemo.TimeProvider;
        }

        private void buttonExamples_Click(object sender, EventArgs e)
        {
            using (FormExamples form = new FormExamples())
            {
                form.ShowDialog();
            }
        }

        private void numericUpDownTimerInterval_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDownTimerInterval.Value;
        }
    }
}
