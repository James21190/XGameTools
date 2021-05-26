namespace XRAMTool.Bases.Sector
{
    partial class SectorObject_Display
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
            this.sectorObjectView1 = new XCommonLib.UI.SectorObjectView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(210, 426);
            this.treeView1.TabIndex = 0;
            // 
            // sectorObjectView1
            // 
            this.sectorObjectView1.Location = new System.Drawing.Point(228, 12);
            this.sectorObjectView1.Name = "sectorObjectView1";
            this.sectorObjectView1.Size = new System.Drawing.Size(560, 426);
            this.sectorObjectView1.TabIndex = 1;
            // 
            // SectorObject_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sectorObjectView1);
            this.Controls.Add(this.treeView1);
            this.Name = "SectorObject_Display";
            this.Text = "SectorObject_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private XCommonLib.UI.SectorObjectView sectorObjectView1;
    }
}