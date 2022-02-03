namespace XRAMTool
{
    partial class AssemblyScripts_Display
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
            this.btnAttachEventManager = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstEventScripts = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstInlineScripts = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAttachEventManager
            // 
            this.btnAttachEventManager.Location = new System.Drawing.Point(12, 12);
            this.btnAttachEventManager.Name = "btnAttachEventManager";
            this.btnAttachEventManager.Size = new System.Drawing.Size(145, 23);
            this.btnAttachEventManager.TabIndex = 0;
            this.btnAttachEventManager.Text = "Attach Injection Manager";
            this.btnAttachEventManager.UseVisualStyleBackColor = true;
            this.btnAttachEventManager.Click += new System.EventHandler(this.btnAttachEventManager_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lstEventScripts);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 397);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Scripts";
            // 
            // lstEventScripts
            // 
            this.lstEventScripts.FormattingEnabled = true;
            this.lstEventScripts.Location = new System.Drawing.Point(6, 19);
            this.lstEventScripts.Name = "lstEventScripts";
            this.lstEventScripts.Size = new System.Drawing.Size(137, 368);
            this.lstEventScripts.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.lstInlineScripts);
            this.groupBox2.Location = new System.Drawing.Point(248, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 397);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inline Scripts";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstInlineScripts
            // 
            this.lstInlineScripts.FormattingEnabled = true;
            this.lstInlineScripts.Location = new System.Drawing.Point(6, 19);
            this.lstInlineScripts.Name = "lstInlineScripts";
            this.lstInlineScripts.Size = new System.Drawing.Size(137, 368);
            this.lstInlineScripts.TabIndex = 0;
            // 
            // AssemblyScripts_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAttachEventManager);
            this.Name = "AssemblyScripts_Display";
            this.Text = "AssemblyScriptsDisplay";
            this.Load += new System.EventHandler(this.AssemblyScripts_Display_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAttachEventManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstEventScripts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lstInlineScripts;
    }
}