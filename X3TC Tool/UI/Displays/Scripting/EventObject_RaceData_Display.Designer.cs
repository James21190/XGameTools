namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    partial class EventObject_RaceData_Display
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstOwnedShips = new System.Windows.Forms.ListBox();
            this.eventObjectPannel1 = new X3TCsTool.EventObjectPannel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstOwnedStations = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Race ID";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lstOwnedShips
            // 
            this.lstOwnedShips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOwnedShips.FormattingEnabled = true;
            this.lstOwnedShips.Location = new System.Drawing.Point(6, 19);
            this.lstOwnedShips.Name = "lstOwnedShips";
            this.lstOwnedShips.Size = new System.Drawing.Size(227, 186);
            this.lstOwnedShips.TabIndex = 7;
            this.lstOwnedShips.SelectedIndexChanged += new System.EventHandler(this.lstOwnedShips_SelectedIndexChanged);
            // 
            // eventObjectPannel1
            // 
            this.eventObjectPannel1.EventObject = null;
            this.eventObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.eventObjectPannel1.Name = "eventObjectPannel1";
            this.eventObjectPannel1.Size = new System.Drawing.Size(460, 148);
            this.eventObjectPannel1.TabIndex = 6;
            this.eventObjectPannel1.EventObjectLoaded += new System.EventHandler(this.eventObjectPannel1_EventObjectLoaded);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstOwnedShips);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 216);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Owned Ships";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstOwnedStations);
            this.groupBox3.Location = new System.Drawing.Point(257, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 216);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Owned Factories";
            // 
            // lstOwnedFactories
            // 
            this.lstOwnedStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOwnedStations.FormattingEnabled = true;
            this.lstOwnedStations.Location = new System.Drawing.Point(6, 19);
            this.lstOwnedStations.Name = "lstOwnedFactories";
            this.lstOwnedStations.Size = new System.Drawing.Size(227, 186);
            this.lstOwnedStations.TabIndex = 7;
            this.lstOwnedStations.SelectedIndexChanged += new System.EventHandler(this.lstOwnedFactories_SelectedIndexChanged);
            // 
            // EventObject_RaceData_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.eventObjectPannel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "EventObject_RaceData_Display";
            this.Text = "ScriptMemory_RaceData_Display";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private X3TCsTool.EventObjectPannel eventObjectPannel1;
        private System.Windows.Forms.ListBox lstOwnedShips;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstOwnedStations;
    }
}