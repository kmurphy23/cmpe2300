namespace Lab03_Kaitlyn
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
            this.components = new System.ComponentModel.Container();
            this.CarSpawn = new System.Windows.Forms.Timer(this.components);
            this.GameTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CarSpawn
            // 
            this.CarSpawn.Enabled = true;
            this.CarSpawn.Interval = 4000;
            this.CarSpawn.Tick += new System.EventHandler(this.CarSpawn_Tick);
            // 
            // GameTime
            // 
            this.GameTime.Enabled = true;
            this.GameTime.Tick += new System.EventHandler(this.GameTime_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CarSpawn;
        private System.Windows.Forms.Timer GameTime;
    }
}

