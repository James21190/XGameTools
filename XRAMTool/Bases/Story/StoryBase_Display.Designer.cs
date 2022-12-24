namespace XRAMTool.Bases.Story
{
    partial class StoryBase_Display
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblScriptInstanceCount = new System.Windows.Forms.Label();
            this.lstScriptInstances = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblScriptTaskObjectCount = new System.Windows.Forms.Label();
            this.lstScriptTaskObjects = new System.Windows.Forms.ListBox();
            this.ntxtAddress = new CommonToolLib.UI.NamedTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblScriptInstanceCount);
            this.groupBox1.Controls.Add(this.lstScriptInstances);
            this.groupBox1.Location = new System.Drawing.Point(12, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 324);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script Instances";
            // 
            // lblScriptInstanceCount
            // 
            this.lblScriptInstanceCount.AutoSize = true;
            this.lblScriptInstanceCount.Location = new System.Drawing.Point(6, 16);
            this.lblScriptInstanceCount.Name = "lblScriptInstanceCount";
            this.lblScriptInstanceCount.Size = new System.Drawing.Size(38, 13);
            this.lblScriptInstanceCount.TabIndex = 1;
            this.lblScriptInstanceCount.Text = "Count:";
            // 
            // lstScriptInstances
            // 
            this.lstScriptInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScriptInstances.FormattingEnabled = true;
            this.lstScriptInstances.Location = new System.Drawing.Point(6, 32);
            this.lstScriptInstances.Name = "lstScriptInstances";
            this.lstScriptInstances.Size = new System.Drawing.Size(109, 277);
            this.lstScriptInstances.TabIndex = 0;
            this.lstScriptInstances.DoubleClick += new System.EventHandler(this.lstScriptInstances_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblScriptTaskObjectCount);
            this.groupBox2.Controls.Add(this.lstScriptTaskObjects);
            this.groupBox2.Location = new System.Drawing.Point(139, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 324);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Script Task Objects";
            // 
            // lblScriptTaskObjectCount
            // 
            this.lblScriptTaskObjectCount.AutoSize = true;
            this.lblScriptTaskObjectCount.Location = new System.Drawing.Point(6, 16);
            this.lblScriptTaskObjectCount.Name = "lblScriptTaskObjectCount";
            this.lblScriptTaskObjectCount.Size = new System.Drawing.Size(38, 13);
            this.lblScriptTaskObjectCount.TabIndex = 2;
            this.lblScriptTaskObjectCount.Text = "Count:";
            // 
            // lstScriptTaskObjects
            // 
            this.lstScriptTaskObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScriptTaskObjects.FormattingEnabled = true;
            this.lstScriptTaskObjects.Location = new System.Drawing.Point(6, 32);
            this.lstScriptTaskObjects.Name = "lstScriptTaskObjects";
            this.lstScriptTaskObjects.Size = new System.Drawing.Size(109, 277);
            this.lstScriptTaskObjects.TabIndex = 0;
            // 
            // ntxtAddress
            // 
            this.ntxtAddress.Location = new System.Drawing.Point(12, 12);
            this.ntxtAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtAddress.Name = "ntxtAddress";
            this.ntxtAddress.Size = new System.Drawing.Size(138, 50);
            this.ntxtAddress.TabIndex = 3;
            this.ntxtAddress.Title = "Address";
            // 
            // StoryBase_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ntxtAddress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StoryBase_Display";
            this.Text = "StoryBase_Display";
            this.Load += new System.EventHandler(this.StoryBase_Display_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstScriptInstances;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstScriptTaskObjects;
        private System.Windows.Forms.Label lblScriptInstanceCount;
        private System.Windows.Forms.Label lblScriptTaskObjectCount;
        private CommonToolLib.UI.NamedTextBox ntxtAddress;
    }
}