namespace XCommonLib.UI.Bases.Story
{
    partial class ScriptInstanceView
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
            this.scriptVariableArrayView1 = new XCommonLib.UI.Bases.Story.ScriptVariableArrayView();
            this.ntxtMemoryAddress = new CommonToolLib.UI.NamedTextBox();
            this.namedTextBox1 = new CommonToolLib.UI.NamedTextBox();
            this.nnudReferenceCount = new CommonToolLib.UI.NamedNumericUpDown();
            this.numericIDObjectControl1 = new XCommonLib.UI.NumericIDObjectControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.scriptVariableArrayView1);
            this.groupBox1.Controls.Add(this.ntxtMemoryAddress);
            this.groupBox1.Location = new System.Drawing.Point(334, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 358);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script Memory";
            // 
            // scriptVariableArrayView1
            // 
            this.scriptVariableArrayView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptVariableArrayView1.DynamicValues = null;
            this.scriptVariableArrayView1.Location = new System.Drawing.Point(6, 75);
            this.scriptVariableArrayView1.Name = "scriptVariableArrayView1";
            this.scriptVariableArrayView1.Size = new System.Drawing.Size(293, 277);
            this.scriptVariableArrayView1.TabIndex = 1;
            this.scriptVariableArrayView1.RequestView += new XCommonLib.UI.Bases.Story.ScriptVariableArrayView.RequestViewHandler(this.scriptVariableArrayView1_RequestView);
            // 
            // ntxtMemoryAddress
            // 
            this.ntxtMemoryAddress.Location = new System.Drawing.Point(6, 19);
            this.ntxtMemoryAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtMemoryAddress.Name = "ntxtMemoryAddress";
            this.ntxtMemoryAddress.ReadOnly = true;
            this.ntxtMemoryAddress.Size = new System.Drawing.Size(100, 50);
            this.ntxtMemoryAddress.TabIndex = 0;
            this.ntxtMemoryAddress.Title = "Address";
            // 
            // namedTextBox1
            // 
            this.namedTextBox1.Location = new System.Drawing.Point(3, 121);
            this.namedTextBox1.MinimumSize = new System.Drawing.Size(100, 50);
            this.namedTextBox1.Name = "namedTextBox1";
            this.namedTextBox1.ReadOnly = true;
            this.namedTextBox1.Size = new System.Drawing.Size(206, 50);
            this.namedTextBox1.TabIndex = 3;
            this.namedTextBox1.Title = "Type";
            // 
            // nnudReferenceCount
            // 
            this.nnudReferenceCount.Location = new System.Drawing.Point(215, 3);
            this.nnudReferenceCount.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nnudReferenceCount.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudReferenceCount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudReferenceCount.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudReferenceCount.Name = "nnudReferenceCount";
            this.nnudReferenceCount.ReadOnly = true;
            this.nnudReferenceCount.Size = new System.Drawing.Size(100, 50);
            this.nnudReferenceCount.TabIndex = 1;
            this.nnudReferenceCount.Title = "Reference Count";
            this.nnudReferenceCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numericIDObjectControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.numericIDObjectControl1.ID = 0;
            this.numericIDObjectControl1.Location = new System.Drawing.Point(3, 3);
            this.numericIDObjectControl1.MaximumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.MinimumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.Name = "numericIDObjectControl1";
            this.numericIDObjectControl1.Size = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.TabIndex = 0;
            this.numericIDObjectControl1.AddressLoad += new XCommonLib.UI.NumericIDObjectControl.LoadEvent(this.numericIDObjectControl1_AddressLoad);
            this.numericIDObjectControl1.IDLoad += new XCommonLib.UI.NumericIDObjectControl.LoadEvent(this.numericIDObjectControl1_IDLoad);
            // 
            // ScriptInstanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.namedTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nnudReferenceCount);
            this.Controls.Add(this.numericIDObjectControl1);
            this.Name = "ScriptInstanceView";
            this.Size = new System.Drawing.Size(642, 364);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NumericIDObjectControl numericIDObjectControl1;
        private CommonToolLib.UI.NamedNumericUpDown nnudReferenceCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonToolLib.UI.NamedTextBox ntxtMemoryAddress;
        private CommonToolLib.UI.NamedTextBox namedTextBox1;
        private ScriptVariableArrayView scriptVariableArrayView1;
    }
}
