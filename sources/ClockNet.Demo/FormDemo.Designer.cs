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

namespace DustInTheWind.ClockNet.Demo
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
            DustInTheWind.ClockNet.Shapes.Advanced.FancyBackground fancyBackground2 = new DustInTheWind.ClockNet.Shapes.Advanced.FancyBackground();
            DustInTheWind.ClockNet.Shapes.Basic.StringBackground stringBackground2 = new DustInTheWind.ClockNet.Shapes.Basic.StringBackground();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemo));
            DustInTheWind.ClockNet.Shapes.Advanced.DiamondHand diamondHand3 = new DustInTheWind.ClockNet.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Shapes.Advanced.DiamondHand diamondHand4 = new DustInTheWind.ClockNet.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Shapes.Basic.LineHand lineHand2 = new DustInTheWind.ClockNet.Shapes.Basic.LineHand();
            DustInTheWind.ClockNet.Shapes.Advanced.Pin pin2 = new DustInTheWind.ClockNet.Shapes.Advanced.Pin();
            DustInTheWind.ClockNet.Shapes.Advanced.Ticks ticks3 = new DustInTheWind.ClockNet.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Shapes.Advanced.Ticks ticks4 = new DustInTheWind.ClockNet.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Shapes.Basic.StringRimMarker stringRimMarker3 = new DustInTheWind.ClockNet.Shapes.Basic.StringRimMarker();
            DustInTheWind.ClockNet.Shapes.Basic.StringRimMarker stringRimMarker4 = new DustInTheWind.ClockNet.Shapes.Basic.StringRimMarker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxTextFont = new System.Windows.Forms.TextBox();
            this.checkBoxKeepProportions = new System.Windows.Forms.CheckBox();
            this.numericUpDownPaddingBottom = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBoxValue = new System.Windows.Forms.GroupBox();
            this.checkBoxTimeProviderPresent = new System.Windows.Forms.CheckBox();
            this.nullableDateTimePickerUtcOffset = new DustInTheWind.ClockNet.NullableDateTimePicker();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMiscellaneous = new System.Windows.Forms.TabPage();
            this.tabPageBackgrounds = new System.Windows.Forms.TabPage();
            this.tabPageRimMarkers = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridAngularShapes = new System.Windows.Forms.PropertyGrid();
            this.groupBoxAngularShapes = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelAngularShapes = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxRimMarkers = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAngularUp = new System.Windows.Forms.Button();
            this.buttonAngularDown = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddAngularShape = new System.Windows.Forms.Button();
            this.buttonRemoveAngularShape = new System.Windows.Forms.Button();
            this.listBoxRimMarkersAvailable = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPageHands = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridHandShapes = new System.Windows.Forms.PropertyGrid();
            this.groupBoxHandShapes = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonHandUp = new System.Windows.Forms.Button();
            this.buttonHandDown = new System.Windows.Forms.Button();
            this.listBoxHands = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddHandShape = new System.Windows.Forms.Button();
            this.buttonRemoveHandShape = new System.Windows.Forms.Button();
            this.listBoxHandsAvailable = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPageTimeProviders = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridTimeProvider = new System.Windows.Forms.PropertyGrid();
            this.groupBoxTimeProviders = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTimeProviders = new System.Windows.Forms.ComboBox();
            this.panelClock = new System.Windows.Forms.Panel();
            this.analogClockDemo = new DustInTheWind.ClockNet.AnalogClock();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxClockTemplates = new System.Windows.Forms.ComboBox();
            this.groupBoxExternalTimer = new System.Windows.Forms.GroupBox();
            this.numericUpDownTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.localTimeProvider1 = new DustInTheWind.ClockNet.TimeProviders.LocalTimeProvider();
            this.backgroundsEditor1 = new DustInTheWind.ClockNet.Demo.BackgroundsEditor();
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
            this.tabPageBackgrounds.SuspendLayout();
            this.tabPageRimMarkers.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxAngularShapes.SuspendLayout();
            this.tableLayoutPanelAngularShapes.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPageHands.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxHandShapes.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPageTimeProviders.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxTimeProviders.SuspendLayout();
            this.panelClock.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.groupBoxExternalTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).BeginInit();
            this.panelParameters.SuspendLayout();
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
            // groupBoxValue
            // 
            this.groupBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxValue.Controls.Add(this.checkBoxTimeProviderPresent);
            this.groupBoxValue.Controls.Add(this.nullableDateTimePickerUtcOffset);
            this.groupBoxValue.Controls.Add(this.dateTimePickerTime);
            this.groupBoxValue.Controls.Add(this.label6);
            this.groupBoxValue.Controls.Add(this.label4);
            this.groupBoxValue.Location = new System.Drawing.Point(3, 219);
            this.groupBoxValue.Name = "groupBoxValue";
            this.groupBoxValue.Size = new System.Drawing.Size(198, 115);
            this.groupBoxValue.TabIndex = 4;
            this.groupBoxValue.TabStop = false;
            this.groupBoxValue.Text = "Value";
            // 
            // checkBoxTimeProviderPresent
            // 
            this.checkBoxTimeProviderPresent.AutoSize = true;
            this.checkBoxTimeProviderPresent.Enabled = false;
            this.checkBoxTimeProviderPresent.Location = new System.Drawing.Point(20, 91);
            this.checkBoxTimeProviderPresent.Name = "checkBoxTimeProviderPresent";
            this.checkBoxTimeProviderPresent.Size = new System.Drawing.Size(130, 17);
            this.checkBoxTimeProviderPresent.TabIndex = 2;
            this.checkBoxTimeProviderPresent.Text = "Time Provider Present";
            this.checkBoxTimeProviderPresent.UseVisualStyleBackColor = true;
            // 
            // nullableDateTimePickerUtcOffset
            // 
            this.nullableDateTimePickerUtcOffset.Location = new System.Drawing.Point(20, 65);
            this.nullableDateTimePickerUtcOffset.Name = "nullableDateTimePickerUtcOffset";
            this.nullableDateTimePickerUtcOffset.Size = new System.Drawing.Size(172, 20);
            this.nullableDateTimePickerUtcOffset.TabIndex = 1;
            this.nullableDateTimePickerUtcOffset.Value = null;
            this.nullableDateTimePickerUtcOffset.ValueChanged += new System.EventHandler(this.dateTimePickerUtcOffset_ValueChanged);
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(86, 19);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerTime.TabIndex = 0;
            this.dateTimePickerTime.Value = new System.DateTime(2010, 11, 30, 0, 0, 0, 0);
            this.dateTimePickerTime.ValueChanged += new System.EventHandler(this.dateTimePickerTime_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "UTC Offset:";
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
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingRight);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMiscellaneous);
            this.tabControl.Controls.Add(this.tabPageBackgrounds);
            this.tabControl.Controls.Add(this.tabPageRimMarkers);
            this.tabControl.Controls.Add(this.tabPageHands);
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
            // tabPageBackgrounds
            // 
            this.tabPageBackgrounds.Controls.Add(this.backgroundsEditor1);
            this.tabPageBackgrounds.Location = new System.Drawing.Point(4, 22);
            this.tabPageBackgrounds.Name = "tabPageBackgrounds";
            this.tabPageBackgrounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBackgrounds.Size = new System.Drawing.Size(409, 546);
            this.tabPageBackgrounds.TabIndex = 9;
            this.tabPageBackgrounds.Text = "Backgrounds";
            this.tabPageBackgrounds.UseVisualStyleBackColor = true;
            // 
            // tabPageRimMarkers
            // 
            this.tabPageRimMarkers.Controls.Add(this.tableLayoutPanel3);
            this.tabPageRimMarkers.Location = new System.Drawing.Point(4, 22);
            this.tabPageRimMarkers.Name = "tabPageRimMarkers";
            this.tabPageRimMarkers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRimMarkers.Size = new System.Drawing.Size(409, 546);
            this.tabPageRimMarkers.TabIndex = 10;
            this.tabPageRimMarkers.Text = "Rim Markers";
            this.tabPageRimMarkers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.propertyGridAngularShapes, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxAngularShapes, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(403, 540);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // propertyGridAngularShapes
            // 
            this.propertyGridAngularShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.propertyGridAngularShapes, 2);
            this.propertyGridAngularShapes.Location = new System.Drawing.Point(3, 203);
            this.propertyGridAngularShapes.Name = "propertyGridAngularShapes";
            this.propertyGridAngularShapes.Size = new System.Drawing.Size(397, 334);
            this.propertyGridAngularShapes.TabIndex = 12;
            // 
            // groupBoxAngularShapes
            // 
            this.groupBoxAngularShapes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.groupBoxAngularShapes, 2);
            this.groupBoxAngularShapes.Controls.Add(this.tableLayoutPanelAngularShapes);
            this.groupBoxAngularShapes.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAngularShapes.Name = "groupBoxAngularShapes";
            this.groupBoxAngularShapes.Size = new System.Drawing.Size(397, 194);
            this.groupBoxAngularShapes.TabIndex = 2;
            this.groupBoxAngularShapes.TabStop = false;
            this.groupBoxAngularShapes.Text = "Angular Shapes";
            // 
            // tableLayoutPanelAngularShapes
            // 
            this.tableLayoutPanelAngularShapes.ColumnCount = 3;
            this.tableLayoutPanelAngularShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAngularShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelAngularShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAngularShapes.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanelAngularShapes.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanelAngularShapes.Controls.Add(this.listBoxRimMarkersAvailable, 2, 1);
            this.tableLayoutPanelAngularShapes.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanelAngularShapes.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanelAngularShapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAngularShapes.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelAngularShapes.Name = "tableLayoutPanelAngularShapes";
            this.tableLayoutPanelAngularShapes.RowCount = 2;
            this.tableLayoutPanelAngularShapes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAngularShapes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAngularShapes.Size = new System.Drawing.Size(391, 175);
            this.tableLayoutPanelAngularShapes.TabIndex = 2;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel9.Controls.Add(this.listBoxRimMarkers, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.flowLayoutPanel5, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 13);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(163, 162);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // listBoxRimMarkers
            // 
            this.listBoxRimMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRimMarkers.FormattingEnabled = true;
            this.listBoxRimMarkers.IntegralHeight = false;
            this.listBoxRimMarkers.Location = new System.Drawing.Point(33, 3);
            this.listBoxRimMarkers.Name = "listBoxRimMarkers";
            this.listBoxRimMarkers.Size = new System.Drawing.Size(127, 156);
            this.listBoxRimMarkers.TabIndex = 0;
            this.listBoxRimMarkers.SelectedIndexChanged += new System.EventHandler(this.listBoxAngularShapes_SelectedIndexChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.buttonAngularUp);
            this.flowLayoutPanel5.Controls.Add(this.buttonAngularDown);
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(30, 60);
            this.flowLayoutPanel5.TabIndex = 2;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // buttonAngularUp
            // 
            this.buttonAngularUp.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_up;
            this.buttonAngularUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAngularUp.Location = new System.Drawing.Point(0, 0);
            this.buttonAngularUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAngularUp.Name = "buttonAngularUp";
            this.buttonAngularUp.Size = new System.Drawing.Size(30, 30);
            this.buttonAngularUp.TabIndex = 0;
            this.buttonAngularUp.UseVisualStyleBackColor = true;
            this.buttonAngularUp.Click += new System.EventHandler(this.buttonAngularUp_Click);
            // 
            // buttonAngularDown
            // 
            this.buttonAngularDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAngularDown.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_down;
            this.buttonAngularDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAngularDown.Location = new System.Drawing.Point(0, 30);
            this.buttonAngularDown.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAngularDown.Name = "buttonAngularDown";
            this.buttonAngularDown.Size = new System.Drawing.Size(30, 30);
            this.buttonAngularDown.TabIndex = 1;
            this.buttonAngularDown.UseVisualStyleBackColor = true;
            this.buttonAngularDown.Click += new System.EventHandler(this.buttonAngularDown_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonAddAngularShape);
            this.flowLayoutPanel2.Controls.Add(this.buttonRemoveAngularShape);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(166, 36);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(58, 116);
            this.flowLayoutPanel2.TabIndex = 9;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // buttonAddAngularShape
            // 
            this.buttonAddAngularShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAngularShape.Location = new System.Drawing.Point(3, 3);
            this.buttonAddAngularShape.Name = "buttonAddAngularShape";
            this.buttonAddAngularShape.Size = new System.Drawing.Size(52, 52);
            this.buttonAddAngularShape.TabIndex = 8;
            this.buttonAddAngularShape.Text = "<<<";
            this.buttonAddAngularShape.UseVisualStyleBackColor = true;
            this.buttonAddAngularShape.Click += new System.EventHandler(this.buttonAddAngularShape_Click);
            // 
            // buttonRemoveAngularShape
            // 
            this.buttonRemoveAngularShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveAngularShape.Location = new System.Drawing.Point(3, 61);
            this.buttonRemoveAngularShape.Name = "buttonRemoveAngularShape";
            this.buttonRemoveAngularShape.Size = new System.Drawing.Size(52, 52);
            this.buttonRemoveAngularShape.TabIndex = 11;
            this.buttonRemoveAngularShape.Text = ">>>";
            this.buttonRemoveAngularShape.UseVisualStyleBackColor = true;
            this.buttonRemoveAngularShape.Click += new System.EventHandler(this.buttonRemoveAngularShape_Click);
            // 
            // listBoxRimMarkersAvailable
            // 
            this.listBoxRimMarkersAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRimMarkersAvailable.DisplayMember = "Name";
            this.listBoxRimMarkersAvailable.FormattingEnabled = true;
            this.listBoxRimMarkersAvailable.IntegralHeight = false;
            this.listBoxRimMarkersAvailable.Location = new System.Drawing.Point(230, 16);
            this.listBoxRimMarkersAvailable.Name = "listBoxRimMarkersAvailable";
            this.listBoxRimMarkersAvailable.Size = new System.Drawing.Size(158, 156);
            this.listBoxRimMarkersAvailable.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "In Use";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Available";
            // 
            // tabPageHands
            // 
            this.tabPageHands.Controls.Add(this.tableLayoutPanel4);
            this.tabPageHands.Location = new System.Drawing.Point(4, 22);
            this.tabPageHands.Name = "tabPageHands";
            this.tabPageHands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHands.Size = new System.Drawing.Size(409, 546);
            this.tabPageHands.TabIndex = 11;
            this.tabPageHands.Text = "Hands";
            this.tabPageHands.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.propertyGridHandShapes, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBoxHandShapes, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(403, 540);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // propertyGridHandShapes
            // 
            this.propertyGridHandShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.propertyGridHandShapes, 2);
            this.propertyGridHandShapes.Location = new System.Drawing.Point(3, 203);
            this.propertyGridHandShapes.Name = "propertyGridHandShapes";
            this.propertyGridHandShapes.Size = new System.Drawing.Size(397, 334);
            this.propertyGridHandShapes.TabIndex = 12;
            // 
            // groupBoxHandShapes
            // 
            this.groupBoxHandShapes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.groupBoxHandShapes, 2);
            this.groupBoxHandShapes.Controls.Add(this.tableLayoutPanel6);
            this.groupBoxHandShapes.Location = new System.Drawing.Point(3, 3);
            this.groupBoxHandShapes.Name = "groupBoxHandShapes";
            this.groupBoxHandShapes.Size = new System.Drawing.Size(397, 194);
            this.groupBoxHandShapes.TabIndex = 2;
            this.groupBoxHandShapes.TabStop = false;
            this.groupBoxHandShapes.Text = "Hand Shapes";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.listBoxHandsAvailable, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label18, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(391, 175);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel8.Controls.Add(this.flowLayoutPanel6, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.listBoxHands, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 13);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(163, 162);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel6.Controls.Add(this.buttonHandUp);
            this.flowLayoutPanel6.Controls.Add(this.buttonHandDown);
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(30, 60);
            this.flowLayoutPanel6.TabIndex = 2;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // buttonHandUp
            // 
            this.buttonHandUp.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_up;
            this.buttonHandUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonHandUp.Location = new System.Drawing.Point(0, 0);
            this.buttonHandUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHandUp.Name = "buttonHandUp";
            this.buttonHandUp.Size = new System.Drawing.Size(30, 30);
            this.buttonHandUp.TabIndex = 0;
            this.buttonHandUp.UseVisualStyleBackColor = true;
            this.buttonHandUp.Click += new System.EventHandler(this.buttonHandUp_Click);
            // 
            // buttonHandDown
            // 
            this.buttonHandDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHandDown.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_down;
            this.buttonHandDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonHandDown.Location = new System.Drawing.Point(0, 30);
            this.buttonHandDown.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHandDown.Name = "buttonHandDown";
            this.buttonHandDown.Size = new System.Drawing.Size(30, 30);
            this.buttonHandDown.TabIndex = 1;
            this.buttonHandDown.UseVisualStyleBackColor = true;
            this.buttonHandDown.Click += new System.EventHandler(this.buttonHandDown_Click);
            // 
            // listBoxHands
            // 
            this.listBoxHands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxHands.FormattingEnabled = true;
            this.listBoxHands.IntegralHeight = false;
            this.listBoxHands.Location = new System.Drawing.Point(33, 3);
            this.listBoxHands.Name = "listBoxHands";
            this.listBoxHands.Size = new System.Drawing.Size(127, 156);
            this.listBoxHands.TabIndex = 0;
            this.listBoxHands.SelectedIndexChanged += new System.EventHandler(this.listBoxHandShapes_SelectedIndexChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.buttonAddHandShape);
            this.flowLayoutPanel3.Controls.Add(this.buttonRemoveHandShape);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(166, 36);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(58, 116);
            this.flowLayoutPanel3.TabIndex = 9;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // buttonAddHandShape
            // 
            this.buttonAddHandShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddHandShape.Location = new System.Drawing.Point(3, 3);
            this.buttonAddHandShape.Name = "buttonAddHandShape";
            this.buttonAddHandShape.Size = new System.Drawing.Size(52, 52);
            this.buttonAddHandShape.TabIndex = 8;
            this.buttonAddHandShape.Text = "<<<";
            this.buttonAddHandShape.UseVisualStyleBackColor = true;
            this.buttonAddHandShape.Click += new System.EventHandler(this.buttonAddHandShape_Click);
            // 
            // buttonRemoveHandShape
            // 
            this.buttonRemoveHandShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveHandShape.Location = new System.Drawing.Point(3, 61);
            this.buttonRemoveHandShape.Name = "buttonRemoveHandShape";
            this.buttonRemoveHandShape.Size = new System.Drawing.Size(52, 52);
            this.buttonRemoveHandShape.TabIndex = 11;
            this.buttonRemoveHandShape.Text = ">>>";
            this.buttonRemoveHandShape.UseVisualStyleBackColor = true;
            this.buttonRemoveHandShape.Click += new System.EventHandler(this.buttonRemoveHandShape_Click);
            // 
            // listBoxHandsAvailable
            // 
            this.listBoxHandsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxHandsAvailable.DisplayMember = "Name";
            this.listBoxHandsAvailable.FormattingEnabled = true;
            this.listBoxHandsAvailable.IntegralHeight = false;
            this.listBoxHandsAvailable.Location = new System.Drawing.Point(230, 16);
            this.listBoxHandsAvailable.Name = "listBoxHandsAvailable";
            this.listBoxHandsAvailable.Size = new System.Drawing.Size(158, 156);
            this.listBoxHandsAvailable.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "In Use";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(230, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Available";
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
            this.propertyGridTimeProvider.Location = new System.Drawing.Point(3, 65);
            this.propertyGridTimeProvider.Name = "propertyGridTimeProvider";
            this.propertyGridTimeProvider.Size = new System.Drawing.Size(403, 478);
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
            this.groupBoxTimeProviders.Size = new System.Drawing.Size(403, 56);
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
            this.comboBoxTimeProviders.DisplayMember = "Name";
            this.comboBoxTimeProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeProviders.FormattingEnabled = true;
            this.comboBoxTimeProviders.Location = new System.Drawing.Point(95, 19);
            this.comboBoxTimeProviders.Name = "comboBoxTimeProviders";
            this.comboBoxTimeProviders.Size = new System.Drawing.Size(265, 21);
            this.comboBoxTimeProviders.TabIndex = 0;
            this.comboBoxTimeProviders.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeProviders_SelectedIndexChanged);
            // 
            // panelClock
            // 
            this.panelClock.Controls.Add(this.analogClockDemo);
            this.panelClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClock.Location = new System.Drawing.Point(8, 8);
            this.panelClock.Name = "panelClock";
            this.panelClock.Padding = new System.Windows.Forms.Padding(8);
            this.panelClock.Size = new System.Drawing.Size(679, 627);
            this.panelClock.TabIndex = 13;
            // 
            // analogClockDemo
            // 
            fancyBackground2.Name = "Fancy Dial Shape";
            fancyBackground2.OutlineColor = System.Drawing.Color.Empty;
            stringBackground2.FillColor = System.Drawing.Color.White;
            stringBackground2.Font = new System.Drawing.Font("Arial", 2.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stringBackground2.Location = ((System.Drawing.PointF)(resources.GetObject("stringBackground2.Location")));
            stringBackground2.Name = "String Ground Shape";
            stringBackground2.OutlineColor = System.Drawing.Color.Empty;
            this.analogClockDemo.Backgrounds.Add(fancyBackground2);
            this.analogClockDemo.Backgrounds.Add(stringBackground2);
            this.analogClockDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            diamondHand3.ComponentToDisplay = DustInTheWind.ClockNet.Shapes.TimeComponent.Hour;
            diamondHand3.FillColor = System.Drawing.Color.RoyalBlue;
            diamondHand3.Length = 25F;
            diamondHand3.Name = "Hour Hand Shape";
            diamondHand3.OutlineColor = System.Drawing.Color.Empty;
            diamondHand3.Time = System.TimeSpan.Parse("21:00:39.1321947");
            diamondHand4.ComponentToDisplay = DustInTheWind.ClockNet.Shapes.TimeComponent.Minute;
            diamondHand4.FillColor = System.Drawing.Color.LimeGreen;
            diamondHand4.Length = 38F;
            diamondHand4.Name = "Minute Hand Shape";
            diamondHand4.OutlineColor = System.Drawing.Color.Empty;
            diamondHand4.TailLength = 4F;
            diamondHand4.Time = System.TimeSpan.Parse("21:00:39.1321947");
            diamondHand4.Width = 4F;
            lineHand2.ComponentToDisplay = DustInTheWind.ClockNet.Shapes.TimeComponent.Second;
            lineHand2.FillColor = System.Drawing.Color.Empty;
            lineHand2.Length = 43F;
            lineHand2.Name = "Second Hand Shape";
            lineHand2.OutlineColor = System.Drawing.Color.Red;
            lineHand2.Time = System.TimeSpan.Parse("21:00:39.1321947");
            pin2.FillColor = System.Drawing.Color.Red;
            pin2.Name = "Pin Shape";
            pin2.OutlineColor = System.Drawing.Color.Empty;
            pin2.Time = System.TimeSpan.Parse("21:00:39.1321947");
            this.analogClockDemo.Hands.Add(diamondHand3);
            this.analogClockDemo.Hands.Add(diamondHand4);
            this.analogClockDemo.Hands.Add(lineHand2);
            this.analogClockDemo.Hands.Add(pin2);
            this.analogClockDemo.Location = new System.Drawing.Point(8, 8);
            this.analogClockDemo.Name = "analogClockDemo";
            ticks3.DistanceFromEdge = 7F;
            ticks3.FillColor = System.Drawing.Color.Empty;
            ticks3.Index = 61;
            ticks3.Name = "Second Ticks";
            ticks3.SkipIndex = 5;
            ticks4.Angle = 30F;
            ticks4.DistanceFromEdge = 7F;
            ticks4.FillColor = System.Drawing.Color.Empty;
            ticks4.Index = 13;
            ticks4.Name = "Hour Ticks";
            ticks4.OutlineColor = System.Drawing.Color.White;
            ticks4.OutlineWidth = 1F;
            stringRimMarker3.Angle = 30F;
            stringRimMarker3.DistanceFromEdge = 15F;
            stringRimMarker3.FillColor = System.Drawing.Color.LightGray;
            stringRimMarker3.Font = new System.Drawing.Font("Vivaldi", 6.25F, System.Drawing.FontStyle.Italic);
            stringRimMarker3.Index = 13;
            stringRimMarker3.Name = "Hours";
            stringRimMarker3.Orientation = DustInTheWind.ClockNet.Shapes.RimMarkerOrientation.Normal;
            stringRimMarker3.OutlineColor = System.Drawing.Color.Empty;
            stringRimMarker3.Texts = new string[] {
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
            stringRimMarker4.Angle = 30F;
            stringRimMarker4.DistanceFromEdge = 2.7F;
            stringRimMarker4.FillColor = System.Drawing.Color.DarkGray;
            stringRimMarker4.Font = new System.Drawing.Font("Arial", 2.2F);
            stringRimMarker4.Index = 13;
            stringRimMarker4.Name = "Minutes";
            stringRimMarker4.OutlineColor = System.Drawing.Color.Empty;
            stringRimMarker4.Texts = new string[] {
        "5",
        "10",
        "15",
        "20",
        "25",
        "30",
        "35",
        "40",
        "45",
        "50",
        "55",
        "60"};
            this.analogClockDemo.RimMarkers.Add(ticks3);
            this.analogClockDemo.RimMarkers.Add(ticks4);
            this.analogClockDemo.RimMarkers.Add(stringRimMarker3);
            this.analogClockDemo.RimMarkers.Add(stringRimMarker4);
            this.analogClockDemo.Size = new System.Drawing.Size(663, 611);
            this.analogClockDemo.TabIndex = 0;
            this.analogClockDemo.Text = "Dust in the Wind";
            this.analogClockDemo.Time = System.TimeSpan.Parse("21:00:39.1321947");
            this.analogClockDemo.Timer = this.timer1;
            this.analogClockDemo.TimeProviderChanged += new System.EventHandler(this.analogClockDemo_TimeProviderChanged);
            this.analogClockDemo.AngularShapeAdded += new System.EventHandler<DustInTheWind.ClockNet.ShapeAddedEventArgs>(this.analogClockDemo_AngularShapeAdded);
            this.analogClockDemo.AngularShapeRemoved += new System.EventHandler<DustInTheWind.ClockNet.ShapeRemovedEventArgs>(this.analogClockDemo_AngularShapeRemoved);
            this.analogClockDemo.AngularShapeCleared += new System.EventHandler(this.analogClockDemo_AngularShapeCleared);
            this.analogClockDemo.HandShapeAdded += new System.EventHandler<DustInTheWind.ClockNet.ShapeAddedEventArgs>(this.analogClockDemo_HandShapeAdded);
            this.analogClockDemo.HandShapeRemoved += new System.EventHandler<DustInTheWind.ClockNet.ShapeRemovedEventArgs>(this.analogClockDemo_HandShapeRemoved);
            this.analogClockDemo.HandShapeCleared += new System.EventHandler(this.analogClockDemo_HandShapeCleared);
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
            this.flowLayoutPanelButtons.Controls.Add(this.label5);
            this.flowLayoutPanelButtons.Controls.Add(this.comboBoxClockTemplates);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(8, 635);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(1096, 29);
            this.flowLayoutPanelButtons.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Template:";
            // 
            // comboBoxClockTemplates
            // 
            this.comboBoxClockTemplates.DisplayMember = "Name";
            this.comboBoxClockTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClockTemplates.FormattingEnabled = true;
            this.comboBoxClockTemplates.Location = new System.Drawing.Point(144, 3);
            this.comboBoxClockTemplates.Name = "comboBoxClockTemplates";
            this.comboBoxClockTemplates.Size = new System.Drawing.Size(291, 21);
            this.comboBoxClockTemplates.TabIndex = 13;
            this.comboBoxClockTemplates.SelectedIndexChanged += new System.EventHandler(this.comboBoxClockTemplates_SelectedIndexChanged);
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
            100,
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
            // backgroundsEditor1
            // 
            this.backgroundsEditor1.AnalogClock = null;
            this.backgroundsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundsEditor1.Location = new System.Drawing.Point(3, 3);
            this.backgroundsEditor1.Name = "backgroundsEditor1";
            this.backgroundsEditor1.Size = new System.Drawing.Size(403, 540);
            this.backgroundsEditor1.TabIndex = 0;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 672);
            this.Controls.Add(this.panelClock);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.flowLayoutPanelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.tabPageBackgrounds.ResumeLayout(false);
            this.tabPageRimMarkers.ResumeLayout(false);
            this.tabPageRimMarkers.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBoxAngularShapes.ResumeLayout(false);
            this.tableLayoutPanelAngularShapes.ResumeLayout(false);
            this.tableLayoutPanelAngularShapes.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPageHands.ResumeLayout(false);
            this.tabPageHands.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBoxHandShapes.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tabPageTimeProviders.ResumeLayout(false);
            this.tabPageTimeProviders.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxTimeProviders.ResumeLayout(false);
            this.groupBoxTimeProviders.PerformLayout();
            this.panelClock.ResumeLayout(false);
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.groupBoxExternalTimer.ResumeLayout(false);
            this.groupBoxExternalTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).EndInit();
            this.panelParameters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTextFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox checkBoxKeepProportions;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMiscellaneous;
        private System.Windows.Forms.GroupBox groupBoxMiscellaneous;
        private System.Windows.Forms.Panel panelClock;
        private System.Windows.Forms.Button buttonBrowseTextFont;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPageTimeProviders;
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
        private AnalogClock analogClockDemo;
        private DustInTheWind.ClockNet.TimeProviders.LocalTimeProvider localTimeProvider1;
        private System.Windows.Forms.Label label6;
        private NullableDateTimePicker nullableDateTimePickerUtcOffset;
        private System.Windows.Forms.CheckBox checkBoxTimeProviderPresent;
        private System.Windows.Forms.TabPage tabPageBackgrounds;
        private System.Windows.Forms.TabPage tabPageRimMarkers;
        private System.Windows.Forms.TabPage tabPageHands;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PropertyGrid propertyGridAngularShapes;
        private System.Windows.Forms.GroupBox groupBoxAngularShapes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAngularShapes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button buttonAddAngularShape;
        private System.Windows.Forms.Button buttonRemoveAngularShape;
        private System.Windows.Forms.ListBox listBoxRimMarkers;
        private System.Windows.Forms.ListBox listBoxRimMarkersAvailable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PropertyGrid propertyGridHandShapes;
        private System.Windows.Forms.GroupBox groupBoxHandShapes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button buttonAddHandShape;
        private System.Windows.Forms.Button buttonRemoveHandShape;
        private System.Windows.Forms.ListBox listBoxHands;
        private System.Windows.Forms.ListBox listBoxHandsAvailable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button buttonAngularUp;
        private System.Windows.Forms.Button buttonAngularDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Button buttonHandUp;
        private System.Windows.Forms.Button buttonHandDown;
        private System.Windows.Forms.ComboBox comboBoxClockTemplates;
        private System.Windows.Forms.Label label5;
        private BackgroundsEditor backgroundsEditor1;
    }
}

