namespace XRAMTool.Bases.Story
{
    partial class ScriptArray_Display
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
            this.scriptVariableArrayView1 = new XCommonLib.UI.Bases.Story.ScriptVariableArrayView();
            this.SuspendLayout();
            // 
            // scriptVariableArrayView1
            // 
            this.scriptVariableArrayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptVariableArrayView1.DynamicValues = null;
            this.scriptVariableArrayView1.Location = new System.Drawing.Point(12, 12);
            this.scriptVariableArrayView1.Name = "scriptVariableArrayView1";
            this.scriptVariableArrayView1.Size = new System.Drawing.Size(776, 426);
            this.scriptVariableArrayView1.TabIndex = 0;
            this.scriptVariableArrayView1.RequestView += new XCommonLib.UI.Bases.Story.ScriptVariableArrayView.RequestViewHandler(this.scriptVariableArrayView1_RequestView);
            // 
            // ScriptArray_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scriptVariableArrayView1);
            this.Name = "ScriptArray_Display";
            this.Text = "ScriptArray_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private XCommonLib.UI.Bases.Story.ScriptVariableArrayView scriptVariableArrayView1;
    }
}