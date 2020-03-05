namespace X3TC_Tool
{
    partial class X3TCToolForm
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
            this.ViewStoryBaseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ViewSectorObjectManagerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptObjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingHashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPlayerShipButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dynamicValueObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ViewSectorObjectManagerButton);
            this.groupBox1.Controls.Add(this.ViewStoryBaseButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bases";
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
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventObjectToolStripMenuItem,
            this.sectorObjectToolStripMenuItem,
            this.typeDataToolStripMenuItem,
            this.hashTableToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.scriptingObjectsToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.windowToolStripMenuItem.Text = "Viewers";
            // 
            // eventObjectToolStripMenuItem
            // 
            this.eventObjectToolStripMenuItem.Name = "eventObjectToolStripMenuItem";
            this.eventObjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eventObjectToolStripMenuItem.Text = "EventObject";
            this.eventObjectToolStripMenuItem.Click += new System.EventHandler(this.LoadEventObjectDisplay);
            // 
            // sectorObjectToolStripMenuItem
            // 
            this.sectorObjectToolStripMenuItem.Name = "sectorObjectToolStripMenuItem";
            this.sectorObjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sectorObjectToolStripMenuItem.Text = "SectorObject";
            this.sectorObjectToolStripMenuItem.Click += new System.EventHandler(this.sectorObjectToolStripMenuItem_Click);
            // 
            // typeDataToolStripMenuItem
            // 
            this.typeDataToolStripMenuItem.Name = "typeDataToolStripMenuItem";
            this.typeDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.typeDataToolStripMenuItem.Text = "TypeData";
            this.typeDataToolStripMenuItem.Click += new System.EventHandler(this.typeDataToolStripMenuItem_Click);
            // 
            // hashTableToolStripMenuItem
            // 
            this.hashTableToolStripMenuItem.Name = "hashTableToolStripMenuItem";
            this.hashTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hashTableToolStripMenuItem.Text = "HashTable";
            this.hashTableToolStripMenuItem.Click += new System.EventHandler(this.hashTableToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cameraToolStripMenuItem.Text = "Camera";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // scriptingObjectsToolStripMenuItem
            // 
            this.scriptingObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dynamicValueObjectToolStripMenuItem,
            this.scriptObjectToolStripMenuItem1,
            this.scriptingHashTableToolStripMenuItem,
            this.scriptingArrayToolStripMenuItem,
            this.dynamicValueToolStripMenuItem1});
            this.scriptingObjectsToolStripMenuItem.Name = "scriptingObjectsToolStripMenuItem";
            this.scriptingObjectsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scriptingObjectsToolStripMenuItem.Text = "Scripting Objects";
            // 
            // scriptObjectToolStripMenuItem1
            // 
            this.scriptObjectToolStripMenuItem1.Name = "scriptObjectToolStripMenuItem1";
            this.scriptObjectToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.scriptObjectToolStripMenuItem1.Text = "ScriptObject";
            this.scriptObjectToolStripMenuItem1.Click += new System.EventHandler(this.scriptObjectToolStripMenuItem1_Click);
            // 
            // scriptingHashTableToolStripMenuItem
            // 
            this.scriptingHashTableToolStripMenuItem.Name = "scriptingHashTableToolStripMenuItem";
            this.scriptingHashTableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.scriptingHashTableToolStripMenuItem.Text = "ScriptingHashTable";
            this.scriptingHashTableToolStripMenuItem.Click += new System.EventHandler(this.scriptingHashTableToolStripMenuItem_Click);
            // 
            // scriptingArrayToolStripMenuItem
            // 
            this.scriptingArrayToolStripMenuItem.Name = "scriptingArrayToolStripMenuItem";
            this.scriptingArrayToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.scriptingArrayToolStripMenuItem.Text = "ScriptingArray";
            this.scriptingArrayToolStripMenuItem.Click += new System.EventHandler(this.scriptingArrayToolStripMenuItem_Click);
            // 
            // dynamicValueToolStripMenuItem1
            // 
            this.dynamicValueToolStripMenuItem1.Name = "dynamicValueToolStripMenuItem1";
            this.dynamicValueToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.dynamicValueToolStripMenuItem1.Text = "DynamicValue";
            this.dynamicValueToolStripMenuItem1.Click += new System.EventHandler(this.dynamicValueToolStripMenuItem1_Click);
            // 
            // LoadPlayerShipButton
            // 
            this.LoadPlayerShipButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadPlayerShipButton.Location = new System.Drawing.Point(218, 27);
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
            this.groupBox2.Location = new System.Drawing.Point(608, 34);
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
            // dynamicValueObjectToolStripMenuItem
            // 
            this.dynamicValueObjectToolStripMenuItem.Name = "dynamicValueObjectToolStripMenuItem";
            this.dynamicValueObjectToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.dynamicValueObjectToolStripMenuItem.Text = "DynamicValueObject";
            this.dynamicValueObjectToolStripMenuItem.Click += new System.EventHandler(this.dynamicValueObjectToolStripMenuItem_Click);
            // 
            // X3TCToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LoadPlayerShipButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "X3TCToolForm";
            this.Text = "X3 Terran Confict Tool - Alpha 5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.X3TCToolForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewStoryBaseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventObjectToolStripMenuItem;
        private System.Windows.Forms.Button ViewSectorObjectManagerButton;
        private System.Windows.Forms.Button LoadPlayerShipButton;
        private System.Windows.Forms.ToolStripMenuItem sectorObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDataToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem hashTableToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem scriptingObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptObjectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scriptingHashTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptingArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynamicValueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dynamicValueObjectToolStripMenuItem;
    }
}

