namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    partial class IScriptMemoryObject_RaceData_Player_Panel
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
            this.RaceDataPanel = new X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels.IScriptMemoryObject_RaceData_Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRaces = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudCredits = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudTradeRank = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudFightRank = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTradeRank)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFightRank)).BeginInit();
            this.SuspendLayout();
            // 
            // RaceDataPanel
            // 
            this.RaceDataPanel.Location = new System.Drawing.Point(3, 3);
            this.RaceDataPanel.Name = "RaceDataPanel";
            this.RaceDataPanel.Size = new System.Drawing.Size(499, 320);
            this.RaceDataPanel.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lstRaces);
            this.groupBox3.Location = new System.Drawing.Point(508, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 216);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Races";
            // 
            // lstRaces
            // 
            this.lstRaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRaces.FormattingEnabled = true;
            this.lstRaces.Location = new System.Drawing.Point(6, 19);
            this.lstRaces.Name = "lstRaces";
            this.lstRaces.Size = new System.Drawing.Size(227, 173);
            this.lstRaces.TabIndex = 7;
            this.lstRaces.SelectedIndexChanged += new System.EventHandler(this.lstRaces_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudCredits);
            this.groupBox1.Location = new System.Drawing.Point(508, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 46);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credits";
            // 
            // nudCredits
            // 
            this.nudCredits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudCredits.Location = new System.Drawing.Point(6, 19);
            this.nudCredits.Name = "nudCredits";
            this.nudCredits.ReadOnly = true;
            this.nudCredits.Size = new System.Drawing.Size(105, 20);
            this.nudCredits.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudTradeRank);
            this.groupBox2.Location = new System.Drawing.Point(508, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 46);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trade Rank";
            // 
            // nudTradeRank
            // 
            this.nudTradeRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTradeRank.Location = new System.Drawing.Point(6, 19);
            this.nudTradeRank.Name = "nudTradeRank";
            this.nudTradeRank.ReadOnly = true;
            this.nudTradeRank.Size = new System.Drawing.Size(105, 20);
            this.nudTradeRank.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudFightRank);
            this.groupBox4.Location = new System.Drawing.Point(631, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 46);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fight Rank";
            // 
            // nudFightRank
            // 
            this.nudFightRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFightRank.Location = new System.Drawing.Point(6, 19);
            this.nudFightRank.Name = "nudFightRank";
            this.nudFightRank.ReadOnly = true;
            this.nudFightRank.Size = new System.Drawing.Size(105, 20);
            this.nudFightRank.TabIndex = 0;
            // 
            // IScriptMemoryObject_RaceData_Player_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RaceDataPanel);
            this.Name = "IScriptMemoryObject_RaceData_Player_Panel";
            this.Size = new System.Drawing.Size(759, 326);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTradeRank)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFightRank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IScriptMemoryObject_RaceData_Panel RaceDataPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstRaces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudCredits;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudTradeRank;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudFightRank;
    }
}
