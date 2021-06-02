using System;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Galaxy;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class GalaxyBaseDisplay : Form
    {
        public GalaxyBaseDisplay()
        {
            InitializeComponent();
            nudX.Maximum = GalaxyBase.width - 1;
            nudY.Maximum = GalaxyBase.height - 1;
            Reload();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadSectorData((int)nudIndex.Value);
        }

        private int CurrentGateData = 0;

        private void LoadSectorData(int index)
        {
            CurrentGateData = index;
            ReloadSectorData();
        }

        public void Reload()
        {
            GalaxyBase gateSystemObject = GameHook.galaxyBase;
            txtGateSystemObjectAddress.Text = gateSystemObject.pThis.ToString("X");

            ReloadSectorData();

        }

        public void ReloadSectorData()
        {
            GalaxyBase.SectorData sectorData = GameHook.galaxyBase.sectorData[CurrentGateData];
            txtSectorDataAddress.Text = sectorData.pThis.ToString("X");
            txtSectorDataRace.Text = sectorData.owningRace.ToString();
        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            nudIndex.Value = GalaxyBase.GetIndexOfSector((short)nudX.Value, (short)nudY.Value);
        }
    }
}
