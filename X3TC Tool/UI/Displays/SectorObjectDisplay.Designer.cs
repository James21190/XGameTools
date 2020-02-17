namespace X3TC_Tool.UI.Displays
{
    partial class SectorObjectDisplay
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadIDButton = new System.Windows.Forms.Button();
            this.IDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DefaultNameBox = new System.Windows.Forms.TextBox();
            this.AutoReloader = new System.Windows.Forms.Timer(this.components);
            this.AutoReloadCheckBox = new System.Windows.Forms.CheckBox();
            this.PositionVectorDisplay = new Common.UI.Vector3Display();
            this.RotationVectorDisplay = new Common.UI.Vector3Display();
            this.NextButton = new System.Windows.Forms.Button();
            this.ParentButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EventObjectIDBox = new System.Windows.Forms.TextBox();
            this.EventObjectIDLoadButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LastChildButton = new System.Windows.Forms.Button();
            this.ChildTypeSelectionBox = new System.Windows.Forms.ComboBox();
            this.FirstChildButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.UnknownsListBox = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.SpeedBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TargetSpeedBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBox)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetSpeedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(6, 19);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.ReadOnly = true;
            this.AddressBox.Size = new System.Drawing.Size(109, 20);
            this.AddressBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadIDButton);
            this.groupBox1.Controls.Add(this.IDNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(257, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID";
            // 
            // LoadIDButton
            // 
            this.LoadIDButton.Location = new System.Drawing.Point(97, 16);
            this.LoadIDButton.Name = "LoadIDButton";
            this.LoadIDButton.Size = new System.Drawing.Size(75, 23);
            this.LoadIDButton.TabIndex = 1;
            this.LoadIDButton.Text = "Load";
            this.LoadIDButton.UseVisualStyleBackColor = true;
            this.LoadIDButton.Click += new System.EventHandler(this.LoadIDButton_Click);
            // 
            // IDNumericUpDown
            // 
            this.IDNumericUpDown.Location = new System.Drawing.Point(6, 19);
            this.IDNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.IDNumericUpDown.Name = "IDNumericUpDown";
            this.IDNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.IDNumericUpDown.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DefaultNameBox);
            this.groupBox3.Location = new System.Drawing.Point(130, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default Name";
            // 
            // DefaultNameBox
            // 
            this.DefaultNameBox.Location = new System.Drawing.Point(6, 19);
            this.DefaultNameBox.Name = "DefaultNameBox";
            this.DefaultNameBox.ReadOnly = true;
            this.DefaultNameBox.Size = new System.Drawing.Size(109, 20);
            this.DefaultNameBox.TabIndex = 0;
            // 
            // AutoReloader
            // 
            this.AutoReloader.Interval = 1000;
            this.AutoReloader.Tick += new System.EventHandler(this.AutoReloader_Tick);
            // 
            // AutoReloadCheckBox
            // 
            this.AutoReloadCheckBox.AutoSize = true;
            this.AutoReloadCheckBox.Location = new System.Drawing.Point(625, 3);
            this.AutoReloadCheckBox.Name = "AutoReloadCheckBox";
            this.AutoReloadCheckBox.Size = new System.Drawing.Size(85, 17);
            this.AutoReloadCheckBox.TabIndex = 8;
            this.AutoReloadCheckBox.Text = "Auto Reload";
            this.AutoReloadCheckBox.UseVisualStyleBackColor = true;
            this.AutoReloadCheckBox.CheckedChanged += new System.EventHandler(this.AutoReloadCheckBox_CheckedChanged);
            // 
            // PositionVectorDisplay
            // 
            this.PositionVectorDisplay.Location = new System.Drawing.Point(3, 119);
            this.PositionVectorDisplay.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.PositionVectorDisplay.MaximumSize = new System.Drawing.Size(156, 103);
            this.PositionVectorDisplay.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.PositionVectorDisplay.MinimumSize = new System.Drawing.Size(100, 103);
            this.PositionVectorDisplay.Name = "PositionVectorDisplay";
            this.PositionVectorDisplay.ReadOnly = true;
            this.PositionVectorDisplay.Size = new System.Drawing.Size(156, 103);
            this.PositionVectorDisplay.TabIndex = 7;
            this.PositionVectorDisplay.Text = "Position";
            this.PositionVectorDisplay.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PositionVectorDisplay.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PositionVectorDisplay.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // RotationVectorDisplay
            // 
            this.RotationVectorDisplay.Location = new System.Drawing.Point(3, 228);
            this.RotationVectorDisplay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.RotationVectorDisplay.MaximumSize = new System.Drawing.Size(156, 103);
            this.RotationVectorDisplay.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.RotationVectorDisplay.MinimumSize = new System.Drawing.Size(100, 103);
            this.RotationVectorDisplay.Name = "RotationVectorDisplay";
            this.RotationVectorDisplay.ReadOnly = true;
            this.RotationVectorDisplay.Size = new System.Drawing.Size(156, 103);
            this.RotationVectorDisplay.TabIndex = 9;
            this.RotationVectorDisplay.Text = "Rotation";
            this.RotationVectorDisplay.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RotationVectorDisplay.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RotationVectorDisplay.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(258, 61);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(90, 23);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Go To Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // ParentButton
            // 
            this.ParentButton.Location = new System.Drawing.Point(258, 119);
            this.ParentButton.Name = "ParentButton";
            this.ParentButton.Size = new System.Drawing.Size(90, 23);
            this.ParentButton.TabIndex = 11;
            this.ParentButton.Text = "Go To Parent";
            this.ParentButton.UseVisualStyleBackColor = true;
            this.ParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(258, 90);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(90, 23);
            this.PreviousButton.TabIndex = 12;
            this.PreviousButton.Text = "Go To Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EventObjectIDBox);
            this.groupBox4.Controls.Add(this.EventObjectIDLoadButton);
            this.groupBox4.Location = new System.Drawing.Point(441, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 52);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EventObject ID";
            // 
            // EventObjectIDBox
            // 
            this.EventObjectIDBox.Location = new System.Drawing.Point(6, 19);
            this.EventObjectIDBox.Name = "EventObjectIDBox";
            this.EventObjectIDBox.ReadOnly = true;
            this.EventObjectIDBox.Size = new System.Drawing.Size(85, 20);
            this.EventObjectIDBox.TabIndex = 1;
            // 
            // EventObjectIDLoadButton
            // 
            this.EventObjectIDLoadButton.Location = new System.Drawing.Point(97, 17);
            this.EventObjectIDLoadButton.Name = "EventObjectIDLoadButton";
            this.EventObjectIDLoadButton.Size = new System.Drawing.Size(75, 23);
            this.EventObjectIDLoadButton.TabIndex = 1;
            this.EventObjectIDLoadButton.Text = "Load";
            this.EventObjectIDLoadButton.UseVisualStyleBackColor = true;
            this.EventObjectIDLoadButton.Click += new System.EventHandler(this.EventObjectIDLoadButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TypeBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 52);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type";
            // 
            // TypeBox
            // 
            this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeBox.Location = new System.Drawing.Point(6, 19);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.ReadOnly = true;
            this.TypeBox.Size = new System.Drawing.Size(236, 20);
            this.TypeBox.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LastChildButton);
            this.groupBox6.Controls.Add(this.ChildTypeSelectionBox);
            this.groupBox6.Controls.Add(this.FirstChildButton);
            this.groupBox6.Location = new System.Drawing.Point(457, 61);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(140, 108);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Children";
            // 
            // LastChildButton
            // 
            this.LastChildButton.Location = new System.Drawing.Point(6, 75);
            this.LastChildButton.Name = "LastChildButton";
            this.LastChildButton.Size = new System.Drawing.Size(121, 23);
            this.LastChildButton.TabIndex = 15;
            this.LastChildButton.Text = "Go To Last";
            this.LastChildButton.UseVisualStyleBackColor = true;
            this.LastChildButton.Click += new System.EventHandler(this.LastChildButton_Click);
            // 
            // ChildTypeSelectionBox
            // 
            this.ChildTypeSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChildTypeSelectionBox.FormattingEnabled = true;
            this.ChildTypeSelectionBox.Location = new System.Drawing.Point(6, 19);
            this.ChildTypeSelectionBox.Name = "ChildTypeSelectionBox";
            this.ChildTypeSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.ChildTypeSelectionBox.TabIndex = 0;
            this.ChildTypeSelectionBox.SelectedIndexChanged += new System.EventHandler(this.ChildTypeSelectionBox_SelectedIndexChanged);
            // 
            // FirstChildButton
            // 
            this.FirstChildButton.Location = new System.Drawing.Point(6, 46);
            this.FirstChildButton.Name = "FirstChildButton";
            this.FirstChildButton.Size = new System.Drawing.Size(121, 23);
            this.FirstChildButton.TabIndex = 14;
            this.FirstChildButton.Text = "Go To First";
            this.FirstChildButton.UseVisualStyleBackColor = true;
            this.FirstChildButton.Click += new System.EventHandler(this.FirstChildButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.UnknownsListBox);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.PositionVectorDisplay);
            this.panel1.Controls.Add(this.PreviousButton);
            this.panel1.Controls.Add(this.AutoReloadCheckBox);
            this.panel1.Controls.Add(this.ParentButton);
            this.panel1.Controls.Add(this.RotationVectorDisplay);
            this.panel1.Controls.Add(this.NextButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Load Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UnknownsListBox
            // 
            this.UnknownsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UnknownsListBox.FormattingEnabled = true;
            this.UnknownsListBox.Location = new System.Drawing.Point(603, 61);
            this.UnknownsListBox.Name = "UnknownsListBox";
            this.UnknownsListBox.Size = new System.Drawing.Size(170, 355);
            this.UnknownsListBox.TabIndex = 21;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.SpeedBox);
            this.groupBox7.Location = new System.Drawing.Point(165, 148);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(121, 52);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Speed";
            // 
            // SpeedBox
            // 
            this.SpeedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeedBox.Location = new System.Drawing.Point(6, 19);
            this.SpeedBox.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.SpeedBox.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147483648});
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(109, 20);
            this.SpeedBox.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TargetSpeedBox);
            this.groupBox8.Location = new System.Drawing.Point(292, 148);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(121, 52);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Target Speed";
            // 
            // TargetSpeedBox
            // 
            this.TargetSpeedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetSpeedBox.Location = new System.Drawing.Point(6, 19);
            this.TargetSpeedBox.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.TargetSpeedBox.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147483648});
            this.TargetSpeedBox.Name = "TargetSpeedBox";
            this.TargetSpeedBox.Size = new System.Drawing.Size(109, 20);
            this.TargetSpeedBox.TabIndex = 0;
            // 
            // SectorObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "SectorObjectDisplay";
            this.Text = "SectorObjectDisplay";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBox)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TargetSpeedBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadIDButton;
        private System.Windows.Forms.NumericUpDown IDNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox DefaultNameBox;
        private Common.UI.Vector3Display PositionVectorDisplay;
        private System.Windows.Forms.Timer AutoReloader;
        private System.Windows.Forms.CheckBox AutoReloadCheckBox;
        private Common.UI.Vector3Display RotationVectorDisplay;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button ParentButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox EventObjectIDBox;
        private System.Windows.Forms.Button EventObjectIDLoadButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TypeBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox ChildTypeSelectionBox;
        private System.Windows.Forms.Button LastChildButton;
        private System.Windows.Forms.Button FirstChildButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox UnknownsListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown TargetSpeedBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown SpeedBox;
    }
}