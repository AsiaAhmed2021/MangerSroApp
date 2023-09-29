namespace Image_Converter
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tİFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.ShowShortcutKeys = false;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "&Open File";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem1.ShowShortcutKeys = false;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "&Open Folder";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDJToolStripMenuItem,
            this.dDSToolStripMenuItem,
            this.pNGToolStripMenuItem,
            this.bMPToolStripMenuItem,
            this.jPGToolStripMenuItem,
            this.gIFToolStripMenuItem,
            this.tİFToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // dDJToolStripMenuItem
            // 
            this.dDJToolStripMenuItem.Checked = true;
            this.dDJToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dDJToolStripMenuItem.Name = "dDJToolStripMenuItem";
            this.dDJToolStripMenuItem.ShowShortcutKeys = false;
            this.dDJToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.dDJToolStripMenuItem.Tag = "DDJ";
            this.dDJToolStripMenuItem.Text = "DDJ";
            this.dDJToolStripMenuItem.Click += new System.EventHandler(this.dDJToolStripMenuItem_Click);
            // 
            // dDSToolStripMenuItem
            // 
            this.dDSToolStripMenuItem.Name = "dDSToolStripMenuItem";
            this.dDSToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.dDSToolStripMenuItem.Text = "DDS";
            this.dDSToolStripMenuItem.Click += new System.EventHandler(this.dDSToolStripMenuItem_Click);
            // 
            // pNGToolStripMenuItem
            // 
            this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            this.pNGToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.pNGToolStripMenuItem.Text = "PNG";
            this.pNGToolStripMenuItem.Click += new System.EventHandler(this.pNGToolStripMenuItem_Click);
            // 
            // bMPToolStripMenuItem
            // 
            this.bMPToolStripMenuItem.Name = "bMPToolStripMenuItem";
            this.bMPToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.bMPToolStripMenuItem.Text = "BMP";
            this.bMPToolStripMenuItem.Click += new System.EventHandler(this.bMPToolStripMenuItem_Click);
            // 
            // jPGToolStripMenuItem
            // 
            this.jPGToolStripMenuItem.Name = "jPGToolStripMenuItem";
            this.jPGToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.jPGToolStripMenuItem.Text = "JPG";
            this.jPGToolStripMenuItem.Click += new System.EventHandler(this.jPGToolStripMenuItem_Click);
            // 
            // gIFToolStripMenuItem
            // 
            this.gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            this.gIFToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.gIFToolStripMenuItem.Text = "GİF";
            this.gIFToolStripMenuItem.Click += new System.EventHandler(this.gIFToolStripMenuItem_Click);
            // 
            // tİFToolStripMenuItem
            // 
            this.tİFToolStripMenuItem.Name = "tİFToolStripMenuItem";
            this.tİFToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.tİFToolStripMenuItem.Text = "TİF";
            this.tİFToolStripMenuItem.Click += new System.EventHandler(this.tİFToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.saveToolStripMenuItem.Text = "&Convert";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(784, 737);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 737);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageConverter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tİFToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

