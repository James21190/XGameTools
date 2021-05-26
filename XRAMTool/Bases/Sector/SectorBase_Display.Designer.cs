namespace XRAMTool.Bases.Sector
{
    partial class SectorBase_Display
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
            this.ntxtAddress = new CommonToolLib.UI.NamedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ntxtAddress
            // 
            this.ntxtAddress.Location = new System.Drawing.Point(12, 12);
            this.ntxtAddress.MaximumSize = new System.Drawing.Size(0, 50);
            this.ntxtAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtAddress.Name = "ntxtAddress";
            this.ntxtAddress.ReadOnly = true;
            this.ntxtAddress.Size = new System.Drawing.Size(100, 50);
            this.ntxtAddress.TabIndex = 0;
            this.ntxtAddress.Title = "Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "View Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SectorBase_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ntxtAddress);
            this.Name = "SectorBase_Display";
            this.Text = "SectorBase";
            this.Load += new System.EventHandler(this.SectorBase_Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonToolLib.UI.NamedTextBox ntxtAddress;
        private System.Windows.Forms.Button button1;
    }
}