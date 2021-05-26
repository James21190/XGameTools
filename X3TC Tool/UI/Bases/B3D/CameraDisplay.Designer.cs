namespace X3TC_RAM_Tool.UI.Displays
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FunctionIndexBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FocusBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FogDisplay = new CommonToolLib.UI.Vector3Display();
            this.BackgroundDisplay = new CommonToolLib.UI.Vector3Display();
            this.numericIDObjectControl1 = new X3Tools.RAM.UI.NumericIDObjectControl();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FunctionIndexBox);
            this.groupBox3.Location = new System.Drawing.Point(224, 12);
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
            this.groupBox4.Location = new System.Drawing.Point(224, 70);
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
            this.groupBox5.Location = new System.Drawing.Point(351, 12);
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
            this.FogDisplay.DecimalPlaces = 0;
            this.FogDisplay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.BackgroundDisplay.DecimalPlaces = 0;
            this.BackgroundDisplay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // numericIDObjectControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.numericIDObjectControl1.EnableLoad = false;
            this.numericIDObjectControl1.ID = 0;
            this.numericIDObjectControl1.Location = new System.Drawing.Point(12, 10);
            this.numericIDObjectControl1.MaximumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.MinimumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.Name = "numericIDObjectControl1";
            this.numericIDObjectControl1.Size = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.TabIndex = 12;
            // 
            // CameraDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericIDObjectControl1);
            this.Controls.Add(this.FogDisplay);
            this.Controls.Add(this.BackgroundDisplay);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "CameraDisplay";
            this.Text = "CameraDisplay";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox FunctionIndexBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox FocusBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private CommonToolLib.UI.Vector3Display BackgroundDisplay;
        private CommonToolLib.UI.Vector3Display FogDisplay;
        private X3Tools.RAM.UI.NumericIDObjectControl numericIDObjectControl1;
    }
}