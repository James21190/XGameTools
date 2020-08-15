namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    partial class EventObject_RaceData_Display
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
            this.eventObjectPannel1 = new X3TCsTool.EventObjectPannel();
            this.SuspendLayout();
            // 
            // eventObjectPannel1
            // 
            this.eventObjectPannel1.EventObject = null;
            this.eventObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.eventObjectPannel1.Name = "eventObjectPannel1";
            this.eventObjectPannel1.Size = new System.Drawing.Size(460, 59);
            this.eventObjectPannel1.TabIndex = 0;
            // 
            // EventObject_RaceData_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eventObjectPannel1);
            this.Name = "EventObject_RaceData_Display";
            this.Text = "ScriptMemory_Sector_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private X3TCsTool.EventObjectPannel eventObjectPannel1;
    }
}