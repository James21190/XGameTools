namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting
{
    partial class ScriptMemorySearcher
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
            this.pbScriptInstance = new System.Windows.Forms.ProgressBar();
            this.bwScriptInstance = new System.ComponentModel.BackgroundWorker();
            this.lstScriptInstance = new System.Windows.Forms.ListBox();
            this.bwScriptArray = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbScriptArray = new System.Windows.Forms.ProgressBar();
            this.lstScriptArray = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbScriptInstance
            // 
            this.pbScriptInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScriptInstance.Location = new System.Drawing.Point(6, 19);
            this.pbScriptInstance.Name = "pbScriptInstance";
            this.pbScriptInstance.Size = new System.Drawing.Size(224, 23);
            this.pbScriptInstance.TabIndex = 0;
            // 
            // bwScriptInstance
            // 
            this.bwScriptInstance.WorkerReportsProgress = true;
            this.bwScriptInstance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bwScriptInstance.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // lstScriptInstance
            // 
            this.lstScriptInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScriptInstance.FormattingEnabled = true;
            this.lstScriptInstance.Location = new System.Drawing.Point(6, 48);
            this.lstScriptInstance.Name = "lstScriptInstance";
            this.lstScriptInstance.Size = new System.Drawing.Size(224, 95);
            this.lstScriptInstance.TabIndex = 1;
            // 
            // bwScriptArray
            // 
            this.bwScriptArray.WorkerReportsProgress = true;
            this.bwScriptArray.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwScriptArray_DoWork);
            this.bwScriptArray.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwScriptArray_ProgressChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbScriptInstance);
            this.groupBox1.Controls.Add(this.lstScriptInstance);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 155);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ScriptInstances";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbScriptArray);
            this.groupBox2.Controls.Add(this.lstScriptArray);
            this.groupBox2.Location = new System.Drawing.Point(254, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 155);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ScriptArrays";
            // 
            // pbScriptArray
            // 
            this.pbScriptArray.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScriptArray.Location = new System.Drawing.Point(6, 19);
            this.pbScriptArray.Name = "pbScriptArray";
            this.pbScriptArray.Size = new System.Drawing.Size(224, 23);
            this.pbScriptArray.TabIndex = 0;
            // 
            // lstScriptArray
            // 
            this.lstScriptArray.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstScriptArray.FormattingEnabled = true;
            this.lstScriptArray.Location = new System.Drawing.Point(6, 48);
            this.lstScriptArray.Name = "lstScriptArray";
            this.lstScriptArray.Size = new System.Drawing.Size(224, 95);
            this.lstScriptArray.TabIndex = 1;
            // 
            // ScriptMemorySearcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 184);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScriptMemorySearcher";
            this.Text = "ScriptMemorySearcher";
            this.Load += new System.EventHandler(this.ScriptInstanceSearcher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbScriptInstance;
        private System.ComponentModel.BackgroundWorker bwScriptInstance;
        private System.Windows.Forms.ListBox lstScriptInstance;
        private System.ComponentModel.BackgroundWorker bwScriptArray;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pbScriptArray;
        private System.Windows.Forms.ListBox lstScriptArray;
    }
}