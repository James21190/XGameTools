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
    public partial class SectorBase_Display : Form
    {
        public SectorBase_Display()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            var sb = Program.GameHook.SectorBase;
            ntxtAddress.Text = sb.pThis.ToString("X");
        }

        private void SectorBase_Display_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new SectorObject_Display();
            display.LoadObject(Program.GameHook.SectorBase.Player);
            display.Show();
        }
    }
}
