namespace XRAMTool.Bases.Sector
{
    partial class TypeData_Display
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
            this.cmbMainType = new System.Windows.Forms.ComboBox();
            this.cmbSubType = new System.Windows.Forms.ComboBox();
            this.typeDataView1 = new XCommonLib.UI.Bases.Sector.TypeData.TypeDataView();
            this.namedTextBox1 = new CommonToolLib.UI.NamedTextBox();
            this.SuspendLayout();
            // 
            // cmbMainType
            // 
            this.cmbMainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainType.FormattingEnabled = true;
            this.cmbMainType.Location = new System.Drawing.Point(12, 12);
            this.cmbMainType.Name = "cmbMainType";
            this.cmbMainType.Size = new System.Drawing.Size(121, 21);
            this.cmbMainType.TabIndex = 0;
            this.cmbMainType.SelectedIndexChanged += new System.EventHandler(this.cmbMainType_SelectedIndexChanged);
            // 
            // cmbSubType
            // 
            this.cmbSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubType.FormattingEnabled = true;
            this.cmbSubType.Location = new System.Drawing.Point(12, 39);
            this.cmbSubType.Name = "cmbSubType";
            this.cmbSubType.Size = new System.Drawing.Size(121, 21);
            this.cmbSubType.TabIndex = 1;
            this.cmbSubType.SelectedIndexChanged += new System.EventHandler(this.cmbSubType_SelectedIndexChanged);
            // 
            // typeDataView1
            // 
            this.typeDataView1.Location = new System.Drawing.Point(12, 68);
            this.typeDataView1.Name = "typeDataView1";
            this.typeDataView1.Size = new System.Drawing.Size(776, 370);
            this.typeDataView1.TabIndex = 0;
            // 
            // namedTextBox1
            // 
            this.namedTextBox1.Location = new System.Drawing.Point(139, 12);
            this.namedTextBox1.MinimumSize = new System.Drawing.Size(100, 50);
            this.namedTextBox1.Name = "namedTextBox1";
            this.namedTextBox1.Size = new System.Drawing.Size(138, 50);
            this.namedTextBox1.TabIndex = 3;
            this.namedTextBox1.Title = "Address";
            // 
            // TypeData_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.typeDataView1);
            this.Controls.Add(this.namedTextBox1);
            this.Controls.Add(this.cmbSubType);
            this.Controls.Add(this.cmbMainType);
            this.Name = "TypeData_Display";
            this.Text = "TypeData_Display";
            this.Load += new System.EventHandler(this.TypeData_Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMainType;
        private System.Windows.Forms.ComboBox cmbSubType;
        private XCommonLib.UI.Bases.Sector.TypeData.TypeDataView typeDataView1;
        private CommonToolLib.UI.NamedTextBox namedTextBox1;
    }
}