using System;
using System.Windows.Forms;

using XRAMTool.Bases.Sector;

namespace XRAMTool
{
    public partial class XRAMTool : Form
    {
        public XRAMTool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSectorBase.Enabled = Program.GameHook.SectorBase != null;
        }

        private void btnSectorBase_Click(object sender, EventArgs e)
        {
            new SectorBase_Display().Show();
        }
    }
}
