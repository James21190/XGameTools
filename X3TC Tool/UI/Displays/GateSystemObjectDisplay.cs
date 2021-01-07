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
            nudX.Maximum = GalaxyBase.width  - 1;
            nudY.Maximum = GalaxyBase.height - 1;
            Reload();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LoadSectorData((int)nudIndex.Value);
        }

        int CurrentGateData = 0;

        private void LoadSectorData(int index)
        {
            CurrentGateData = index;
            ReloadSectorData();
        }

        public void Reload()
        {
            var gateSystemObject = GameHook.gateSystemObject;
            txtGateSystemObjectAddress.Text = gateSystemObject.pThis.ToString("X");

            ReloadSectorData();

        }

        public void ReloadSectorData()
        {
            var sectorData = GameHook.gateSystemObject.sectorData[CurrentGateData];
            txtSectorDataAddress.Text = sectorData.pThis.ToString("X");
            txtSectorDataRace.Text = sectorData.owningRace.ToString();
        }

        private void nudX_ValueChanged(object sender, EventArgs e)
        {
            nudIndex.Value = GalaxyBase.GetIndexOfSector((short)nudX.Value, (short)nudY.Value);
        }
    }
}
