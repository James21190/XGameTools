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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.dynamicValueObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptObjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingHashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kCodeViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPlayerShipButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chartPerformance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBlocksAllocated = new System.Windows.Forms.Label();
            this.lblBytesAllocated = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).BeginInit();
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
            this.scriptingObjectsToolStripMenuItem,
            this.textPageToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.windowToolStripMenuItem.Text = "Viewers";
            // 
            // eventObjectToolStripMenuItem
            // 
            this.eventObjectToolStripMenuItem.Name = "eventObjectToolStripMenuItem";
            this.eventObjectToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.eventObjectToolStripMenuItem.Text = "EventObject";
            this.eventObjectToolStripMenuItem.Click += new System.EventHandler(this.LoadEventObjectDisplay);
            // 
            // sectorObjectToolStripMenuItem
            // 
            this.sectorObjectToolStripMenuItem.Name = "sectorObjectToolStripMenuItem";
            this.sectorObjectToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.sectorObjectToolStripMenuItem.Text = "SectorObject";
            this.sectorObjectToolStripMenuItem.Click += new System.EventHandler(this.sectorObjectToolStripMenuItem_Click);
            // 
            // typeDataToolStripMenuItem
            // 
            this.typeDataToolStripMenuItem.Name = "typeDataToolStripMenuItem";
            this.typeDataToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.typeDataToolStripMenuItem.Text = "TypeData";
            this.typeDataToolStripMenuItem.Click += new System.EventHandler(this.typeDataToolStripMenuItem_Click);
            // 
            // hashTableToolStripMenuItem
            // 
            this.hashTableToolStripMenuItem.Name = "hashTableToolStripMenuItem";
            this.hashTableToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.hashTableToolStripMenuItem.Text = "HashTable";
            this.hashTableToolStripMenuItem.Click += new System.EventHandler(this.hashTableToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
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
            this.dynamicValueToolStripMenuItem1,
            this.kCodeViewerToolStripMenuItem});
            this.scriptingObjectsToolStripMenuItem.Name = "scriptingObjectsToolStripMenuItem";
            this.scriptingObjectsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.scriptingObjectsToolStripMenuItem.Text = "Scripting Objects";
            // 
            // dynamicValueObjectToolStripMenuItem
            // 
            this.dynamicValueObjectToolStripMenuItem.Name = "dynamicValueObjectToolStripMenuItem";
            this.dynamicValueObjectToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.dynamicValueObjectToolStripMenuItem.Text = "DynamicValueObject";
            this.dynamicValueObjectToolStripMenuItem.Click += new System.EventHandler(this.dynamicValueObjectToolStripMenuItem_Click);
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
            // kCodeViewerToolStripMenuItem
            // 
            this.kCodeViewerToolStripMenuItem.Name = "kCodeViewerToolStripMenuItem";
            this.kCodeViewerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.kCodeViewerToolStripMenuItem.Text = "KCode Viewer";
            this.kCodeViewerToolStripMenuItem.Click += new System.EventHandler(this.kCodeViewerToolStripMenuItem_Click);
            // 
            // textPageToolStripMenuItem
            // 
            this.textPageToolStripMenuItem.Name = "textPageToolStripMenuItem";
            this.textPageToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.textPageToolStripMenuItem.Text = "TextPage";
            this.textPageToolStripMenuItem.Click += new System.EventHandler(this.textPageToolStripMenuItem_Click);
            // 
            // LoadPlayerShipButton
            // 
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(608, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 73);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type Lookup";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(249, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(187, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Full Type";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartPerformance);
            this.groupBox4.Controls.Add(this.lblBlocksAllocated);
            this.groupBox4.Controls.Add(this.lblBytesAllocated);
            this.groupBox4.Location = new System.Drawing.Point(18, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(854, 271);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Performance";
            // 
            // chartPerformance
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPerformance.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPerformance.Legends.Add(legend1);
            this.chartPerformance.Location = new System.Drawing.Point(9, 45);
            this.chartPerformance.Name = "chartPerformance";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Legend = "Legend1";
            series1.Name = "Bytes Allocated";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Legend = "Legend1";
            series2.Name = "Blocks Allocated";
            this.chartPerformance.Series.Add(series1);
            this.chartPerformance.Series.Add(series2);
            this.chartPerformance.Size = new System.Drawing.Size(839, 220);
            this.chartPerformance.TabIndex = 7;
            this.chartPerformance.Text = "Performance";
            // 
            // lblBlocksAllocated
            // 
            this.lblBlocksAllocated.AutoSize = true;
            this.lblBlocksAllocated.Location = new System.Drawing.Point(6, 29);
            this.lblBlocksAllocated.Name = "lblBlocksAllocated";
            this.lblBlocksAllocated.Size = new System.Drawing.Size(89, 13);
            this.lblBlocksAllocated.TabIndex = 1;
            this.lblBlocksAllocated.Text = "Blocks Allocated:";
            // 
            // lblBytesAllocated
            // 
            this.lblBytesAllocated.AutoSize = true;
            this.lblBytesAllocated.Location = new System.Drawing.Point(6, 16);
            this.lblBytesAllocated.Name = "lblBytesAllocated";
            this.lblBytesAllocated.Size = new System.Drawing.Size(83, 13);
            this.lblBytesAllocated.TabIndex = 0;
            this.lblBytesAllocated.Text = "Bytes Allocated:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(218, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Load Sector";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // X3TCToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerformance)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem kCodeViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textPageToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblBlocksAllocated;
        private System.Windows.Forms.Label lblBytesAllocated;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformance;
        private System.Windows.Forms.Button button4;
    }
}

