namespace ICA10_Kaitlyn
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
            this.MakeBtn = new System.Windows.Forms.Button();
            this.ShuffleBtn = new System.Windows.Forms.Button();
            this.PopBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // MakeBtn
            // 
            this.MakeBtn.Location = new System.Drawing.Point(17, 48);
            this.MakeBtn.Name = "MakeBtn";
            this.MakeBtn.Size = new System.Drawing.Size(271, 33);
            this.MakeBtn.TabIndex = 0;
            this.MakeBtn.Text = "Make List";
            this.MakeBtn.UseVisualStyleBackColor = true;
            this.MakeBtn.Click += new System.EventHandler(this.MakeBtn_Click);
            // 
            // ShuffleBtn
            // 
            this.ShuffleBtn.Location = new System.Drawing.Point(18, 87);
            this.ShuffleBtn.Name = "ShuffleBtn";
            this.ShuffleBtn.Size = new System.Drawing.Size(271, 33);
            this.ShuffleBtn.TabIndex = 1;
            this.ShuffleBtn.Text = "Shuffle It!";
            this.ShuffleBtn.UseVisualStyleBackColor = true;
            this.ShuffleBtn.Click += new System.EventHandler(this.ShuffleBtn_Click);
            // 
            // PopBtn
            // 
            this.PopBtn.Location = new System.Drawing.Point(17, 126);
            this.PopBtn.Name = "PopBtn";
            this.PopBtn.Size = new System.Drawing.Size(271, 33);
            this.PopBtn.TabIndex = 2;
            this.PopBtn.Text = "Populate Linked List!";
            this.PopBtn.UseVisualStyleBackColor = true;
            this.PopBtn.Click += new System.EventHandler(this.PopBtn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(18, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(269, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 200);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.PopBtn);
            this.Controls.Add(this.ShuffleBtn);
            this.Controls.Add(this.MakeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MakeBtn;
        private System.Windows.Forms.Button ShuffleBtn;
        private System.Windows.Forms.Button PopBtn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

