namespace XRAMTool.Bases.B3D
{
    partial class B3DBase_Display
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
            this.ntxtAddress = new CommonToolLib.UI.NamedTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCollectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ntxtAddress
            // 
            this.ntxtAddress.Location = new System.Drawing.Point(12, 12);
            this.ntxtAddress.MaximumSize = new System.Drawing.Size(0, 50);
            this.ntxtAddress.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtAddress.Name = "ntxtAddress";
            this.ntxtAddress.ReadOnly = true;
            this.ntxtAddress.Size = new System.Drawing.Size(100, 50);
            this.ntxtAddress.TabIndex = 1;
            this.ntxtAddress.Title = "Address";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmBody,
            this.clmCollectionID});
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(436, 246);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // clmID
            // 
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            // 
            // clmBody
            // 
            this.clmBody.HeaderText = "BodyID";
            this.clmBody.Name = "clmBody";
            // 
            // clmCollectionID
            // 
            this.clmCollectionID.HeaderText = "Collection";
            this.clmCollectionID.Name = "clmCollectionID";
            // 
            // B3DBase_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ntxtAddress);
            this.Name = "B3DBase_Display";
            this.Text = "B3DBase_Display";
            this.Load += new System.EventHandler(this.B3DBase_Display_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonToolLib.UI.NamedTextBox ntxtAddress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmBody;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCollectionID;
    }
}