
namespace XCommonLib.UI.Bases.Sector
{
    partial class SectorMapView
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
            this.pnlMapCanvas = new CommonToolLib.UI.DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // pnlMapCanvas
            // 
            this.pnlMapCanvas.Location = new System.Drawing.Point(3, 3);
            this.pnlMapCanvas.Name = "pnlMapCanvas";
            this.pnlMapCanvas.Size = new System.Drawing.Size(574, 424);
            this.pnlMapCanvas.TabIndex = 0;
            // 
            // SectorMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMapCanvas);
            this.Name = "SectorMapView";
            this.Size = new System.Drawing.Size(580, 430);
            this.Load += new System.EventHandler(this.SectorMap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonToolLib.UI.DoubleBufferedPanel pnlMapCanvas;
    }
}
