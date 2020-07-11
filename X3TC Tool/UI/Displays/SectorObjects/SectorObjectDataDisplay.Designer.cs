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
            this.button1 = new System.Windows.Forms.Button();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LastChildButton = new System.Windows.Forms.Button();
            this.FirstChildButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ScaleBox = new Common.UI.Vector3Display();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudTotalSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(12, 70);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(98, 23);
            this.NextButton.TabIndex = 13;
            this.NextButton.Text = "Go To Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // LastChildButton
            // 
            this.LastChildButton.Location = new System.Drawing.Point(116, 99);
            this.LastChildButton.Name = "LastChildButton";
            this.LastChildButton.Size = new System.Drawing.Size(98, 23);
            this.LastChildButton.TabIndex = 16;
            this.LastChildButton.Text = "Go To Last Child";
            this.LastChildButton.UseVisualStyleBackColor = true;
            this.LastChildButton.Click += new System.EventHandler(this.LastChildButton_Click);
            // 
            // FirstChildButton
            // 
            this.FirstChildButton.Location = new System.Drawing.Point(116, 70);
            this.FirstChildButton.Name = "FirstChildButton";
            this.FirstChildButton.Size = new System.Drawing.Size(98, 23);
            this.FirstChildButton.TabIndex = 15;
            this.FirstChildButton.Text = "Go To First Child";
            this.FirstChildButton.UseVisualStyleBackColor = true;
            this.FirstChildButton.Click += new System.EventHandler(this.FirstChildButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(382, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ScaleBox
            // 
            this.ScaleBox.DecimalPlaces = 0;
            this.ScaleBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleBox.Location = new System.Drawing.Point(220, 19);
            this.ScaleBox.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.ScaleBox.MaximumSize = new System.Drawing.Size(156, 103);
            this.ScaleBox.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ScaleBox.MinimumSize = new System.Drawing.Size(100, 103);
            this.ScaleBox.Name = "ScaleBox";
            this.ScaleBox.Size = new System.Drawing.Size(156, 103);
            this.ScaleBox.TabIndex = 17;
            this.ScaleBox.Text = "Scale";
            this.ScaleBox.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ScaleBox.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ScaleBox.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudSize
            // 
            this.nudSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSize.Location = new System.Drawing.Point(6, 19);
            this.nudSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.ReadOnly = true;
            this.nudSize.Size = new System.Drawing.Size(144, 20);
            this.nudSize.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSize);
            this.groupBox1.Location = new System.Drawing.Point(220, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 46);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudTotalSize);
            this.groupBox3.Location = new System.Drawing.Point(220, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 46);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Size";
            // 
            // nudTotalSize
            // 
            this.nudTotalSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTotalSize.Location = new System.Drawing.Point(6, 19);
            this.nudTotalSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudTotalSize.Name = "nudTotalSize";
            this.nudTotalSize.ReadOnly = true;
            this.nudTotalSize.Size = new System.Drawing.Size(144, 20);
            this.nudTotalSize.TabIndex = 19;
            // 
            // SectorObjectDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ScaleBox);
            this.Controls.Add(this.LastChildButton);
            this.Controls.Add(this.FirstChildButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.groupBox2);
            this.Name = "SectorObjectDataDisplay";
            this.Text = "SectorObjectDataDisplay";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button LastChildButton;
        private System.Windows.Forms.Button FirstChildButton;
        private Common.UI.Vector3Display ScaleBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudTotalSize;
    }
}