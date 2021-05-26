using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM.Bases.Sector;

namespace XRAMTool.Bases.Sector
{
    public partial class SectorObject_Display : Form
    {
        public SectorObject_Display()
        {
            InitializeComponent();
        }

        public void LoadObject(SectorObject obj)
        {
            sectorObjectView1.LoadObject(obj);
        }
    }
}
