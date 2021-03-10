using X3Tools.Bases.Story.Scripting;

namespace X3_Tool.UI.Displays
{
    partial class DynamicValueEditorDisplay
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
            X3Tools.Bases.Story.Scripting.DynamicValue dynamicValue1 = new X3Tools.Bases.Story.Scripting.DynamicValue();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dynamicValueDisplay1 = new X3Tools.DynamicValueDisplay();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dynamicValueDisplay1
            // 
            this.dynamicValueDisplay1.Location = new System.Drawing.Point(12, 12);
            this.dynamicValueDisplay1.MinimumSize = new System.Drawing.Size(179, 108);
            this.dynamicValueDisplay1.Name = "dynamicValueDisplay1";
            this.dynamicValueDisplay1.Size = new System.Drawing.Size(179, 108);
            this.dynamicValueDisplay1.TabIndex = 2;
            this.dynamicValueDisplay1.Text = "Value";
            this.dynamicValueDisplay1.Value = dynamicValue1;
            // 
            // DynamicValueEditorDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 181);
            this.Controls.Add(this.dynamicValueDisplay1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DynamicValueEditorDisplay";
            this.Text = "DynamicValueEditorDisplay";
            this.Load += new System.EventHandler(this.DynamicValueEditorDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private X3Tools.DynamicValueDisplay dynamicValueDisplay1;
    }
}