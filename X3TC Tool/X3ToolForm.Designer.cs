namespace X3_Tool
{
    partial class X3ToolForm
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
            this.ViewStoryBaseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ViewSectorObjectManagerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameHookMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.hashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorObjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renderObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storyBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingObjectsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ScriptingObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingHashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingTextObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingDisassemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bodyDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x86DisassemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPlayerShipButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.GameHookPanel = new System.Windows.Forms.Panel();
            this.dLLInjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.GameHookPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewStoryBaseButton
            // 
            this.ViewStoryBaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewStoryBaseButton.Location = new System.Drawing.Point(6, 19);
            this.ViewStoryBaseButton.Name = "ViewStoryBaseButton";
            this.ViewStoryBaseButton.Size = new System.Drawing.Size(188, 23);
            this.ViewStoryBaseButton.TabIndex = 0;
            this.ViewStoryBaseButton.Text = "View StoryBase";
            this.ViewStoryBaseButton.UseVisualStyleBackColor = true;
            this.ViewStoryBaseButton.Click += new System.EventHandler(this.LoadStoryBaseDisplay);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ViewSectorObjectManagerButton);
            this.groupBox1.Controls.Add(this.ViewStoryBaseButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bases";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(6, 135);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "View GateSystemObject";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(6, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "View CameraBase";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "View InputBase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewSectorObjectManagerButton
            // 
            this.ViewSectorObjectManagerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewSectorObjectManagerButton.Location = new System.Drawing.Point(6, 48);
            this.ViewSectorObjectManagerButton.Name = "ViewSectorObjectManagerButton";
            this.ViewSectorObjectManagerButton.Size = new System.Drawing.Size(188, 23);
            this.ViewSectorObjectManagerButton.TabIndex = 1;
            this.ViewSectorObjectManagerButton.Text = "View SectorObjectManager";
            this.ViewSectorObjectManagerButton.UseVisualStyleBackColor = true;
            this.ViewSectorObjectManagerButton.Click += new System.EventHandler(this.LoadSectorObjectManagerDisplay);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameHookMenuStrip,
            this.dLLInjectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameHookMenuStrip
            // 
            this.GameHookMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hashTableToolStripMenuItem,
            this.sectorObjectsToolStripMenuItem,
            this.storyBaseToolStripMenuItem,
            this.cameraBaseToolStripMenuItem,
            this.x86DisassemblerToolStripMenuItem});
            this.GameHookMenuStrip.Name = "GameHookMenuStrip";
            this.GameHookMenuStrip.Size = new System.Drawing.Size(79, 20);
            this.GameHookMenuStrip.Text = "GameHook";
            // 
            // hashTableToolStripMenuItem
            // 
            this.hashTableToolStripMenuItem.Name = "hashTableToolStripMenuItem";
            this.hashTableToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.hashTableToolStripMenuItem.Text = "HashTable";
            this.hashTableToolStripMenuItem.Click += new System.EventHandler(this.hashTableToolStripMenuItem_Click);
            // 
            // sectorObjectsToolStripMenuItem
            // 
            this.sectorObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectorObjectToolStripMenuItem1,
            this.typeDataToolStripMenuItem1,
            this.renderObjectToolStripMenuItem});
            this.sectorObjectsToolStripMenuItem.Name = "sectorObjectsToolStripMenuItem";
            this.sectorObjectsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sectorObjectsToolStripMenuItem.Text = "Sector Objects";
            // 
            // sectorObjectToolStripMenuItem1
            // 
            this.sectorObjectToolStripMenuItem1.Name = "sectorObjectToolStripMenuItem1";
            this.sectorObjectToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.sectorObjectToolStripMenuItem1.Text = "SectorObject";
            this.sectorObjectToolStripMenuItem1.Click += new System.EventHandler(this.sectorObjectToolStripMenuItem1_Click);
            // 
            // typeDataToolStripMenuItem1
            // 
            this.typeDataToolStripMenuItem1.Name = "typeDataToolStripMenuItem1";
            this.typeDataToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.typeDataToolStripMenuItem1.Text = "TypeData";
            this.typeDataToolStripMenuItem1.Click += new System.EventHandler(this.typeDataToolStripMenuItem1_Click);
            // 
            // renderObjectToolStripMenuItem
            // 
            this.renderObjectToolStripMenuItem.Name = "renderObjectToolStripMenuItem";
            this.renderObjectToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.renderObjectToolStripMenuItem.Text = "RenderObject";
            this.renderObjectToolStripMenuItem.Click += new System.EventHandler(this.renderObjectToolStripMenuItem_Click);
            // 
            // storyBaseToolStripMenuItem
            // 
            this.storyBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptingObjectsToolStripMenuItem1,
            this.textPageToolStripMenuItem});
            this.storyBaseToolStripMenuItem.Name = "storyBaseToolStripMenuItem";
            this.storyBaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.storyBaseToolStripMenuItem.Text = "StoryBase Objects";
            // 
            // scriptingObjectsToolStripMenuItem1
            // 
            this.scriptingObjectsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScriptingObjectToolStripMenuItem,
            this.scriptObjectToolStripMenuItem,
            this.scriptingHashTableToolStripMenuItem,
            this.scriptingTextObjectToolStripMenuItem,
            this.scriptingArrayToolStripMenuItem,
            this.scriptingDisassemblerToolStripMenuItem});
            this.scriptingObjectsToolStripMenuItem1.Name = "scriptingObjectsToolStripMenuItem1";
            this.scriptingObjectsToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.scriptingObjectsToolStripMenuItem1.Text = "Scripting Objects";
            // 
            // ScriptingObjectToolStripMenuItem
            // 
            this.ScriptingObjectToolStripMenuItem.Name = "ScriptingObjectToolStripMenuItem";
            this.ScriptingObjectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ScriptingObjectToolStripMenuItem.Text = "ScriptingObject";
            this.ScriptingObjectToolStripMenuItem.Click += new System.EventHandler(this.ScriptingObjectToolStripMenuItem_Click);
            // 
            // scriptObjectToolStripMenuItem
            // 
            this.scriptObjectToolStripMenuItem.Name = "scriptObjectToolStripMenuItem";
            this.scriptObjectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scriptObjectToolStripMenuItem.Text = "ScriptingTaskObject";
            this.scriptObjectToolStripMenuItem.Click += new System.EventHandler(this.scriptObjectToolStripMenuItem_Click);
            // 
            // scriptingHashTableToolStripMenuItem
            // 
            this.scriptingHashTableToolStripMenuItem.Name = "scriptingHashTableToolStripMenuItem";
            this.scriptingHashTableToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scriptingHashTableToolStripMenuItem.Text = "ScriptingHashTable";
            this.scriptingHashTableToolStripMenuItem.Click += new System.EventHandler(this.scriptingHashTableToolStripMenuItem_Click);
            // 
            // scriptingTextObjectToolStripMenuItem
            // 
            this.scriptingTextObjectToolStripMenuItem.Name = "scriptingTextObjectToolStripMenuItem";
            this.scriptingTextObjectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scriptingTextObjectToolStripMenuItem.Text = "ScriptingTextObject";
            this.scriptingTextObjectToolStripMenuItem.Click += new System.EventHandler(this.scriptingTextObjectToolStripMenuItem_Click);
            // 
            // scriptingArrayToolStripMenuItem
            // 
            this.scriptingArrayToolStripMenuItem.Name = "scriptingArrayToolStripMenuItem";
            this.scriptingArrayToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scriptingArrayToolStripMenuItem.Text = "ScriptingArray";
            this.scriptingArrayToolStripMenuItem.Click += new System.EventHandler(this.scriptingArrayToolStripMenuItem_Click);
            // 
            // scriptingDisassemblerToolStripMenuItem
            // 
            this.scriptingDisassemblerToolStripMenuItem.Name = "scriptingDisassemblerToolStripMenuItem";
            this.scriptingDisassemblerToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scriptingDisassemblerToolStripMenuItem.Text = "ScriptingDisassembler";
            this.scriptingDisassemblerToolStripMenuItem.Click += new System.EventHandler(this.scriptingDisassemblerToolStripMenuItem_Click);
            // 
            // textPageToolStripMenuItem
            // 
            this.textPageToolStripMenuItem.Name = "textPageToolStripMenuItem";
            this.textPageToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.textPageToolStripMenuItem.Text = "TextPage";
            this.textPageToolStripMenuItem.Click += new System.EventHandler(this.textPageToolStripMenuItem_Click);
            // 
            // cameraBaseToolStripMenuItem
            // 
            this.cameraBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem1,
            this.bodyDataToolStripMenuItem1});
            this.cameraBaseToolStripMenuItem.Name = "cameraBaseToolStripMenuItem";
            this.cameraBaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cameraBaseToolStripMenuItem.Text = "CameraBase";
            // 
            // cameraToolStripMenuItem1
            // 
            this.cameraToolStripMenuItem1.Name = "cameraToolStripMenuItem1";
            this.cameraToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.cameraToolStripMenuItem1.Text = "Camera";
            this.cameraToolStripMenuItem1.Click += new System.EventHandler(this.cameraToolStripMenuItem1_Click);
            // 
            // bodyDataToolStripMenuItem1
            // 
            this.bodyDataToolStripMenuItem1.Name = "bodyDataToolStripMenuItem1";
            this.bodyDataToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.bodyDataToolStripMenuItem1.Text = "BodyData";
            this.bodyDataToolStripMenuItem1.Click += new System.EventHandler(this.bodyDataToolStripMenuItem1_Click);
            // 
            // x86DisassemblerToolStripMenuItem
            // 
            this.x86DisassemblerToolStripMenuItem.Name = "x86DisassemblerToolStripMenuItem";
            this.x86DisassemblerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.x86DisassemblerToolStripMenuItem.Text = "x86 Disassembler";
            this.x86DisassemblerToolStripMenuItem.Click += new System.EventHandler(this.x86DisassemblerToolStripMenuItem_Click);
            // 
            // LoadPlayerShipButton
            // 
            this.LoadPlayerShipButton.Location = new System.Drawing.Point(209, 3);
            this.LoadPlayerShipButton.Name = "LoadPlayerShipButton";
            this.LoadPlayerShipButton.Size = new System.Drawing.Size(132, 23);
            this.LoadPlayerShipButton.TabIndex = 2;
            this.LoadPlayerShipButton.Text = "Load Player Ship";
            this.LoadPlayerShipButton.UseVisualStyleBackColor = true;
            this.LoadPlayerShipButton.Click += new System.EventHandler(this.LoadPlayerShipButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 42);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(252, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(517, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 93);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SETA Override";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(113, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Increase Maximum SETA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "SETA: x1";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(209, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Load Sector";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(347, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Load Player Ship Event Object";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GameHookPanel
            // 
            this.GameHookPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameHookPanel.Controls.Add(this.groupBox1);
            this.GameHookPanel.Controls.Add(this.button5);
            this.GameHookPanel.Controls.Add(this.LoadPlayerShipButton);
            this.GameHookPanel.Controls.Add(this.groupBox2);
            this.GameHookPanel.Controls.Add(this.button4);
            this.GameHookPanel.Location = new System.Drawing.Point(12, 27);
            this.GameHookPanel.Name = "GameHookPanel";
            this.GameHookPanel.Size = new System.Drawing.Size(860, 522);
            this.GameHookPanel.TabIndex = 9;
            // 
            // dLLInjectToolStripMenuItem
            // 
            this.dLLInjectToolStripMenuItem.Name = "dLLInjectToolStripMenuItem";
            this.dLLInjectToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.dLLInjectToolStripMenuItem.Text = "DLL Inject";
            this.dLLInjectToolStripMenuItem.Click += new System.EventHandler(this.dLLInjectToolStripMenuItem_Click);
            // 
            // X3ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.GameHookPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "X3ToolForm";
            this.Text = "X3 Tool - Alpha 6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.X3TCToolForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GameHookPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewStoryBaseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GameHookMenuStrip;
        private System.Windows.Forms.Button ViewSectorObjectManagerButton;
        private System.Windows.Forms.Button LoadPlayerShipButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem hashTableToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel GameHookPanel;
        private System.Windows.Forms.ToolStripMenuItem x86DisassemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storyBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptingObjectsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ScriptingObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectorObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectorObjectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem typeDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scriptingHashTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptingTextObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptingArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bodyDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scriptingDisassemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dLLInjectToolStripMenuItem;
    }
}

