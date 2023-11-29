using System;
using System.Windows.Forms;
using XRAMTool.Bases.B3D;
using XRAMTool.Bases.Sector;
using XRAMTool.Bases.Story;

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

        private void btnTypeData_Click(object sender, EventArgs e)
        {
            new TypeData_Display().Show();
        }

        private void btnStoryBase_Click(object sender, EventArgs e)
        {
            new StoryBase_Display().Show();
        }

        private void btnAssemblyScripts_Click(object sender, EventArgs e)
        {
            new AssemblyScripts_Display().Show();
        }

        private void btnSystemBase_Click(object sender, EventArgs e)
        {
            new Bases.SystemBase.SystemBase_Display().Show();
        }

        private void btnHashTableHelper_Click(object sender, EventArgs e)
        {
            new HashTable_Display().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new B3DBase_Display().Show();
        }
    }
}
