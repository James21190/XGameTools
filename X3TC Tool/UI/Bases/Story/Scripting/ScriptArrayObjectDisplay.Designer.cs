namespace X3TC_RAM_Tool.UI.Displays
{
    partial class ScriptArrayObjectDisplay
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.scriptMemoryObject_Raw_Panel1 = new X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudID = new System.Windows.Forms.NumericUpDown();
            this.btnLoadID = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 52);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(6, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(114, 20);
            this.txtAddress.TabIndex = 0;
            // 
            // scriptMemoryObject_Raw_Panel1
            // 
            this.scriptMemoryObject_Raw_Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptMemoryObject_Raw_Panel1.Location = new System.Drawing.Point(12, 70);
            this.scriptMemoryObject_Raw_Panel1.Name = "scriptMemoryObject_Raw_Panel1";
            this.scriptMemoryObject_Raw_Panel1.Size = new System.Drawing.Size(587, 286);
            this.scriptMemoryObject_Raw_Panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudID);
            this.groupBox1.Controls.Add(this.btnLoadID);
            this.groupBox1.Location = new System.Drawing.Point(144, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID";
            // 
            // nudID
            // 
            this.nudID.Location = new System.Drawing.Point(6, 20);
            this.nudID.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudID.Name = "nudID";
            this.nudID.Size = new System.Drawing.Size(106, 20);
            this.nudID.TabIndex = 2;
            // 
            // btnLoadID
            // 
            this.btnLoadID.Location = new System.Drawing.Point(118, 17);
            this.btnLoadID.Name = "btnLoadID";
            this.btnLoadID.Size = new System.Drawing.Size(69, 23);
            this.btnLoadID.TabIndex = 1;
            this.btnLoadID.Text = "Load";
            this.btnLoadID.UseVisualStyleBackColor = true;
            this.btnLoadID.Click += new System.EventHandler(this.btnLoadID_Click);
            // 
            // ScriptArrayObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.scriptMemoryObject_Raw_Panel1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ScriptArrayObjectDisplay";
            this.Text = "DynamicValueDisplay";
            this.Load += new System.EventHandler(this.ScriptArrayObjectDisplay_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAddress;
        private Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.ScriptMemoryObject_Raw_Panel scriptMemoryObject_Raw_Panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadID;
        private System.Windows.Forms.NumericUpDown nudID;
    }
}