namespace XRAMTool
{
    partial class XRAMTool
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
            this.btnSectorBase = new System.Windows.Forms.Button();
            this.grpBases = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStoryBase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTypeData = new System.Windows.Forms.Button();
            this.btnAssemblyScripts = new System.Windows.Forms.Button();
            this.grpBases.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSectorBase
            // 
            this.btnSectorBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSectorBase.Location = new System.Drawing.Point(6, 19);
            this.btnSectorBase.Name = "btnSectorBase";
            this.btnSectorBase.Size = new System.Drawing.Size(101, 23);
            this.btnSectorBase.TabIndex = 0;
            this.btnSectorBase.Text = "SectorBase";
            this.btnSectorBase.UseVisualStyleBackColor = true;
            this.btnSectorBase.Click += new System.EventHandler(this.btnSectorBase_Click);
            // 
            // grpBases
            // 
            this.grpBases.Controls.Add(this.groupBox2);
            this.grpBases.Controls.Add(this.groupBox1);
            this.grpBases.Location = new System.Drawing.Point(12, 12);
            this.grpBases.Name = "grpBases";
            this.grpBases.Size = new System.Drawing.Size(263, 114);
            this.grpBases.TabIndex = 1;
            this.grpBases.TabStop = false;
            this.grpBases.Text = "Bases";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStoryBase);
            this.groupBox2.Location = new System.Drawing.Point(125, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Story";
            // 
            // btnStoryBase
            // 
            this.btnStoryBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoryBase.Location = new System.Drawing.Point(6, 19);
            this.btnStoryBase.Name = "btnStoryBase";
            this.btnStoryBase.Size = new System.Drawing.Size(101, 23);
            this.btnStoryBase.TabIndex = 2;
            this.btnStoryBase.Text = "StoryBase";
            this.btnStoryBase.UseVisualStyleBackColor = true;
            this.btnStoryBase.Click += new System.EventHandler(this.btnStoryBase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTypeData);
            this.groupBox1.Controls.Add(this.btnSectorBase);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sector";
            // 
            // btnTypeData
            // 
            this.btnTypeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTypeData.Location = new System.Drawing.Point(6, 48);
            this.btnTypeData.Name = "btnTypeData";
            this.btnTypeData.Size = new System.Drawing.Size(101, 23);
            this.btnTypeData.TabIndex = 1;
            this.btnTypeData.Text = "TypeData";
            this.btnTypeData.UseVisualStyleBackColor = true;
            this.btnTypeData.Click += new System.EventHandler(this.btnTypeData_Click);
            // 
            // btnAssemblyScripts
            // 
            this.btnAssemblyScripts.Location = new System.Drawing.Point(688, 12);
            this.btnAssemblyScripts.Name = "btnAssemblyScripts";
            this.btnAssemblyScripts.Size = new System.Drawing.Size(100, 23);
            this.btnAssemblyScripts.TabIndex = 2;
            this.btnAssemblyScripts.Text = "Assembly Scripts";
            this.btnAssemblyScripts.UseVisualStyleBackColor = true;
            this.btnAssemblyScripts.Click += new System.EventHandler(this.btnAssemblyScripts_Click);
            // 
            // XRAMTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAssemblyScripts);
            this.Controls.Add(this.grpBases);
            this.Name = "XRAMTool";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBases.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSectorBase;
        private System.Windows.Forms.GroupBox grpBases;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTypeData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStoryBase;
        private System.Windows.Forms.Button btnAssemblyScripts;
    }
}

