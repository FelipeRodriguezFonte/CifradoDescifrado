namespace CifradoDescifrado
{
    partial class StepByStep
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
            this.logFrame = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logFrame
            // 
            this.logFrame.Location = new System.Drawing.Point(12, 12);
            this.logFrame.Multiline = true;
            this.logFrame.Name = "logFrame";
            this.logFrame.Size = new System.Drawing.Size(854, 312);
            this.logFrame.TabIndex = 0;
            this.logFrame.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StepByStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 336);
            this.Controls.Add(this.logFrame);
            this.Name = "StepByStep";
            this.Text = "StepByStep";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox logFrame;
    }
}