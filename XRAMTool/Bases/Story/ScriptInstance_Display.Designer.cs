namespace XRAMTool.Bases.Story
{
    partial class ScriptInstance_Display
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
            this.scriptInstanceView1 = new XCommonLib.UI.Bases.Story.ScriptInstanceView();
            this.SuspendLayout();
            // 
            // scriptInstanceView1
            // 
            this.scriptInstanceView1.Location = new System.Drawing.Point(12, 12);
            this.scriptInstanceView1.Name = "scriptInstanceView1";
            this.scriptInstanceView1.Size = new System.Drawing.Size(674, 348);
            this.scriptInstanceView1.TabIndex = 0;
            // 
            // ScriptInstance_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scriptInstanceView1);
            this.Name = "ScriptInstance_Display";
            this.Text = "ScriptInstance_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private XCommonLib.UI.Bases.Story.ScriptInstanceView scriptInstanceView1;
    }
}