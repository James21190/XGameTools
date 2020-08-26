namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    partial class EventObject_Sector_Display
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
            this.button1 = new System.Windows.Forms.Button();
            this.vector2Display1 = new Common.UI.Vector2Display();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.eventObjectPannel1 = new X3TCsTool.EventObjectPannel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "View Owning Race Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vector2Display1
            // 
            this.vector2Display1.DecimalPlaces = 0;
            this.vector2Display1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vector2Display1.Location = new System.Drawing.Point(12, 245);
            this.vector2Display1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.vector2Display1.MaximumSize = new System.Drawing.Size(156, 103);
            this.vector2Display1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vector2Display1.MinimumSize = new System.Drawing.Size(156, 80);
            this.vector2Display1.Name = "vector2Display1";
            this.vector2Display1.ReadOnly = true;
            this.vector2Display1.Size = new System.Drawing.Size(156, 80);
            this.vector2Display1.TabIndex = 2;
            this.vector2Display1.Text = "Position";
            this.vector2Display1.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vector2Display1.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(286, 20);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(174, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(174, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Background ID";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(286, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // eventObjectPannel1
            // 
            this.eventObjectPannel1.EventObject = null;
            this.eventObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.eventObjectPannel1.MinimumSize = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.Name = "eventObjectPannel1";
            this.eventObjectPannel1.Size = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.TabIndex = 6;
            this.eventObjectPannel1.EventObjectLoaded += new System.EventHandler(this.eventObjectPannel1_EventObjectLoaded);
            // 
            // EventObject_Sector_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eventObjectPannel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vector2Display1);
            this.Controls.Add(this.button1);
            this.Name = "EventObject_Sector_Display";
            this.Text = "ScriptMemory_Sector_Display";
            this.Load += new System.EventHandler(this.EventObject_Sector_Display_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Common.UI.Vector2Display vector2Display1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private X3TCsTool.EventObjectPannel eventObjectPannel1;
    }
}