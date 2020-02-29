namespace X3TC_Tool.UI.Displays
{
    partial class SectorObjectManagerDisplay
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
            this.LoadPlayerButton = new System.Windows.Forms.Button();
            this.LoadSectorButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.AddressBox.Size = new System.Drawing.Size(109, 20);
            this.AddressBox.TabIndex = 0;
            // 
            // LoadPlayerButton
            // 
            this.LoadPlayerButton.Location = new System.Drawing.Point(139, 12);
            this.LoadPlayerButton.Name = "LoadPlayerButton";
            this.LoadPlayerButton.Size = new System.Drawing.Size(98, 23);
            this.LoadPlayerButton.TabIndex = 1;
            this.LoadPlayerButton.Text = "Load Player Ship";
            this.LoadPlayerButton.UseVisualStyleBackColor = true;
            this.LoadPlayerButton.Click += new System.EventHandler(this.LoadPlayerButton_Click);
            // 
            // LoadSectorButton
            // 
            this.LoadSectorButton.Location = new System.Drawing.Point(139, 41);
            this.LoadSectorButton.Name = "LoadSectorButton";
            this.LoadSectorButton.Size = new System.Drawing.Size(98, 23);
            this.LoadSectorButton.TabIndex = 6;
            this.LoadSectorButton.Text = "Load Sector";
            this.LoadSectorButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Load SectorObjectHashTable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SectorObjectManagerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoadSectorButton);
            this.Controls.Add(this.LoadPlayerButton);
            this.Controls.Add(this.groupBox2);
            this.Name = "SectorObjectManagerDisplay";
            this.Text = "SectorObjectManagerDisplay";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button LoadPlayerButton;
        private System.Windows.Forms.Button LoadSectorButton;
        private System.Windows.Forms.Button button1;
    }
}