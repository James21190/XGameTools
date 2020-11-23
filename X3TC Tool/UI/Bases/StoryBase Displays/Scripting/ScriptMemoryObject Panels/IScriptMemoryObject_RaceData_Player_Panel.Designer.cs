namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    partial class IScriptMemoryObject_RaceData_Player_Panel
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
            this.RaceDataPanel = new X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.IScriptMemoryObject_RaceData_Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRaces = new System.Windows.Forms.ListBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // RaceDataPanel
            // 
            this.RaceDataPanel.Location = new System.Drawing.Point(3, 3);
            this.RaceDataPanel.Name = "RaceDataPanel";
            this.RaceDataPanel.Size = new System.Drawing.Size(499, 320);
            this.RaceDataPanel.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lstRaces);
            this.groupBox3.Location = new System.Drawing.Point(508, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 224);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Races";
            // 
            // lstRaces
            // 
            this.lstRaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRaces.FormattingEnabled = true;
            this.lstRaces.Location = new System.Drawing.Point(6, 19);
            this.lstRaces.Name = "lstRaces";
            this.lstRaces.Size = new System.Drawing.Size(227, 186);
            this.lstRaces.TabIndex = 7;
            this.lstRaces.SelectedIndexChanged += new System.EventHandler(this.lstRaces_SelectedIndexChanged);
            // 
            // IScriptMemoryObject_RaceData_Player_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RaceDataPanel);
            this.Name = "IScriptMemoryObject_RaceData_Player_Panel";
            this.Size = new System.Drawing.Size(797, 326);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IScriptMemoryObject_RaceData_Panel RaceDataPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstRaces;
    }
}
