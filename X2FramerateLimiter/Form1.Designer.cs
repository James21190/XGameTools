namespace X2FramerateLimiter
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudFPSLimit = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFPSLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudFPSLimit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FPS Limit";
            // 
            // nudFPSLimit
            // 
            this.nudFPSLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFPSLimit.Location = new System.Drawing.Point(6, 19);
            this.nudFPSLimit.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.nudFPSLimit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFPSLimit.Name = "nudFPSLimit";
            this.nudFPSLimit.Size = new System.Drawing.Size(171, 20);
            this.nudFPSLimit.TabIndex = 0;
            this.nudFPSLimit.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFPSLimit.ValueChanged += new System.EventHandler(this.nudFPSLimit_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 70);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(223, 109);
            this.MinimumSize = new System.Drawing.Size(223, 109);
            this.Name = "Form1";
            this.Text = "X2 FPS Limiter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFPSLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudFPSLimit;
    }
}

