namespace XCatTool
{
    partial class CatDatViewer
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHexView = new System.Windows.Forms.TabPage();
            this.rtxtHex = new System.Windows.Forms.RichTextBox();
            this.tabTextView = new System.Windows.Forms.TabPage();
            this.rtxtText = new System.Windows.Forms.RichTextBox();
            this.tabImageView = new System.Windows.Forms.TabPage();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.ofdGetCats = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCatFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsCatDatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportReadableCatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgdReloadTree = new System.ComponentModel.BackgroundWorker();
            this.ofdGetPcks = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabHexView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.tabImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(214, 411);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabHexView);
            this.tabControl1.Controls.Add(this.tabTextView);
            this.tabControl1.Controls.Add(this.tabImageView);
            this.tabControl1.Location = new System.Drawing.Point(232, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 411);
            this.tabControl1.TabIndex = 1;
            // 
            // tabHexView
            // 
            this.tabHexView.Controls.Add(this.rtxtHex);
            this.tabHexView.Location = new System.Drawing.Point(4, 22);
            this.tabHexView.Name = "tabHexView";
            this.tabHexView.Padding = new System.Windows.Forms.Padding(3);
            this.tabHexView.Size = new System.Drawing.Size(548, 385);
            this.tabHexView.TabIndex = 0;
            this.tabHexView.Text = "Hex";
            this.tabHexView.UseVisualStyleBackColor = true;
            // 
            // rtxtHex
            // 
            this.rtxtHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtHex.Location = new System.Drawing.Point(3, 3);
            this.rtxtHex.Name = "rtxtHex";
            this.rtxtHex.Size = new System.Drawing.Size(542, 379);
            this.rtxtHex.TabIndex = 0;
            this.rtxtHex.Text = "";
            // 
            // tabTextView
            // 
            this.tabTextView.Controls.Add(this.rtxtText);
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Size = new System.Drawing.Size(548, 385);
            this.tabTextView.TabIndex = 1;
            this.tabTextView.Text = "Text";
            this.tabTextView.UseVisualStyleBackColor = true;
            // 
            // rtxtText
            // 
            this.rtxtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtText.Location = new System.Drawing.Point(3, 3);
            this.rtxtText.Name = "rtxtText";
            this.rtxtText.Size = new System.Drawing.Size(542, 379);
            this.rtxtText.TabIndex = 1;
            this.rtxtText.Text = "";
            this.rtxtText.WordWrap = false;
            // 
            // tabImageView
            // 
            this.tabImageView.Controls.Add(this.picImage);
            this.tabImageView.Location = new System.Drawing.Point(4, 22);
            this.tabImageView.Name = "tabImageView";
            this.tabImageView.Size = new System.Drawing.Size(548, 385);
            this.tabImageView.TabIndex = 2;
            this.tabImageView.Text = "Image";
            this.tabImageView.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(3, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(542, 379);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // ofdGetCats
            // 
            this.ofdGetCats.Filter = "Catalog File|*.cat";
            this.ofdGetCats.Multiselect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCatFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fileToolStripMenuItem.Text = "Import";
            // 
            // loadCatFilesToolStripMenuItem
            // 
            this.loadCatFilesToolStripMenuItem.Name = "loadCatFilesToolStripMenuItem";
            this.loadCatFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadCatFilesToolStripMenuItem.Text = "Cat and Dat";
            this.loadCatFilesToolStripMenuItem.Click += new System.EventHandler(this.loadCatFilesToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToDirectoryToolStripMenuItem,
            this.exportAsCatDatToolStripMenuItem,
            this.exportReadableCatsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportToDirectoryToolStripMenuItem
            // 
            this.exportToDirectoryToolStripMenuItem.Name = "exportToDirectoryToolStripMenuItem";
            this.exportToDirectoryToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportToDirectoryToolStripMenuItem.Text = "Export to Directory";
            this.exportToDirectoryToolStripMenuItem.Click += new System.EventHandler(this.exportToDirectoryToolStripMenuItem_Click);
            // 
            // exportAsCatDatToolStripMenuItem
            // 
            this.exportAsCatDatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.exportChangesToolStripMenuItem});
            this.exportAsCatDatToolStripMenuItem.Name = "exportAsCatDatToolStripMenuItem";
            this.exportAsCatDatToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportAsCatDatToolStripMenuItem.Text = "Export as Cat Dat";
            this.exportAsCatDatToolStripMenuItem.Click += new System.EventHandler(this.exportAsCatDatToolStripMenuItem_Click);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exportAllToolStripMenuItem.Text = "Export All";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // exportChangesToolStripMenuItem
            // 
            this.exportChangesToolStripMenuItem.Enabled = false;
            this.exportChangesToolStripMenuItem.Name = "exportChangesToolStripMenuItem";
            this.exportChangesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exportChangesToolStripMenuItem.Text = "Export Changes";
            // 
            // exportReadableCatsToolStripMenuItem
            // 
            this.exportReadableCatsToolStripMenuItem.Name = "exportReadableCatsToolStripMenuItem";
            this.exportReadableCatsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportReadableCatsToolStripMenuItem.Text = "Export readable Cats";
            this.exportReadableCatsToolStripMenuItem.Click += new System.EventHandler(this.exportReadableCatsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click_1);
            // 
            // bgdReloadTree
            // 
            this.bgdReloadTree.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgdReloadTree_DoWork);
            // 
            // ofdGetPcks
            // 
            this.ofdGetPcks.Filter = "Pack|*.pck";
            this.ofdGetPcks.Multiselect = true;
            // 
            // CatDatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CatDatViewer";
            this.Text = "Cat Dat Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabHexView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHexView;
        private System.Windows.Forms.RichTextBox rtxtHex;
        private System.Windows.Forms.TabPage tabTextView;
        private System.Windows.Forms.TabPage tabImageView;
        private System.Windows.Forms.RichTextBox rtxtText;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.OpenFileDialog ofdGetCats;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCatFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsCatDatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgdReloadTree;
        private System.Windows.Forms.ToolStripMenuItem exportReadableCatsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdGetPcks;
    }
}

