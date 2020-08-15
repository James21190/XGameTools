using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Bases;

namespace X3TC_Tool.UI.Displays
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
            int pData = (int)GameHook.gateSystemObject.pThis + 0x10 + (GateSystemObject.SectorData.ByteSize * index);
            textBox1.Text = pData.ToString("X");
        }
    }
}
