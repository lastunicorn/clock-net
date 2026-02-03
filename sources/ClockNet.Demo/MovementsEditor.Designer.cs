namespace DustInTheWind.ClockNet.Demo
{
    partial class MovementsEditor
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
            this.propertyGridMovement = new System.Windows.Forms.PropertyGrid();
            this.groupBoxMovements = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMovements = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxMovements.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.propertyGridMovement, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxMovements, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // propertyGridMovement
            // 
            this.propertyGridMovement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.propertyGridMovement, 2);
            this.propertyGridMovement.Location = new System.Drawing.Point(3, 65);
            this.propertyGridMovement.Name = "propertyGridMovement";
            this.propertyGridMovement.Size = new System.Drawing.Size(394, 532);
            this.propertyGridMovement.TabIndex = 12;
            // 
            // groupBoxMovements
            // 
            this.groupBoxMovements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxMovements, 2);
            this.groupBoxMovements.Controls.Add(this.label1);
            this.groupBoxMovements.Controls.Add(this.comboBoxMovements);
            this.groupBoxMovements.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMovements.Name = "groupBoxMovements";
            this.groupBoxMovements.Size = new System.Drawing.Size(394, 56);
            this.groupBoxMovements.TabIndex = 2;
            this.groupBoxMovements.TabStop = false;
            this.groupBoxMovements.Text = "Movements";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movement";
            // 
            // comboBoxMovements
            // 
            this.comboBoxMovements.DisplayMember = "Name";
            this.comboBoxMovements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMovements.FormattingEnabled = true;
            this.comboBoxMovements.Location = new System.Drawing.Point(95, 19);
            this.comboBoxMovements.Name = "comboBoxMovements";
            this.comboBoxMovements.Size = new System.Drawing.Size(265, 21);
            this.comboBoxMovements.TabIndex = 0;
            this.comboBoxMovements.SelectedIndexChanged += new System.EventHandler(this.comboBoxMovements_SelectedIndexChanged);
            // 
            // MovementsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "MovementsEditor";
            this.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxMovements.ResumeLayout(false);
            this.groupBoxMovements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PropertyGrid propertyGridMovement;
        private System.Windows.Forms.GroupBox groupBoxMovements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMovements;
    }
}
