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
            this.EventObjectIDBox = new System.Windows.Forms.TextBox();
            this.EventObjectIDLoadButton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EventObjectIDBox);
            this.groupBox4.Controls.Add(this.EventObjectIDLoadButton);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 52);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EventObject ID";
            // 
            // EventObjectIDBox
            // 
            this.EventObjectIDBox.Location = new System.Drawing.Point(6, 19);
            this.EventObjectIDBox.Name = "EventObjectIDBox";
            this.EventObjectIDBox.ReadOnly = true;
            this.EventObjectIDBox.Size = new System.Drawing.Size(85, 20);
            this.EventObjectIDBox.TabIndex = 1;
            // 
            // EventObjectIDLoadButton
            // 
            this.EventObjectIDLoadButton.Location = new System.Drawing.Point(97, 17);
            this.EventObjectIDLoadButton.Name = "EventObjectIDLoadButton";
            this.EventObjectIDLoadButton.Size = new System.Drawing.Size(75, 23);
            this.EventObjectIDLoadButton.TabIndex = 1;
            this.EventObjectIDLoadButton.Text = "Load";
            this.EventObjectIDLoadButton.UseVisualStyleBackColor = true;
            this.EventObjectIDLoadButton.Click += new System.EventHandler(this.EventObjectIDLoadButton_Click);
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
        private System.Windows.Forms.TextBox EventObjectIDBox;
        private System.Windows.Forms.Button EventObjectIDLoadButton;
    }
}