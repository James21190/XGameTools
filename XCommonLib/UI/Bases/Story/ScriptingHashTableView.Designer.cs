namespace XCommonLib.UI.Bases.Story
{
    partial class ScriptingHashTableView
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
            this.btnScan = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nnudCount = new CommonToolLib.UI.NamedNumericUpDown();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(3, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(157, 199);
            this.listBox1.TabIndex = 1;
            // 
            // nnudCount
            // 
            this.nnudCount.Location = new System.Drawing.Point(166, 3);
            this.nnudCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudCount.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudCount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudCount.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudCount.Name = "nnudCount";
            this.nnudCount.Size = new System.Drawing.Size(100, 50);
            this.nnudCount.TabIndex = 2;
            this.nnudCount.Title = "Count";
            this.nnudCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ScriptingHashTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nnudCount);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnScan);
            this.Name = "ScriptingHashTableView";
            this.Size = new System.Drawing.Size(380, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox listBox1;
        private CommonToolLib.UI.NamedNumericUpDown nnudCount;
    }
}
