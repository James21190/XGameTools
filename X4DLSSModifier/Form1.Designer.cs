namespace X4DLSSModifier
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbDlssPreset = new ComboBox();
            checkBox1 = new CheckBox();
            btnApply = new Button();
            nudDlssPresetValue = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            groupBox3 = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            comboBox2 = new ComboBox();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudDlssPresetValue).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // cmbDlssPreset
            // 
            cmbDlssPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDlssPreset.FormattingEnabled = true;
            cmbDlssPreset.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            cmbDlssPreset.Location = new Point(80, 16);
            cmbDlssPreset.Name = "cmbDlssPreset";
            cmbDlssPreset.Size = new Size(87, 23);
            cmbDlssPreset.TabIndex = 0;
            cmbDlssPreset.SelectedIndexChanged += cmbDlssPreset_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 264);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(140, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Enable DLSS Indicator";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(112, 289);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 23);
            btnApply.TabIndex = 2;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // nudDlssPresetValue
            // 
            nudDlssPresetValue.Location = new Point(111, 45);
            nudDlssPresetValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudDlssPresetValue.Name = "nudDlssPresetValue";
            nudDlssPresetValue.Size = new Size(56, 23);
            nudDlssPresetValue.TabIndex = 3;
            nudDlssPresetValue.ValueChanged += nudDlssPresetValue_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 4;
            label1.Text = "DLSS Preset";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 47);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 5;
            label2.Text = "DLSS Preset Value";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbDlssPreset);
            groupBox1.Controls.Add(nudDlssPresetValue);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(175, 78);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Quality";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Location = new Point(12, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 78);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Balanced";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "DLSS Preset";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 47);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 5;
            label4.Text = "DLSS Preset Value";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            comboBox1.Location = new Point(80, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(87, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(111, 45);
            numericUpDown1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(56, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(numericUpDown2);
            groupBox3.Location = new Point(12, 180);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(175, 78);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Performance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 4;
            label5.Text = "DLSS Preset";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 47);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 5;
            label6.Text = "DLSS Preset Value";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            comboBox2.Location = new Point(80, 16);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(87, 23);
            comboBox2.TabIndex = 0;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(111, 45);
            numericUpDown2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(56, 23);
            numericUpDown2.TabIndex = 3;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(199, 321);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnApply);
            Controls.Add(checkBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(215, 360);
            MinimumSize = new Size(215, 360);
            Name = "Form1";
            Text = "X4 DLSS Modifier";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudDlssPresetValue).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDlssPreset;
        private CheckBox checkBox1;
        private Button btnApply;
        private NumericUpDown nudDlssPresetValue;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox3;
        private Label label5;
        private Label label6;
        private ComboBox comboBox2;
        private NumericUpDown numericUpDown2;
    }
}
