namespace XCatTool
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHexView = new System.Windows.Forms.TabPage();
            this.rtxtHex = new System.Windows.Forms.RichTextBox();
            this.tabTextView = new System.Windows.Forms.TabPage();
            this.tabImageView = new System.Windows.Forms.TabPage();
            this.rtxtText = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabHexView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(214, 426);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHexView);
            this.tabControl1.Controls.Add(this.tabTextView);
            this.tabControl1.Controls.Add(this.tabImageView);
            this.tabControl1.Location = new System.Drawing.Point(232, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 426);
            this.tabControl1.TabIndex = 1;
            // 
            // tabHexView
            // 
            this.tabHexView.Controls.Add(this.rtxtHex);
            this.tabHexView.Location = new System.Drawing.Point(4, 22);
            this.tabHexView.Name = "tabHexView";
            this.tabHexView.Padding = new System.Windows.Forms.Padding(3);
            this.tabHexView.Size = new System.Drawing.Size(548, 400);
            this.tabHexView.TabIndex = 0;
            this.tabHexView.Text = "Hex";
            this.tabHexView.UseVisualStyleBackColor = true;
            // 
            // rtxtHex
            // 
            this.rtxtHex.Location = new System.Drawing.Point(6, 6);
            this.rtxtHex.Name = "rtxtHex";
            this.rtxtHex.Size = new System.Drawing.Size(536, 388);
            this.rtxtHex.TabIndex = 0;
            this.rtxtHex.Text = "";
            // 
            // tabTextView
            // 
            this.tabTextView.Controls.Add(this.rtxtText);
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Size = new System.Drawing.Size(548, 400);
            this.tabTextView.TabIndex = 1;
            this.tabTextView.Text = "Text";
            this.tabTextView.UseVisualStyleBackColor = true;
            // 
            // tabImageView
            // 
            this.tabImageView.Location = new System.Drawing.Point(4, 22);
            this.tabImageView.Name = "tabImageView";
            this.tabImageView.Size = new System.Drawing.Size(548, 400);
            this.tabImageView.TabIndex = 2;
            this.tabImageView.Text = "Image";
            this.tabImageView.UseVisualStyleBackColor = true;
            // 
            // rtxtText
            // 
            this.rtxtText.Location = new System.Drawing.Point(3, 3);
            this.rtxtText.Name = "rtxtText";
            this.rtxtText.Size = new System.Drawing.Size(536, 388);
            this.rtxtText.TabIndex = 1;
            this.rtxtText.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabHexView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHexView;
        private System.Windows.Forms.RichTextBox rtxtHex;
        private System.Windows.Forms.TabPage tabTextView;
        private System.Windows.Forms.TabPage tabImageView;
        private System.Windows.Forms.RichTextBox rtxtText;
    }
}

