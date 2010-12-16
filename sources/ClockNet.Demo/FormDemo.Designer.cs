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

namespace DustInTheWind.Clock.Demo
{
    partial class FormDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DustInTheWind.Clock.Shapes.Default.DialShape dialShape1 = new DustInTheWind.Clock.Shapes.Default.DialShape();
            DustInTheWind.Clock.Shapes.Default.HourHandShape hourHandShape1 = new DustInTheWind.Clock.Shapes.Default.HourHandShape();
            DustInTheWind.Clock.Shapes.Default.MinuteHandShape minuteHandShape1 = new DustInTheWind.Clock.Shapes.Default.MinuteHandShape();
            DustInTheWind.Clock.Shapes.Default.NumbersShape numbersShape1 = new DustInTheWind.Clock.Shapes.Default.NumbersShape();
            DustInTheWind.Clock.Shapes.Default.PinShape pinShape1 = new DustInTheWind.Clock.Shapes.Default.PinShape();
            DustInTheWind.Clock.Shapes.Default.SweepHandShape sweepHandShape1 = new DustInTheWind.Clock.Shapes.Default.SweepHandShape();
            DustInTheWind.Clock.Shapes.Default.TextShape textShape1 = new DustInTheWind.Clock.Shapes.Default.TextShape();
            DustInTheWind.Clock.Shapes.Default.Ticks1Shape ticks1Shape1 = new DustInTheWind.Clock.Shapes.Default.Ticks1Shape();
            DustInTheWind.Clock.Shapes.Default.Ticks5Shape ticks5Shape1 = new DustInTheWind.Clock.Shapes.Default.Ticks5Shape();
            DustInTheWind.Clock.TimeProviders.LocalTimeProvider localTimeProvider1 = new DustInTheWind.Clock.TimeProviders.LocalTimeProvider();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxTextFont = new System.Windows.Forms.TextBox();
            this.checkBoxKeepProportions = new System.Windows.Forms.CheckBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.numericUpDownPaddingBottom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBoxIntegralSeconds = new System.Windows.Forms.CheckBox();
            this.checkBoxIntegralMinutes = new System.Windows.Forms.CheckBox();
            this.checkBoxIntegralHours = new System.Windows.Forms.CheckBox();
            this.groupBoxValue = new System.Windows.Forms.GroupBox();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxUseExternalTimer = new System.Windows.Forms.CheckBox();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMiscellaneous = new System.Windows.Forms.GroupBox();
            this.buttonBrowseTextFont = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.propertyGridHourHand = new System.Windows.Forms.PropertyGrid();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMiscellaneous = new System.Windows.Forms.TabPage();
            this.tabPageClockHands = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHourHand = new System.Windows.Forms.TabPage();
            this.tabPageMinuteHand = new System.Windows.Forms.TabPage();
            this.propertyGridMinuteHand = new System.Windows.Forms.PropertyGrid();
            this.tabPageSweepHand = new System.Windows.Forms.TabPage();
            this.propertyGridSweepHand = new System.Windows.Forms.PropertyGrid();
            this.tabPagePin = new System.Windows.Forms.TabPage();
            this.propertyGridPin = new System.Windows.Forms.PropertyGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPageTicks = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageTicks1 = new System.Windows.Forms.TabPage();
            this.propertyGridTicks1 = new System.Windows.Forms.PropertyGrid();
            this.tabPageTicks5 = new System.Windows.Forms.TabPage();
            this.propertyGridTicks5 = new System.Windows.Forms.PropertyGrid();
            this.tabPageNumbers = new System.Windows.Forms.TabPage();
            this.propertyGridNumbers = new System.Windows.Forms.PropertyGrid();
            this.tabPageTimeProviders = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridTimeProvider = new System.Windows.Forms.PropertyGrid();
            this.groupBoxTimeProviders = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTimeProviders = new System.Windows.Forms.ComboBox();
            this.panelClock = new System.Windows.Forms.Panel();
            this.analogClock1 = new DustInTheWind.Clock.AnalogClock();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxExternalTimer = new System.Windows.Forms.GroupBox();
            this.numericUpDownTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.tabPageDial = new System.Windows.Forms.TabPage();
            this.propertyGridDial = new System.Windows.Forms.PropertyGrid();
            this.tabControlDial = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyGridText = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).BeginInit();
            this.groupBoxValue.SuspendLayout();
            this.groupBoxTimer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxMiscellaneous.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMiscellaneous.SuspendLayout();
            this.tabPageClockHands.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageHourHand.SuspendLayout();
            this.tabPageMinuteHand.SuspendLayout();
            this.tabPageSweepHand.SuspendLayout();
            this.tabPagePin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageTicks.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageTicks1.SuspendLayout();
            this.tabPageTicks5.SuspendLayout();
            this.tabPageNumbers.SuspendLayout();
            this.tabPageTimeProviders.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxTimeProviders.SuspendLayout();
            this.panelClock.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.groupBoxExternalTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).BeginInit();
            this.panelParameters.SuspendLayout();
            this.tabPageDial.SuspendLayout();
            this.tabControlDial.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // textBoxTextFont
            // 
            this.textBoxTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTextFont.Location = new System.Drawing.Point(80, 116);
            this.textBoxTextFont.Multiline = true;
            this.textBoxTextFont.Name = "textBoxTextFont";
            this.textBoxTextFont.ReadOnly = true;
            this.textBoxTextFont.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextFont.Size = new System.Drawing.Size(267, 65);
            this.textBoxTextFont.TabIndex = 2;
            // 
            // checkBoxKeepProportions
            // 
            this.checkBoxKeepProportions.AutoSize = true;
            this.checkBoxKeepProportions.Location = new System.Drawing.Point(80, 187);
            this.checkBoxKeepProportions.Name = "checkBoxKeepProportions";
            this.checkBoxKeepProportions.Size = new System.Drawing.Size(107, 17);
            this.checkBoxKeepProportions.TabIndex = 0;
            this.checkBoxKeepProportions.Text = "Keep Proportions";
            this.checkBoxKeepProportions.UseVisualStyleBackColor = true;
            this.checkBoxKeepProportions.CheckedChanged += new System.EventHandler(this.checkBoxKeepProportions_CheckedChanged);
            // 
            // textBoxText
            // 
            this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxText.Location = new System.Drawing.Point(80, 90);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(317, 20);
            this.textBoxText.TabIndex = 2;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // numericUpDownPaddingBottom
            // 
            this.numericUpDownPaddingBottom.Location = new System.Drawing.Point(287, 64);
            this.numericUpDownPaddingBottom.Name = "numericUpDownPaddingBottom";
            this.numericUpDownPaddingBottom.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingBottom.TabIndex = 1;
            this.numericUpDownPaddingBottom.ValueChanged += new System.EventHandler(this.numericUpDownPaddingBottom_ValueChanged);
            // 
            // numericUpDownPaddingRight
            // 
            this.numericUpDownPaddingRight.Location = new System.Drawing.Point(218, 64);
            this.numericUpDownPaddingRight.Name = "numericUpDownPaddingRight";
            this.numericUpDownPaddingRight.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingRight.TabIndex = 1;
            this.numericUpDownPaddingRight.ValueChanged += new System.EventHandler(this.numericUpDownPaddingRight_ValueChanged);
            // 
            // numericUpDownPaddingTop
            // 
            this.numericUpDownPaddingTop.Location = new System.Drawing.Point(149, 64);
            this.numericUpDownPaddingTop.Name = "numericUpDownPaddingTop";
            this.numericUpDownPaddingTop.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingTop.TabIndex = 1;
            this.numericUpDownPaddingTop.ValueChanged += new System.EventHandler(this.numericUpDownPaddingTop_ValueChanged);
            // 
            // numericUpDownPaddingLeft
            // 
            this.numericUpDownPaddingLeft.Location = new System.Drawing.Point(80, 64);
            this.numericUpDownPaddingLeft.Name = "numericUpDownPaddingLeft";
            this.numericUpDownPaddingLeft.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingLeft.TabIndex = 1;
            this.numericUpDownPaddingLeft.ValueChanged += new System.EventHandler(this.numericUpDownPaddingLeft_ValueChanged);
            // 
            // labelBackgroundColor
            // 
            this.labelBackgroundColor.BackColor = System.Drawing.Color.White;
            this.labelBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBackgroundColor.Location = new System.Drawing.Point(80, 23);
            this.labelBackgroundColor.Margin = new System.Windows.Forms.Padding(3);
            this.labelBackgroundColor.Name = "labelBackgroundColor";
            this.labelBackgroundColor.Size = new System.Drawing.Size(16, 16);
            this.labelBackgroundColor.TabIndex = 0;
            this.labelBackgroundColor.Click += new System.EventHandler(this.labelBackgroundColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Font:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Padding:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Background:";
            // 
            // checkBoxIntegralSeconds
            // 
            this.checkBoxIntegralSeconds.AutoSize = true;
            this.checkBoxIntegralSeconds.Location = new System.Drawing.Point(6, 19);
            this.checkBoxIntegralSeconds.Name = "checkBoxIntegralSeconds";
            this.checkBoxIntegralSeconds.Size = new System.Drawing.Size(106, 17);
            this.checkBoxIntegralSeconds.TabIndex = 0;
            this.checkBoxIntegralSeconds.Text = "Integral Seconds";
            this.checkBoxIntegralSeconds.UseVisualStyleBackColor = true;
            this.checkBoxIntegralSeconds.CheckedChanged += new System.EventHandler(this.checkBoxIntegralSeconds_CheckedChanged);
            // 
            // checkBoxIntegralMinutes
            // 
            this.checkBoxIntegralMinutes.AutoSize = true;
            this.checkBoxIntegralMinutes.Location = new System.Drawing.Point(6, 19);
            this.checkBoxIntegralMinutes.Name = "checkBoxIntegralMinutes";
            this.checkBoxIntegralMinutes.Size = new System.Drawing.Size(101, 17);
            this.checkBoxIntegralMinutes.TabIndex = 0;
            this.checkBoxIntegralMinutes.Text = "Integral Minutes";
            this.checkBoxIntegralMinutes.UseVisualStyleBackColor = true;
            this.checkBoxIntegralMinutes.CheckedChanged += new System.EventHandler(this.checkBoxIntegralMinutes_CheckedChanged);
            // 
            // checkBoxIntegralHours
            // 
            this.checkBoxIntegralHours.AutoSize = true;
            this.checkBoxIntegralHours.Location = new System.Drawing.Point(6, 19);
            this.checkBoxIntegralHours.Name = "checkBoxIntegralHours";
            this.checkBoxIntegralHours.Size = new System.Drawing.Size(92, 17);
            this.checkBoxIntegralHours.TabIndex = 0;
            this.checkBoxIntegralHours.Text = "Integral Hours";
            this.checkBoxIntegralHours.UseVisualStyleBackColor = true;
            this.checkBoxIntegralHours.CheckedChanged += new System.EventHandler(this.checkBoxIntegralHours_CheckedChanged);
            // 
            // groupBoxValue
            // 
            this.groupBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxValue.Controls.Add(this.dateTimePickerTime);
            this.groupBoxValue.Controls.Add(this.label4);
            this.groupBoxValue.Location = new System.Drawing.Point(3, 219);
            this.groupBoxValue.Name = "groupBoxValue";
            this.groupBoxValue.Size = new System.Drawing.Size(198, 115);
            this.groupBoxValue.TabIndex = 4;
            this.groupBoxValue.TabStop = false;
            this.groupBoxValue.Text = "Value";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(61, 19);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerTime.TabIndex = 0;
            this.dateTimePickerTime.Value = new System.DateTime(2010, 11, 30, 0, 0, 0, 0);
            this.dateTimePickerTime.ValueChanged += new System.EventHandler(this.dateTimePickerTime_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Time:";
            // 
            // checkBoxUseExternalTimer
            // 
            this.checkBoxUseExternalTimer.AutoSize = true;
            this.checkBoxUseExternalTimer.Location = new System.Drawing.Point(20, 19);
            this.checkBoxUseExternalTimer.Name = "checkBoxUseExternalTimer";
            this.checkBoxUseExternalTimer.Size = new System.Drawing.Size(127, 17);
            this.checkBoxUseExternalTimer.TabIndex = 0;
            this.checkBoxUseExternalTimer.Text = "Attach External Timer";
            this.checkBoxUseExternalTimer.UseVisualStyleBackColor = true;
            this.checkBoxUseExternalTimer.CheckedChanged += new System.EventHandler(this.checkBoxUseExternalTimer_CheckedChanged);
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimer.Controls.Add(this.checkBoxUseExternalTimer);
            this.groupBoxTimer.Location = new System.Drawing.Point(207, 219);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(199, 115);
            this.groupBoxTimer.TabIndex = 7;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTimer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMiscellaneous, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxValue, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 546);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBoxMiscellaneous
            // 
            this.groupBoxMiscellaneous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxMiscellaneous, 2);
            this.groupBoxMiscellaneous.Controls.Add(this.buttonBrowseTextFont);
            this.groupBoxMiscellaneous.Controls.Add(this.textBoxTextFont);
            this.groupBoxMiscellaneous.Controls.Add(this.label9);
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingLeft);
            this.groupBoxMiscellaneous.Controls.Add(this.checkBoxKeepProportions);
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingTop);
            this.groupBoxMiscellaneous.Controls.Add(this.label12);
            this.groupBoxMiscellaneous.Controls.Add(this.label11);
            this.groupBoxMiscellaneous.Controls.Add(this.label10);
            this.groupBoxMiscellaneous.Controls.Add(this.label8);
            this.groupBoxMiscellaneous.Controls.Add(this.label3);
            this.groupBoxMiscellaneous.Controls.Add(this.labelBackgroundColor);
            this.groupBoxMiscellaneous.Controls.Add(this.textBoxText);
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingRight);
            this.groupBoxMiscellaneous.Controls.Add(this.label5);
            this.groupBoxMiscellaneous.Controls.Add(this.label7);
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingBottom);
            this.groupBoxMiscellaneous.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMiscellaneous.Name = "groupBoxMiscellaneous";
            this.groupBoxMiscellaneous.Size = new System.Drawing.Size(403, 210);
            this.groupBoxMiscellaneous.TabIndex = 13;
            this.groupBoxMiscellaneous.TabStop = false;
            this.groupBoxMiscellaneous.Text = "Miscellaneous";
            // 
            // buttonBrowseTextFont
            // 
            this.buttonBrowseTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseTextFont.Location = new System.Drawing.Point(353, 116);
            this.buttonBrowseTextFont.Name = "buttonBrowseTextFont";
            this.buttonBrowseTextFont.Size = new System.Drawing.Size(44, 44);
            this.buttonBrowseTextFont.TabIndex = 3;
            this.buttonBrowseTextFont.Text = "...";
            this.buttonBrowseTextFont.UseVisualStyleBackColor = true;
            this.buttonBrowseTextFont.Click += new System.EventHandler(this.buttonBrowseTextFont_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Bottom";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(215, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Right";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Top";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Left";
            // 
            // propertyGridHourHand
            // 
            this.propertyGridHourHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridHourHand.Location = new System.Drawing.Point(0, 0);
            this.propertyGridHourHand.Name = "propertyGridHourHand";
            this.propertyGridHourHand.Size = new System.Drawing.Size(395, 272);
            this.propertyGridHourHand.TabIndex = 10;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMiscellaneous);
            this.tabControl.Controls.Add(this.tabPageDial);
            this.tabControl.Controls.Add(this.tabPageClockHands);
            this.tabControl.Controls.Add(this.tabPageTicks);
            this.tabControl.Controls.Add(this.tabPageNumbers);
            this.tabControl.Controls.Add(this.tabPageTimeProviders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(417, 572);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageMiscellaneous
            // 
            this.tabPageMiscellaneous.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMiscellaneous.Location = new System.Drawing.Point(4, 22);
            this.tabPageMiscellaneous.Name = "tabPageMiscellaneous";
            this.tabPageMiscellaneous.Size = new System.Drawing.Size(409, 546);
            this.tabPageMiscellaneous.TabIndex = 0;
            this.tabPageMiscellaneous.Text = "Miscellaneous";
            this.tabPageMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // tabPageClockHands
            // 
            this.tabPageClockHands.Controls.Add(this.tableLayoutPanel2);
            this.tabPageClockHands.Location = new System.Drawing.Point(4, 22);
            this.tabPageClockHands.Name = "tabPageClockHands";
            this.tabPageClockHands.Size = new System.Drawing.Size(409, 546);
            this.tabPageClockHands.TabIndex = 7;
            this.tabPageClockHands.Text = "Clock Hands";
            this.tabPageClockHands.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(409, 546);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tabPageHourHand);
            this.tabControl1.Controls.Add(this.tabPageMinuteHand);
            this.tabControl1.Controls.Add(this.tabPageSweepHand);
            this.tabControl1.Controls.Add(this.tabPagePin);
            this.tabControl1.Location = new System.Drawing.Point(3, 245);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 298);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPageHourHand
            // 
            this.tabPageHourHand.Controls.Add(this.propertyGridHourHand);
            this.tabPageHourHand.Location = new System.Drawing.Point(4, 22);
            this.tabPageHourHand.Name = "tabPageHourHand";
            this.tabPageHourHand.Size = new System.Drawing.Size(395, 272);
            this.tabPageHourHand.TabIndex = 1;
            this.tabPageHourHand.Text = "Hour Hand";
            this.tabPageHourHand.UseVisualStyleBackColor = true;
            // 
            // tabPageMinuteHand
            // 
            this.tabPageMinuteHand.Controls.Add(this.propertyGridMinuteHand);
            this.tabPageMinuteHand.Location = new System.Drawing.Point(4, 22);
            this.tabPageMinuteHand.Name = "tabPageMinuteHand";
            this.tabPageMinuteHand.Size = new System.Drawing.Size(358, 272);
            this.tabPageMinuteHand.TabIndex = 2;
            this.tabPageMinuteHand.Text = "Minute Hand";
            this.tabPageMinuteHand.UseVisualStyleBackColor = true;
            // 
            // propertyGridMinuteHand
            // 
            this.propertyGridMinuteHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMinuteHand.Location = new System.Drawing.Point(0, 0);
            this.propertyGridMinuteHand.Name = "propertyGridMinuteHand";
            this.propertyGridMinuteHand.Size = new System.Drawing.Size(358, 272);
            this.propertyGridMinuteHand.TabIndex = 11;
            // 
            // tabPageSweepHand
            // 
            this.tabPageSweepHand.Controls.Add(this.propertyGridSweepHand);
            this.tabPageSweepHand.Location = new System.Drawing.Point(4, 22);
            this.tabPageSweepHand.Name = "tabPageSweepHand";
            this.tabPageSweepHand.Size = new System.Drawing.Size(358, 272);
            this.tabPageSweepHand.TabIndex = 3;
            this.tabPageSweepHand.Text = "Sweep Hand";
            this.tabPageSweepHand.UseVisualStyleBackColor = true;
            // 
            // propertyGridSweepHand
            // 
            this.propertyGridSweepHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSweepHand.Location = new System.Drawing.Point(0, 0);
            this.propertyGridSweepHand.Name = "propertyGridSweepHand";
            this.propertyGridSweepHand.Size = new System.Drawing.Size(358, 272);
            this.propertyGridSweepHand.TabIndex = 12;
            // 
            // tabPagePin
            // 
            this.tabPagePin.Controls.Add(this.propertyGridPin);
            this.tabPagePin.Location = new System.Drawing.Point(4, 22);
            this.tabPagePin.Name = "tabPagePin";
            this.tabPagePin.Size = new System.Drawing.Size(358, 272);
            this.tabPagePin.TabIndex = 6;
            this.tabPagePin.Text = "Pin";
            this.tabPagePin.UseVisualStyleBackColor = true;
            // 
            // propertyGridPin
            // 
            this.propertyGridPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridPin.Location = new System.Drawing.Point(0, 0);
            this.propertyGridPin.Name = "propertyGridPin";
            this.propertyGridPin.Size = new System.Drawing.Size(358, 272);
            this.propertyGridPin.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxIntegralHours);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 115);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hour Hand";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBoxIntegralMinutes);
            this.groupBox3.Location = new System.Drawing.Point(207, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 115);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Minute Hand";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxIntegralSeconds);
            this.groupBox1.Location = new System.Drawing.Point(3, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 115);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sweep Hend";
            // 
            // tabPageTicks
            // 
            this.tabPageTicks.Controls.Add(this.tabControl2);
            this.tabPageTicks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTicks.Name = "tabPageTicks";
            this.tabPageTicks.Size = new System.Drawing.Size(409, 546);
            this.tabPageTicks.TabIndex = 4;
            this.tabPageTicks.Text = "Ticks";
            this.tabPageTicks.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageTicks1);
            this.tabControl2.Controls.Add(this.tabPageTicks5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(409, 546);
            this.tabControl2.TabIndex = 12;
            // 
            // tabPageTicks1
            // 
            this.tabPageTicks1.Controls.Add(this.propertyGridTicks1);
            this.tabPageTicks1.Location = new System.Drawing.Point(4, 22);
            this.tabPageTicks1.Name = "tabPageTicks1";
            this.tabPageTicks1.Size = new System.Drawing.Size(401, 520);
            this.tabPageTicks1.TabIndex = 1;
            this.tabPageTicks1.Text = "Ticks1";
            this.tabPageTicks1.UseVisualStyleBackColor = true;
            // 
            // propertyGridTicks1
            // 
            this.propertyGridTicks1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridTicks1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTicks1.Name = "propertyGridTicks1";
            this.propertyGridTicks1.Size = new System.Drawing.Size(401, 520);
            this.propertyGridTicks1.TabIndex = 10;
            // 
            // tabPageTicks5
            // 
            this.tabPageTicks5.Controls.Add(this.propertyGridTicks5);
            this.tabPageTicks5.Location = new System.Drawing.Point(4, 22);
            this.tabPageTicks5.Name = "tabPageTicks5";
            this.tabPageTicks5.Size = new System.Drawing.Size(364, 520);
            this.tabPageTicks5.TabIndex = 2;
            this.tabPageTicks5.Text = "Ticks5";
            this.tabPageTicks5.UseVisualStyleBackColor = true;
            // 
            // propertyGridTicks5
            // 
            this.propertyGridTicks5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridTicks5.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTicks5.Name = "propertyGridTicks5";
            this.propertyGridTicks5.Size = new System.Drawing.Size(364, 520);
            this.propertyGridTicks5.TabIndex = 11;
            // 
            // tabPageNumbers
            // 
            this.tabPageNumbers.Controls.Add(this.propertyGridNumbers);
            this.tabPageNumbers.Location = new System.Drawing.Point(4, 22);
            this.tabPageNumbers.Name = "tabPageNumbers";
            this.tabPageNumbers.Size = new System.Drawing.Size(409, 546);
            this.tabPageNumbers.TabIndex = 5;
            this.tabPageNumbers.Text = "Numbers";
            this.tabPageNumbers.UseVisualStyleBackColor = true;
            // 
            // propertyGridNumbers
            // 
            this.propertyGridNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridNumbers.Location = new System.Drawing.Point(0, 0);
            this.propertyGridNumbers.Name = "propertyGridNumbers";
            this.propertyGridNumbers.Size = new System.Drawing.Size(409, 546);
            this.propertyGridNumbers.TabIndex = 11;
            // 
            // tabPageTimeProviders
            // 
            this.tabPageTimeProviders.Controls.Add(this.tableLayoutPanel5);
            this.tabPageTimeProviders.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeProviders.Name = "tabPageTimeProviders";
            this.tabPageTimeProviders.Size = new System.Drawing.Size(409, 546);
            this.tabPageTimeProviders.TabIndex = 8;
            this.tabPageTimeProviders.Text = "Time Providers";
            this.tabPageTimeProviders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.propertyGridTimeProvider, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxTimeProviders, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(409, 546);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // propertyGridTimeProvider
            // 
            this.propertyGridTimeProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.propertyGridTimeProvider, 2);
            this.propertyGridTimeProvider.Location = new System.Drawing.Point(3, 124);
            this.propertyGridTimeProvider.Name = "propertyGridTimeProvider";
            this.propertyGridTimeProvider.Size = new System.Drawing.Size(403, 419);
            this.propertyGridTimeProvider.TabIndex = 12;
            // 
            // groupBoxTimeProviders
            // 
            this.groupBoxTimeProviders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxTimeProviders, 2);
            this.groupBoxTimeProviders.Controls.Add(this.label1);
            this.groupBoxTimeProviders.Controls.Add(this.comboBoxTimeProviders);
            this.groupBoxTimeProviders.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTimeProviders.Name = "groupBoxTimeProviders";
            this.groupBoxTimeProviders.Size = new System.Drawing.Size(403, 115);
            this.groupBoxTimeProviders.TabIndex = 2;
            this.groupBoxTimeProviders.TabStop = false;
            this.groupBoxTimeProviders.Text = "Time Providers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Providers";
            // 
            // comboBoxTimeProviders
            // 
            this.comboBoxTimeProviders.DisplayMember = "Key";
            this.comboBoxTimeProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeProviders.FormattingEnabled = true;
            this.comboBoxTimeProviders.Location = new System.Drawing.Point(95, 19);
            this.comboBoxTimeProviders.Name = "comboBoxTimeProviders";
            this.comboBoxTimeProviders.Size = new System.Drawing.Size(265, 21);
            this.comboBoxTimeProviders.TabIndex = 0;
            this.comboBoxTimeProviders.ValueMember = "Value";
            this.comboBoxTimeProviders.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeProviders_SelectedIndexChanged);
            // 
            // panelClock
            // 
            this.panelClock.Controls.Add(this.analogClock1);
            this.panelClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClock.Location = new System.Drawing.Point(8, 8);
            this.panelClock.Name = "panelClock";
            this.panelClock.Padding = new System.Windows.Forms.Padding(8);
            this.panelClock.Size = new System.Drawing.Size(679, 627);
            this.panelClock.TabIndex = 13;
            // 
            // analogClock1
            // 
            dialShape1.FillColor = System.Drawing.Color.Empty;
            dialShape1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClock1.DialShape = dialShape1;
            this.analogClock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analogClock1.ForeColor = System.Drawing.Color.White;
            hourHandShape1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClock1.HourHandShape = hourHandShape1;
            this.analogClock1.Location = new System.Drawing.Point(8, 8);
            minuteHandShape1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClock1.MinuteHandShape = minuteHandShape1;
            this.analogClock1.Name = "analogClock1";
            numbersShape1.CurrentIndex = 11;
            numbersShape1.Font = new System.Drawing.Font("Vivaldi", 6.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numbersShape1.Numbers = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12"};
            numbersShape1.OutlineColor = System.Drawing.Color.Empty;
            numbersShape1.PositionOffset = 9F;
            this.analogClock1.NumbersShape = numbersShape1;
            pinShape1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClock1.PinShape = pinShape1;
            this.analogClock1.Size = new System.Drawing.Size(663, 611);
            sweepHandShape1.FillColor = System.Drawing.Color.Empty;
            sweepHandShape1.Height = 41F;
            this.analogClock1.SweepHandShape = sweepHandShape1;
            this.analogClock1.TabIndex = 11;
            this.analogClock1.Text = "Cool";
            textShape1.Font = new System.Drawing.Font("Arial", 3F);
            textShape1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClock1.TextShape = textShape1;
            ticks1Shape1.FillColor = System.Drawing.Color.Empty;
            ticks1Shape1.PositionOffset = 5.5F;
            this.analogClock1.Ticks1Shape = ticks1Shape1;
            ticks5Shape1.FillColor = System.Drawing.Color.Empty;
            ticks5Shape1.PositionOffset = 3F;
            this.analogClock1.Ticks5Shape = ticks5Shape1;
            this.analogClock1.Time = System.TimeSpan.Parse("11:17:25.2153866");
            this.analogClock1.TimeProvider = localTimeProvider1;
            this.analogClock1.Timer = this.timer1;
            this.analogClock1.TimeProviderChanged += new System.EventHandler(this.analogClock1_TimeProviderChanged);
            // 
            // buttonExamples
            // 
            this.buttonExamples.Location = new System.Drawing.Point(3, 3);
            this.buttonExamples.Name = "buttonExamples";
            this.buttonExamples.Size = new System.Drawing.Size(75, 23);
            this.buttonExamples.TabIndex = 12;
            this.buttonExamples.Text = "Examples";
            this.buttonExamples.UseVisualStyleBackColor = true;
            this.buttonExamples.Click += new System.EventHandler(this.buttonExamples_Click);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonExamples);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(8, 635);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(1096, 29);
            this.flowLayoutPanelButtons.TabIndex = 9;
            // 
            // groupBoxExternalTimer
            // 
            this.groupBoxExternalTimer.Controls.Add(this.numericUpDownTimerInterval);
            this.groupBoxExternalTimer.Controls.Add(this.label2);
            this.groupBoxExternalTimer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxExternalTimer.Location = new System.Drawing.Point(0, 572);
            this.groupBoxExternalTimer.Name = "groupBoxExternalTimer";
            this.groupBoxExternalTimer.Size = new System.Drawing.Size(417, 55);
            this.groupBoxExternalTimer.TabIndex = 5;
            this.groupBoxExternalTimer.TabStop = false;
            this.groupBoxExternalTimer.Text = "External Timer";
            // 
            // numericUpDownTimerInterval
            // 
            this.numericUpDownTimerInterval.Location = new System.Drawing.Point(68, 20);
            this.numericUpDownTimerInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTimerInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimerInterval.Name = "numericUpDownTimerInterval";
            this.numericUpDownTimerInterval.Size = new System.Drawing.Size(82, 20);
            this.numericUpDownTimerInterval.TabIndex = 1;
            this.numericUpDownTimerInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimerInterval.ValueChanged += new System.EventHandler(this.numericUpDownTimerInterval_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Interval:";
            // 
            // panelParameters
            // 
            this.panelParameters.AutoSize = true;
            this.panelParameters.Controls.Add(this.tabControl);
            this.panelParameters.Controls.Add(this.groupBoxExternalTimer);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelParameters.Location = new System.Drawing.Point(687, 8);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(417, 627);
            this.panelParameters.TabIndex = 1;
            // 
            // tabPageDial
            // 
            this.tabPageDial.Controls.Add(this.tabControlDial);
            this.tabPageDial.Location = new System.Drawing.Point(4, 22);
            this.tabPageDial.Name = "tabPageDial";
            this.tabPageDial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDial.Size = new System.Drawing.Size(409, 546);
            this.tabPageDial.TabIndex = 9;
            this.tabPageDial.Text = "Dial";
            this.tabPageDial.UseVisualStyleBackColor = true;
            // 
            // propertyGridDial
            // 
            this.propertyGridDial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDial.Location = new System.Drawing.Point(3, 3);
            this.propertyGridDial.Name = "propertyGridDial";
            this.propertyGridDial.Size = new System.Drawing.Size(389, 508);
            this.propertyGridDial.TabIndex = 12;
            // 
            // tabControlDial
            // 
            this.tabControlDial.Controls.Add(this.tabPage1);
            this.tabControlDial.Controls.Add(this.tabPage2);
            this.tabControlDial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDial.Location = new System.Drawing.Point(3, 3);
            this.tabControlDial.Name = "tabControlDial";
            this.tabControlDial.SelectedIndex = 0;
            this.tabControlDial.Size = new System.Drawing.Size(403, 540);
            this.tabControlDial.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertyGridDial);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(395, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dial";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGridText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(395, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyGridText
            // 
            this.propertyGridText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridText.Location = new System.Drawing.Point(3, 3);
            this.propertyGridText.Name = "propertyGridText";
            this.propertyGridText.Size = new System.Drawing.Size(389, 508);
            this.propertyGridText.TabIndex = 13;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 672);
            this.Controls.Add(this.panelClock);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.flowLayoutPanelButtons);
            this.Name = "FormDemo";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).EndInit();
            this.groupBoxValue.ResumeLayout(false);
            this.groupBoxValue.PerformLayout();
            this.groupBoxTimer.ResumeLayout(false);
            this.groupBoxTimer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxMiscellaneous.ResumeLayout(false);
            this.groupBoxMiscellaneous.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageMiscellaneous.ResumeLayout(false);
            this.tabPageMiscellaneous.PerformLayout();
            this.tabPageClockHands.ResumeLayout(false);
            this.tabPageClockHands.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageHourHand.ResumeLayout(false);
            this.tabPageMinuteHand.ResumeLayout(false);
            this.tabPageSweepHand.ResumeLayout(false);
            this.tabPagePin.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageTicks.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageTicks1.ResumeLayout(false);
            this.tabPageTicks5.ResumeLayout(false);
            this.tabPageNumbers.ResumeLayout(false);
            this.tabPageTimeProviders.ResumeLayout(false);
            this.tabPageTimeProviders.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxTimeProviders.ResumeLayout(false);
            this.groupBoxTimeProviders.PerformLayout();
            this.panelClock.ResumeLayout(false);
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.groupBoxExternalTimer.ResumeLayout(false);
            this.groupBoxExternalTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).EndInit();
            this.panelParameters.ResumeLayout(false);
            this.tabPageDial.ResumeLayout(false);
            this.tabControlDial.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxIntegralSeconds;
        private System.Windows.Forms.CheckBox checkBoxIntegralMinutes;
        private System.Windows.Forms.CheckBox checkBoxIntegralHours;
        private System.Windows.Forms.GroupBox groupBoxValue;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxUseExternalTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingBottom;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingRight;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingTop;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingLeft;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTextFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox checkBoxKeepProportions;
        private System.Windows.Forms.PropertyGrid propertyGridHourHand;
        private DustInTheWind.Clock.AnalogClock analogClock1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMiscellaneous;
        private System.Windows.Forms.TabPage tabPageHourHand;
        private System.Windows.Forms.TabPage tabPageMinuteHand;
        private System.Windows.Forms.PropertyGrid propertyGridMinuteHand;
        private System.Windows.Forms.TabPage tabPageSweepHand;
        private System.Windows.Forms.PropertyGrid propertyGridSweepHand;
        private System.Windows.Forms.GroupBox groupBoxMiscellaneous;
        private System.Windows.Forms.TabPage tabPageTicks;
        private System.Windows.Forms.TabPage tabPageNumbers;
        private System.Windows.Forms.Panel panelClock;
        private System.Windows.Forms.TabPage tabPagePin;
        private System.Windows.Forms.PropertyGrid propertyGridPin;
        private System.Windows.Forms.TabPage tabPageClockHands;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonBrowseTextFont;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPageTimeProviders;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageTicks1;
        private System.Windows.Forms.PropertyGrid propertyGridTicks1;
        private System.Windows.Forms.TabPage tabPageTicks5;
        private System.Windows.Forms.PropertyGrid propertyGridTicks5;
        private System.Windows.Forms.PropertyGrid propertyGridNumbers;
        private System.Windows.Forms.PropertyGrid propertyGridTimeProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBoxTimeProviders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTimeProviders;
        private System.Windows.Forms.Button buttonExamples;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.GroupBox groupBoxExternalTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.NumericUpDown numericUpDownTimerInterval;
        private System.Windows.Forms.TabPage tabPageDial;
        private System.Windows.Forms.PropertyGrid propertyGridDial;
        private System.Windows.Forms.TabControl tabControlDial;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGridText;




    }
}

