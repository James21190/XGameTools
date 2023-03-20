namespace XRAMTool.Bases.B3D
{
    partial class RenderObject_Display
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
            this.numericIDObjectControl1 = new XCommonLib.UI.NumericIDObjectControl();
            this.SuspendLayout();
            // 
            // numericIDObjectControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.numericIDObjectControl1.ID = 0;
            this.numericIDObjectControl1.Location = new System.Drawing.Point(12, 12);
            this.numericIDObjectControl1.MaximumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.MinimumSize = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.Name = "numericIDObjectControl1";
            this.numericIDObjectControl1.Size = new System.Drawing.Size(206, 112);
            this.numericIDObjectControl1.TabIndex = 0;
            // 
            // RenderObject_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericIDObjectControl1);
            this.Name = "RenderObject_Display";
            this.Text = "RenderObject_Display";
            this.ResumeLayout(false);

        }

        #endregion

        private XCommonLib.UI.NumericIDObjectControl numericIDObjectControl1;
    }
}