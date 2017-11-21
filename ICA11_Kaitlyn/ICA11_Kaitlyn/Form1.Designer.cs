namespace ICA11_Kaitlyn
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
            this.LoadBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AvgBtn = new System.Windows.Forms.Button();
            this.ByteHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CountHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            this.LoadBtn.Location = new System.Drawing.Point(1, 2);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(273, 30);
            this.LoadBtn.TabIndex = 0;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ByteHead,
            this.CountHead});
            this.listView1.Location = new System.Drawing.Point(2, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(272, 316);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // AvgBtn
            // 
            this.AvgBtn.Location = new System.Drawing.Point(1, 38);
            this.AvgBtn.Name = "AvgBtn";
            this.AvgBtn.Size = new System.Drawing.Size(273, 30);
            this.AvgBtn.TabIndex = 2;
            this.AvgBtn.Text = "Average: ";
            this.AvgBtn.UseVisualStyleBackColor = true;
            this.AvgBtn.Click += new System.EventHandler(this.AvgBtn_Click);
            // 
            // ByteHead
            // 
            this.ByteHead.Text = "Bytes";
            // 
            // CountHead
            // 
            this.CountHead.Text = "Count";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 390);
            this.Controls.Add(this.AvgBtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.LoadBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ByteHead;
        private System.Windows.Forms.ColumnHeader CountHead;
        private System.Windows.Forms.Button AvgBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

