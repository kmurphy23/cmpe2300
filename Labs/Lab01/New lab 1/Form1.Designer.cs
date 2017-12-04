namespace New_lab_1
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
            this.Gobtn = new System.Windows.Forms.Button();
            this.LoadImagebtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Decoderchoice = new System.Windows.Forms.ToolStripComboBox();
            this.ColourChose = new System.Windows.Forms.ToolStripComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Gobtn
            // 
            this.Gobtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Gobtn.Location = new System.Drawing.Point(591, 597);
            this.Gobtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gobtn.Name = "Gobtn";
            this.Gobtn.Size = new System.Drawing.Size(187, 34);
            this.Gobtn.TabIndex = 2;
            this.Gobtn.Text = "GO!";
            this.Gobtn.UseVisualStyleBackColor = true;
            this.Gobtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoadImagebtn
            // 
            this.LoadImagebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadImagebtn.Location = new System.Drawing.Point(5, 593);
            this.LoadImagebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadImagebtn.Name = "LoadImagebtn";
            this.LoadImagebtn.Size = new System.Drawing.Size(180, 34);
            this.LoadImagebtn.TabIndex = 1;
            this.LoadImagebtn.Text = "Load Image...";
            this.LoadImagebtn.UseVisualStyleBackColor = true;
            this.LoadImagebtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Decoderchoice,
            this.ColourChose,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(188, 599);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(285, 28);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Decoderchoice
            // 
            this.Decoderchoice.Items.AddRange(new object[] {
            "Decode Colour ",
            "Decode Text"});
            this.Decoderchoice.Name = "Decoderchoice";
            this.Decoderchoice.Size = new System.Drawing.Size(143, 28);
            this.Decoderchoice.Text = "Choose Decoder  ";
            // 
            // ColourChose
            // 
            this.ColourChose.Items.AddRange(new object[] {
            "With 1 Bit, Red",
            "With 1 Bit, Green",
            "With 1 Bit, Blue",
            "With 1 Bit, RGB"});
            this.ColourChose.Name = "ColourChose";
            this.ColourChose.Size = new System.Drawing.Size(120, 28);
            this.ColourChose.Text = "Chose colour";
            this.ColourChose.SelectedIndexChanged += new System.EventHandler(this.ColourChose_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(824, 596);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(212, 34);
            this.progressBar1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(5, 523);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1029, 64);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(5, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1031, 505);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 28);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 640);
            this.Controls.Add(this.Gobtn);
            this.Controls.Add(this.LoadImagebtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 481);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Gobtn;
        private System.Windows.Forms.Button LoadImagebtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripComboBox Decoderchoice;
        private System.Windows.Forms.ToolStripComboBox ColourChose;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
    }
}

