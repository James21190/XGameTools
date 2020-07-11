namespace X2TheThreatRETool
{
    partial class X2Tool
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
            this.btnLoadPlayerShip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadPlayerShip
            // 
            this.btnLoadPlayerShip.Location = new System.Drawing.Point(12, 12);
            this.btnLoadPlayerShip.Name = "btnLoadPlayerShip";
            this.btnLoadPlayerShip.Size = new System.Drawing.Size(98, 23);
            this.btnLoadPlayerShip.TabIndex = 0;
            this.btnLoadPlayerShip.Text = "Load Player Ship";
            this.btnLoadPlayerShip.UseVisualStyleBackColor = true;
            this.btnLoadPlayerShip.Click += new System.EventHandler(this.btnLoadPlayerShip_Click);
            // 
            // X2Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadPlayerShip);
            this.Name = "X2Tool";
            this.Text = "X2 Tool - Alpha 8";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPlayerShip;
    }
}