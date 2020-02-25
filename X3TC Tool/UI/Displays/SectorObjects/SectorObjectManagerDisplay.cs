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
    public partial class SectorObjectManagerDisplay : Form
    {
        private GameHook m_GameHook;
        public SectorObjectManagerDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            Reload();
        }

        public void Reload()
        {
            var sectorObjectManager = m_GameHook.sectorObjectManager;
            AddressBox.Text = sectorObjectManager.pThis.ToString("X");

            LoadPlayerButton.Enabled = sectorObjectManager.pPlayerShip.IsValid;
        }

        private void LoadPlayerButton_Click(object sender, EventArgs e)
        {
            var sectorObjectManager = m_GameHook.sectorObjectManager;
            var display = new SectorObjectDisplay(m_GameHook);
            display.LoadObject(sectorObjectManager.pPlayerShip.obj);
            display.Show();
        }
    }
}
