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
            DustInTheWind.ClockNet.Core.Shapes.Default.FlatBackground flatBackground1 = new DustInTheWind.ClockNet.Core.Shapes.Default.FlatBackground();
            DustInTheWind.ClockNet.Core.Shapes.Basic.StringBackground stringBackground1 = new DustInTheWind.ClockNet.Core.Shapes.Basic.StringBackground();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDemo));
            DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand diamondHand1 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand diamondHand2 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.DiamondHand();
            DustInTheWind.ClockNet.Core.Shapes.Basic.LineHand lineHand1 = new DustInTheWind.ClockNet.Core.Shapes.Basic.LineHand();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Pin pin1 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Pin();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks ticks1 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks ticks2 = new DustInTheWind.ClockNet.Core.Shapes.Advanced.Ticks();
            DustInTheWind.ClockNet.Core.Shapes.Default.Hours hours1 = new DustInTheWind.ClockNet.Core.Shapes.Default.Hours();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.localTimeProvider1 = new DustInTheWind.ClockNet.Core.TimeProviders.LocalTimeProvider();
            this.analogClockDemo = new DustInTheWind.ClockNet.AnalogClock();
            this.tableLayoutPanelProperties = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxTemplates = new System.Windows.Forms.GroupBox();
            this.comboBoxClockTemplates = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTimeProviders = new System.Windows.Forms.TabPage();
            this.timeProvidersEditor1 = new DustInTheWind.ClockNet.Demo.TimeProvidersEditor();
            this.tabPageHands = new System.Windows.Forms.TabPage();
            this.handsEditor1 = new DustInTheWind.ClockNet.Demo.HandsEditor();
            this.tabPageRimMarkers = new System.Windows.Forms.TabPage();
            this.rimMarkersEditor1 = new DustInTheWind.ClockNet.Demo.RimMarkersEditor();
            this.tabPageBackgrounds = new System.Windows.Forms.TabPage();
            this.backgroundsEditor1 = new DustInTheWind.ClockNet.Demo.BackgroundsEditor();
            this.tabPageMiscellaneous = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxValue = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.nullableDateTimePickerUtcOffset = new DustInTheWind.ClockNet.NullableDateTimePicker();
            this.checkBoxTimeProviderPresent = new System.Windows.Forms.CheckBox();
            this.groupBoxMiscellaneous = new System.Windows.Forms.GroupBox();
            this.numericUpDownPaddingBottom = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownPaddingRight = new System.Windows.Forms.NumericUpDown();
            this.labelBackgroundColor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownPaddingTop = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKeepProportions = new System.Windows.Forms.CheckBox();
            this.numericUpDownPaddingLeft = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTextFont = new System.Windows.Forms.TextBox();
            this.buttonBrowseTextFont = new System.Windows.Forms.Button();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.checkBoxUseExternalTimer = new System.Windows.Forms.CheckBox();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelProperties.SuspendLayout();
            this.groupBoxTemplates.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageTimeProviders.SuspendLayout();
            this.tabPageHands.SuspendLayout();
            this.tabPageRimMarkers.SuspendLayout();
            this.tabPageBackgrounds.SuspendLayout();
            this.tabPageMiscellaneous.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxValue.SuspendLayout();
            this.groupBoxMiscellaneous.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).BeginInit();
            this.groupBoxTimer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // analogClockDemo
            // 
            flatBackground1.FillColor = System.Drawing.Color.Gainsboro;
            flatBackground1.Name = "Background Shape";
            flatBackground1.OutlineColor = System.Drawing.Color.Empty;
            stringBackground1.FillColor = System.Drawing.Color.DarkSlateGray;
            stringBackground1.Font = new System.Drawing.Font("Arial", 2.5F);
            stringBackground1.Location = ((System.Drawing.PointF)(resources.GetObject("stringBackground1.Location")));
            stringBackground1.Name = "Copyright";
            stringBackground1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClockDemo.Backgrounds.Add(flatBackground1);
            this.analogClockDemo.Backgrounds.Add(stringBackground1);
            this.analogClockDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            diamondHand1.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Hour;
            diamondHand1.FillColor = System.Drawing.Color.RoyalBlue;
            diamondHand1.Length = 24F;
            diamondHand1.Name = "Hour Hand";
            diamondHand1.OutlineColor = System.Drawing.Color.Empty;
            diamondHand1.Time = System.TimeSpan.Parse("02:27:37.7794054");
            diamondHand2.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Minute;
            diamondHand2.FillColor = System.Drawing.Color.LimeGreen;
            diamondHand2.Length = 37F;
            diamondHand2.Name = "Minute Hand";
            diamondHand2.OutlineColor = System.Drawing.Color.Empty;
            diamondHand2.TailLength = 4F;
            diamondHand2.Time = System.TimeSpan.Parse("02:27:37.7794054");
            diamondHand2.Width = 4F;
            lineHand1.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Second;
            lineHand1.FillColor = System.Drawing.Color.Empty;
            lineHand1.Length = 42.5F;
            lineHand1.Name = "Second Hand";
            lineHand1.OutlineColor = System.Drawing.Color.Red;
            lineHand1.Time = System.TimeSpan.Parse("02:27:37.7794054");
            pin1.FillColor = System.Drawing.Color.Red;
            pin1.Name = "Pin";
            pin1.OutlineColor = System.Drawing.Color.Empty;
            pin1.Time = System.TimeSpan.Parse("02:27:37.7794054");
            this.analogClockDemo.Hands.Add(diamondHand1);
            this.analogClockDemo.Hands.Add(diamondHand2);
            this.analogClockDemo.Hands.Add(lineHand1);
            this.analogClockDemo.Hands.Add(pin1);
            this.analogClockDemo.Location = new System.Drawing.Point(3, 3);
            this.analogClockDemo.Name = "analogClockDemo";
            ticks1.DistanceFromEdge = 3F;
            ticks1.Index = 61;
            ticks1.Name = "Minute Ticks";
            ticks1.SkipIndex = 5;
            ticks2.Angle = 30F;
            ticks2.DistanceFromEdge = 3F;
            ticks2.Index = 13;
            ticks2.Name = "Hour Ticks";
            ticks2.OutlineWidth = 1F;
            hours1.Angle = 30F;
            hours1.DistanceFromEdge = 13F;
            hours1.Font = new System.Drawing.Font("Arial", 6.25F);
            hours1.Index = 13;
            hours1.Name = "Hours";
            hours1.Orientation = DustInTheWind.ClockNet.Core.Shapes.RimMarkerOrientation.Normal;
            hours1.OutlineColor = System.Drawing.Color.Empty;
            hours1.Texts = new string[] {
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
            this.analogClockDemo.RimMarkers.Add(ticks1);
            this.analogClockDemo.RimMarkers.Add(ticks2);
            this.analogClockDemo.RimMarkers.Add(hours1);
            this.analogClockDemo.Size = new System.Drawing.Size(640, 621);
            this.analogClockDemo.TabIndex = 0;
            this.analogClockDemo.Text = "analogClock1";
            this.analogClockDemo.Time = System.TimeSpan.Parse("02:27:37.7794054");
            this.analogClockDemo.TimeProvider = this.localTimeProvider1;
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
            // tabPageTimeProviders
            // 
            this.tabPageTimeProviders.Controls.Add(this.timeProvidersEditor1);
            this.tabPageTimeProviders.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeProviders.Name = "tabPageTimeProviders";
            this.tabPageTimeProviders.Size = new System.Drawing.Size(528, 301);
            this.tabPageTimeProviders.TabIndex = 8;
            this.tabPageTimeProviders.Text = "Time Providers";
            this.tabPageTimeProviders.UseVisualStyleBackColor = true;
            // 
            // timeProvidersEditor1
            // 
            this.timeProvidersEditor1.AnalogClock = null;
            this.timeProvidersEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeProvidersEditor1.Location = new System.Drawing.Point(0, 0);
            this.timeProvidersEditor1.Name = "timeProvidersEditor1";
            this.timeProvidersEditor1.Size = new System.Drawing.Size(528, 301);
            this.timeProvidersEditor1.TabIndex = 0;
            // 
            // tabPageHands
            // 
            this.tabPageHands.Controls.Add(this.handsEditor1);
            this.tabPageHands.Location = new System.Drawing.Point(4, 22);
            this.tabPageHands.Name = "tabPageHands";
            this.tabPageHands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHands.Size = new System.Drawing.Size(528, 301);
            this.tabPageHands.TabIndex = 11;
            this.tabPageHands.Text = "Hands";
            this.tabPageHands.UseVisualStyleBackColor = true;
            // 
            // handsEditor1
            // 
            this.handsEditor1.AnalogClock = null;
            this.handsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handsEditor1.Location = new System.Drawing.Point(3, 3);
            this.handsEditor1.Name = "handsEditor1";
            this.handsEditor1.Size = new System.Drawing.Size(522, 295);
            this.handsEditor1.TabIndex = 0;
            // 
            // tabPageRimMarkers
            // 
            this.tabPageRimMarkers.Controls.Add(this.rimMarkersEditor1);
            this.tabPageRimMarkers.Location = new System.Drawing.Point(4, 22);
            this.tabPageRimMarkers.Name = "tabPageRimMarkers";
            this.tabPageRimMarkers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRimMarkers.Size = new System.Drawing.Size(528, 301);
            this.tabPageRimMarkers.TabIndex = 10;
            this.tabPageRimMarkers.Text = "Rim Markers";
            this.tabPageRimMarkers.UseVisualStyleBackColor = true;
            // 
            // rimMarkersEditor1
            // 
            this.rimMarkersEditor1.AnalogClock = null;
            this.rimMarkersEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rimMarkersEditor1.Location = new System.Drawing.Point(3, 3);
            this.rimMarkersEditor1.Name = "rimMarkersEditor1";
            this.rimMarkersEditor1.Size = new System.Drawing.Size(522, 295);
            this.rimMarkersEditor1.TabIndex = 0;
            // 
            // tabPageBackgrounds
            // 
            this.tabPageBackgrounds.Controls.Add(this.backgroundsEditor1);
            this.tabPageBackgrounds.Location = new System.Drawing.Point(4, 22);
            this.tabPageBackgrounds.Name = "tabPageBackgrounds";
            this.tabPageBackgrounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBackgrounds.Size = new System.Drawing.Size(528, 301);
            this.tabPageBackgrounds.TabIndex = 9;
            this.tabPageBackgrounds.Text = "Backgrounds";
            this.tabPageBackgrounds.UseVisualStyleBackColor = true;
            // 
            // backgroundsEditor1
            // 
            this.backgroundsEditor1.AnalogClock = null;
            this.backgroundsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundsEditor1.Location = new System.Drawing.Point(3, 3);
            this.backgroundsEditor1.Name = "backgroundsEditor1";
            this.backgroundsEditor1.Size = new System.Drawing.Size(522, 295);
            this.backgroundsEditor1.TabIndex = 0;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 528);
            this.tableLayoutPanel1.TabIndex = 8;
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
            this.groupBoxValue.Size = new System.Drawing.Size(209, 115);
            this.groupBoxValue.TabIndex = 4;
            this.groupBoxValue.TabStop = false;
            this.groupBoxValue.Text = "Value";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "UTC Offset:";
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
            // nullableDateTimePickerUtcOffset
            // 
            this.nullableDateTimePickerUtcOffset.Location = new System.Drawing.Point(20, 65);
            this.nullableDateTimePickerUtcOffset.Name = "nullableDateTimePickerUtcOffset";
            this.nullableDateTimePickerUtcOffset.Size = new System.Drawing.Size(172, 20);
            this.nullableDateTimePickerUtcOffset.TabIndex = 1;
            this.nullableDateTimePickerUtcOffset.Value = null;
            this.nullableDateTimePickerUtcOffset.ValueChanged += new System.EventHandler(this.dateTimePickerUtcOffset_ValueChanged);
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
            this.groupBoxMiscellaneous.Size = new System.Drawing.Size(424, 210);
            this.groupBoxMiscellaneous.TabIndex = 13;
            this.groupBoxMiscellaneous.TabStop = false;
            this.groupBoxMiscellaneous.Text = "Miscellaneous";
            // 
            // numericUpDownPaddingBottom
            // 
            this.numericUpDownPaddingBottom.Location = new System.Drawing.Point(287, 64);
            this.numericUpDownPaddingBottom.Name = "numericUpDownPaddingBottom";
            this.numericUpDownPaddingBottom.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingBottom.TabIndex = 1;
            this.numericUpDownPaddingBottom.ValueChanged += new System.EventHandler(this.numericUpDownPaddingBottom_ValueChanged);
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
            // numericUpDownPaddingRight
            // 
            this.numericUpDownPaddingRight.Location = new System.Drawing.Point(218, 64);
            this.numericUpDownPaddingRight.Name = "numericUpDownPaddingRight";
            this.numericUpDownPaddingRight.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingRight.TabIndex = 1;
            this.numericUpDownPaddingRight.ValueChanged += new System.EventHandler(this.numericUpDownPaddingRight_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Padding:";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Top";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Bottom";
            // 
            // numericUpDownPaddingTop
            // 
            this.numericUpDownPaddingTop.Location = new System.Drawing.Point(149, 64);
            this.numericUpDownPaddingTop.Name = "numericUpDownPaddingTop";
            this.numericUpDownPaddingTop.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingTop.TabIndex = 1;
            this.numericUpDownPaddingTop.ValueChanged += new System.EventHandler(this.numericUpDownPaddingTop_ValueChanged);
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
            // numericUpDownPaddingLeft
            // 
            this.numericUpDownPaddingLeft.Location = new System.Drawing.Point(80, 64);
            this.numericUpDownPaddingLeft.Name = "numericUpDownPaddingLeft";
            this.numericUpDownPaddingLeft.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPaddingLeft.TabIndex = 1;
            this.numericUpDownPaddingLeft.ValueChanged += new System.EventHandler(this.numericUpDownPaddingLeft_ValueChanged);
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
            // textBoxTextFont
            // 
            this.textBoxTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTextFont.Location = new System.Drawing.Point(80, 116);
            this.textBoxTextFont.Multiline = true;
            this.textBoxTextFont.Name = "textBoxTextFont";
            this.textBoxTextFont.ReadOnly = true;
            this.textBoxTextFont.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextFont.Size = new System.Drawing.Size(418, 65);
            this.textBoxTextFont.TabIndex = 2;
            // 
            // buttonBrowseTextFont
            // 
            this.buttonBrowseTextFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseTextFont.Location = new System.Drawing.Point(374, 116);
            this.buttonBrowseTextFont.Name = "buttonBrowseTextFont";
            this.buttonBrowseTextFont.Size = new System.Drawing.Size(44, 44);
            this.buttonBrowseTextFont.TabIndex = 3;
            this.buttonBrowseTextFont.Text = "...";
            this.buttonBrowseTextFont.UseVisualStyleBackColor = true;
            this.buttonBrowseTextFont.Click += new System.EventHandler(this.buttonBrowseTextFont_Click);
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimer.Controls.Add(this.checkBoxUseExternalTimer);
            this.groupBoxTimer.Location = new System.Drawing.Point(218, 219);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(209, 115);
            this.groupBoxTimer.TabIndex = 7;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
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
            // buttonExamples
            // 
            this.buttonExamples.Location = new System.Drawing.Point(3, 630);
            this.buttonExamples.Name = "buttonExamples";
            this.buttonExamples.Size = new System.Drawing.Size(75, 23);
            this.buttonExamples.TabIndex = 12;
            this.buttonExamples.Text = "Examples";
            this.buttonExamples.UseVisualStyleBackColor = true;
            this.buttonExamples.Click += new System.EventHandler(this.buttonExamples_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel2.Controls.Add(this.buttonExamples, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanelProperties, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.analogClockDemo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1096, 656);
            this.tableLayoutPanel2.TabIndex = 14;
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
            this.groupBoxTemplates.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageTimeProviders.ResumeLayout(false);
            this.tabPageHands.ResumeLayout(false);
            this.tabPageRimMarkers.ResumeLayout(false);
            this.tabPageBackgrounds.ResumeLayout(false);
            this.tabPageMiscellaneous.ResumeLayout(false);
            this.tabPageMiscellaneous.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxValue.ResumeLayout(false);
            this.groupBoxValue.PerformLayout();
            this.groupBoxMiscellaneous.ResumeLayout(false);
            this.groupBoxMiscellaneous.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaddingLeft)).EndInit();
            this.groupBoxTimer.ResumeLayout(false);
            this.groupBoxTimer.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private DustInTheWind.ClockNet.Core.TimeProviders.LocalTimeProvider localTimeProvider1;
        private AnalogClock analogClockDemo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProperties;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMiscellaneous;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.CheckBox checkBoxUseExternalTimer;
        private System.Windows.Forms.GroupBox groupBoxMiscellaneous;
        private System.Windows.Forms.Button buttonBrowseTextFont;
        private System.Windows.Forms.TextBox textBoxTextFont;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownPaddingBottom;
        private System.Windows.Forms.GroupBox groupBoxValue;
        private System.Windows.Forms.CheckBox checkBoxTimeProviderPresent;
        private NullableDateTimePicker nullableDateTimePickerUtcOffset;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.Label label6;
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
    }
}

