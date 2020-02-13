namespace X3TC_Tool.UI.Displays
{
    partial class SectorObjectDataDisplay
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LastChildButton = new System.Windows.Forms.Button();
            this.FirstChildButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(6, 19);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.ReadOnly = true;
            this.AddressBox.Size = new System.Drawing.Size(109, 20);
            this.AddressBox.TabIndex = 0;
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(12, 99);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(98, 23);
            this.PreviousButton.TabIndex = 14;
            this.PreviousButton.Text = "Go To Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(12, 70);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(98, 23);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = "Go To Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // LastChildButton
            // 
            this.LastChildButton.Location = new System.Drawing.Point(116, 99);
            this.LastChildButton.Name = "LastChildButton";
            this.LastChildButton.Size = new System.Drawing.Size(98, 23);
            this.LastChildButton.TabIndex = 16;
            this.LastChildButton.Text = "Go To Last Child";
            this.LastChildButton.UseVisualStyleBackColor = true;
            // 
            // FirstChildButton
            // 
            this.FirstChildButton.Location = new System.Drawing.Point(116, 70);
            this.FirstChildButton.Name = "FirstChildButton";
            this.FirstChildButton.Size = new System.Drawing.Size(98, 23);
            this.FirstChildButton.TabIndex = 15;
            this.FirstChildButton.Text = "Go To First Child";
            this.FirstChildButton.UseVisualStyleBackColor = true;
            // 
            // SectorObjectDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LastChildButton);
            this.Controls.Add(this.FirstChildButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.groupBox2);
            this.Name = "SectorObjectDataDisplay";
            this.Text = "SectorObjectDataDisplay";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button LastChildButton;
        private System.Windows.Forms.Button FirstChildButton;
    }
}