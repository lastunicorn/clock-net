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
            this.localTimeMovement1 = new DustInTheWind.ClockNet.Core.Movements.LocalTimeMovement();
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
            this.labelMovement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageBackgrounds = new System.Windows.Forms.TabPage();
            this.backgroundsEditor1 = new DustInTheWind.ClockNet.Demo.BackgroundsEditor();
            this.tabPageRims = new System.Windows.Forms.TabPage();
            this.rimsEditor1 = new DustInTheWind.ClockNet.Demo.RimsEditor();
            this.tabPageHands = new System.Windows.Forms.TabPage();
            this.handsEditor1 = new DustInTheWind.ClockNet.Demo.HandsEditor();
            this.tabPageMovements = new System.Windows.Forms.TabPage();
            this.movementsEditor1 = new DustInTheWind.ClockNet.Demo.MovementsEditor();
            this.groupBoxTemplates = new System.Windows.Forms.GroupBox();
            this.comboBoxClockTemplates = new System.Windows.Forms.ComboBox();
            this.buttonExamples = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.tabPageRims.SuspendLayout();
            this.tabPageHands.SuspendLayout();
            this.tabPageMovements.SuspendLayout();
            this.groupBoxTemplates.SuspendLayout();
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
            this.tableLayoutPanel2.SetColumnSpan(this.analogClockDemo, 3);
            this.analogClockDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            diamondHand1.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Hour;
            diamondHand1.FillColor = System.Drawing.Color.RoyalBlue;
            diamondHand1.Length = 24F;
            diamondHand1.Name = "Hour Hand";
            diamondHand1.OutlineColor = System.Drawing.Color.Empty;
            diamondHand2.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Minute;
            diamondHand2.FillColor = System.Drawing.Color.LimeGreen;
            diamondHand2.Length = 37F;
            diamondHand2.Name = "Minute Hand";
            diamondHand2.OutlineColor = System.Drawing.Color.Empty;
            diamondHand2.TailLength = 4F;
            diamondHand2.Width = 4F;
            lineHand1.ComponentToDisplay = DustInTheWind.ClockNet.Core.Shapes.TimeComponent.Second;
            lineHand1.FillColor = System.Drawing.Color.Empty;
            lineHand1.Length = 42.5F;
            lineHand1.Name = "Second Hand";
            lineHand1.OutlineColor = System.Drawing.Color.Red;
            pin1.FillColor = System.Drawing.Color.Red;
            pin1.Name = "Pin";
            pin1.OutlineColor = System.Drawing.Color.Empty;
            this.analogClockDemo.Hands.Add(diamondHand1);
            this.analogClockDemo.Hands.Add(diamondHand2);
            this.analogClockDemo.Hands.Add(lineHand1);
            this.analogClockDemo.Hands.Add(pin1);
            this.analogClockDemo.Location = new System.Drawing.Point(3, 3);
            this.analogClockDemo.Movement = this.localTimeMovement1;
            this.analogClockDemo.Name = "analogClockDemo";
            ticks1.DistanceFromEdge = 4F;
            ticks1.MaxCoverageAngle = ((uint)(360u));
            ticks1.MaxCoverageCount = ((uint)(0u));
            ticks1.Name = "Minute Ticks";
            ticks1.SkipIndex = 5;
            ticks2.Angle = 30F;
            ticks2.DistanceFromEdge = 4F;
            ticks2.MaxCoverageAngle = ((uint)(360u));
            ticks2.MaxCoverageCount = ((uint)(0u));
            ticks2.Name = "Hour Ticks";
            ticks2.OutlineWidth = 1F;
            hours1.Angle = 30F;
            hours1.DistanceFromEdge = 13F;
            hours1.Font = new System.Drawing.Font("Arial", 6.25F);
            hours1.MaxCoverageAngle = ((uint)(360u));
            hours1.MaxCoverageCount = ((uint)(0u));
            hours1.Name = "Hours";
            hours1.OffsetAngle = 30F;
            hours1.Orientation = DustInTheWind.ClockNet.Core.Shapes.RimItemOrientation.Normal;
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
            this.analogClockDemo.Rims.Add(ticks1);
            this.analogClockDemo.Rims.Add(ticks2);
            this.analogClockDemo.Rims.Add(hours1);
            this.analogClockDemo.Size = new System.Drawing.Size(640, 621);
            this.analogClockDemo.TabIndex = 0;
            this.analogClockDemo.Text = "analogClock1";
            this.analogClockDemo.Time = System.TimeSpan.Parse("11:57:25.9634162");
            this.analogClockDemo.MovementChanged += new System.EventHandler(this.analogClockDemo_MovementChanged);
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
            this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanelProperties, 2);
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProperties.Size = new System.Drawing.Size(444, 650);
            this.tableLayoutPanelProperties.TabIndex = 13;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMiscellaneous);
            this.tabControl.Controls.Add(this.tabPageBackgrounds);
            this.tabControl.Controls.Add(this.tabPageRims);
            this.tabControl.Controls.Add(this.tabPageHands);
            this.tabControl.Controls.Add(this.tabPageMovements);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 64);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(438, 583);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageMiscellaneous
            // 
            this.tabPageMiscellaneous.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMiscellaneous.Location = new System.Drawing.Point(4, 22);
            this.tabPageMiscellaneous.Name = "tabPageMiscellaneous";
            this.tabPageMiscellaneous.Size = new System.Drawing.Size(430, 557);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 557);
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
            this.groupBoxValue.Controls.Add(this.labelMovement);
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
            // labelMovement
            // 
            this.labelMovement.AutoSize = true;
            this.labelMovement.Location = new System.Drawing.Point(98, 57);
            this.labelMovement.Name = "labelMovement";
            this.labelMovement.Size = new System.Drawing.Size(43, 13);
            this.labelMovement.TabIndex = 0;
            this.labelMovement.Text = "<none>";
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
            this.tabPageBackgrounds.Size = new System.Drawing.Size(430, 557);
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
            this.backgroundsEditor1.Size = new System.Drawing.Size(424, 551);
            this.backgroundsEditor1.TabIndex = 0;
            // 
            // tabPageRims
            // 
            this.tabPageRims.Controls.Add(this.rimsEditor1);
            this.tabPageRims.Location = new System.Drawing.Point(4, 22);
            this.tabPageRims.Name = "tabPageRims";
            this.tabPageRims.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRims.Size = new System.Drawing.Size(430, 557);
            this.tabPageRims.TabIndex = 10;
            this.tabPageRims.Text = "Rims";
            this.tabPageRims.UseVisualStyleBackColor = true;
            // 
            // rimsEditor1
            // 
            this.rimsEditor1.AnalogClock = null;
            this.rimsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rimsEditor1.Location = new System.Drawing.Point(3, 3);
            this.rimsEditor1.Name = "rimsEditor1";
            this.rimsEditor1.Size = new System.Drawing.Size(424, 551);
            this.rimsEditor1.TabIndex = 0;
            // 
            // tabPageHands
            // 
            this.tabPageHands.Controls.Add(this.handsEditor1);
            this.tabPageHands.Location = new System.Drawing.Point(4, 22);
            this.tabPageHands.Name = "tabPageHands";
            this.tabPageHands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHands.Size = new System.Drawing.Size(430, 557);
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
            this.handsEditor1.Size = new System.Drawing.Size(424, 551);
            this.handsEditor1.TabIndex = 0;
            // 
            // tabPageMovements
            // 
            this.tabPageMovements.Controls.Add(this.movementsEditor1);
            this.tabPageMovements.Location = new System.Drawing.Point(4, 22);
            this.tabPageMovements.Name = "tabPageMovements";
            this.tabPageMovements.Size = new System.Drawing.Size(430, 557);
            this.tabPageMovements.TabIndex = 8;
            this.tabPageMovements.Text = "Movements";
            this.tabPageMovements.UseVisualStyleBackColor = true;
            // 
            // movementsEditor1
            // 
            this.movementsEditor1.AnalogClock = null;
            this.movementsEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movementsEditor1.Location = new System.Drawing.Point(0, 0);
            this.movementsEditor1.Name = "movementsEditor1";
            this.movementsEditor1.Size = new System.Drawing.Size(430, 557);
            this.movementsEditor1.TabIndex = 0;
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
            this.tabPageRims.ResumeLayout(false);
            this.tabPageHands.ResumeLayout(false);
            this.tabPageMovements.ResumeLayout(false);
            this.groupBoxTemplates.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private DustInTheWind.ClockNet.Core.Movements.LocalTimeMovement localTimeMovement1;
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
        private System.Windows.Forms.TabPage tabPageRims;
        private RimsEditor rimsEditor1;
        private System.Windows.Forms.TabPage tabPageHands;
        private HandsEditor handsEditor1;
        private System.Windows.Forms.TabPage tabPageMovements;
        private MovementsEditor movementsEditor1;
        private System.Windows.Forms.GroupBox groupBoxTemplates;
        private System.Windows.Forms.ComboBox comboBoxClockTemplates;
        private System.Windows.Forms.Button buttonExamples;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelMovement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

