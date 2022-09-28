namespace XCommonLib.UI.Bases.Sector.TypeData
{
    partial class TypeDataShipSubView
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
            this.nnudMaxSpeed = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudExteriorModelID = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudOriginRace = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudTurretCount = new CommonToolLib.UI.NamedNumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTurretSelect = new System.Windows.Forms.ComboBox();
            this.nnudTurretWeaponCount = new CommonToolLib.UI.NamedNumericUpDown();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nnudMaxSpeed
            // 
            this.nnudMaxSpeed.Location = new System.Drawing.Point(3, 3);
            this.nnudMaxSpeed.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudMaxSpeed.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudMaxSpeed.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudMaxSpeed.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudMaxSpeed.Name = "nnudMaxSpeed";
            this.nnudMaxSpeed.ReadOnly = true;
            this.nnudMaxSpeed.Size = new System.Drawing.Size(100, 50);
            this.nnudMaxSpeed.TabIndex = 0;
            this.nnudMaxSpeed.Title = "Max Speed";
            this.nnudMaxSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudExteriorModelID
            // 
            this.nnudExteriorModelID.Location = new System.Drawing.Point(3, 59);
            this.nnudExteriorModelID.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudExteriorModelID.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudExteriorModelID.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudExteriorModelID.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudExteriorModelID.Name = "nnudExteriorModelID";
            this.nnudExteriorModelID.ReadOnly = true;
            this.nnudExteriorModelID.Size = new System.Drawing.Size(100, 50);
            this.nnudExteriorModelID.TabIndex = 2;
            this.nnudExteriorModelID.Title = "Exterior Model ID";
            this.nnudExteriorModelID.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudOriginRace
            // 
            this.nnudOriginRace.Location = new System.Drawing.Point(3, 115);
            this.nnudOriginRace.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudOriginRace.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudOriginRace.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudOriginRace.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudOriginRace.Name = "nnudOriginRace";
            this.nnudOriginRace.ReadOnly = true;
            this.nnudOriginRace.Size = new System.Drawing.Size(100, 50);
            this.nnudOriginRace.TabIndex = 3;
            this.nnudOriginRace.Title = "Origin Race";
            this.nnudOriginRace.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudTurretCount
            // 
            this.nnudTurretCount.Location = new System.Drawing.Point(109, 3);
            this.nnudTurretCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudTurretCount.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudTurretCount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudTurretCount.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudTurretCount.Name = "nnudTurretCount";
            this.nnudTurretCount.ReadOnly = true;
            this.nnudTurretCount.Size = new System.Drawing.Size(100, 50);
            this.nnudTurretCount.TabIndex = 4;
            this.nnudTurretCount.Title = "Turret Count";
            this.nnudTurretCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nnudTurretWeaponCount);
            this.groupBox1.Controls.Add(this.cmbTurretSelect);
            this.groupBox1.Location = new System.Drawing.Point(215, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 185);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turrets";
            // 
            // cmbTurretSelect
            // 
            this.cmbTurretSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurretSelect.FormattingEnabled = true;
            this.cmbTurretSelect.Location = new System.Drawing.Point(6, 19);
            this.cmbTurretSelect.Name = "cmbTurretSelect";
            this.cmbTurretSelect.Size = new System.Drawing.Size(121, 21);
            this.cmbTurretSelect.TabIndex = 0;
            this.cmbTurretSelect.SelectedIndexChanged += new System.EventHandler(this.cmbTurretSelect_SelectedIndexChanged);
            // 
            // nnudTurretWeaponCount
            // 
            this.nnudTurretWeaponCount.Location = new System.Drawing.Point(6, 46);
            this.nnudTurretWeaponCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nnudTurretWeaponCount.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudTurretWeaponCount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nnudTurretWeaponCount.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudTurretWeaponCount.Name = "nnudTurretWeaponCount";
            this.nnudTurretWeaponCount.ReadOnly = true;
            this.nnudTurretWeaponCount.Size = new System.Drawing.Size(100, 50);
            this.nnudTurretWeaponCount.TabIndex = 6;
            this.nnudTurretWeaponCount.Title = "Weapon Count";
            this.nnudTurretWeaponCount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // TypeDataShipSubView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nnudTurretCount);
            this.Controls.Add(this.nnudOriginRace);
            this.Controls.Add(this.nnudExteriorModelID);
            this.Controls.Add(this.nnudMaxSpeed);
            this.Name = "TypeDataShipSubView";
            this.Size = new System.Drawing.Size(475, 422);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonToolLib.UI.NamedNumericUpDown nnudMaxSpeed;
        private CommonToolLib.UI.NamedNumericUpDown nnudExteriorModelID;
        private CommonToolLib.UI.NamedNumericUpDown nnudOriginRace;
        private CommonToolLib.UI.NamedNumericUpDown nnudTurretCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonToolLib.UI.NamedNumericUpDown nnudTurretWeaponCount;
        private System.Windows.Forms.ComboBox cmbTurretSelect;
    }
}
