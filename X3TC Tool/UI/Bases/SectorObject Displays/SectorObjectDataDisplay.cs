using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Bases.CameraBase_Displays;
using X3TCTools;
using X3TCTools.Sector_Objects;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDataDisplay : Form
    {
        private RenderObject m_SectorObjectData;
        public SectorObjectDataDisplay()
        {
            InitializeComponent();
        }

        public void LoadData(RenderObject sectorObjectData)
        {
            m_SectorObjectData = sectorObjectData;
            Reload();
        }

        public void LoadData(IntPtr pSectorObjectData)
        {
            m_SectorObjectData = new RenderObject();
            m_SectorObjectData.SetLocation(GameHook.hProcess, pSectorObjectData);
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_SectorObjectData.pThis.ToString("X");

            ScaleBox.Vector = m_SectorObjectData.ModelScale;

            nudSize.Value = m_SectorObjectData.Size;
            nudTotalSize.Value = m_SectorObjectData.TotalSize;

            nudModelID.Value = m_SectorObjectData.ModelID;

            // Relations
            NextButton.Enabled = m_SectorObjectData.pNext.obj.IsValid;
            PreviousButton.Enabled = m_SectorObjectData.pPrevious.obj.IsValid;
            FirstChildButton.Enabled = m_SectorObjectData.pFirstChild.obj.IsValid;
            LastChildButton.Enabled = m_SectorObjectData.pLastChild.obj.IsValid;
            btnParent.Enabled = m_SectorObjectData.pParent.obj.IsValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pPrevious.obj);
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pFirstChild.obj);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pLastChild.obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_SectorObjectData.ModelScale = ScaleBox.Vector;
            m_SectorObjectData.ModelID = (int)nudModelID.Value;
            m_SectorObjectData.Save();
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pParent.obj);
        }

        private void btnViewModelData_Click(object sender, EventArgs e)
        {
            var display = new BodyDataDisplay();
            display.LoadBodyData(m_SectorObjectData.ModelID);
            display.Show();
        }
    }
}
