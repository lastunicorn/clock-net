namespace DustInTheWind.ClockNet
{
    partial class NullableDateTimePicker
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
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonNull = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePicker.CalendarForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.DateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.DateTimePicker.TabIndex = 0;
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // buttonNull
            // 
            this.buttonNull.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNull.AutoSize = true;
            this.buttonNull.Location = new System.Drawing.Point(227, 0);
            this.buttonNull.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.buttonNull.Name = "buttonNull";
            this.buttonNull.Size = new System.Drawing.Size(73, 20);
            this.buttonNull.TabIndex = 1;
            this.buttonNull.Text = "Delete";
            this.buttonNull.UseVisualStyleBackColor = true;
            this.buttonNull.Click += new System.EventHandler(this.buttonNull_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreate.Location = new System.Drawing.Point(0, 0);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(300, 20);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create New Date";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonNull, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DateTimePicker, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 20);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Visible = false;
            // 
            // NullableDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonCreate);
            this.Name = "NullableDateTimePicker";
            this.Size = new System.Drawing.Size(300, 20);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNull;
        public System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
