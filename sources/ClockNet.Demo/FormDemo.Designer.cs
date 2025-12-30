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
            DustInTheWind.ClockNet.Core.Shapes.Default.FlatBackground flatBackground2 = new DustInTheWind.ClockNet.Core.Shapes.Default.FlatBackground();
            DustInTheWind.ClockNet.Core.Shapes.Basic.StringBackground stringBackground2 = new DustInTheWind.ClockNet.Core.Shapes.Basic.StringBackground();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemo));
            DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand diamondHand3 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand diamondHand4 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Core.Shapes.Basic.LineHand lineHand2 = new DustInTheWind.ClockNet.Core.Shapes.Basic.LineHand();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Pin pin2 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Pin();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks ticks3 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks ticks4 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Core.Shapes.Default.Hours hours2 = new DustInTheWind.ClockNet.Core.Shapes.Default.Hours();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.localTimeProvider1 = new DustInTheWind.ClockNet.Core.TimeProviders.LocalTimeProvider();
            this.analogClockDemo = new DustInTheWind.ClockNet.AnalogClock();
            this.tableLayoutPanelProperties = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMiscellaneous = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMiscellaneous = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownPaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKeepProportions = new System.Windows.Forms.CheckBox();
            this.numericUpDownPaddingTop = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.numericUpDownPaddingRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPaddingBottom = new System.Windows.Forms.NumericUpDown();
            this.groupBoxValue = new System.Windows.Forms.GroupBox();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageBackgrounds = new System.Windows.Forms.TabPage();
            this.tabPageRimMarkers = new System.Windows.Forms.TabPage();
            this.tabPageHands = new System.Windows.Forms.TabPage();
            this.tabPageTimeProviders = new System.Windows.Forms.TabPage();
            this.groupBoxTemplates = new System.Windows.Forms.GroupBox();
            this.comboBoxClockTemplates = new System.Windows.Forms.ComboBox();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTimeProvider = new System.Windows.Forms.Label();
            this.backgroundsEditor1 = new DustInTheWind.ClockNet.Demo.BackgroundsEditor();
            this.rimMarkersEditor1 = new DustInTheWind.ClockNet.Demo.RimMarkersEditor();
            this.handsEditor1 = new DustInTheWind.ClockNet.Demo.HandsEditor();
            this.timeProvidersEditor1 = new DustInTheWind.ClockNet.Demo.TimeProvidersEditor();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelProperties.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMiscellaneous.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxMiscellaneous.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).BeginInit();
            this.groupBoxValue.SuspendLayout();
            this.tabPageBackgrounds.SuspendLayout();
            this.tabPageRimMarkers.SuspendLayout();
            this.tabPageHands.SuspendLayout();
            this.tabPageTimeProviders.SuspendLayout();
            this.groupBoxTemplates.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // analogClockDemo
            // 
            flatBackground2.FillColor = System.Drawing.Color.Gainsboro;
            flatBackground2.Name = "Background Shape";
            flatBackground2.OutlineColor = System.Drawing.Color.Empty;
            stringBackground2.FillColor = System.Drawing.Color.DarkSlateGray;
            stringBackground2.Font = new System.Drawing.Font("Arial", 2.5F);
            stringBackground2.Location = ((System.Drawing.PointF)(resources.GetObject("stringBackground2.Location")));
            stringBackground2.Name = "Copyright";
            stringBackground2.OutlineColor = System.Drawing.Color.Empty;
            this.analogClockDemo.Backgrounds.Add(flatBackground2);
            this.analogClockDemo.Backgrounds.Add(stringBackground2);
            this.analogClockDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            diamondHand3.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Hour;
            diamondHand3.FillColor = System.Drawing.Color.RoyalBlue;
            diamondHand3.Length = 24F;
            diamondHand3.Name = "Hour Hand";
            diamondHand3.OutlineColor = System.Drawing.Color.Empty;
            diamondHand3.Time = System.TimeSpan.Parse("14:32:02.7483716");
            diamondHand4.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Minute;
            diamondHand4.FillColor = System.Drawing.Color.LimeGreen;
            diamondHand4.Length = 37F;
            diamondHand4.Name = "Minute Hand";
            diamondHand4.OutlineColor = System.Drawing.Color.Empty;
            diamondHand4.TailLength = 4F;
            diamondHand4.Time = System.TimeSpan.Parse("14:32:02.7483716");
            diamondHand4.Width = 4F;
            lineHand2.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Second;
            lineHand2.FillColor = System.Drawing.Color.Empty;
            lineHand2.Length = 42.5F;
            lineHand2.Name = "Second Hand";
            lineHand2.OutlineColor = System.Drawing.Color.Red;
            lineHand2.Time = System.TimeSpan.Parse("14:32:02.7483716");
            pin2.FillColor = System.Drawing.Color.Red;
            pin2.Name = "Pin";
            pin2.OutlineColor = System.Drawing.Color.Empty;
            pin2.Time = System.TimeSpan.Parse("14:32:02.7483716");
            this.analogClockDemo.Hands.Add(diamondHand3);
            this.analogClockDemo.Hands.Add(diamondHand4);
            this.analogClockDemo.Hands.Add(lineHand2);
            this.analogClockDemo.Hands.Add(pin2);
            this.analogClockDemo.Location = new System.Drawing.Point(3, 3);
            this.analogClockDemo.Name = "analogClockDemo";
            ticks3.DistanceFromEdge = 3F;
            ticks3.Index = 61;
            ticks3.Name = "Minute Ticks";
            ticks3.SkipIndex = 5;
            ticks4.Angle = 30F;
            ticks4.DistanceFromEdge = 3F;
            ticks4.Index = 13;
            ticks4.Name = "Hour Ticks";
            ticks4.OutlineWidth = 1F;
            hours2.Angle = 30F;
            hours2.DistanceFromEdge = 13F;
            hours2.Font = new System.Drawing.Font("Arial", 6.25F);
            hours2.Index = 13;
            hours2.Name = "Hours";
            hours2.Orientation = DustInTheWind.ClockNet.Core.Shapes.RimMarkerOrientation.Normal;
            hours2.OutlineColor = System.Drawing.Color.Empty;
            hours2.Texts = new string[] {
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
            this.analogClockDemo.RimMarkers.Add(ticks3);
            this.analogClockDemo.RimMarkers.Add(ticks4);
            this.analogClockDemo.RimMarkers.Add(hours2);
            this.analogClockDemo.Size = new System.Drawing.Size(640, 621);
            this.analogClockDemo.TabIndex = 0;
            this.analogClockDemo.Text = "analogClock1";
            this.analogClockDemo.Time = System.TimeSpan.Parse("14:32:02.7483716");
            this.analogClockDemo.TimeProvider = this.localTimeProvider1;
            this.analogClockDemo.TimeProviderChanged += new System.EventHandler(this.analogClockDemo_TimeProviderChanged);
            // 
            // tableLayoutPanelProperties
            // 
            this.tableLayoutPanelProperties.ColumnCount = 1;
            this.tableLayoutPanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProperties.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanelProperties.Controls.Add(this.groupBoxTemplates, 0, 0);
            this.tableLayoutPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProperties.Location = new System.Drawing.Point(649, 3);
            this.tableLayoutPanelProperties.Name = "tableLayoutPanelProperties";
            this.tableLayoutPanelProperties.RowCount = 2;
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProperties.Size = new System.Drawing.Size(444, 621);
            this.tableLayoutPanelProperties.TabIndex = 13;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMiscellaneous);
            this.tabControl.Controls.Add(this.tabPageBackgrounds);
            this.tabControl.Controls.Add(this.tabPageRimMarkers);
            this.tabControl.Controls.Add(this.tabPageHands);
            this.tabControl.Controls.Add(this.tabPageTimeProviders);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 64);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(438, 554);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageMiscellaneous
            // 
            this.tabPageMiscellaneous.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMiscellaneous.Location = new System.Drawing.Point(4, 22);
            this.tabPageMiscellaneous.Name = "tabPageMiscellaneous";
            this.tabPageMiscellaneous.Size = new System.Drawing.Size(430, 528);
            this.tabPageMiscellaneous.TabIndex = 0;
            this.tabPageMiscellaneous.Text = "Miscellaneous";
            this.tabPageMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMiscellaneous, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxValue, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 528);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBoxMiscellaneous
            // 
            this.groupBoxMiscellaneous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxMiscellaneous.Controls.Add(this.numericUpDownPaddingBottom);
            this.groupBoxMiscellaneous.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMiscellaneous.Name = "groupBoxMiscellaneous";
            this.groupBoxMiscellaneous.Size = new System.Drawing.Size(424, 127);
            this.groupBoxMiscellaneous.TabIndex = 13;
            this.groupBoxMiscellaneous.TabStop = false;
            this.groupBoxMiscellaneous.Text = "Miscellaneous";
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
            // numericUpDownPaddingLeft
            // 
            this.numericUpDownPaddingLeft.Location = new System.Drawing.Point(80, 64);
            this.numericUpDownPaddingLeft.Name = "numericUpDownPaddingLeft";
            this.numericUpDownPaddingLeft.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingLeft.TabIndex = 1;
            this.numericUpDownPaddingLeft.ValueChanged += new System.EventHandler(this.numericUpDownPaddingLeft_ValueChanged);
            // 
            // checkBoxKeepProportions
            // 
            this.checkBoxKeepProportions.AutoSize = true;
            this.checkBoxKeepProportions.Location = new System.Drawing.Point(80, 90);
            this.checkBoxKeepProportions.Name = "checkBoxKeepProportions";
            this.checkBoxKeepProportions.Size = new System.Drawing.Size(107, 17);
            this.checkBoxKeepProportions.TabIndex = 0;
            this.checkBoxKeepProportions.Text = "Keep Proportions";
            this.checkBoxKeepProportions.UseVisualStyleBackColor = true;
            this.checkBoxKeepProportions.CheckedChanged += new System.EventHandler(this.checkBoxKeepProportions_CheckedChanged);
            // 
            // numericUpDownPaddingTop
            // 
            this.numericUpDownPaddingTop.Location = new System.Drawing.Point(149, 64);
            this.numericUpDownPaddingTop.Name = "numericUpDownPaddingTop";
            this.numericUpDownPaddingTop.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingTop.TabIndex = 1;
            this.numericUpDownPaddingTop.ValueChanged += new System.EventHandler(this.numericUpDownPaddingTop_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Padding:";
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
            // numericUpDownPaddingRight
            // 
            this.numericUpDownPaddingRight.Location = new System.Drawing.Point(218, 64);
            this.numericUpDownPaddingRight.Name = "numericUpDownPaddingRight";
            this.numericUpDownPaddingRight.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingRight.TabIndex = 1;
            this.numericUpDownPaddingRight.ValueChanged += new System.EventHandler(this.numericUpDownPaddingRight_ValueChanged);
            // 
            // numericUpDownPaddingBottom
            // 
            this.numericUpDownPaddingBottom.Location = new System.Drawing.Point(287, 64);
            this.numericUpDownPaddingBottom.Name = "numericUpDownPaddingBottom";
            this.numericUpDownPaddingBottom.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingBottom.TabIndex = 1;
            this.numericUpDownPaddingBottom.ValueChanged += new System.EventHandler(this.numericUpDownPaddingBottom_ValueChanged);
            // 
            // groupBoxValue
            // 
            this.groupBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxValue.Controls.Add(this.dateTimePickerTime);
            this.groupBoxValue.Controls.Add(this.labelTimeProvider);
            this.groupBoxValue.Controls.Add(this.label1);
            this.groupBoxValue.Controls.Add(this.label4);
            this.groupBoxValue.Location = new System.Drawing.Point(3, 136);
            this.groupBoxValue.Name = "groupBoxValue";
            this.groupBoxValue.Size = new System.Drawing.Size(424, 115);
            this.groupBoxValue.TabIndex = 4;
            this.groupBoxValue.TabStop = false;
            this.groupBoxValue.Text = "Value";
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(101, 19);
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
            // tabPageBackgrounds
            // 
            this.tabPageBackgrounds.Controls.Add(this.backgroundsEditor1);
            this.tabPageBackgrounds.Location = new System.Drawing.Point(4, 22);
            this.tabPageBackgrounds.Name = "tabPageBackgrounds";
            this.tabPageBackgrounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBackgrounds.Size = new System.Drawing.Size(430, 528);
            this.tabPageBackgrounds.TabIndex = 9;
            this.tabPageBackgrounds.Text = "Backgrounds";
            this.tabPageBackgrounds.UseVisualStyleBackColor = true;
            // 
            // tabPageRimMarkers
            // 
            this.tabPageRimMarkers.Controls.Add(this.rimMarkersEditor1);
            this.tabPageRimMarkers.Location = new System.Drawing.Point(4, 22);
            this.tabPageRimMarkers.Name = "tabPageRimMarkers";
            this.tabPageRimMarkers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRimMarkers.Size = new System.Drawing.Size(430, 528);
            this.tabPageRimMarkers.TabIndex = 10;
            this.tabPageRimMarkers.Text = "Rim Markers";
            this.tabPageRimMarkers.UseVisualStyleBackColor = true;
            // 
            // tabPageHands
            // 
            this.tabPageHands.Controls.Add(this.handsEditor1);
            this.tabPageHands.Location = new System.Drawing.Point(4, 22);
            this.tabPageHands.Name = "tabPageHands";
            this.tabPageHands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHands.Size = new System.Drawing.Size(430, 528);
            this.tabPageHands.TabIndex = 11;
            this.tabPageHands.Text = "Hands";
            this.tabPageHands.UseVisualStyleBackColor = true;
            // 
            // tabPageTimeProviders
            // 
            this.tabPageTimeProviders.Controls.Add(this.timeProvidersEditor1);
            this.tabPageTimeProviders.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeProviders.Name = "tabPageTimeProviders";
            this.tabPageTimeProviders.Size = new System.Drawing.Size(430, 528);
            this.tabPageTimeProviders.TabIndex = 8;
            this.tabPageTimeProviders.Text = "Time Providers";
            this.tabPageTimeProviders.UseVisualStyleBackColor = true;
            // 
            // groupBoxTemplates
            // 
            this.groupBoxTemplates.Controls.Add(this.comboBoxClockTemplates);
            this.groupBoxTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTemplates.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTemplates.Name = "groupBoxTemplates";
            this.groupBoxTemplates.Size = new System.Drawing.Size(438, 55);
            this.groupBoxTemplates.TabIndex = 14;
            this.groupBoxTemplates.TabStop = false;
            this.groupBoxTemplates.Text = "Templates";
            // 
            // comboBoxClockTemplates
            // 
            this.comboBoxClockTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClockTemplates.DisplayMember = "Name";
            this.comboBoxClockTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClockTemplates.FormattingEnabled = true;
            this.comboBoxClockTemplates.Location = new System.Drawing.Point(7, 19);
            this.comboBoxClockTemplates.Name = "comboBoxClockTemplates";
            this.comboBoxClockTemplates.Size = new System.Drawing.Size(425, 21);
            this.comboBoxClockTemplates.TabIndex = 13;
            this.comboBoxClockTemplates.SelectedIndexChanged += new System.EventHandler(this.comboBoxClockTemplates_SelectedIndexChanged);
            // 
            // buttonExamples
            // 
            this.buttonExamples.AutoSize = true;
            this.buttonExamples.Location = new System.Drawing.Point(3, 630);
            this.buttonExamples.Name = "buttonExamples";
            this.buttonExamples.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonExamples.Size = new System.Drawing.Size(100, 23);
            this.buttonExamples.TabIndex = 12;
            this.buttonExamples.Text = "More Examples";
            this.buttonExamples.UseVisualStyleBackColor = true;
            this.buttonExamples.Click += new System.EventHandler(this.buttonExamples_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(109, 630);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.AutoSize = true;
            this.buttonLoad.Location = new System.Drawing.Point(190, 630);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 16;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "Clock Template Files (*.xml)|*.xml|All Files (*.*)|*.*";
            this.saveFileDialog1.Title = "Save Clock Template";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "Clock Template Files (*.xml)|*.xml|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "Load Clock Template";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel2.Controls.Add(this.buttonExamples, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonLoad, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelProperties, 3, 0);
            this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanelProperties, 2);
            this.tableLayoutPanel2.Controls.Add(this.analogClockDemo, 0, 0);
            this.tableLayoutPanel2.SetColumnSpan(this.analogClockDemo, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1096, 656);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Provider:";
            // 
            // labelTimeProvider
            // 
            this.labelTimeProvider.AutoSize = true;
            this.labelTimeProvider.Location = new System.Drawing.Point(98, 57);
            this.labelTimeProvider.Name = "labelTimeProvider";
            this.labelTimeProvider.Size = new System.Drawing.Size(43, 13);
            this.labelTimeProvider.TabIndex = 0;
            this.labelTimeProvider.Text = "<none>";
            // 
            // backgroundsEditor1
            // 
            this.backgroundsEditor1.AnalogClock = null;
            this.backgroundsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundsEditor1.Location = new System.Drawing.Point(3, 3);
            this.backgroundsEditor1.Name = "backgroundsEditor1";
            this.backgroundsEditor1.Size = new System.Drawing.Size(424, 522);
            this.backgroundsEditor1.TabIndex = 0;
            // 
            // rimMarkersEditor1
            // 
            this.rimMarkersEditor1.AnalogClock = null;
            this.rimMarkersEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rimMarkersEditor1.Location = new System.Drawing.Point(3, 3);
            this.rimMarkersEditor1.Name = "rimMarkersEditor1";
            this.rimMarkersEditor1.Size = new System.Drawing.Size(424, 522);
            this.rimMarkersEditor1.TabIndex = 0;
            // 
            // handsEditor1
            // 
            this.handsEditor1.AnalogClock = null;
            this.handsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handsEditor1.Location = new System.Drawing.Point(3, 3);
            this.handsEditor1.Name = "handsEditor1";
            this.handsEditor1.Size = new System.Drawing.Size(424, 522);
            this.handsEditor1.TabIndex = 0;
            // 
            // timeProvidersEditor1
            // 
            this.timeProvidersEditor1.AnalogClock = null;
            this.timeProvidersEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeProvidersEditor1.Location = new System.Drawing.Point(0, 0);
            this.timeProvidersEditor1.Name = "timeProvidersEditor1";
            this.timeProvidersEditor1.Size = new System.Drawing.Size(430, 528);
            this.timeProvidersEditor1.TabIndex = 0;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 672);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDemo";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelProperties.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageMiscellaneous.ResumeLayout(false);
            this.tabPageMiscellaneous.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxMiscellaneous.ResumeLayout(false);
            this.groupBoxMiscellaneous.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).EndInit();
            this.groupBoxValue.ResumeLayout(false);
            this.groupBoxValue.PerformLayout();
            this.tabPageBackgrounds.ResumeLayout(false);
            this.tabPageRimMarkers.ResumeLayout(false);
            this.tabPageHands.ResumeLayout(false);
            this.tabPageTimeProviders.ResumeLayout(false);
            this.groupBoxTemplates.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private DustInTheWind.ClockNet.Core.TimeProviders.LocalTimeProvider localTimeProvider1;
        private AnalogClock analogClockDemo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProperties;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMiscellaneous;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxMiscellaneous;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingLeft;
        private System.Windows.Forms.CheckBox checkBoxKeepProportions;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingTop;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBackgroundColor;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingRight;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingBottom;
        private System.Windows.Forms.GroupBox groupBoxValue;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageBackgrounds;
        private BackgroundsEditor backgroundsEditor1;
        private System.Windows.Forms.TabPage tabPageRimMarkers;
        private RimMarkersEditor rimMarkersEditor1;
        private System.Windows.Forms.TabPage tabPageHands;
        private HandsEditor handsEditor1;
        private System.Windows.Forms.TabPage tabPageTimeProviders;
        private TimeProvidersEditor timeProvidersEditor1;
        private System.Windows.Forms.GroupBox groupBoxTemplates;
        private System.Windows.Forms.ComboBox comboBoxClockTemplates;
        private System.Windows.Forms.Button buttonExamples;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelTimeProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

