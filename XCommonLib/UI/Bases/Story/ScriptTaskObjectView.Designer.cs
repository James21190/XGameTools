namespace XCommonLib.UI.Bases.Story
{
    partial class ScriptTaskObjectView
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
            this.scriptVariableArrayView1 = new XCommonLib.UI.Bases.Story.ScriptVariableArrayView();
            this.SuspendLayout();
            // 
            // scriptVariableArrayView1
            // 
            this.scriptVariableArrayView1.DynamicValues = null;
            this.scriptVariableArrayView1.Location = new System.Drawing.Point(3, 3);
            this.scriptVariableArrayView1.Name = "scriptVariableArrayView1";
            this.scriptVariableArrayView1.Size = new System.Drawing.Size(517, 332);
            this.scriptVariableArrayView1.TabIndex = 0;
            // 
            // ScriptTaskObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scriptVariableArrayView1);
            this.Name = "ScriptTaskObjectView";
            this.Size = new System.Drawing.Size(846, 657);
            this.ResumeLayout(false);

        }

        #endregion

        private ScriptVariableArrayView scriptVariableArrayView1;
    }
}
