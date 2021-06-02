using System;
using System.Windows.Forms;
using X3Tools.RAM;

namespace X3TC_RAM_Tool.UI.Displays
{
    public partial class SectorObjectManagerDisplay : Form
    {
        private GameHook GameHook;
        public SectorObjectManagerDisplay(GameHook gameHook)
        {
            InitializeComponent();
            GameHook = gameHook;
            Reload();
        }

        public void Reload()
        {
            X3Tools.RAM.Bases.Sector.SectorBase sectorObjectManager = GameHook.sectorObjectManager;
            AddressBox.Text = sectorObjectManager.pThis.ToString("X");

            LoadPlayerButton.Enabled = sectorObjectManager.pPlayerShip.IsValid;
        }

        private void LoadPlayerButton_Click(object sender, EventArgs e)
        {
            X3Tools.RAM.Bases.Sector.SectorBase sectorObjectManager = GameHook.sectorObjectManager;
            SectorObjectDisplay display = new SectorObjectDisplay();
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
            display.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X3Tools.RAM.Bases.Sector.SectorBase sectorObjectManager = GameHook.sectorObjectManager;
            HashTableDisplay display = new HashTableDisplay("SectorObjectManager - SectorObjects");
            display.LoadTable(sectorObjectManager.pObjectHashTable.address);
            display.Show();
        }
    }
}
