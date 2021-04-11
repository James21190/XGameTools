namespace X3TC_RAM_Tool.UI.Displays
{
    partial class B3DBaseDisplay
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRenderObjectFirst = new System.Windows.Forms.Button();
            this.btnRenderObjectLast = new System.Windows.Forms.Button();
            this.btnRenderObjectTable = new System.Windows.Forms.Button();
            this.nudRenderObjectID = new System.Windows.Forms.NumericUpDown();
            this.btnRenderObjectLoadID = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBodyDataLoadID = new System.Windows.Forms.Button();
            this.nudBodyDataID = new System.Windows.Forms.NumericUpDown();
            this.btnBodyDataTable = new System.Windows.Forms.Button();
            this.btnBodyDataLast = new System.Windows.Forms.Button();
            this.btnBodyDataFirst = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRenderObjectID)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyDataID)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddressBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 52);
            this.groupBox2.TabIndex = 5;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "View ModelCollectionHashTable";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "View SceneHashTable";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRenderObjectLoadID);
            this.groupBox3.Controls.Add(this.nudRenderObjectID);
            this.groupBox3.Controls.Add(this.btnRenderObjectTable);
            this.groupBox3.Controls.Add(this.btnRenderObjectLast);
            this.groupBox3.Controls.Add(this.btnRenderObjectFirst);
            this.groupBox3.Location = new System.Drawing.Point(12, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 82);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RenderObject";
            // 
            // btnRenderObjectFirst
            // 
            this.btnRenderObjectFirst.Location = new System.Drawing.Point(6, 19);
            this.btnRenderObjectFirst.Name = "btnRenderObjectFirst";
            this.btnRenderObjectFirst.Size = new System.Drawing.Size(75, 23);
            this.btnRenderObjectFirst.TabIndex = 0;
            this.btnRenderObjectFirst.Text = "First";
            this.btnRenderObjectFirst.UseVisualStyleBackColor = true;
            this.btnRenderObjectFirst.Click += new System.EventHandler(this.btnRenderObjectFirst_Click);
            // 
            // btnRenderObjectLast
            // 
            this.btnRenderObjectLast.Location = new System.Drawing.Point(87, 19);
            this.btnRenderObjectLast.Name = "btnRenderObjectLast";
            this.btnRenderObjectLast.Size = new System.Drawing.Size(75, 23);
            this.btnRenderObjectLast.TabIndex = 1;
            this.btnRenderObjectLast.Text = "Last";
            this.btnRenderObjectLast.UseVisualStyleBackColor = true;
            this.btnRenderObjectLast.Click += new System.EventHandler(this.btnRenderObjectLast_Click);
            // 
            // btnRenderObjectTable
            // 
            this.btnRenderObjectTable.Location = new System.Drawing.Point(168, 19);
            this.btnRenderObjectTable.Name = "btnRenderObjectTable";
            this.btnRenderObjectTable.Size = new System.Drawing.Size(75, 23);
            this.btnRenderObjectTable.TabIndex = 2;
            this.btnRenderObjectTable.Text = "Table";
            this.btnRenderObjectTable.UseVisualStyleBackColor = true;
            this.btnRenderObjectTable.Click += new System.EventHandler(this.btnRenderObjectTable_Click);
            // 
            // nudRenderObjectID
            // 
            this.nudRenderObjectID.Enabled = false;
            this.nudRenderObjectID.Location = new System.Drawing.Point(6, 51);
            this.nudRenderObjectID.Name = "nudRenderObjectID";
            this.nudRenderObjectID.Size = new System.Drawing.Size(156, 20);
            this.nudRenderObjectID.TabIndex = 11;
            // 
            // btnRenderObjectLoadID
            // 
            this.btnRenderObjectLoadID.Enabled = false;
            this.btnRenderObjectLoadID.Location = new System.Drawing.Point(168, 48);
            this.btnRenderObjectLoadID.Name = "btnRenderObjectLoadID";
            this.btnRenderObjectLoadID.Size = new System.Drawing.Size(75, 23);
            this.btnRenderObjectLoadID.TabIndex = 12;
            this.btnRenderObjectLoadID.Text = "Load";
            this.btnRenderObjectLoadID.UseVisualStyleBackColor = true;
            this.btnRenderObjectLoadID.Click += new System.EventHandler(this.btnRenderObjectLoadID_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBodyDataLoadID);
            this.groupBox1.Controls.Add(this.nudBodyDataID);
            this.groupBox1.Controls.Add(this.btnBodyDataTable);
            this.groupBox1.Controls.Add(this.btnBodyDataLast);
            this.groupBox1.Controls.Add(this.btnBodyDataFirst);
            this.groupBox1.Location = new System.Drawing.Point(12, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 82);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BodyData";
            // 
            // btnBodyDataLoadID
            // 
            this.btnBodyDataLoadID.Enabled = false;
            this.btnBodyDataLoadID.Location = new System.Drawing.Point(168, 48);
            this.btnBodyDataLoadID.Name = "btnBodyDataLoadID";
            this.btnBodyDataLoadID.Size = new System.Drawing.Size(75, 23);
            this.btnBodyDataLoadID.TabIndex = 12;
            this.btnBodyDataLoadID.Text = "Load";
            this.btnBodyDataLoadID.UseVisualStyleBackColor = true;
            this.btnBodyDataLoadID.Click += new System.EventHandler(this.btnBodyDataLoadID_Click);
            // 
            // nudBodyDataID
            // 
            this.nudBodyDataID.Enabled = false;
            this.nudBodyDataID.Location = new System.Drawing.Point(6, 51);
            this.nudBodyDataID.Name = "nudBodyDataID";
            this.nudBodyDataID.Size = new System.Drawing.Size(156, 20);
            this.nudBodyDataID.TabIndex = 11;
            // 
            // btnBodyDataTable
            // 
            this.btnBodyDataTable.Location = new System.Drawing.Point(168, 19);
            this.btnBodyDataTable.Name = "btnBodyDataTable";
            this.btnBodyDataTable.Size = new System.Drawing.Size(75, 23);
            this.btnBodyDataTable.TabIndex = 2;
            this.btnBodyDataTable.Text = "Table";
            this.btnBodyDataTable.UseVisualStyleBackColor = true;
            this.btnBodyDataTable.Click += new System.EventHandler(this.btnBodyDataTable_Click);
            // 
            // btnBodyDataLast
            // 
            this.btnBodyDataLast.Location = new System.Drawing.Point(87, 19);
            this.btnBodyDataLast.Name = "btnBodyDataLast";
            this.btnBodyDataLast.Size = new System.Drawing.Size(75, 23);
            this.btnBodyDataLast.TabIndex = 1;
            this.btnBodyDataLast.Text = "Last";
            this.btnBodyDataLast.UseVisualStyleBackColor = true;
            this.btnBodyDataLast.Click += new System.EventHandler(this.btnBodyDataLast_Click);
            // 
            // btnBodyDataFirst
            // 
            this.btnBodyDataFirst.Location = new System.Drawing.Point(6, 19);
            this.btnBodyDataFirst.Name = "btnBodyDataFirst";
            this.btnBodyDataFirst.Size = new System.Drawing.Size(75, 23);
            this.btnBodyDataFirst.TabIndex = 0;
            this.btnBodyDataFirst.Text = "First";
            this.btnBodyDataFirst.UseVisualStyleBackColor = true;
            this.btnBodyDataFirst.Click += new System.EventHandler(this.btnBodyDataFirst_Click);
            // 
            // B3DBaseDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Name = "B3DBaseDisplay";
            this.Text = "B3DBase";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRenderObjectID)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudBodyDataID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRenderObjectLast;
        private System.Windows.Forms.Button btnRenderObjectFirst;
        private System.Windows.Forms.Button btnRenderObjectLoadID;
        private System.Windows.Forms.NumericUpDown nudRenderObjectID;
        private System.Windows.Forms.Button btnRenderObjectTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBodyDataLoadID;
        private System.Windows.Forms.NumericUpDown nudBodyDataID;
        private System.Windows.Forms.Button btnBodyDataTable;
        private System.Windows.Forms.Button btnBodyDataLast;
        private System.Windows.Forms.Button btnBodyDataFirst;
    }
}