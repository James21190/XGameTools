namespace XCommonLib.UI
{
    partial class SectorObjectView
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
            this.ntxtDefaultName = new CommonToolLib.UI.NamedTextBox();
            this.ntxtDefaultNameParsed = new CommonToolLib.UI.NamedTextBox();
            this.ntxtRace = new CommonToolLib.UI.NamedTextBox();
            this.vec3PositionStrafeDelta = new CommonToolLib.UI.Vector3Display();
            this.vec3Position = new CommonToolLib.UI.Vector3Display();
            this.nnudDesiredSpeed = new CommonToolLib.UI.NamedNumericUpDown();
            this.nnudSpeed = new CommonToolLib.UI.NamedNumericUpDown();
            this.vec3AutopilotRotationDeltaTarget = new CommonToolLib.UI.Vector3Display();
            this.vec3LocalEulerRotationDelta = new CommonToolLib.UI.Vector3Display();
            this.vec3EulerRotation = new CommonToolLib.UI.Vector3Display();
            this.numericIDObjectControl1 = new XCommonLib.UI.NumericIDObjectControl();
            this.bitFieldDisplay1 = new CommonToolLib.UI.BitFieldDisplay();
            this.SuspendLayout();
            // 
            // ntxtDefaultName
            // 
            this.ntxtDefaultName.Location = new System.Drawing.Point(483, 59);
            this.ntxtDefaultName.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtDefaultName.Name = "ntxtDefaultName";
            this.ntxtDefaultName.ReadOnly = true;
            this.ntxtDefaultName.Size = new System.Drawing.Size(180, 50);
            this.ntxtDefaultName.TabIndex = 12;
            this.ntxtDefaultName.Text = "namedTextBox1";
            this.ntxtDefaultName.Title = "Default Name";
            // 
            // ntxtDefaultNameParsed
            // 
            this.ntxtDefaultNameParsed.Location = new System.Drawing.Point(483, 3);
            this.ntxtDefaultNameParsed.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtDefaultNameParsed.Name = "ntxtDefaultNameParsed";
            this.ntxtDefaultNameParsed.ReadOnly = true;
            this.ntxtDefaultNameParsed.Size = new System.Drawing.Size(180, 50);
            this.ntxtDefaultNameParsed.TabIndex = 11;
            this.ntxtDefaultNameParsed.Text = "namedTextBox1";
            this.ntxtDefaultNameParsed.Title = "Default Name (Parsed)";
            // 
            // ntxtRace
            // 
            this.ntxtRace.Location = new System.Drawing.Point(377, 115);
            this.ntxtRace.MaximumSize = new System.Drawing.Size(0, 50);
            this.ntxtRace.MinimumSize = new System.Drawing.Size(100, 50);
            this.ntxtRace.Name = "ntxtRace";
            this.ntxtRace.ReadOnly = true;
            this.ntxtRace.Size = new System.Drawing.Size(100, 50);
            this.ntxtRace.TabIndex = 8;
            this.ntxtRace.Title = "Race";
            // 
            // vec3PositionStrafeDelta
            // 
            this.vec3PositionStrafeDelta.DecimalPlaces = 0;
            this.vec3PositionStrafeDelta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3PositionStrafeDelta.Location = new System.Drawing.Point(3, 221);
            this.vec3PositionStrafeDelta.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.vec3PositionStrafeDelta.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3PositionStrafeDelta.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.vec3PositionStrafeDelta.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3PositionStrafeDelta.Name = "vec3PositionStrafeDelta";
            this.vec3PositionStrafeDelta.ReadOnly = true;
            this.vec3PositionStrafeDelta.Size = new System.Drawing.Size(156, 103);
            this.vec3PositionStrafeDelta.TabIndex = 7;
            this.vec3PositionStrafeDelta.Text = "PositionStrafeDelta";
            this.vec3PositionStrafeDelta.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3PositionStrafeDelta.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3PositionStrafeDelta.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vec3Position
            // 
            this.vec3Position.DecimalPlaces = 0;
            this.vec3Position.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3Position.Location = new System.Drawing.Point(3, 112);
            this.vec3Position.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.vec3Position.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3Position.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.vec3Position.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3Position.Name = "vec3Position";
            this.vec3Position.ReadOnly = true;
            this.vec3Position.Size = new System.Drawing.Size(156, 103);
            this.vec3Position.TabIndex = 6;
            this.vec3Position.Text = "Position";
            this.vec3Position.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3Position.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3Position.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudDesiredSpeed
            // 
            this.nnudDesiredSpeed.Location = new System.Drawing.Point(377, 56);
            this.nnudDesiredSpeed.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudDesiredSpeed.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudDesiredSpeed.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudDesiredSpeed.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudDesiredSpeed.Name = "nnudDesiredSpeed";
            this.nnudDesiredSpeed.ReadOnly = true;
            this.nnudDesiredSpeed.Size = new System.Drawing.Size(100, 50);
            this.nnudDesiredSpeed.TabIndex = 5;
            this.nnudDesiredSpeed.Title = "Desired Speed";
            this.nnudDesiredSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nnudSpeed
            // 
            this.nnudSpeed.Location = new System.Drawing.Point(377, 3);
            this.nnudSpeed.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nnudSpeed.MaximumSize = new System.Drawing.Size(0, 50);
            this.nnudSpeed.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nnudSpeed.MinimumSize = new System.Drawing.Size(100, 50);
            this.nnudSpeed.Name = "nnudSpeed";
            this.nnudSpeed.ReadOnly = true;
            this.nnudSpeed.Size = new System.Drawing.Size(100, 50);
            this.nnudSpeed.TabIndex = 4;
            this.nnudSpeed.Title = "Speed";
            this.nnudSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vec3AutopilotRotationDeltaTarget
            // 
            this.vec3AutopilotRotationDeltaTarget.DecimalPlaces = 0;
            this.vec3AutopilotRotationDeltaTarget.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3AutopilotRotationDeltaTarget.Location = new System.Drawing.Point(215, 221);
            this.vec3AutopilotRotationDeltaTarget.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.vec3AutopilotRotationDeltaTarget.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3AutopilotRotationDeltaTarget.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.vec3AutopilotRotationDeltaTarget.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3AutopilotRotationDeltaTarget.Name = "vec3AutopilotRotationDeltaTarget";
            this.vec3AutopilotRotationDeltaTarget.ReadOnly = true;
            this.vec3AutopilotRotationDeltaTarget.Size = new System.Drawing.Size(156, 103);
            this.vec3AutopilotRotationDeltaTarget.TabIndex = 3;
            this.vec3AutopilotRotationDeltaTarget.Text = "AutoRotationDeltaTarget";
            this.vec3AutopilotRotationDeltaTarget.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3AutopilotRotationDeltaTarget.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3AutopilotRotationDeltaTarget.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vec3LocalEulerRotationDelta
            // 
            this.vec3LocalEulerRotationDelta.DecimalPlaces = 0;
            this.vec3LocalEulerRotationDelta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3LocalEulerRotationDelta.Location = new System.Drawing.Point(215, 112);
            this.vec3LocalEulerRotationDelta.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.vec3LocalEulerRotationDelta.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3LocalEulerRotationDelta.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.vec3LocalEulerRotationDelta.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3LocalEulerRotationDelta.Name = "vec3LocalEulerRotationDelta";
            this.vec3LocalEulerRotationDelta.ReadOnly = true;
            this.vec3LocalEulerRotationDelta.Size = new System.Drawing.Size(156, 103);
            this.vec3LocalEulerRotationDelta.TabIndex = 2;
            this.vec3LocalEulerRotationDelta.Text = "LocalEulerRotationDelta";
            this.vec3LocalEulerRotationDelta.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3LocalEulerRotationDelta.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3LocalEulerRotationDelta.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vec3EulerRotation
            // 
            this.vec3EulerRotation.DecimalPlaces = 0;
            this.vec3EulerRotation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vec3EulerRotation.Location = new System.Drawing.Point(215, 3);
            this.vec3EulerRotation.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.vec3EulerRotation.MaximumSize = new System.Drawing.Size(156, 103);
            this.vec3EulerRotation.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.vec3EulerRotation.MinimumSize = new System.Drawing.Size(100, 103);
            this.vec3EulerRotation.Name = "vec3EulerRotation";
            this.vec3EulerRotation.ReadOnly = true;
            this.vec3EulerRotation.Size = new System.Drawing.Size(156, 103);
            this.vec3EulerRotation.TabIndex = 1;
            this.vec3EulerRotation.Text = "EulerRotation";
            this.vec3EulerRotation.X = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3EulerRotation.Y = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vec3EulerRotation.Z = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numericIDObjectControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.numericIDObjectControl1.EnableLoad = false;
            this.numericIDObjectControl1.ID = 0;
            this.numericIDObjectControl1.Location = new System.Drawing.Point(3, 3);
            this.numericIDObjectControl1.MaximumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.MinimumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.Name = "numericIDObjectControl1";
            this.numericIDObjectControl1.Size = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.TabIndex = 0;
            // 
            // bitFieldDisplay1
            // 
            this.bitFieldDisplay1.Bits = 32;
            this.bitFieldDisplay1.Enabled = false;
            this.bitFieldDisplay1.Lables = new string[] {
        "",
        "IsPlayer",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "IsDestroyed"};
            this.bitFieldDisplay1.Location = new System.Drawing.Point(377, 171);
            this.bitFieldDisplay1.Name = "bitFieldDisplay1";
            this.bitFieldDisplay1.Size = new System.Drawing.Size(150, 146);
            this.bitFieldDisplay1.TabIndex = 13;
            this.bitFieldDisplay1.Value = null;
            this.bitFieldDisplay1.Visible = false;
            // 
            // SectorObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bitFieldDisplay1);
            this.Controls.Add(this.ntxtDefaultName);
            this.Controls.Add(this.ntxtDefaultNameParsed);
            this.Controls.Add(this.ntxtRace);
            this.Controls.Add(this.vec3PositionStrafeDelta);
            this.Controls.Add(this.vec3Position);
            this.Controls.Add(this.nnudDesiredSpeed);
            this.Controls.Add(this.nnudSpeed);
            this.Controls.Add(this.vec3AutopilotRotationDeltaTarget);
            this.Controls.Add(this.vec3LocalEulerRotationDelta);
            this.Controls.Add(this.vec3EulerRotation);
            this.Controls.Add(this.numericIDObjectControl1);
            this.Name = "SectorObjectView";
            this.Size = new System.Drawing.Size(666, 410);
            this.ResumeLayout(false);

        }

        #endregion

        private NumericIDObjectControl numericIDObjectControl1;
        private CommonToolLib.UI.Vector3Display vec3EulerRotation;
        private CommonToolLib.UI.Vector3Display vec3LocalEulerRotationDelta;
        private CommonToolLib.UI.Vector3Display vec3AutopilotRotationDeltaTarget;
        private CommonToolLib.UI.NamedNumericUpDown nnudSpeed;
        private CommonToolLib.UI.NamedNumericUpDown nnudDesiredSpeed;
        private CommonToolLib.UI.Vector3Display vec3Position;
        private CommonToolLib.UI.Vector3Display vec3PositionStrafeDelta;
        private CommonToolLib.UI.NamedTextBox ntxtRace;
        private CommonToolLib.UI.NamedTextBox ntxtDefaultNameParsed;
        private CommonToolLib.UI.NamedTextBox ntxtDefaultName;
        private CommonToolLib.UI.BitFieldDisplay bitFieldDisplay1;
    }
}
