namespace XCommonLib.UI
{
    partial class HashTableView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ntxtEntryID = new CommonToolLib.UI.NamedTextBox();
            this.ntxtEntryObject = new CommonToolLib.UI.NamedTextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(129, 29);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(133, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 290);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ntxtEntryID
            // 
            this.ntxtEntryID.Location = new System.Drawing.Point(129, 58);
            this.ntxtEntryID.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtEntryID.Name = "ntxtEntryID";
            this.ntxtEntryID.ReadOnly = true;
            this.ntxtEntryID.Size = new System.Drawing.Size(133, 50);
            this.ntxtEntryID.TabIndex = 3;
            this.ntxtEntryID.Title = "Entry ID";
            // 
            // ntxtEntryObject
            // 
            this.ntxtEntryObject.Location = new System.Drawing.Point(129, 114);
            this.ntxtEntryObject.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtEntryObject.Name = "ntxtEntryObject";
            this.ntxtEntryObject.ReadOnly = true;
            this.ntxtEntryObject.Size = new System.Drawing.Size(133, 50);
            this.ntxtEntryObject.TabIndex = 4;
            this.ntxtEntryObject.Title = "Entry Object Pointer";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(50, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(212, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // HashTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.ntxtEntryObject);
            this.Controls.Add(this.ntxtEntryID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnScan);
            this.Name = "HashTableView";
            this.Size = new System.Drawing.Size(268, 331);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox listBox1;
        private CommonToolLib.UI.NamedTextBox ntxtEntryID;
        private CommonToolLib.UI.NamedTextBox ntxtEntryObject;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}
