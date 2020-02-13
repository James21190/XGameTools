using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Memory;
using X3TCTools;
using X3TCTools.SectorObjects;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDataDisplay : Form
    {
        private GameHook m_GameHook;
        private SectorObjectData m_SectorObjectData;
        public SectorObjectDataDisplay(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }

        public void LoadData(SectorObjectData sectorObjectData)
        {
            m_SectorObjectData = sectorObjectData;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_SectorObjectData.pThis.ToString("X");

            ScaleBox.Vector = m_SectorObjectData.ComponentPositionMult;

            // Relations
            NextButton.Enabled = m_SectorObjectData.pNext.IsValid;
            PreviousButton.Enabled = m_SectorObjectData.pPrevious.IsValid;
            FirstChildButton.Enabled = m_SectorObjectData.pFirstChild.IsValid;
            LastChildButton.Enabled = m_SectorObjectData.pLastChild.IsValid;
        }
    }
}
