using System;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases;

namespace X3_Tool.UI.Displays
{
    public partial class GateSystemObjectDisplay : Form
    {
        public GateSystemObjectDisplay()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadSectorData((int)numericUpDown1.Value);
        }

        private void LoadSectorData(int index)
        {
            int pData = (int)GameHook.gateSystemObject.pThis + 0x10 + (GateSystemObject.SectorData.ByteSizeConst * index);
            textBox1.Text = pData.ToString("X");
        }
    }
}
