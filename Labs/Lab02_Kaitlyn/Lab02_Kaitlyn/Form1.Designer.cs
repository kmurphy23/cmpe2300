namespace Lab02_Kaitlyn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadBtn = new System.Windows.Forms.ToolStripButton();
            this.AnalyzeBtn = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PackLoadBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.PackInstBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.UninstBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadBtn,
            this.AnalyzeBtn,
            this.comboBox1,
            this.comboBox2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(368, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoadBtn
            // 
            this.LoadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadBtn.Image")));
            this.LoadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(58, 22);
            this.LoadBtn.Text = "Load File";
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // AnalyzeBtn
            // 
            this.AnalyzeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AnalyzeBtn.Image = ((System.Drawing.Image)(resources.GetObject("AnalyzeBtn.Image")));
            this.AnalyzeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AnalyzeBtn.Name = "AnalyzeBtn";
            this.AnalyzeBtn.Size = new System.Drawing.Size(52, 22);
            this.AnalyzeBtn.Text = "Analyze";
            this.AnalyzeBtn.Click += new System.EventHandler(this.AnalyzeBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Raw List Access",
            "Library Helpers",
            "Binary Search"});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // comboBox2
            // 
            this.comboBox2.Items.AddRange(new object[] {
            "All Packages ",
            "Loadable Packages",
            "Unloadable Packages"});
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 25);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PackLoadBar,
            this.PackInstBar,
            this.UninstBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(412, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PackLoadBar
            // 
            this.PackLoadBar.ActiveLinkColor = System.Drawing.Color.PowderBlue;
            this.PackLoadBar.BackColor = System.Drawing.Color.PowderBlue;
            this.PackLoadBar.Name = "PackLoadBar";
            this.PackLoadBar.Size = new System.Drawing.Size(107, 17);
            this.PackLoadBar.Text = "0 Packages Loaded";
            // 
            // PackInstBar
            // 
            this.PackInstBar.ActiveLinkColor = System.Drawing.Color.PaleGreen;
            this.PackInstBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PackInstBar.Name = "PackInstBar";
            this.PackInstBar.Size = new System.Drawing.Size(121, 17);
            this.PackInstBar.Text = "0 Packages Installable";
            // 
            // UninstBar
            // 
            this.UninstBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.UninstBar.Name = "UninstBar";
            this.UninstBar.Size = new System.Drawing.Size(136, 17);
            this.UninstBar.Text = "0 Packages UnInstallable";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(607, 455);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Package";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dependencies";
            this.columnHeader2.Width = 348;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 505);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton LoadBtn;
        private System.Windows.Forms.ToolStripButton AnalyzeBtn;
        private System.Windows.Forms.ToolStripComboBox comboBox1;
        private System.Windows.Forms.ToolStripComboBox comboBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PackLoadBar;
        private System.Windows.Forms.ToolStripStatusLabel PackInstBar;
        private System.Windows.Forms.ToolStripStatusLabel UninstBar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

