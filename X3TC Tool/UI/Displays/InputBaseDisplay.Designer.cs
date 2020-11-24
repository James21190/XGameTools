namespace X3_Tool.UI.Displays
{
    partial class InputBaseDisplay
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ScriptingObjectIDBox = new System.Windows.Forms.TextBox();
            this.ScriptingObjectIDLoadButton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ScriptingObjectIDBox);
            this.groupBox4.Controls.Add(this.ScriptingObjectIDLoadButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ScriptingObject ID";
            // 
            // ScriptingObjectIDBox
            // 
            this.ScriptingObjectIDBox.Location = new System.Drawing.Point(6, 19);
            this.ScriptingObjectIDBox.Name = "ScriptingObjectIDBox";
            this.ScriptingObjectIDBox.ReadOnly = true;
            this.ScriptingObjectIDBox.Size = new System.Drawing.Size(85, 20);
            this.ScriptingObjectIDBox.TabIndex = 1;
            // 
            // ScriptingObjectIDLoadButton
            // 
            this.ScriptingObjectIDLoadButton.Location = new System.Drawing.Point(97, 17);
            this.ScriptingObjectIDLoadButton.Name = "ScriptingObjectIDLoadButton";
            this.ScriptingObjectIDLoadButton.Size = new System.Drawing.Size(75, 23);
            this.ScriptingObjectIDLoadButton.TabIndex = 1;
            this.ScriptingObjectIDLoadButton.Text = "Load";
            this.ScriptingObjectIDLoadButton.UseVisualStyleBackColor = true;
            this.ScriptingObjectIDLoadButton.Click += new System.EventHandler(this.ScriptingObjectIDLoadButton_Click);
            // 
            // InputBaseDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Name = "InputBaseDisplay";
            this.Text = "InputBaseDisplay";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ScriptingObjectIDBox;
        private System.Windows.Forms.Button ScriptingObjectIDLoadButton;
    }
}