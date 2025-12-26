namespace DustInTheWind.ClockNet.Demo
{
    partial class TimeProvidersEditor
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridTimeProvider = new System.Windows.Forms.PropertyGrid();
            this.groupBoxTimeProviders = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTimeProviders = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxTimeProviders.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // propertyGridTimeProvider
            // 
            this.propertyGridTimeProvider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.propertyGridTimeProvider, 2);
            this.propertyGridTimeProvider.Location = new System.Drawing.Point(3, 65);
            this.propertyGridTimeProvider.Name = "propertyGridTimeProvider";
            this.propertyGridTimeProvider.Size = new System.Drawing.Size(394, 532);
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
            this.groupBoxTimeProviders.Size = new System.Drawing.Size(394, 56);
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
            // TimeProvidersEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "TimeProvidersEditor";
            this.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxTimeProviders.ResumeLayout(false);
            this.groupBoxTimeProviders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PropertyGrid propertyGridTimeProvider;
        private System.Windows.Forms.GroupBox groupBoxTimeProviders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTimeProviders;
    }
}
