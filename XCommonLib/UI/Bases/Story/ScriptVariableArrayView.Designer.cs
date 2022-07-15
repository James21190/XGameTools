namespace XCommonLib.UI.Bases.Story
{
    partial class ScriptVariableArrayView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMemoryTable = new System.Windows.Forms.DataGridView();
            this.clmIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValueDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValueHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemoryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMemoryTable
            // 
            this.dgvMemoryTable.AllowUserToAddRows = false;
            this.dgvMemoryTable.AllowUserToDeleteRows = false;
            this.dgvMemoryTable.AllowUserToOrderColumns = true;
            this.dgvMemoryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMemoryTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMemoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIndex,
            this.clmType,
            this.clmValueDec,
            this.clmValueHex,
            this.colView});
            this.dgvMemoryTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMemoryTable.Location = new System.Drawing.Point(3, 3);
            this.dgvMemoryTable.Name = "dgvMemoryTable";
            this.dgvMemoryTable.ReadOnly = true;
            this.dgvMemoryTable.RowHeadersVisible = false;
            this.dgvMemoryTable.Size = new System.Drawing.Size(511, 326);
            this.dgvMemoryTable.TabIndex = 2;
            this.dgvMemoryTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemoryTable_CellContentClick);
            // 
            // clmIndex
            // 
            this.clmIndex.HeaderText = "Variable";
            this.clmIndex.Name = "clmIndex";
            this.clmIndex.ReadOnly = true;
            this.clmIndex.Width = 70;
            // 
            // clmType
            // 
            this.clmType.HeaderText = "Type";
            this.clmType.Name = "clmType";
            this.clmType.ReadOnly = true;
            this.clmType.Width = 56;
            // 
            // clmValueDec
            // 
            this.clmValueDec.HeaderText = "Value (Dec)";
            this.clmValueDec.Name = "clmValueDec";
            this.clmValueDec.ReadOnly = true;
            this.clmValueDec.Width = 88;
            // 
            // clmValueHex
            // 
            this.clmValueHex.HeaderText = "Value (Hex)";
            this.clmValueHex.Name = "clmValueHex";
            this.clmValueHex.ReadOnly = true;
            this.clmValueHex.Width = 87;
            // 
            // colView
            // 
            this.colView.HeaderText = "";
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Text = "View";
            this.colView.Width = 5;
            // 
            // ScriptVariableArrayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMemoryTable);
            this.Name = "ScriptVariableArrayView";
            this.Size = new System.Drawing.Size(517, 332);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemoryTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMemoryTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValueDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValueHex;
        private System.Windows.Forms.DataGridViewButtonColumn colView;
    }
}
