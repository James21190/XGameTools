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
            this.grpBases.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSectorBase
            // 
            this.btnSectorBase.Location = new System.Drawing.Point(6, 19);
            this.btnSectorBase.Name = "btnSectorBase";
            this.btnSectorBase.Size = new System.Drawing.Size(79, 23);
            this.btnSectorBase.TabIndex = 0;
            this.btnSectorBase.Text = "Sector";
            this.btnSectorBase.UseVisualStyleBackColor = true;
            this.btnSectorBase.Click += new System.EventHandler(this.btnSectorBase_Click);
            // 
            // grpBases
            // 
            this.grpBases.Controls.Add(this.btnSectorBase);
            this.grpBases.Location = new System.Drawing.Point(12, 12);
            this.grpBases.Name = "grpBases";
            this.grpBases.Size = new System.Drawing.Size(91, 58);
            this.grpBases.TabIndex = 1;
            this.grpBases.TabStop = false;
            this.grpBases.Text = "Bases";
            // 
            // XRAMTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBases);
            this.Name = "XRAMTool";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBases.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSectorBase;
        private System.Windows.Forms.GroupBox grpBases;
    }
}

