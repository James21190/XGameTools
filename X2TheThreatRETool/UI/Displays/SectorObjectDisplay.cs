using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X2Tools;
using X2Tools.X2.SectorObjects;

namespace X2TheThreatRETool.UI.Displays
{
    public partial class SectorObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private SectorObject m_SectorObject;
        public SectorObjectDisplay(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }
        
        public void LoadSectorObject(SectorObject sectorObject)
        {
            m_SectorObject = sectorObject;

            btnGoNext.Enabled = m_SectorObject.pNext.obj.IsValid;
            btnGoPrevious.Enabled = m_SectorObject.pPrevious.obj.IsValid;
            btnGoParent.Enabled = m_SectorObject.pParent.obj.IsValid;

            Reload();
        }
        
        public void Reload()
        {
            txtAddress.Text = m_SectorObject.pThis.ToString("X");
            txtDefaultName.Text = m_SectorObject.pDefaultName.obj.value;
            nudSectorObjectID.Value = m_SectorObject.SectorObjectID;
            txtRace.Text = m_SectorObject.RaceID.ToString();
            ModelCollectionIDBox.Text = m_SectorObject.ModelCollectionID.ToString();

            v3dPosition.Vector = m_SectorObject.PositionCopy;
            const int distanceFactor = 222300;
            v3dPositionKm.X = ((decimal)m_SectorObject.PositionCopy.X) / distanceFactor;
            v3dPositionKm.Y = ((decimal)m_SectorObject.PositionCopy.Y) / distanceFactor;
            v3dPositionKm.Z = ((decimal)m_SectorObject.PositionCopy.Z) / distanceFactor;
            v3dRotation.Vector = m_SectorObject.Rotation;

            txtType.Text = string.Format("{0} - {1} // {2} - {3}", m_SectorObject.MainType.ToString(), m_SectorObject.GetSubTypeAsString(), (int)m_SectorObject.MainType, m_SectorObject.SubType);
        }

        private void btnGoNext_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_SectorObject.pNext.obj);
        }

        private void btnGoPrevious_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_SectorObject.pPrevious.obj);
        }

        private void btnGoParent_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_SectorObject.pParent.obj);
        }
    }
}
