namespace ICA09_Kaitlyn
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
            this.SimBtn = new System.Windows.Forms.Button();
            this.Lbl = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // SimBtn
            // 
            this.SimBtn.Location = new System.Drawing.Point(1, 1);
            this.SimBtn.Name = "SimBtn";
            this.SimBtn.Size = new System.Drawing.Size(166, 37);
            this.SimBtn.TabIndex = 0;
            this.SimBtn.Text = "Simulate";
            this.SimBtn.UseVisualStyleBackColor = true;
            this.SimBtn.Click += new System.EventHandler(this.SimBtn_Click);
            // 
            // Lbl
            // 
            this.Lbl.BackColor = System.Drawing.Color.White;
            this.Lbl.Location = new System.Drawing.Point(3, 41);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(238, 39);
            this.Lbl.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(173, 11);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 87);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.SimBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SimBtn;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Timer timer1;
    }
}

