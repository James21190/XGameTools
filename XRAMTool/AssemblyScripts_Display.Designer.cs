namespace XRAMTool
{
    partial class AssemblyScripts_Display
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
            this.btnAttachEventManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAttachEventManager
            // 
            this.btnAttachEventManager.Location = new System.Drawing.Point(12, 12);
            this.btnAttachEventManager.Name = "btnAttachEventManager";
            this.btnAttachEventManager.Size = new System.Drawing.Size(107, 23);
            this.btnAttachEventManager.TabIndex = 0;
            this.btnAttachEventManager.Text = "Attach Events";
            this.btnAttachEventManager.UseVisualStyleBackColor = true;
            this.btnAttachEventManager.Click += new System.EventHandler(this.btnAttachEventManager_Click);
            // 
            // AssemblyScripts_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAttachEventManager);
            this.Name = "AssemblyScripts_Display";
            this.Text = "AssemblyScriptsDisplay";
            this.Load += new System.EventHandler(this.AssemblyScripts_Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAttachEventManager;
    }
}