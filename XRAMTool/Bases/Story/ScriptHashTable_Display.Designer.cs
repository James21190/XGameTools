namespace XRAMTool.Bases.Story
{
    partial class ScriptHashTable_Display
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
            this.scriptingHashTableView1 = new XCommonLib.UI.Bases.Story.ScriptingHashTableView();
            this.SuspendLayout();
            // 
            // scriptingHashTableView1
            // 
            this.scriptingHashTableView1.Location = new System.Drawing.Point(12, 12);
            this.scriptingHashTableView1.Name = "scriptingHashTableView1";
            this.scriptingHashTableView1.Size = new System.Drawing.Size(380, 242);
            this.scriptingHashTableView1.TabIndex = 0;
            // 
            // ScriptHashTable_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scriptingHashTableView1);
            this.Name = "ScriptHashTable_Display";
            this.Text = "ScriptHashTable_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private XCommonLib.UI.Bases.Story.ScriptingHashTableView scriptingHashTableView1;
    }
}