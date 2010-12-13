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


            // Hour Hand
            checkBoxIntegralHours.Checked = analogClock1.IntegralHour;
            propertyGridHourHand.SelectedObject = analogClock1.HourHandShape;

            // Minute Hand
            checkBoxIntegralMinutes.Checked = analogClock1.IntegralMinute;
            propertyGridMinuteHand.SelectedObject = analogClock1.MinuteHandShape;

            // Sweep Hand
            checkBoxIntegralSeconds.Checked = analogClock1.IntegralSecond;
            propertyGridSweepHand.SelectedObject = analogClock1.SweepHandShape;

            // Ticks 1
            propertyGridTicks1.SelectedObject = analogClock1.Ticks1Shape;

            // Ticks 5
            propertyGridTicks5.SelectedObject = analogClock1.Ticks5Shape;

            // Value
            dateTimePickerTime.Value = DateTime.Now.Date.Add(analogClock1.Time);
            //dateTimePickerUtcOffset.Value = DateTime.Now.Date.Add(analogClock1.UtcOffset);

            // Timer
            checkBoxUseExternalTimer.Checked = analogClock1.Timer != null;

            // Numbers
            propertyGridNumbers.SelectedObject = analogClock1.NumbersShape;

            // Pin
            propertyGridPin.SelectedObject = analogClock1.PinShape;

            // Time Provider
            propertyGridTimeProvider.SelectedObject = analogClock1.TimeProvider;

            // Miscellaneous

            // >> Background
            labelBackgroundColor.BackColor = analogClock1.BackColor;

            // >> Padding
            numericUpDownPaddingLeft.Value = analogClock1.Padding.Left;
            numericUpDownPaddingTop.Value = analogClock1.Padding.Top;
            numericUpDownPaddingRight.Value = analogClock1.Padding.Right;
            numericUpDownPaddingBottom.Value = analogClock1.Padding.Bottom;

            // >> Text
            textBoxText.Text = analogClock1.Text;

            // >> Font
            textBoxTextFont.Text = analogClock1.Font.ToString();

            // >> Keep Proportions
            checkBoxKeepProportions.Checked = analogClock1.KeepProportions;
        }

        private void labelBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                labelBackgroundColor.BackColor = colorDialog1.Color;
                analogClock1.BackColor = colorDialog1.Color;
            }
        }

        private void checkBoxIntegralHours_CheckedChanged(object sender, EventArgs e)
        {
            analogClock1.IntegralHour = checkBoxIntegralHours.Checked;
        }

        private void checkBoxIntegralMinutes_CheckedChanged(object sender, EventArgs e)
        {
            analogClock1.IntegralMinute = checkBoxIntegralMinutes.Checked;
        }

        private void checkBoxIntegralSeconds_CheckedChanged(object sender, EventArgs e)
        {
            analogClock1.IntegralSecond = checkBoxIntegralSeconds.Checked;
        }

        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            analogClock1.Time = dateTimePickerTime.Value.TimeOfDay;
        }

        private void checkBoxUseExternalTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseExternalTimer.Checked)
            {
                analogClock1.Timer = timer1;
                timer1.Start();
            }
            else
            {
                analogClock1.Timer = null;
                timer1.Stop();
            }
        }

        private void numericUpDownPaddingLeft_ValueChanged(object sender, EventArgs e)
        {
            analogClock1.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingTop_ValueChanged(object sender, EventArgs e)
        {
            analogClock1.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingRight_ValueChanged(object sender, EventArgs e)
        {
            analogClock1.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void numericUpDownPaddingBottom_ValueChanged(object sender, EventArgs e)
        {
            analogClock1.Padding = new Padding(
                (int)numericUpDownPaddingLeft.Value,
                (int)numericUpDownPaddingTop.Value,
                (int)numericUpDownPaddingRight.Value,
                (int)numericUpDownPaddingBottom.Value);
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            analogClock1.Text = textBoxText.Text;
        }

        private void checkBoxKeepProportions_CheckedChanged(object sender, EventArgs e)
        {
            analogClock1.KeepProportions = checkBoxKeepProportions.Checked;
        }

        private void buttonBrowseTextFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = analogClock1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxTextFont.Text = fontDialog1.Font.ToString();
                analogClock1.Font = fontDialog1.Font;
            }
        }

        private void comboBoxTimeProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeProviders.SelectedItem != null)
            {
                analogClock1.TimeProvider = ((KeyValuePair<string, ITimeProvider>)comboBoxTimeProviders.SelectedItem).Value;
            }
            else
            {
                analogClock1.TimeProvider = null;
            }
        }

        private void analogClock1_TimeProviderChanged(object sender, EventArgs e)
        {
            propertyGridTimeProvider.SelectedObject = analogClock1.TimeProvider;
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
