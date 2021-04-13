namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    partial class ScriptInstanceDisplay
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
            this.ScriptingObjectPannel1 = new X3Tools.RAM.ScriptingObjectPannel();
            this.typeBackPanel = new System.Windows.Forms.Panel();
            this.tmrAutoReload = new System.Windows.Forms.Timer(this.components);
            this.scriptMemoryObject_Raw_Panel1 = new X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // ScriptingObjectPannel1
            // 
            this.ScriptingObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.ScriptingObjectPannel1.MinimumSize = new System.Drawing.Size(469, 227);
            this.ScriptingObjectPannel1.Name = "ScriptingObjectPannel1";
            this.ScriptingObjectPannel1.ReadOnly = false;
            this.ScriptingObjectPannel1.ScriptingObject = null;
            this.ScriptingObjectPannel1.Size = new System.Drawing.Size(469, 361);
            this.ScriptingObjectPannel1.TabIndex = 10;
            this.ScriptingObjectPannel1.ScriptingObjectLoaded += new System.EventHandler(this.ScriptingObjectPannel1_ScriptingObjectLoaded);
            // 
            // typeBackPanel
            // 
            this.typeBackPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeBackPanel.AutoScroll = true;
            this.typeBackPanel.Location = new System.Drawing.Point(606, 12);
            this.typeBackPanel.Name = "typeBackPanel";
            this.typeBackPanel.Size = new System.Drawing.Size(431, 616);
            this.typeBackPanel.TabIndex = 12;
            // 
            // tmrAutoReload
            // 
            this.tmrAutoReload.Enabled = true;
            this.tmrAutoReload.Interval = 1000;
            this.tmrAutoReload.Tick += new System.EventHandler(this.tmrAutoReload_Tick);
            // 
            // scriptMemoryObject_Raw_Panel1
            // 
            this.scriptMemoryObject_Raw_Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scriptMemoryObject_Raw_Panel1.Location = new System.Drawing.Point(12, 379);
            this.scriptMemoryObject_Raw_Panel1.Name = "scriptMemoryObject_Raw_Panel1";
            this.scriptMemoryObject_Raw_Panel1.Size = new System.Drawing.Size(588, 249);
            this.scriptMemoryObject_Raw_Panel1.TabIndex = 11;
            this.scriptMemoryObject_Raw_Panel1.Load += new System.EventHandler(this.scriptMemoryObject_Raw_Panel1_Load);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1049, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ScriptInstanceDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 653);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scriptMemoryObject_Raw_Panel1);
            this.Controls.Add(this.typeBackPanel);
            this.Controls.Add(this.ScriptingObjectPannel1);
            this.Name = "ScriptInstanceDisplay";
            this.Text = "ScriptInstance";
            this.Load += new System.EventHandler(this.ScriptingObjectDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private X3Tools.RAM.ScriptingObjectPannel ScriptingObjectPannel1;
        private ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel scriptMemoryObject_Raw_Panel1;
        private System.Windows.Forms.Panel typeBackPanel;
        private System.Windows.Forms.Timer tmrAutoReload;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}