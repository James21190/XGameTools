namespace X3TCTools
{
    partial class DynamicValueDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.FlagBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FlagBox);
            this.groupBox1.Controls.Add(this.ValueBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(6, 45);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(161, 20);
            this.ValueBox.TabIndex = 2;
            this.ValueBox.TextChanged += new System.EventHandler(this.ValueBox_TextChanged);
            // 
            // FlagBox
            // 
            this.FlagBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlagBox.FormattingEnabled = true;
            this.FlagBox.Location = new System.Drawing.Point(6, 18);
            this.FlagBox.Name = "FlagBox";
            this.FlagBox.Size = new System.Drawing.Size(161, 21);
            this.FlagBox.TabIndex = 3;
            this.FlagBox.SelectedIndexChanged += new System.EventHandler(this.FlagBox_SelectedIndexChanged);
            // 
            // DynamicValueDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DynamicValueDisplay";
            this.Size = new System.Drawing.Size(179, 83);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ValueBox;
        private System.Windows.Forms.ComboBox FlagBox;
    }
}
