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
using X3TCTools.SectorObjects;

using Common.Memory;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private SectorObject m_SectorObject;
        public SectorObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                ChildTypeSelectionBox.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }

        public void LoadObject(int ID)
        {
            var sectorObjectManager = m_GameHook.sectorObjectManager;
            var hashtable = sectorObjectManager.pObjectHashTable.obj;
            SectorObject obj;
            try
            {
                obj = hashtable.GetObject(ID);
            }
            catch (Exception)
            {
                AddressBox.Text = "Not Found!";
                return;
            }
            LoadObject(obj);
        }

        public void LoadObject(SectorObject sectorObject)
        {
            m_SectorObject = sectorObject;
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_SectorObject.pThis.ToString("X");
            DefaultNameBox.Text = MemoryControl.ReadNullTerminatedString(m_GameHook.hProcess, m_SectorObject.pDefaultName);
            IDNumericUpDown.Value = m_SectorObject.ObjectID;
            PositionVectorDisplay.Vector = m_SectorObject.Position_Copy;
            RotationVectorDisplay.Vector = m_SectorObject.EulerRotationCopy;
            EventObjectIDBox.Text = m_SectorObject.EventObjectID.ToString();
            TypeBox.Text = string.Format("{0} - {1} // {2} - {3}", m_SectorObject.MainType.ToString(), m_SectorObject.GetSubTypeAsString(), (int)m_SectorObject.MainType, m_SectorObject.SubType);

            SpeedBox.Value = m_SectorObject.Speed;
            TargetSpeedBox.Value = m_SectorObject.TargetSpeed;


            // Unknowns
            UnknownsListBox.Items.Clear();
            int i = 4;
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_4.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_5));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_6));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_7));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_8));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_9.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_10.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_11));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_12));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_13));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1} {2} {3}", i++, m_SectorObject.Unknown_14_0, m_SectorObject.Unknown_14_1, m_SectorObject.Unknown_14_2));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_15));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_16));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_17));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_18));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_19.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_20));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_21.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_22));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_23));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_24.ToString("X")));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_25));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_26));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_27));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_28));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_29));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_30));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_31));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_32));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_33));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_34));
            UnknownsListBox.Items.Add(string.Format("Unknown {0} - {1}", i++, m_SectorObject.Unknown_35));


            // Object relation
            NextButton.Enabled = m_SectorObject.pNext.IsValid && m_SectorObject.pNext.obj.IsValid;
            PreviousButton.Enabled = m_SectorObject.pPrevious.IsValid && m_SectorObject.pPrevious.obj.IsValid;
            ParentButton.Enabled = m_SectorObject.pParent.IsValid && m_SectorObject.pParent.obj.IsValid;

            ReloadChildren();
        
        }

        public void ReloadChildren()
        {
            if (ChildTypeSelectionBox.SelectedIndex < 0) goto failed;
            var meta = m_SectorObject.GetMeta();
            if (meta == null || meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null || meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null) goto failed;

            FirstChildButton.Enabled = true;
            LastChildButton.Enabled = true;
            return;

            failed:
                FirstChildButton.Enabled = false;
                LastChildButton.Enabled = false;
            return;
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            LoadObject(Convert.ToInt32(IDNumericUpDown.Value));
        }

        private void AutoReloader_Tick(object sender, EventArgs e)
        {
            m_SectorObject.ReloadFromMemory();
            if (m_SectorObject.IsValid)
            {
                Reload();
            }
            else
            {
                m_SectorObject = null;
                AddressBox.Text = "Object Destroyed.";
                AutoReloadCheckBox.Enabled = false;
                AutoReloader.Enabled = false;
            }
        }

        private void AutoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = AutoReloadCheckBox.Checked;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pPrevious.obj);
        }

        private void ParentButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pParent.obj);
        }

        private void EventObjectIDLoadButton_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay(m_GameHook);
            display.LoadObject(m_SectorObject.EventObjectID);
            display.Show();
        }

        private void ChildTypeSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadChildren();
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            var meta = m_SectorObject.GetMeta();
            var child = meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if(child != null)
                LoadObject(child);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            var meta = m_SectorObject.GetMeta();
            var child = meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
                LoadObject(child);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new SectorObjectDataDisplay(m_GameHook);
            display.LoadData(m_SectorObject.pData.obj);
            display.Show();
        }
    }
}
