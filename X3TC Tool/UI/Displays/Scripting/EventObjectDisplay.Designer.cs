namespace X3TC_Tool.UI.Displays
{
    partial class EventObjectDisplay
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
            this.components = new System.ComponentModel.Container();
            this.LoadSubButton = new System.Windows.Forms.Button();
            this.LoadVariablesButton = new System.Windows.Forms.Button();
            this.AutoReloadCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoReloader = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkLoadWithArray = new System.Windows.Forms.CheckBox();
            this.eventObjectPannel1 = new X3TCsTool.EventObjectPannel();
            this.SuspendLayout();
            // 
            // LoadSubButton
            // 
            this.LoadSubButton.Location = new System.Drawing.Point(12, 245);
            this.LoadSubButton.Name = "LoadSubButton";
            this.LoadSubButton.Size = new System.Drawing.Size(97, 23);
            this.LoadSubButton.TabIndex = 2;
            this.LoadSubButton.Text = "Load Sub";
            this.LoadSubButton.UseVisualStyleBackColor = true;
            this.LoadSubButton.Click += new System.EventHandler(this.LoadSubButton_Click);
            // 
            // LoadVariablesButton
            // 
            this.LoadVariablesButton.Location = new System.Drawing.Point(115, 245);
            this.LoadVariablesButton.Name = "LoadVariablesButton";
            this.LoadVariablesButton.Size = new System.Drawing.Size(102, 23);
            this.LoadVariablesButton.TabIndex = 4;
            this.LoadVariablesButton.Text = "Load Variables";
            this.LoadVariablesButton.UseVisualStyleBackColor = true;
            this.LoadVariablesButton.Click += new System.EventHandler(this.LoadVariablesButton_Click);
            // 
            // AutoReloadCheckBox
            // 
            this.AutoReloadCheckBox.AutoSize = true;
            this.AutoReloadCheckBox.Location = new System.Drawing.Point(12, 303);
            this.AutoReloadCheckBox.Name = "AutoReloadCheckBox";
            this.AutoReloadCheckBox.Size = new System.Drawing.Size(85, 17);
            this.AutoReloadCheckBox.TabIndex = 5;
            this.AutoReloadCheckBox.Text = "Auto Reload";
            this.AutoReloadCheckBox.UseVisualStyleBackColor = true;
            this.AutoReloadCheckBox.CheckedChanged += new System.EventHandler(this.AutoReloadCheckBox_CheckedChanged);
            // 
            // AutoReloader
            // 
            this.AutoReloader.Interval = 1000;
            this.AutoReloader.Tick += new System.EventHandler(this.AutoReloader_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 274);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(115, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Load Variables As";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkLoadWithArray
            // 
            this.chkLoadWithArray.AutoSize = true;
            this.chkLoadWithArray.Location = new System.Drawing.Point(103, 303);
            this.chkLoadWithArray.Name = "chkLoadWithArray";
            this.chkLoadWithArray.Size = new System.Drawing.Size(138, 17);
            this.chkLoadWithArray.TabIndex = 9;
            this.chkLoadWithArray.Text = "Open with array display.";
            this.chkLoadWithArray.UseVisualStyleBackColor = true;
            // 
            // eventObjectPannel1
            // 
            this.eventObjectPannel1.EventObject = null;
            this.eventObjectPannel1.Location = new System.Drawing.Point(12, 12);
            this.eventObjectPannel1.MinimumSize = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.Name = "eventObjectPannel1";
            this.eventObjectPannel1.Size = new System.Drawing.Size(469, 227);
            this.eventObjectPannel1.TabIndex = 10;
            this.eventObjectPannel1.EventObjectLoaded += new System.EventHandler(this.eventObjectPannel1_EventObjectLoaded);
            // 
            // EventObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 328);
            this.Controls.Add(this.eventObjectPannel1);
            this.Controls.Add(this.chkLoadWithArray);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.AutoReloadCheckBox);
            this.Controls.Add(this.LoadVariablesButton);
            this.Controls.Add(this.LoadSubButton);
            this.Name = "EventObjectDisplay";
            this.Text = "EventObjectDisplay";
            this.Load += new System.EventHandler(this.EventObjectDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoadSubButton;
        private System.Windows.Forms.Button LoadVariablesButton;
        private System.Windows.Forms.CheckBox AutoReloadCheckBox;
        private System.Windows.Forms.Timer AutoReloader;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkLoadWithArray;
        private X3TCsTool.EventObjectPannel eventObjectPannel1;
    }
}