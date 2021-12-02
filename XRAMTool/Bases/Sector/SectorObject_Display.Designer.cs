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
            this.btnLoadScriptInstance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(210, 426);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // sectorObjectView1
            // 
            this.sectorObjectView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sectorObjectView1.Location = new System.Drawing.Point(228, 12);
            this.sectorObjectView1.Name = "sectorObjectView1";
            this.sectorObjectView1.Size = new System.Drawing.Size(707, 397);
            this.sectorObjectView1.TabIndex = 1;
            // 
            // btnLoadScriptInstance
            // 
            this.btnLoadScriptInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadScriptInstance.Location = new System.Drawing.Point(228, 415);
            this.btnLoadScriptInstance.Name = "btnLoadScriptInstance";
            this.btnLoadScriptInstance.Size = new System.Drawing.Size(164, 23);
            this.btnLoadScriptInstance.TabIndex = 2;
            this.btnLoadScriptInstance.Text = "Load ScriptInstance";
            this.btnLoadScriptInstance.UseVisualStyleBackColor = true;
            this.btnLoadScriptInstance.Click += new System.EventHandler(this.btnLoadScriptInstance_Click);
            // 
            // SectorObject_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 450);
            this.Controls.Add(this.btnLoadScriptInstance);
            this.Controls.Add(this.sectorObjectView1);
            this.Controls.Add(this.treeView1);
            this.Name = "SectorObject_Display";
            this.Text = "SectorObject_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private XCommonLib.UI.SectorObjectView sectorObjectView1;
        private System.Windows.Forms.Button btnLoadScriptInstance;
    }
}