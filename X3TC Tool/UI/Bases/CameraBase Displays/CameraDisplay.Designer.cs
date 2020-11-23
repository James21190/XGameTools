namespace X3_Tool.UI.Displays
{
    partial class CameraDisplay
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FunctionIndexBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FocusBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FogDisplay = new Common.UI.Vector3Display();
            this.BackgroundDisplay = new Common.UI.Vector3Display();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(121, 17);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(6, 19);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(109, 20);
            this.AddressBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IDBox);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(6, 19);
            this.IDBox.Name = "IDBox";
            this.IDBox.ReadOnly = true;
            this.IDBox.Size = new System.Drawing.Size(109, 20);
            this.IDBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FunctionIndexBox);
            this.groupBox3.Location = new System.Drawing.Point(345, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 52);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FunctionIndex";
            // 
            // FunctionIndexBox
            // 
            this.FunctionIndexBox.Location = new System.Drawing.Point(6, 19);
            this.FunctionIndexBox.Name = "FunctionIndexBox";
            this.FunctionIndexBox.ReadOnly = true;
            this.FunctionIndexBox.Size = new System.Drawing.Size(109, 20);
            this.FunctionIndexBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FocusBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 52);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Focus";
            // 
            // FocusBox
            // 
            this.FocusBox.Location = new System.Drawing.Point(6, 19);
            this.FocusBox.Name = "FocusBox";
            this.FocusBox.ReadOnly = true;
            this.FocusBox.Size = new System.Drawing.Size(109, 20);
            this.FocusBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(139, 70);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(121, 52);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pri";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 0;
            // 
            // FogDisplay
            // 
            this.FogDisplay.Location = new System.Drawing.Point(174, 128);
            this.FogDisplay.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.FogDisplay.MaximumSize = new System.Drawing.Size(156, 103);
            this.FogDisplay.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.FogDisplay.MinimumSize = new System.Drawing.Size(100, 103);
            this.FogDisplay.Name = "FogDisplay";
            this.FogDisplay.ReadOnly = true;
            this.FogDisplay.Size = new System.Drawing.Size(156, 103);
            this.FogDisplay.TabIndex = 11;
            this.FogDisplay.Text = "Fog";
            this.FogDisplay.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FogDisplay.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FogDisplay.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // BackgroundDisplay
            // 
            this.BackgroundDisplay.Location = new System.Drawing.Point(12, 128);
            this.BackgroundDisplay.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.BackgroundDisplay.MaximumSize = new System.Drawing.Size(156, 103);
            this.BackgroundDisplay.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.BackgroundDisplay.MinimumSize = new System.Drawing.Size(100, 103);
            this.BackgroundDisplay.Name = "BackgroundDisplay";
            this.BackgroundDisplay.ReadOnly = true;
            this.BackgroundDisplay.Size = new System.Drawing.Size(156, 103);
            this.BackgroundDisplay.TabIndex = 10;
            this.BackgroundDisplay.Text = "Background";
            this.BackgroundDisplay.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BackgroundDisplay.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BackgroundDisplay.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // CameraDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FogDisplay);
            this.Controls.Add(this.BackgroundDisplay);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "CameraDisplay";
            this.Text = "CameraDisplay";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox FunctionIndexBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox FocusBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private Common.UI.Vector3Display BackgroundDisplay;
        private Common.UI.Vector3Display FogDisplay;
    }
}