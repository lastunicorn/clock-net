namespace DustInTheWind.ClockNet.Demo
{
    partial class ShapesEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridShapes = new System.Windows.Forms.PropertyGrid();
            this.groupBoxShapes = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelBackgroundShapes = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.listBoxShapes = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddShape = new System.Windows.Forms.Button();
            this.buttonRemoveShape = new System.Windows.Forms.Button();
            this.listBoxAvailableShapes = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxShapes.SuspendLayout();
            this.tableLayoutPanelBackgroundShapes.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.propertyGridShapes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxShapes, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // propertyGridShapes
            // 
            this.propertyGridShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.propertyGridShapes, 2);
            this.propertyGridShapes.Location = new System.Drawing.Point(3, 203);
            this.propertyGridShapes.Name = "propertyGridShapes";
            this.propertyGridShapes.Size = new System.Drawing.Size(394, 394);
            this.propertyGridShapes.TabIndex = 12;
            // 
            // groupBoxShapes
            // 
            this.groupBoxShapes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxShapes, 2);
            this.groupBoxShapes.Controls.Add(this.tableLayoutPanelBackgroundShapes);
            this.groupBoxShapes.Location = new System.Drawing.Point(3, 3);
            this.groupBoxShapes.Name = "groupBoxShapes";
            this.groupBoxShapes.Size = new System.Drawing.Size(394, 194);
            this.groupBoxShapes.TabIndex = 2;
            this.groupBoxShapes.TabStop = false;
            this.groupBoxShapes.Text = "Shapes";
            // 
            // tableLayoutPanelBackgroundShapes
            // 
            this.tableLayoutPanelBackgroundShapes.ColumnCount = 3;
            this.tableLayoutPanelBackgroundShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBackgroundShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelBackgroundShapes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBackgroundShapes.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanelBackgroundShapes.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanelBackgroundShapes.Controls.Add(this.listBoxAvailableShapes, 2, 1);
            this.tableLayoutPanelBackgroundShapes.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanelBackgroundShapes.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanelBackgroundShapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBackgroundShapes.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelBackgroundShapes.Name = "tableLayoutPanelBackgroundShapes";
            this.tableLayoutPanelBackgroundShapes.RowCount = 3;
            this.tableLayoutPanelBackgroundShapes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundShapes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBackgroundShapes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelBackgroundShapes.Size = new System.Drawing.Size(388, 175);
            this.tableLayoutPanelBackgroundShapes.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel7.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.listBoxShapes, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 13);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(162, 162);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.buttonMoveUp);
            this.flowLayoutPanel4.Controls.Add(this.buttonMoveDown);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(30, 60);
            this.flowLayoutPanel4.TabIndex = 2;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_up;
            this.buttonMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMoveUp.Location = new System.Drawing.Point(0, 0);
            this.buttonMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(30, 30);
            this.buttonMoveUp.TabIndex = 0;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDown.BackgroundImage = global::DustInTheWind.ClockNet.Demo.Properties.Resources.arrow_down;
            this.buttonMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMoveDown.Location = new System.Drawing.Point(0, 30);
            this.buttonMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(30, 30);
            this.buttonMoveDown.TabIndex = 1;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // listBoxShapes
            // 
            this.listBoxShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxShapes.FormattingEnabled = true;
            this.listBoxShapes.IntegralHeight = false;
            this.listBoxShapes.Location = new System.Drawing.Point(33, 3);
            this.listBoxShapes.Name = "listBoxShapes";
            this.listBoxShapes.Size = new System.Drawing.Size(126, 156);
            this.listBoxShapes.TabIndex = 0;
            this.listBoxShapes.SelectedIndexChanged += new System.EventHandler(this.listBoxBackgrounds_SelectedIndexChanged);
            this.listBoxShapes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxShapes_MouseDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonAddShape);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemoveShape);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(165, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(58, 116);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // buttonAddShape
            // 
            this.buttonAddShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddShape.Location = new System.Drawing.Point(3, 3);
            this.buttonAddShape.Name = "buttonAddShape";
            this.buttonAddShape.Size = new System.Drawing.Size(52, 52);
            this.buttonAddShape.TabIndex = 8;
            this.buttonAddShape.Text = "<<<";
            this.buttonAddShape.UseVisualStyleBackColor = true;
            this.buttonAddShape.Click += new System.EventHandler(this.buttonAddBackground_Click);
            // 
            // buttonRemoveShape
            // 
            this.buttonRemoveShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveShape.Location = new System.Drawing.Point(3, 61);
            this.buttonRemoveShape.Name = "buttonRemoveShape";
            this.buttonRemoveShape.Size = new System.Drawing.Size(52, 52);
            this.buttonRemoveShape.TabIndex = 11;
            this.buttonRemoveShape.Text = ">>>";
            this.buttonRemoveShape.UseVisualStyleBackColor = true;
            this.buttonRemoveShape.Click += new System.EventHandler(this.buttonRemoveShape_Click);
            // 
            // listBoxAvailableShapes
            // 
            this.listBoxAvailableShapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAvailableShapes.DisplayMember = "Name";
            this.listBoxAvailableShapes.FormattingEnabled = true;
            this.listBoxAvailableShapes.IntegralHeight = false;
            this.listBoxAvailableShapes.Location = new System.Drawing.Point(229, 16);
            this.listBoxAvailableShapes.Name = "listBoxAvailableShapes";
            this.listBoxAvailableShapes.Size = new System.Drawing.Size(156, 156);
            this.listBoxAvailableShapes.TabIndex = 0;
            this.listBoxAvailableShapes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxBackgroundsAvailable_MouseDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "In Use";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Available";
            // 
            // BackgroundsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BackgroundsEditor";
            this.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxShapes.ResumeLayout(false);
            this.tableLayoutPanelBackgroundShapes.ResumeLayout(false);
            this.tableLayoutPanelBackgroundShapes.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid propertyGridShapes;
        private System.Windows.Forms.GroupBox groupBoxShapes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBackgroundShapes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.ListBox listBoxShapes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAddShape;
        private System.Windows.Forms.Button buttonRemoveShape;
        private System.Windows.Forms.ListBox listBoxAvailableShapes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
