namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    partial class EventObjectDisplay
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
            this.eventObjectPannel1 = new X3TCTool.EventObjectPannel();
            this.typeBackPanel = new System.Windows.Forms.Panel();
            this.tmrAutoReload = new System.Windows.Forms.Timer(this.components);
            this.scriptMemoryObject_Raw_Panel1 = new X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel();
            this.SuspendLayout();
            // 
            // eventObjectPannel1
            // 
            this.eventObjectPannel1.EventObject = null;
            this.eventObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.eventObjectPannel1.MinimumSize = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.Name = "eventObjectPannel1";
            this.eventObjectPannel1.ReadOnly = false;
            this.eventObjectPannel1.Size = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.TabIndex = 10;
            this.eventObjectPannel1.EventObjectLoaded += new System.EventHandler(this.eventObjectPannel1_EventObjectLoaded);
            // 
            // typeBackPanel
            // 
            this.typeBackPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeBackPanel.AutoScroll = true;
            this.typeBackPanel.Location = new System.Drawing.Point(606, 12);
            this.typeBackPanel.Name = "typeBackPanel";
            this.typeBackPanel.Size = new System.Drawing.Size(431, 491);
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
            this.scriptMemoryObject_Raw_Panel1.Location = new System.Drawing.Point(12, 245);
            this.scriptMemoryObject_Raw_Panel1.Name = "scriptMemoryObject_Raw_Panel1";
            this.scriptMemoryObject_Raw_Panel1.Size = new System.Drawing.Size(588, 258);
            this.scriptMemoryObject_Raw_Panel1.TabIndex = 11;
            this.scriptMemoryObject_Raw_Panel1.Load += new System.EventHandler(this.scriptMemoryObject_Raw_Panel1_Load);
            // 
            // EventObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 515);
            this.Controls.Add(this.scriptMemoryObject_Raw_Panel1);
            this.Controls.Add(this.typeBackPanel);
            this.Controls.Add(this.eventObjectPannel1);
            this.Name = "EventObjectDisplay";
            this.Text = "EventObjectDisplay";
            this.Load += new System.EventHandler(this.EventObjectDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private X3TCTool.EventObjectPannel eventObjectPannel1;
        private ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel scriptMemoryObject_Raw_Panel1;
        private System.Windows.Forms.Panel typeBackPanel;
        private System.Windows.Forms.Timer tmrAutoReload;
    }
}