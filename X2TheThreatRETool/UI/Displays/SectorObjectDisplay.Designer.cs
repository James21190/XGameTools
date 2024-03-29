﻿namespace X2TheThreatRETool.UI.Displays
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
            this.txtType = new System.Windows.Forms.TextBox();
            this.ChildTypeSelectionBox = new System.Windows.Forms.ComboBox();
            this.FirstChildButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ModelCollectionIDBox = new System.Windows.Forms.TextBox();
            this.txtRace = new System.Windows.Forms.TextBox();
            this.TargetSpeedBox = new System.Windows.Forms.NumericUpDown();
            this.LastChildButton = new System.Windows.Forms.Button();
            this.SpeedBox = new System.Windows.Forms.NumericUpDown();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.v3dPosition = new Common.UI.Vector3Display();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.UnknownsListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadIDButton = new System.Windows.Forms.Button();
            this.nudSectorObjectID = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDefaultName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EventObjectIDBox = new System.Windows.Forms.TextBox();
            this.EventObjectIDLoadButton = new System.Windows.Forms.Button();
            this.v3dPositionKm = new Common.UI.Vector3Display();
            this.btnGoPrevious = new System.Windows.Forms.Button();
            this.AutoReloadCheckBox = new System.Windows.Forms.CheckBox();
            this.btnGoParent = new System.Windows.Forms.Button();
            this.v3dRotation = new Common.UI.Vector3Display();
            this.btnGoNext = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.AutoReloader = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TargetSpeedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSectorObjectID)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(6, 19);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(236, 20);
            this.txtType.TabIndex = 0;
            // 
            // ChildTypeSelectionBox
            // 
            this.ChildTypeSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChildTypeSelectionBox.FormattingEnabled = true;
            this.ChildTypeSelectionBox.Location = new System.Drawing.Point(6, 19);
            this.ChildTypeSelectionBox.Name = "ChildTypeSelectionBox";
            this.ChildTypeSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.ChildTypeSelectionBox.TabIndex = 0;
            // 
            // FirstChildButton
            // 
            this.FirstChildButton.Location = new System.Drawing.Point(6, 46);
            this.FirstChildButton.Name = "FirstChildButton";
            this.FirstChildButton.Size = new System.Drawing.Size(121, 23);
            this.FirstChildButton.TabIndex = 14;
            this.FirstChildButton.Text = "Go To First";
            this.FirstChildButton.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(174, 405);
            this.treeView1.TabIndex = 25;
            // 
            // ModelCollectionIDBox
            // 
            this.ModelCollectionIDBox.Location = new System.Drawing.Point(6, 19);
            this.ModelCollectionIDBox.Name = "ModelCollectionIDBox";
            this.ModelCollectionIDBox.ReadOnly = true;
            this.ModelCollectionIDBox.Size = new System.Drawing.Size(109, 20);
            this.ModelCollectionIDBox.TabIndex = 0;
            // 
            // txtRace
            // 
            this.txtRace.Location = new System.Drawing.Point(6, 19);
            this.txtRace.Name = "txtRace";
            this.txtRace.ReadOnly = true;
            this.txtRace.Size = new System.Drawing.Size(109, 20);
            this.txtRace.TabIndex = 0;
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
            // LastChildButton
            // 
            this.LastChildButton.Location = new System.Drawing.Point(6, 75);
            this.LastChildButton.Name = "LastChildButton";
            this.LastChildButton.Size = new System.Drawing.Size(121, 23);
            this.LastChildButton.TabIndex = 15;
            this.LastChildButton.Text = "Go To Last";
            this.LastChildButton.UseVisualStyleBackColor = true;
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
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerShipToolStripMenuItem,
            this.sectorToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // playerShipToolStripMenuItem
            // 
            this.playerShipToolStripMenuItem.Name = "playerShipToolStripMenuItem";
            this.playerShipToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.playerShipToolStripMenuItem.Text = "Player Ship";
            // 
            // sectorToolStripMenuItem
            // 
            this.sectorToolStripMenuItem.Name = "sectorToolStripMenuItem";
            this.sectorToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.sectorToolStripMenuItem.Text = "Sector";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeDataToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.otherToolStripMenuItem.Text = "Load Other";
            // 
            // typeDataToolStripMenuItem
            // 
            this.typeDataToolStripMenuItem.Name = "typeDataToolStripMenuItem";
            this.typeDataToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.typeDataToolStripMenuItem.Text = "TypeData";
            // 
            // spawnToolStripMenuItem
            // 
            this.spawnToolStripMenuItem.Name = "spawnToolStripMenuItem";
            this.spawnToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.spawnToolStripMenuItem.Text = "Spawn";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(779, 411);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox10);
            this.panel1.Controls.Add(this.v3dPosition);
            this.panel1.Controls.Add(this.groupBox9);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Controls.Add(this.UnknownsListBox);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.v3dPositionKm);
            this.panel1.Controls.Add(this.btnGoPrevious);
            this.panel1.Controls.Add(this.AutoReloadCheckBox);
            this.panel1.Controls.Add(this.btnGoParent);
            this.panel1.Controls.Add(this.v3dRotation);
            this.panel1.Controls.Add(this.btnGoNext);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 405);
            this.panel1.TabIndex = 15;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ModelCollectionIDBox);
            this.groupBox10.Location = new System.Drawing.Point(292, 206);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(121, 52);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "ModelID";
            // 
            // v3dPosition
            // 
            this.v3dPosition.DecimalPlaces = 0;
            this.v3dPosition.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.v3dPosition.Location = new System.Drawing.Point(9, 119);
            this.v3dPosition.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.v3dPosition.MaximumSize = new System.Drawing.Size(156, 103);
            this.v3dPosition.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.v3dPosition.MinimumSize = new System.Drawing.Size(100, 103);
            this.v3dPosition.Name = "v3dPosition";
            this.v3dPosition.ReadOnly = true;
            this.v3dPosition.Size = new System.Drawing.Size(156, 103);
            this.v3dPosition.TabIndex = 24;
            this.v3dPosition.Text = "Position";
            this.v3dPosition.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dPosition.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dPosition.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtRace);
            this.groupBox9.Location = new System.Drawing.Point(165, 206);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(121, 52);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Race";
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
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(171, 119);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(90, 23);
            this.btnLoadData.TabIndex = 22;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            // 
            // UnknownsListBox
            // 
            this.UnknownsListBox.FormattingEnabled = true;
            this.UnknownsListBox.Location = new System.Drawing.Point(419, 175);
            this.UnknownsListBox.Name = "UnknownsListBox";
            this.UnknownsListBox.Size = new System.Drawing.Size(170, 433);
            this.UnknownsListBox.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(6, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(109, 20);
            this.txtAddress.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LastChildButton);
            this.groupBox6.Controls.Add(this.ChildTypeSelectionBox);
            this.groupBox6.Controls.Add(this.FirstChildButton);
            this.groupBox6.Location = new System.Drawing.Point(419, 61);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(140, 108);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Children";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadIDButton);
            this.groupBox1.Controls.Add(this.nudSectorObjectID);
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
            // 
            // nudSectorObjectID
            // 
            this.nudSectorObjectID.Location = new System.Drawing.Point(6, 19);
            this.nudSectorObjectID.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.nudSectorObjectID.Name = "nudSectorObjectID";
            this.nudSectorObjectID.Size = new System.Drawing.Size(85, 20);
            this.nudSectorObjectID.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtType);
            this.groupBox5.Location = new System.Drawing.Point(3, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 52);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDefaultName);
            this.groupBox3.Location = new System.Drawing.Point(130, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default Name";
            // 
            // txtDefaultName
            // 
            this.txtDefaultName.Location = new System.Drawing.Point(6, 19);
            this.txtDefaultName.Name = "txtDefaultName";
            this.txtDefaultName.ReadOnly = true;
            this.txtDefaultName.Size = new System.Drawing.Size(109, 20);
            this.txtDefaultName.TabIndex = 0;
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
            // 
            // v3dPositionKm
            // 
            this.v3dPositionKm.DecimalPlaces = 2;
            this.v3dPositionKm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.v3dPositionKm.Location = new System.Drawing.Point(9, 228);
            this.v3dPositionKm.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.v3dPositionKm.MaximumSize = new System.Drawing.Size(156, 103);
            this.v3dPositionKm.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.v3dPositionKm.MinimumSize = new System.Drawing.Size(100, 103);
            this.v3dPositionKm.Name = "v3dPositionKm";
            this.v3dPositionKm.ReadOnly = true;
            this.v3dPositionKm.Size = new System.Drawing.Size(156, 103);
            this.v3dPositionKm.TabIndex = 7;
            this.v3dPositionKm.Text = "Position (Km)";
            this.v3dPositionKm.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dPositionKm.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dPositionKm.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnGoPrevious
            // 
            this.btnGoPrevious.Location = new System.Drawing.Point(267, 90);
            this.btnGoPrevious.Name = "btnGoPrevious";
            this.btnGoPrevious.Size = new System.Drawing.Size(90, 23);
            this.btnGoPrevious.TabIndex = 12;
            this.btnGoPrevious.Text = "Go To Previous";
            this.btnGoPrevious.UseVisualStyleBackColor = true;
            this.btnGoPrevious.Click += new System.EventHandler(this.btnGoPrevious_Click);
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
            // 
            // btnGoParent
            // 
            this.btnGoParent.Location = new System.Drawing.Point(267, 119);
            this.btnGoParent.Name = "btnGoParent";
            this.btnGoParent.Size = new System.Drawing.Size(90, 23);
            this.btnGoParent.TabIndex = 11;
            this.btnGoParent.Text = "Go To Parent";
            this.btnGoParent.UseVisualStyleBackColor = true;
            this.btnGoParent.Click += new System.EventHandler(this.btnGoParent_Click);
            // 
            // v3dRotation
            // 
            this.v3dRotation.DecimalPlaces = 0;
            this.v3dRotation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.v3dRotation.Location = new System.Drawing.Point(9, 337);
            this.v3dRotation.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.v3dRotation.MaximumSize = new System.Drawing.Size(156, 103);
            this.v3dRotation.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.v3dRotation.MinimumSize = new System.Drawing.Size(100, 103);
            this.v3dRotation.Name = "v3dRotation";
            this.v3dRotation.ReadOnly = true;
            this.v3dRotation.Size = new System.Drawing.Size(156, 103);
            this.v3dRotation.TabIndex = 9;
            this.v3dRotation.Text = "Rotation";
            this.v3dRotation.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dRotation.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.v3dRotation.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnGoNext
            // 
            this.btnGoNext.Location = new System.Drawing.Point(267, 61);
            this.btnGoNext.Name = "btnGoNext";
            this.btnGoNext.Size = new System.Drawing.Size(90, 23);
            this.btnGoNext.TabIndex = 10;
            this.btnGoNext.Text = "Go To Next";
            this.btnGoNext.UseVisualStyleBackColor = true;
            this.btnGoNext.Click += new System.EventHandler(this.btnGoNext_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(710, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.spawnToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 27;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // AutoReloader
            // 
            this.AutoReloader.Interval = 1000;
            // 
            // SectorObjectDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "SectorObjectDisplay";
            this.Text = "SectorObjectDisplay";
            ((System.ComponentModel.ISupportInitialize)(this.TargetSpeedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSectorObjectID)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.ComboBox ChildTypeSelectionBox;
        private System.Windows.Forms.Button FirstChildButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox ModelCollectionIDBox;
        private System.Windows.Forms.TextBox txtRace;
        private System.Windows.Forms.NumericUpDown TargetSpeedBox;
        private System.Windows.Forms.Button LastChildButton;
        private System.Windows.Forms.NumericUpDown SpeedBox;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spawnToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox10;
        private Common.UI.Vector3Display v3dPosition;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.ListBox UnknownsListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoadIDButton;
        private System.Windows.Forms.NumericUpDown nudSectorObjectID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDefaultName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox EventObjectIDBox;
        private System.Windows.Forms.Button EventObjectIDLoadButton;
        private Common.UI.Vector3Display v3dPositionKm;
        private System.Windows.Forms.Button btnGoPrevious;
        private System.Windows.Forms.CheckBox AutoReloadCheckBox;
        private System.Windows.Forms.Button btnGoParent;
        private Common.UI.Vector3Display v3dRotation;
        private System.Windows.Forms.Button btnGoNext;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Timer AutoReloader;
    }
}