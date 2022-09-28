namespace XCommonLib.UI.Bases.Sector.TypeData
{
    partial class TypeDataView
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
            this.ntxtTypeName = new CommonToolLib.UI.NamedTextBox();
            this.nnudWareClass = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudPriceRange = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudRelVal = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudWareVolume = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudDefaultName = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudClass = new CommonToolLib.UI.NamedNumericUpDown();
            this.vec3Rotation = new CommonToolLib.UI.Vector3Display();
            this.nnudBodyID = new CommonToolLib.UI.NamedNumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // ntxtTypeName
            // 
            this.ntxtTypeName.Location = new System.Drawing.Point(165, 224);
            this.ntxtTypeName.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtTypeName.Name = "ntxtTypeName";
            this.ntxtTypeName.Size = new System.Drawing.Size(156, 50);
            this.ntxtTypeName.TabIndex = 8;
            this.ntxtTypeName.Title = "Type Name";
            // 
            // nnudWareClass
            // 
            this.nnudWareClass.Location = new System.Drawing.Point(3, 224);
            this.nnudWareClass.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudWareClass.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudWareClass.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudWareClass.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudWareClass.Name = "nnudWareClass";
            this.nnudWareClass.Size = new System.Drawing.Size(100, 50);
            this.nnudWareClass.TabIndex = 7;
            this.nnudWareClass.Title = "Ware Class";
            this.nnudWareClass.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudPriceRange
            // 
            this.nnudPriceRange.Location = new System.Drawing.Point(165, 168);
            this.nnudPriceRange.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudPriceRange.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudPriceRange.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudPriceRange.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudPriceRange.Name = "nnudPriceRange";
            this.nnudPriceRange.Size = new System.Drawing.Size(100, 50);
            this.nnudPriceRange.TabIndex = 6;
            this.nnudPriceRange.Title = "Price Range";
            this.nnudPriceRange.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudRelVal
            // 
            this.nnudRelVal.Location = new System.Drawing.Point(165, 112);
            this.nnudRelVal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudRelVal.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudRelVal.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudRelVal.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudRelVal.Name = "nnudRelVal";
            this.nnudRelVal.Size = new System.Drawing.Size(100, 50);
            this.nnudRelVal.TabIndex = 5;
            this.nnudRelVal.Title = "RelVal";
            this.nnudRelVal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudWareVolume
            // 
            this.nnudWareVolume.Location = new System.Drawing.Point(3, 168);
            this.nnudWareVolume.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudWareVolume.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudWareVolume.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudWareVolume.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudWareVolume.Name = "nnudWareVolume";
            this.nnudWareVolume.Size = new System.Drawing.Size(100, 50);
            this.nnudWareVolume.TabIndex = 4;
            this.nnudWareVolume.Title = "Ware Volume";
            this.nnudWareVolume.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudDefaultName
            // 
            this.nnudDefaultName.Location = new System.Drawing.Point(3, 112);
            this.nnudDefaultName.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudDefaultName.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudDefaultName.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudDefaultName.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudDefaultName.Name = "nnudDefaultName";
            this.nnudDefaultName.Size = new System.Drawing.Size(100, 50);
            this.nnudDefaultName.TabIndex = 3;
            this.nnudDefaultName.Title = "Default Name ID";
            this.nnudDefaultName.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudClass
            // 
            this.nnudClass.Location = new System.Drawing.Point(3, 56);
            this.nnudClass.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudClass.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudClass.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudClass.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudClass.Name = "nnudClass";
            this.nnudClass.Size = new System.Drawing.Size(100, 50);
            this.nnudClass.TabIndex = 2;
            this.nnudClass.Title = "Object Class";
            this.nnudClass.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vec3Rotation
            // 
            this.vec3Rotation.DecimalPlaces = 0;
            this.vec3Rotation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3Rotation.Location = new System.Drawing.Point(165, 3);
            this.vec3Rotation.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vec3Rotation.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3Rotation.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.vec3Rotation.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3Rotation.Name = "vec3Rotation";
            this.vec3Rotation.Size = new System.Drawing.Size(156, 103);
            this.vec3Rotation.TabIndex = 1;
            this.vec3Rotation.Text = "Rotation";
            this.vec3Rotation.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3Rotation.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3Rotation.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudBodyID
            // 
            this.nnudBodyID.Location = new System.Drawing.Point(3, 3);
            this.nnudBodyID.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudBodyID.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudBodyID.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudBodyID.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudBodyID.Name = "nnudBodyID";
            this.nnudBodyID.Size = new System.Drawing.Size(100, 50);
            this.nnudBodyID.TabIndex = 0;
            this.nnudBodyID.Title = "Body ID";
            this.nnudBodyID.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(327, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 275);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Data";
            // 
            // TypeDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ntxtTypeName);
            this.Controls.Add(this.nnudWareClass);
            this.Controls.Add(this.nnudPriceRange);
            this.Controls.Add(this.nnudRelVal);
            this.Controls.Add(this.nnudWareVolume);
            this.Controls.Add(this.nnudDefaultName);
            this.Controls.Add(this.nnudClass);
            this.Controls.Add(this.vec3Rotation);
            this.Controls.Add(this.nnudBodyID);
            this.Name = "TypeDataView";
            this.Size = new System.Drawing.Size(739, 281);
            this.Load += new System.EventHandler(this.TypeDataView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonToolLib.UI.NamedNumericUpDown nnudBodyID;
        private CommonToolLib.UI.Vector3Display vec3Rotation;
        private CommonToolLib.UI.NamedNumericUpDown nnudClass;
        private CommonToolLib.UI.NamedNumericUpDown nnudDefaultName;
        private CommonToolLib.UI.NamedNumericUpDown nnudWareVolume;
        private CommonToolLib.UI.NamedNumericUpDown nnudRelVal;
        private CommonToolLib.UI.NamedNumericUpDown nnudPriceRange;
        private CommonToolLib.UI.NamedNumericUpDown nnudWareClass;
        private CommonToolLib.UI.NamedTextBox ntxtTypeName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
