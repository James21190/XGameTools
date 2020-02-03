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
            this.ViewSectorObjectManagerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPlayerShipButton = new System.Windows.Forms.Button();
            this.typeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.ViewSectorObjectManagerButton);
            this.groupBox1.Controls.Add(this.ViewStoryBaseButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bases";
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
            this.dynamicValueToolStripMenuItem,
            this.sectorObjectToolStripMenuItem,
            this.typeDataToolStripMenuItem});
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
            // dynamicValueToolStripMenuItem
            // 
            this.dynamicValueToolStripMenuItem.Name = "dynamicValueToolStripMenuItem";
            this.dynamicValueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dynamicValueToolStripMenuItem.Text = "DynamicValue";
            this.dynamicValueToolStripMenuItem.Click += new System.EventHandler(this.LoadDynamicValueDisplay);
            // 
            // sectorObjectToolStripMenuItem
            // 
            this.sectorObjectToolStripMenuItem.Name = "sectorObjectToolStripMenuItem";
            this.sectorObjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sectorObjectToolStripMenuItem.Text = "SectorObject";
            this.sectorObjectToolStripMenuItem.Click += new System.EventHandler(this.sectorObjectToolStripMenuItem_Click);
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
            // typeDataToolStripMenuItem
            // 
            this.typeDataToolStripMenuItem.Name = "typeDataToolStripMenuItem";
            this.typeDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.typeDataToolStripMenuItem.Text = "TypeData";
            this.typeDataToolStripMenuItem.Click += new System.EventHandler(this.typeDataToolStripMenuItem_Click);
            // 
            // X3TCToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
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
        private System.Windows.Forms.ToolStripMenuItem dynamicValueToolStripMenuItem;
        private System.Windows.Forms.Button LoadPlayerShipButton;
        private System.Windows.Forms.ToolStripMenuItem sectorObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDataToolStripMenuItem;
    }
}

