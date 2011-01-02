namespace DustInTheWind.Clock.Demo
{
    partial class Form1
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
            DustInTheWind.Clock.Shapes.Default.TextShape textShape1 = new DustInTheWind.Clock.Shapes.Default.TextShape();
            DustInTheWind.Clock.Shapes.Default.DialShape dialShape1 = new DustInTheWind.Clock.Shapes.Default.DialShape();
            DustInTheWind.Clock.Shapes.Default.DiamondHandShape diamondHandShape1 = new DustInTheWind.Clock.Shapes.Default.DiamondHandShape();
            DustInTheWind.Clock.Shapes.Default.DiamondHandShape diamondHandShape2 = new DustInTheWind.Clock.Shapes.Default.DiamondHandShape();
            DustInTheWind.Clock.Shapes.Basic.LineHandShape lineHandShape1 = new DustInTheWind.Clock.Shapes.Basic.LineHandShape();
            DustInTheWind.Clock.Shapes.Default.PinShape pinShape1 = new DustInTheWind.Clock.Shapes.Default.PinShape();
            this.analogClock1 = new DustInTheWind.Clock.AnalogClock();
            this.SuspendLayout();
            // 
            // analogClock1
            // 
            textShape1.a = 0;
            textShape1.Font = new System.Drawing.Font("Arial", 3F);
            textShape1.OutlineColor = System.Drawing.Color.Empty;
            dialShape1.a = 0;
            dialShape1.FillColor = System.Drawing.Color.White;
            dialShape1.OutlineColor = System.Drawing.Color.Empty;
            dialShape1.Radius = 50F;
            this.analogClock1.BackgroundShapes.Add(textShape1);
            this.analogClock1.BackgroundShapes.Add(dialShape1);
            this.analogClock1.Dock = System.Windows.Forms.DockStyle.Fill;
            diamondHandShape1.ComponentToDisplay = DustInTheWind.Clock.Shapes.TimeComponent.Hour;
            diamondHandShape1.FillColor = System.Drawing.Color.RoyalBlue;
            diamondHandShape1.Height = 24F;
            diamondHandShape1.OutlineColor = System.Drawing.Color.Empty;
            diamondHandShape1.Time = System.TimeSpan.Parse("02:49:57");
            diamondHandShape2.ComponentToDisplay = DustInTheWind.Clock.Shapes.TimeComponent.Minute;
            diamondHandShape2.FillColor = System.Drawing.Color.LimeGreen;
            diamondHandShape2.Height = 37F;
            diamondHandShape2.OutlineColor = System.Drawing.Color.Empty;
            diamondHandShape2.TailLength = 4F;
            diamondHandShape2.Time = System.TimeSpan.Parse("02:49:57");
            diamondHandShape2.Width = 4F;
            lineHandShape1.ComponentToDisplay = DustInTheWind.Clock.Shapes.TimeComponent.Second;
            lineHandShape1.FillColor = System.Drawing.Color.Empty;
            lineHandShape1.Height = 42.5F;
            lineHandShape1.OutlineColor = System.Drawing.Color.Red;
            lineHandShape1.Time = System.TimeSpan.Parse("02:49:57");
            pinShape1.FillColor = System.Drawing.Color.Red;
            pinShape1.OutlineColor = System.Drawing.Color.Empty;
            pinShape1.Time = System.TimeSpan.Parse("02:49:57");
            this.analogClock1.HandShapes.Add(diamondHandShape1);
            this.analogClock1.HandShapes.Add(diamondHandShape2);
            this.analogClock1.HandShapes.Add(lineHandShape1);
            this.analogClock1.HandShapes.Add(pinShape1);
            this.analogClock1.Location = new System.Drawing.Point(0, 0);
            this.analogClock1.Name = "analogClock1";
            this.analogClock1.Size = new System.Drawing.Size(988, 832);
            this.analogClock1.TabIndex = 0;
            this.analogClock1.Text = "Dust in the Wind";
            this.analogClock1.Time = System.TimeSpan.Parse("02:49:57");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 832);
            this.Controls.Add(this.analogClock1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private AnalogClock analogClock1;


    }
}