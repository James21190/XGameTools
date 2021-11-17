using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRAMTool.Bases.Sector
{
    public partial class SectorMap_Display : Form
    {
        public SectorMap_Display()
        {
            InitializeComponent();
            sectorMap1.ReferenceGameHook = Program.GameHook;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sectorMap1.ReloadFromGameHook();
            sectorMap1.Draw();
        }
    }
}
