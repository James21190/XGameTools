namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels
{
    partial class ScriptMemoryt_Headquarters_Panel
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
            this.lstBlueprints = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iScriptMemoryObject_Station_Panel1 = new X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Type_Panels.ScriptMemory_Station_Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBlueprintCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvBlueprints
            // 
            this.lstBlueprints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBlueprints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstBlueprints.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstBlueprints.HideSelection = false;
            this.lstBlueprints.Location = new System.Drawing.Point(6, 32);
            this.lstBlueprints.Name = "lstvBlueprints";
            this.lstBlueprints.Size = new System.Drawing.Size(310, 161);
            this.lstBlueprints.TabIndex = 0;
            this.lstBlueprints.UseCompatibleStateImageBehavior = false;
            this.lstBlueprints.View = System.Windows.Forms.View.Details;
            this.lstBlueprints.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Blueprints";
            this.columnHeader1.Width = 50;
            // 
            // iScriptMemoryObject_Station_Panel1
            // 
            this.iScriptMemoryObject_Station_Panel1.Location = new System.Drawing.Point(3, 3);
            this.iScriptMemoryObject_Station_Panel1.MinimumSize = new System.Drawing.Size(716, 153);
            this.iScriptMemoryObject_Station_Panel1.Name = "iScriptMemoryObject_Station_Panel1";
            this.iScriptMemoryObject_Station_Panel1.Size = new System.Drawing.Size(716, 153);
            this.iScriptMemoryObject_Station_Panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblBlueprintCount);
            this.groupBox1.Controls.Add(this.lstBlueprints);
            this.groupBox1.Location = new System.Drawing.Point(3, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blueprints";
            // 
            // lblBlueprintCount
            // 
            this.lblBlueprintCount.AutoSize = true;
            this.lblBlueprintCount.Location = new System.Drawing.Point(6, 16);
            this.lblBlueprintCount.Name = "lblBlueprintCount";
            this.lblBlueprintCount.Size = new System.Drawing.Size(24, 13);
            this.lblBlueprintCount.TabIndex = 1;
            this.lblBlueprintCount.Text = "0/0";
            // 
            // IScriptMemoryObject_Headquarters_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.iScriptMemoryObject_Station_Panel1);
            this.MinimumSize = new System.Drawing.Size(716, 153);
            this.Name = "IScriptMemoryObject_Headquarters_Panel";
            this.Size = new System.Drawing.Size(734, 364);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScriptMemory_Station_Panel iScriptMemoryObject_Station_Panel1;
        private System.Windows.Forms.ListView lstBlueprints;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBlueprintCount;
    }
}
