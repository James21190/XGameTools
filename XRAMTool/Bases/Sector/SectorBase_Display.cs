using System;
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
            XCommonLib.RAM.Bases.Sector.SectorBase sb = Program.GameHook.SectorBase;
            ntxtAddress.Text = sb.pThis.ToString("X");
        }

        private void SectorBase_Display_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SectorObject_Display display = new SectorObject_Display();
            display.LoadObject(Program.GameHook.SectorBase.Player);
            display.Show();
        }
    }
}
