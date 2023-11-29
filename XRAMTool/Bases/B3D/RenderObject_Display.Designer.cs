namespace XRAMTool.Bases.B3D
{
    partial class RenderObject_Display
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
            this.namedNumericUpDown1 = new CommonToolLib.UI.NamedNumericUpDown();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.numericIDObjectControl1 = new XCommonLib.UI.NumericIDObjectControl();
            this.namedNumericUpDown2 = new CommonToolLib.UI.NamedNumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namedNumericUpDown1
            // 
            this.namedNumericUpDown1.Location = new System.Drawing.Point(12, 130);
            this.namedNumericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.namedNumericUpDown1.MaximumSize = new System.Drawing.Size(0, 50);
            this.namedNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.namedNumericUpDown1.MinimumSize = new System.Drawing.Size(100, 50);
            this.namedNumericUpDown1.Name = "namedNumericUpDown1";
            this.namedNumericUpDown1.Size = new System.Drawing.Size(100, 50);
            this.namedNumericUpDown1.TabIndex = 1;
            this.namedNumericUpDown1.Title = "BodyID";
            this.namedNumericUpDown1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 186);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(158, 193);
            this.treeView1.TabIndex = 2;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // numericIDObjectControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.numericIDObjectControl1.ID = 0;
            this.numericIDObjectControl1.Location = new System.Drawing.Point(12, 12);
            this.numericIDObjectControl1.MaximumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.MinimumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.Name = "numericIDObjectControl1";
            this.numericIDObjectControl1.Size = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.TabIndex = 0;
            // 
            // namedNumericUpDown2
            // 
            this.namedNumericUpDown2.Location = new System.Drawing.Point(118, 130);
            this.namedNumericUpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.namedNumericUpDown2.MaximumSize = new System.Drawing.Size(0, 50);
            this.namedNumericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.namedNumericUpDown2.MinimumSize = new System.Drawing.Size(100, 50);
            this.namedNumericUpDown2.Name = "namedNumericUpDown2";
            this.namedNumericUpDown2.Size = new System.Drawing.Size(100, 50);
            this.namedNumericUpDown2.TabIndex = 3;
            this.namedNumericUpDown2.Title = "CollectionID";
            this.namedNumericUpDown2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find Parent SectorObject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RenderObject_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namedNumericUpDown2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.namedNumericUpDown1);
            this.Controls.Add(this.numericIDObjectControl1);
            this.Name = "RenderObject_Display";
            this.Text = "RenderObject_Display";
            this.Load += new System.EventHandler(this.RenderObject_Display_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private XCommonLib.UI.NumericIDObjectControl numericIDObjectControl1;
        private CommonToolLib.UI.NamedNumericUpDown namedNumericUpDown1;
        private System.Windows.Forms.TreeView treeView1;
        private CommonToolLib.UI.NamedNumericUpDown namedNumericUpDown2;
        private System.Windows.Forms.Button button1;
    }
}