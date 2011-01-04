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
using System.Reflection;
using DustInTheWind.Clock.Shapes;
using DustInTheWind.Clock.Shapes.Basic;
using DustInTheWind.Clock.Shapes.Advanced;

namespace DustInTheWind.Clock.Demo
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
            comboBoxTimeProviders.Items.Add(typeof(UtcOffsetTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(BrokenTimeProvider));
            comboBoxTimeProviders.Items.Add(typeof(RandomTimeProvider));

            listBoxBackgroundShapeTypes.Items.AddRange(new Type[] {
                typeof(LineGroundShape),
                typeof(PolygonGroundShape),
                typeof(RectangleGroundShape),
                typeof(EllipseGroundShape),
                typeof(PathGroundShape),
                typeof(StringGroundShape),
                typeof(ImageGroundShape),
                typeof(DialShape),
                typeof(FancyDialShape)
            });

            listBoxAngularShapeTypes.Items.AddRange(new Type[] {
                typeof(LineAngularShape),
                typeof(PolygonAngularShape),
                typeof(RectangleAngularShape),
                typeof(EllipseAngularShape),
                typeof(PathAngularShape),
                typeof(ImageAngularShape),
                typeof(TicksShape)
            });

            listBoxHandShapeTypes.Items.AddRange(new Type[] {
                typeof(LineHandShape),
                typeof(PolygonHandShape),
                typeof(RectangleHandShape),
                typeof(EllipseHandShape),
                typeof(PathHandShape),
                typeof(ImageHandShape),
                typeof(DiamondHandShape),
                typeof(DigitalHandShape),
                typeof(PinShape),
                typeof(DotHandShape),
                typeof(FancySweepHandShape),
                typeof(NibHandShape),
                typeof(SlotHandShape)
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Timer
            numericUpDownTimerInterval.Value = timer1.Interval;

            // Time Value
            dateTimePickerTime.Value = DateTime.Now.Date.Add(analogClockDemo.Time);
            nullableDateTimePickerUtcOffset.Value = analogClockDemo.UtcOffset == null ? (DateTime?)null : DateTime.Now.Date.Add(analogClockDemo.UtcOffset.Value);
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

            // >> Text
            textBoxText.Text = analogClockDemo.Text;
            //propertyGridText.SelectedObject = analogClock1.TextShape;

            // >> Font
            textBoxTextFont.Text = analogClockDemo.Font.ToString();

            // >> Keep Proportions
            checkBoxKeepProportions.Checked = analogClockDemo.KeepProportions;

            // Background Shapes
            foreach (IGroundShape shape in analogClockDemo.BackgroundShapes)
            {
                listBoxBackgroundShapes.Items.Add(shape);
            }

            // Angular Shapes
            foreach (IAngularShape shape in analogClockDemo.AngularShapes)
            {
                listBoxAngularShapes.Items.Add(shape);
            }

            // Hand Shapes
            foreach (IHandShape shape in analogClockDemo.HandShapes)
            {
                listBoxHandShapes.Items.Add(shape);
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
            if (comboBoxTimeProviders.SelectedItem == null || comboBoxTimeProviders.SelectedItem.Equals("(none)"))
            {
                analogClockDemo.TimeProvider = null;
            }
            else
            {
                Type t = (Type)comboBoxTimeProviders.SelectedItem;

                ConstructorInfo ctor = t.GetConstructor(new Type[0]);
                ITimeProvider timeProvider = (ITimeProvider)ctor.Invoke(null);
                analogClockDemo.TimeProvider = timeProvider;
            }
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


        #region Background Shapes

        private void listBoxBackgroundShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridBackgroundShapes.SelectedObject = listBoxBackgroundShapes.SelectedItem;
        }

        private void buttonAddBackgroundShape_Click(object sender, EventArgs e)
        {
            if (listBoxBackgroundShapeTypes.SelectedItem != null)
            {
                Type t = (Type)listBoxBackgroundShapeTypes.SelectedItem;

                ConstructorInfo ctor = t.GetConstructor(new Type[0]);
                IGroundShape shape = (IGroundShape)ctor.Invoke(null);
                analogClockDemo.BackgroundShapes.Add(shape);
                listBoxBackgroundShapes.Items.Add(shape);
            }
        }

        private void buttonRemoveBackgroundShape_Click(object sender, EventArgs e)
        {
            if (listBoxBackgroundShapes.SelectedItem != null)
            {
                analogClockDemo.BackgroundShapes.Remove(listBoxBackgroundShapes.SelectedItem as IGroundShape);
                listBoxBackgroundShapes.Items.Remove(listBoxBackgroundShapes.SelectedItem);
            }
        }

        #endregion

        #region Angular Shapes

        private void listBoxAngularShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridAngularShapes.SelectedObject = listBoxAngularShapes.SelectedItem;
        }

        private void buttonAddAngularShape_Click(object sender, EventArgs e)
        {
            if (listBoxAngularShapeTypes.SelectedItem != null)
            {
                Type t = (Type)listBoxAngularShapeTypes.SelectedItem;

                ConstructorInfo ctor = t.GetConstructor(new Type[0]);
                IAngularShape shape = (IAngularShape)ctor.Invoke(null);
                analogClockDemo.AngularShapes.Add(shape);
                listBoxAngularShapes.Items.Add(shape);
            }
        }

        private void buttonRemoveAngularShape_Click(object sender, EventArgs e)
        {
            if (listBoxAngularShapes.SelectedItem != null)
            {
                analogClockDemo.AngularShapes.Remove(listBoxAngularShapes.SelectedItem as IAngularShape);
                listBoxAngularShapes.Items.Remove(listBoxAngularShapes.SelectedItem);
            }
        }



        #endregion

        #region Hand Shapes

        private void listBoxHandShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGridHandShapes.SelectedObject = listBoxHandShapes.SelectedItem;
        }

        private void buttonAddHandShape_Click(object sender, EventArgs e)
        {
            if (listBoxHandShapeTypes.SelectedItem != null)
            {
                Type t = (Type)listBoxHandShapeTypes.SelectedItem;

                ConstructorInfo ctor = t.GetConstructor(new Type[0]);
                IHandShape shape = (IHandShape)ctor.Invoke(null);
                analogClockDemo.HandShapes.Add(shape);
                listBoxHandShapes.Items.Add(shape);
            }
        }

        private void buttonRemoveHandShape_Click(object sender, EventArgs e)
        {
            if (listBoxHandShapes.SelectedItem != null)
            {
                analogClockDemo.HandShapes.Remove(listBoxHandShapes.SelectedItem as IHandShape);
                listBoxHandShapes.Items.Remove(listBoxHandShapes.SelectedItem);
            }
        }

        #endregion
    }
}
