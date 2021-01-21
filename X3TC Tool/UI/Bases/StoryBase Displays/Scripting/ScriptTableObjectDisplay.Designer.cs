using X3Tools.Bases.Story.Scripting;

namespace X3_Tool.UI.Displays
{
    partial class ScriptTableObjectDisplay
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
            X3Tools.Bases.Story.Scripting.DynamicValue dynamicValue1 = new X3Tools.Bases.Story.Scripting.DynamicValue();
            X3Tools.Bases.Story.Scripting.DynamicValue dynamicValue2 = new X3Tools.Bases.Story.Scripting.DynamicValue();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CountBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NextAvailableIDBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ScannerLabel = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dynamicValueDisplay1 = new X3Tools.DynamicValueDisplay();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.IDBox = new X3Tools.DynamicValueDisplay();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 52);
            this.groupBox2.TabIndex = 4;
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
            this.groupBox1.Controls.Add(this.CountBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Count";
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(6, 19);
            this.CountBox.Name = "CountBox";
            this.CountBox.ReadOnly = true;
            this.CountBox.Size = new System.Drawing.Size(109, 20);
            this.CountBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NextAvailableIDBox);
            this.groupBox3.Location = new System.Drawing.Point(139, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Next Available ID";
            // 
            // NextAvailableIDBox
            // 
            this.NextAvailableIDBox.Location = new System.Drawing.Point(6, 19);
            this.NextAvailableIDBox.Name = "NextAvailableIDBox";
            this.NextAvailableIDBox.ReadOnly = true;
            this.NextAvailableIDBox.Size = new System.Drawing.Size(109, 20);
            this.NextAvailableIDBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SizeBox);
            this.groupBox4.Location = new System.Drawing.Point(266, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 52);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Size";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(6, 19);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.ReadOnly = true;
            this.SizeBox.Size = new System.Drawing.Size(109, 20);
            this.SizeBox.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 63);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(357, 121);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.ScannerLabel);
            this.groupBox5.Controls.Add(this.listBox1);
            this.groupBox5.Location = new System.Drawing.Point(12, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(369, 197);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scanner";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScannerLabel
            // 
            this.ScannerLabel.AutoSize = true;
            this.ScannerLabel.Location = new System.Drawing.Point(87, 24);
            this.ScannerLabel.Name = "ScannerLabel";
            this.ScannerLabel.Size = new System.Drawing.Size(70, 13);
            this.ScannerLabel.TabIndex = 9;
            this.ScannerLabel.Text = "Not Scanned";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dynamicValueDisplay1);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Location = new System.Drawing.Point(393, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 380);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Entry";
            // 
            // dynamicValueDisplay1
            // 
            this.dynamicValueDisplay1.Location = new System.Drawing.Point(27, 209);
            this.dynamicValueDisplay1.MinimumSize = new System.Drawing.Size(179, 108);
            this.dynamicValueDisplay1.Name = "dynamicValueDisplay1";
            this.dynamicValueDisplay1.Size = new System.Drawing.Size(179, 110);
            this.dynamicValueDisplay1.TabIndex = 3;
            this.dynamicValueDisplay1.Text = "Value";
            this.dynamicValueDisplay1.Value = dynamicValue1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Address:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 183);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.IDBox);
            this.groupBox7.Controls.Add(this.button2);
            this.groupBox7.Location = new System.Drawing.Point(6, 17);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 160);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ID";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(8, 16);
            this.IDBox.MinimumSize = new System.Drawing.Size(179, 108);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(179, 110);
            this.IDBox.TabIndex = 2;
            this.IDBox.Text = "ID";
            this.IDBox.Value = dynamicValue2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ScriptTableObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 331);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MinimumSize = new System.Drawing.Size(629, 370);
            this.Name = "ScriptTableObjectDisplay";
            this.Text = "ScriptTableObject";
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
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CountBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox NextAvailableIDBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ScannerLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private X3Tools.DynamicValueDisplay IDBox;
        private X3Tools.DynamicValueDisplay dynamicValueDisplay1;
    }
}