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
using DustInTheWind.ClockNet.Shapes;
using DustInTheWind.ClockNet.Shapes.Advanced;
using DustInTheWind.ClockNet.Shapes.Basic;
using DustInTheWind.ClockNet.Templates;
using DustInTheWind.ClockNet.TimeProviders;

namespace DustInTheWind.ClockNet.Demo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();

            nullableDateTimePickerUtcOffset.DateTimePicker.Format = DateTimePickerFormat.Time;
            nullableDateTimePickerUtcOffset.DateTimePicker.ShowUpDown = true;

            comboBoxTimeProviders.Items.Add("(none)");
            comboBoxTimeProviders.Items.Add(typeof(LocalTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(UtcTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(BrokenTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(RandomTimeProvider));

            listBoxHandsAvailable.Items.AddRange(new Type[] {
                typeof(LineHand),
                typeof(PolygonHand),
                typeof(RectangleHand),
                typeof(EllipseHand),
                typeof(PathHand),
                typeof(ImageHand),
                typeof(DiamondHand),
                typeof(DigitalHand),
                typeof(Pin),
                typeof(DotHand),
                typeof(FancySweepHand),
                typeof(NibHand),
                typeof(SlotHand)
            });

            comboBoxClockTemplates.Items.Add(typeof(DefaultClockTemplate));
            comboBoxClockTemplates.Items.Add(typeof(BlackClockTemplate));
            comboBoxClockTemplates.Items.Add(typeof(BlueClockTemplate));
            comboBoxClockTemplates.Items.Add(typeof(DotsClockTemplate));
            comboBoxClockTemplates.Items.Add(typeof(FancyClockTemplate));
            comboBoxClockTemplates.Items.Add(typeof(WhiteFancyClockTemplate));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Timer
            numericUpDownTimerInterval.Value = timer1.Interval;

            // Time Value
            dateTimePickerTime.Value = DateTime.Now.Date.Add(analogClockDemo.Time);
            nullableDateTimePickerUtcOffset.Value = analogClockDemo.UtcOffset == null
                ? (DateTime?)null
                : DateTime.Now.Date.Add(analogClockDemo.UtcOffset.Value);
            checkBoxTimeProviderPresent.Checked = analogClockDemo.TimeProvider != null;

            // Timer
            checkBoxUseExternalTimer.Checked = analogClockDemo.Timer != null;

            // Miscellaneous

            // >> Background
            labelBackgroundColor.BackColor = analogClockDemo.BackColor;

            // >> Padding
            numericUpDownPaddingLeft.Value = analogClockDemo.Padding.Left;
            numericUpDownPaddingTop.Value = analogClockDemo.Padding.Top;
            numericUpDownPaddingRight.Value = analogClockDemo.Padding.Right;
            numericUpDownPaddingBottom.Value = analogClockDemo.Padding.Bottom;

            // >> Font
            textBoxTextFont.Text = analogClockDemo.Font.ToString();

            // >> Keep Proportions
            checkBoxKeepProportions.Checked = analogClockDemo.KeepProportions;

            // Background Shapes
            backgroundsEditor1.AnalogClock = analogClockDemo;

            // Angular Shapes
            rimMarkersEditor1.AnalogClock = analogClockDemo;

            // Hand Shapes
            foreach (IHand shape in analogClockDemo.Hands)
            {
                listBoxHands.Items.Add(shape);
            }

            // Time Provider
            if (analogClockDemo.TimeProvider == null)
            {
                comboBoxTimeProviders.SelectedIndex = 0;
            }
            else
            {
                comboBoxTimeProviders.SelectedItem = analogClockDemo.TimeProvider.GetType();
            }
            propertyGridTimeProvider.SelectedObject = analogClockDemo.TimeProvider == null ? null : analogClockDemo.TimeProvider.GetType();
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
            if (comboBoxTimeProviders.SelectedItem == null || comboBoxTimeProviders.SelectedItem.Equals("(none)"))
            {
                analogClockDemo.TimeProvider = null;
            }
            else
            {
                Type type = (Type)comboBoxTimeProviders.SelectedItem;

                ConstructorInfo constructorInfo = type.GetConstructor(new Type[0]);
                ITimeProvider timeProvider = (ITimeProvider)constructorInfo.Invoke(null);
                analogClockDemo.TimeProvider = timeProvider;
            }
        }

        private void buttonExamples_Click(object sender, EventArgs e)
        {
            using (FormExamples form = new FormExamples())
                form.ShowDialog();
        }

        private void numericUpDownTimerInterval_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDownTimerInterval.Value;
        }

        private void dateTimePickerUtcOffset_ValueChanged(object sender, EventArgs e)
        {
            analogClockDemo.UtcOffset = nullableDateTimePickerUtcOffset.Value == null ? (TimeSpan?)null : nullableDateTimePickerUtcOffset.Value.Value.TimeOfDay;
        }

        private void analogClockDemo_TimeProviderChanged(object sender, EventArgs e)
        {
            checkBoxTimeProviderPresent.Checked = analogClockDemo.TimeProvider != null;
            nullableDateTimePickerUtcOffset.Enabled = analogClockDemo.TimeProvider == null;
            propertyGridTimeProvider.SelectedObject = analogClockDemo.TimeProvider;
        }


        #region Hand Shapes

        private void listBoxHandShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridHandShapes.SelectedObject = listBoxHands.SelectedItem;
        }

        private void buttonAddHandShape_Click(object sender, EventArgs e)
        {
            if (listBoxHandsAvailable.SelectedItem != null)
            {
                Type t = (Type)listBoxHandsAvailable.SelectedItem;

                ConstructorInfo ctor = t.GetConstructor(new Type[0]);
                IHand shape = (IHand)ctor.Invoke(null);
                analogClockDemo.Hands.Add(shape);
            }
        }

        private void buttonRemoveHandShape_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedItem != null)
            {
                analogClockDemo.Hands.Remove(listBoxHands.SelectedItem as IHand);
            }
        }

        private void buttonHandUp_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedIndex > 0)
            {
                int index = listBoxHands.SelectedIndex;
                IHand shape = listBoxHands.SelectedItem as IHand;
                if (shape != null)
                {
                    analogClockDemo.Hands.RemoveAt(index);
                    analogClockDemo.Hands.Insert(index - 1, shape);
                    listBoxHands.SelectedItem = shape;
                }
            }
        }

        private void buttonHandDown_Click(object sender, EventArgs e)
        {
            if (listBoxHands.SelectedIndex >= 0 && listBoxHands.SelectedIndex < listBoxHands.Items.Count - 1)
            {
                int index = listBoxHands.SelectedIndex;
                IHand shape = listBoxHands.SelectedItem as IHand;
                if (shape != null)
                {
                    analogClockDemo.Hands.RemoveAt(index);
                    analogClockDemo.Hands.Insert(index + 1, shape);
                    listBoxHands.SelectedItem = shape;
                }
            }
        }

        #endregion

        private void analogClockDemo_HandShapeAdded(object sender, ShapeAddedEventArgs e)
        {
            listBoxHands.Items.Insert(e.Index, e.Shape);
        }

        private void analogClockDemo_HandShapeRemoved(object sender, ShapeRemovedEventArgs e)
        {
            listBoxHands.Items.Remove(e.Shape);
        }

        private void analogClockDemo_HandShapeCleared(object sender, EventArgs e)
        {
            listBoxHands.Items.Clear();
        }

        private void comboBoxClockTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClockTemplates.SelectedItem != null)
            {
                Type type = (Type)comboBoxClockTemplates.SelectedItem;

                ConstructorInfo constructorInfo = type.GetConstructor(new Type[0]);
                ClockTemplate clockTemplate = (ClockTemplate)constructorInfo.Invoke(null);

                if (clockTemplate != null)
                    analogClockDemo.ApplyTemplate(clockTemplate);
            }
        }
    }
}
