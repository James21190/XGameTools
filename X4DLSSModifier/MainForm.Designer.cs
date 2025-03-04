namespace X4DLSSModifier
{
    partial class MainForm
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
            cmbDlssQualityPreset = new ComboBox();
            chkDlssIndicator = new CheckBox();
            btnApply = new Button();
            nudDlssQualityPresetValue = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            cmbDlssBalancedPreset = new ComboBox();
            nudDlssBalancedPresetValue = new NumericUpDown();
            groupBox3 = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            cmbDlssPerformancePreset = new ComboBox();
            nudDlssPerformancePresetValue = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudDlssQualityPresetValue).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDlssBalancedPresetValue).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDlssPerformancePresetValue).BeginInit();
            SuspendLayout();
            // 
            // cmbDlssQualityPreset
            // 
            cmbDlssQualityPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDlssQualityPreset.FormattingEnabled = true;
            cmbDlssQualityPreset.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            cmbDlssQualityPreset.Location = new Point(80, 16);
            cmbDlssQualityPreset.Name = "cmbDlssQualityPreset";
            cmbDlssQualityPreset.Size = new Size(87, 23);
            cmbDlssQualityPreset.TabIndex = 0;
            cmbDlssQualityPreset.SelectedIndexChanged += cmbDlssQualityPreset_SelectedIndexChanged;
            // 
            // chkDlssIndicator
            // 
            chkDlssIndicator.AutoSize = true;
            chkDlssIndicator.Location = new Point(12, 264);
            chkDlssIndicator.Name = "chkDlssIndicator";
            chkDlssIndicator.Size = new Size(140, 19);
            chkDlssIndicator.TabIndex = 1;
            chkDlssIndicator.Text = "Enable DLSS Indicator";
            chkDlssIndicator.UseVisualStyleBackColor = true;
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
            // nudDlssQualityPresetValue
            // 
            nudDlssQualityPresetValue.Location = new Point(111, 45);
            nudDlssQualityPresetValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudDlssQualityPresetValue.Name = "nudDlssQualityPresetValue";
            nudDlssQualityPresetValue.Size = new Size(56, 23);
            nudDlssQualityPresetValue.TabIndex = 3;
            nudDlssQualityPresetValue.ValueChanged += nudDlssQualityPresetValue_ValueChanged;
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
            groupBox1.Controls.Add(cmbDlssQualityPreset);
            groupBox1.Controls.Add(nudDlssQualityPresetValue);
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
            groupBox2.Controls.Add(cmbDlssBalancedPreset);
            groupBox2.Controls.Add(nudDlssBalancedPresetValue);
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
            // cmbDlssBalancedPreset
            // 
            cmbDlssBalancedPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDlssBalancedPreset.FormattingEnabled = true;
            cmbDlssBalancedPreset.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            cmbDlssBalancedPreset.Location = new Point(80, 16);
            cmbDlssBalancedPreset.Name = "cmbDlssBalancedPreset";
            cmbDlssBalancedPreset.Size = new Size(87, 23);
            cmbDlssBalancedPreset.TabIndex = 0;
            cmbDlssBalancedPreset.SelectedIndexChanged += cmbDlssBalancedPreset_SelectedIndexChanged;
            // 
            // nudDlssBalancedPresetValue
            // 
            nudDlssBalancedPresetValue.Location = new Point(111, 45);
            nudDlssBalancedPresetValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudDlssBalancedPresetValue.Name = "nudDlssBalancedPresetValue";
            nudDlssBalancedPresetValue.Size = new Size(56, 23);
            nudDlssBalancedPresetValue.TabIndex = 3;
            nudDlssBalancedPresetValue.ValueChanged += nudDlssBalancedPresetValue_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cmbDlssPerformancePreset);
            groupBox3.Controls.Add(nudDlssPerformancePresetValue);
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
            // cmbDlssPerformancePreset
            // 
            cmbDlssPerformancePreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDlssPerformancePreset.FormattingEnabled = true;
            cmbDlssPerformancePreset.Items.AddRange(new object[] { "Default", "A", "B", "C", "D", "E", "F", "J", "K", "Custom" });
            cmbDlssPerformancePreset.Location = new Point(80, 16);
            cmbDlssPerformancePreset.Name = "cmbDlssPerformancePreset";
            cmbDlssPerformancePreset.Size = new Size(87, 23);
            cmbDlssPerformancePreset.TabIndex = 0;
            cmbDlssPerformancePreset.SelectedIndexChanged += cmbDlssPerformancePreset_SelectedIndexChanged;
            // 
            // nudDlssPerformancePresetValue
            // 
            nudDlssPerformancePresetValue.Location = new Point(111, 45);
            nudDlssPerformancePresetValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudDlssPerformancePresetValue.Name = "nudDlssPerformancePresetValue";
            nudDlssPerformancePresetValue.Size = new Size(56, 23);
            nudDlssPerformancePresetValue.TabIndex = 3;
            nudDlssPerformancePresetValue.ValueChanged += nudDlssPerformancePresetValue_ValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(199, 321);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnApply);
            Controls.Add(chkDlssIndicator);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(215, 360);
            MinimumSize = new Size(215, 360);
            Name = "MainForm";
            Text = "X4 DLSS Modifier";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudDlssQualityPresetValue).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDlssBalancedPresetValue).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDlssPerformancePresetValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDlssQualityPreset;
        private CheckBox chkDlssIndicator;
        private Button btnApply;
        private NumericUpDown nudDlssQualityPresetValue;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label3;
        private Label label4;
        private ComboBox cmbDlssBalancedPreset;
        private NumericUpDown nudDlssBalancedPresetValue;
        private GroupBox groupBox3;
        private Label label5;
        private Label label6;
        private ComboBox cmbDlssPerformancePreset;
        private NumericUpDown nudDlssPerformancePresetValue;
    }
}
