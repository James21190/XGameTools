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
            this.button1 = new System.Windows.Forms.Button();
            this.lstEventScripts = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lstInlineScripts = new System.Windows.Forms.ListBox();
            this.lstLoadedEventScripts = new System.Windows.Forms.ListBox();
            this.lstLoadedInlineScripts = new System.Windows.Forms.ListBox();
            this.ntxtEventScriptAddress = new CommonToolLib.UI.NamedTextBox();
            this.ntxtInlineScriptAddress = new CommonToolLib.UI.NamedTextBox();
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
            this.groupBox1.Controls.Add(this.ntxtEventScriptAddress);
            this.groupBox1.Controls.Add(this.lstLoadedEventScripts);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lstEventScripts);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event Scripts";
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
            // lstEventScripts
            // 
            this.lstEventScripts.FormattingEnabled = true;
            this.lstEventScripts.Location = new System.Drawing.Point(6, 19);
            this.lstEventScripts.Name = "lstEventScripts";
            this.lstEventScripts.Size = new System.Drawing.Size(137, 186);
            this.lstEventScripts.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntxtInlineScriptAddress);
            this.groupBox2.Controls.Add(this.lstLoadedInlineScripts);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.lstInlineScripts);
            this.groupBox2.Location = new System.Drawing.Point(18, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 217);
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
            this.lstInlineScripts.Size = new System.Drawing.Size(137, 186);
            this.lstInlineScripts.TabIndex = 0;
            // 
            // lstLoadedEventScripts
            // 
            this.lstLoadedEventScripts.FormattingEnabled = true;
            this.lstLoadedEventScripts.Location = new System.Drawing.Point(230, 71);
            this.lstLoadedEventScripts.Name = "lstLoadedEventScripts";
            this.lstLoadedEventScripts.Size = new System.Drawing.Size(137, 134);
            this.lstLoadedEventScripts.TabIndex = 2;
            this.lstLoadedEventScripts.SelectedIndexChanged += new System.EventHandler(this.lstLoadedEventScripts_SelectedIndexChanged);
            // 
            // lstLoadedInlineScripts
            // 
            this.lstLoadedInlineScripts.FormattingEnabled = true;
            this.lstLoadedInlineScripts.Location = new System.Drawing.Point(224, 75);
            this.lstLoadedInlineScripts.Name = "lstLoadedInlineScripts";
            this.lstLoadedInlineScripts.Size = new System.Drawing.Size(137, 134);
            this.lstLoadedInlineScripts.TabIndex = 2;
            this.lstLoadedInlineScripts.SelectedIndexChanged += new System.EventHandler(this.lstLoadedInlineScripts_SelectedIndexChanged);
            // 
            // ntxtEventScriptAddress
            // 
            this.ntxtEventScriptAddress.Location = new System.Drawing.Point(230, 19);
            this.ntxtEventScriptAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtEventScriptAddress.Name = "ntxtEventScriptAddress";
            this.ntxtEventScriptAddress.Size = new System.Drawing.Size(137, 50);
            this.ntxtEventScriptAddress.TabIndex = 3;
            this.ntxtEventScriptAddress.Title = "Address";
            // 
            // ntxtInlineScriptAddress
            // 
            this.ntxtInlineScriptAddress.Location = new System.Drawing.Point(227, 19);
            this.ntxtInlineScriptAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtInlineScriptAddress.Name = "ntxtInlineScriptAddress";
            this.ntxtInlineScriptAddress.Size = new System.Drawing.Size(134, 50);
            this.ntxtInlineScriptAddress.TabIndex = 4;
            this.ntxtInlineScriptAddress.Title = "Address";
            // 
            // AssemblyScripts_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
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
        private System.Windows.Forms.ListBox lstLoadedEventScripts;
        private System.Windows.Forms.ListBox lstLoadedInlineScripts;
        private CommonToolLib.UI.NamedTextBox ntxtEventScriptAddress;
        private CommonToolLib.UI.NamedTextBox ntxtInlineScriptAddress;
    }
}