using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Tools;
using X2Tools.X2.SectorObjects;
using X2Tools.X2.SectorObjects.Meta;
using Common;
using Common.Memory;


namespace X2TheThreatRETool
{
    public partial class X2RETool : Form
    {
        private SectorObject m_CurrentSectorObject;
        private void ReloadSectorObjectData()
        {

            // Load type dependent data
            switch (m_CurrentSectorObject.MainType)
            {
                // Type 0 and 8
                case SectorObject.Main_Type.Projectile:
                case SectorObject.Main_Type.ShipGun:
                    textBox7.Text = ((SectorObject.Weapon_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    LoadShipGunMeta();
                    break;
                // Type 1
                case SectorObject.Main_Type.Sector:
                    textBox7.Text = ((SectorObject.Sector_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    LoadSectorMeta();
                    break;
                // Type 2
                case SectorObject.Main_Type.Type_2:
                    textBox7.Text = ((SectorObject.Type_2_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 3
                case SectorObject.Main_Type.Sun:
                    textBox7.Text = ((SectorObject.Sun_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 4
                case SectorObject.Main_Type.Planet:
                    textBox7.Text = ((SectorObject.Planet_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 5
                case SectorObject.Main_Type.Dock:
                    textBox7.Text = ((SectorObject.Dock_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 6
                case SectorObject.Main_Type.Factory:
                    textBox7.Text = ((SectorObject.Factory_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 7
                case SectorObject.Main_Type.Ship:
                    textBox7.Text = ((SectorObject.Ship_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    LoadShipMeta();
                    break;
                // Type 9
                case SectorObject.Main_Type.Shield:
                    textBox7.Text = ((SectorObject.Shield_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    LoadShieldMeta();
                    break;
                // Type 10
                case SectorObject.Main_Type.Missile:
                    textBox7.Text = ((SectorObject.Missile_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 11
                case SectorObject.Main_Type.Ware_Energy:
                    textBox7.Text = ((SectorObject.Ware_Energy_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 12
                case SectorObject.Main_Type.Ware_Mission:
                    textBox7.Text = ((SectorObject.Ware_Mission_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 13
                case SectorObject.Main_Type.Ware_Agriculture:
                    textBox7.Text = ((SectorObject.Ware_Agriculture_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 14
                case SectorObject.Main_Type.Ware_Processed:
                    textBox7.Text = ((SectorObject.Ware_Processed_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 15
                case SectorObject.Main_Type.Ware_Ores:
                    textBox7.Text = ((SectorObject.Ware_Ores_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 16
                case SectorObject.Main_Type.Ware_Technology:
                    textBox7.Text = ((SectorObject.Ware_Technology_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 17
                case SectorObject.Main_Type.Asteroid:
                    textBox7.Text = ((SectorObject.Asteroid_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 18
                case SectorObject.Main_Type.Gate:
                    textBox7.Text = ((SectorObject.Gate_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 19
                case SectorObject.Main_Type.Type_19:
                    textBox7.Text = ((SectorObject.Type_19_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 20
                case SectorObject.Main_Type.Miscellaneous:
                    textBox7.Text = ((SectorObject.Miscellaneous_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 21
                case SectorObject.Main_Type.Nebula:
                    textBox7.Text = ((SectorObject.Nebula_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                // Type 22
                case SectorObject.Main_Type.Station_Internal:
                    textBox7.Text = ((SectorObject.Station_Internal_Sub_Type)m_CurrentSectorObject.SubType).ToString();
                    break;
                default:
                    throw new NotImplementedException("Type " + m_CurrentSectorObject.MainType + " has not been implemented.");
            }

            // Load values

            // Load address
            textBox2.Text = (m_CurrentSectorObject.pThis).ToString("X");
            // Load next and previous objects
            var nextobject = (m_CurrentSectorObject.pNext.obj);
            var previousobject = (m_CurrentSectorObject.pPrevious.obj);

            if (nextobject.pNext.IsValid)
            {
                numericUpDown23.Enabled = true;
                button8.Enabled = true;
                numericUpDown23.Value = nextobject.SectorObjectID;
            }
            else
            {
                numericUpDown23.Enabled = false;
                button8.Enabled = false;
            }
            if (previousobject.pPrevious.IsValid)
            {
                numericUpDown22.Enabled = true;
                button7.Enabled = true;
                numericUpDown22.Value = previousobject.SectorObjectID;
            }
            else
            {
                numericUpDown22.Enabled = false;
                button7.Enabled = false;
            }


            numericUpDown11.Value = m_CurrentSectorObject.SectorObjectID;
            textBox3.Text = MemoryControl.ReadNullTerminatedString(m_GameHook.hProcess, m_CurrentSectorObject.pDefaultName);
            numericUpDown12.Value = m_CurrentSectorObject.Speed;
            numericUpDown13.Value = m_CurrentSectorObject.TargetSpeed;
            vector3Display2.Vector = m_CurrentSectorObject.Rotation;
            vector3Display1.Vector = m_CurrentSectorObject.LocalRotationDelta;
            vector3Display5.Vector = m_CurrentSectorObject.AutoPilotRotationChange;

            comboBox7.SelectedIndex = (int)m_CurrentSectorObject.RaceID;
            // Interaction Flags

            checkedListBox1.SetItemChecked(0, m_CurrentSectorObject.InteractionFlags.Unknown1);
            checkedListBox1.SetItemChecked(1, m_CurrentSectorObject.InteractionFlags.IsPlayerShip);
            checkedListBox1.SetItemChecked(2, m_CurrentSectorObject.InteractionFlags.Unknown3);
            checkedListBox1.SetItemChecked(3, m_CurrentSectorObject.InteractionFlags.Unknown4);
            checkedListBox1.SetItemChecked(4, m_CurrentSectorObject.InteractionFlags.Unknown5);
            checkedListBox1.SetItemChecked(5, m_CurrentSectorObject.InteractionFlags.IsShip);
            checkedListBox1.SetItemChecked(6, m_CurrentSectorObject.InteractionFlags.Unknown7);
            checkedListBox1.SetItemChecked(7, m_CurrentSectorObject.InteractionFlags.Unknown8);
            checkedListBox1.SetItemChecked(8, m_CurrentSectorObject.InteractionFlags.Unknown9);
            checkedListBox1.SetItemChecked(9, m_CurrentSectorObject.InteractionFlags.Unknown10);
            checkedListBox1.SetItemChecked(10, m_CurrentSectorObject.InteractionFlags.Unknown11);
            checkedListBox1.SetItemChecked(11, m_CurrentSectorObject.InteractionFlags.Unknown12);
            checkedListBox1.SetItemChecked(12, m_CurrentSectorObject.InteractionFlags.BlockSeta);
            checkedListBox1.SetItemChecked(13, m_CurrentSectorObject.InteractionFlags.CollisionWarning);
            checkedListBox1.SetItemChecked(14, m_CurrentSectorObject.InteractionFlags.Unknown15);
            checkedListBox1.SetItemChecked(15, m_CurrentSectorObject.InteractionFlags.Unknown16);
            checkedListBox1.SetItemChecked(16, m_CurrentSectorObject.InteractionFlags.Unknown17);
            checkedListBox1.SetItemChecked(17, m_CurrentSectorObject.InteractionFlags.Unknown18);
            checkedListBox1.SetItemChecked(18, m_CurrentSectorObject.InteractionFlags.Unknown19);
            checkedListBox1.SetItemChecked(19, m_CurrentSectorObject.InteractionFlags.IsAIControled);
            checkedListBox1.SetItemChecked(20, m_CurrentSectorObject.InteractionFlags.Unknown21);
            checkedListBox1.SetItemChecked(21, m_CurrentSectorObject.InteractionFlags.Unknown22);
            checkedListBox1.SetItemChecked(22, m_CurrentSectorObject.InteractionFlags.Unknown23);
            checkedListBox1.SetItemChecked(23, m_CurrentSectorObject.InteractionFlags.Unknown24);
            checkedListBox1.SetItemChecked(24, m_CurrentSectorObject.InteractionFlags.Unknown25);
            checkedListBox1.SetItemChecked(25, m_CurrentSectorObject.InteractionFlags.Unknown26);
            checkedListBox1.SetItemChecked(26, m_CurrentSectorObject.InteractionFlags.Unknown27);
            checkedListBox1.SetItemChecked(27, m_CurrentSectorObject.InteractionFlags.IsPendingDestruction);
            checkedListBox1.SetItemChecked(28, m_CurrentSectorObject.InteractionFlags.Unknown29);
            checkedListBox1.SetItemChecked(29, m_CurrentSectorObject.InteractionFlags.Unknown30);
            checkedListBox1.SetItemChecked(30, m_CurrentSectorObject.InteractionFlags.Unknown31);
            checkedListBox1.SetItemChecked(31, m_CurrentSectorObject.InteractionFlags.Unknown32);

            // Flag
            textBox8.Text = m_CurrentSectorObject.MainType.ToString();

            // Meta
            if (m_CurrentSectorObject.pParent.IsValid)
            {
                numericUpDown24.Enabled = true;
                button9.Enabled = true;
                numericUpDown24.Value = (m_CurrentSectorObject.pParent.obj).SectorObjectID;
            }
            else
            {
                numericUpDown24.Enabled = false;
                button9.Enabled = false;
            }
            vector3Display4.Vector = m_CurrentSectorObject.StrafePositionDelta;
            // PositionCopy
            vector3Display3.Vector = m_CurrentSectorObject.PositionCopy;
            // RotationCopy
            // LocalDeltaRotationCopy
            // SpeedCopy
            // Hull

            numericUpDown16.Value = m_CurrentSectorObject.Unknown_4;
            numericUpDown26.Value = m_CurrentSectorObject.Unknown_5;
            numericUpDown19.Value = m_CurrentSectorObject.Unknown_6;
            numericUpDown25.Value = m_CurrentSectorObject.Unknown_7;
            numericUpDown18.Value = m_CurrentSectorObject.RunObjectParamID;
            numericUpDown28.Value = m_CurrentSectorObject.Unknown_10;
            numericUpDown30.Value = m_CurrentSectorObject.Unknown_9;
            numericUpDown29.Value = m_CurrentSectorObject.Unknown_11;
            numericUpDown27.Value = m_CurrentSectorObject.Unknown_12;
            numericUpDown35.Value = m_CurrentSectorObject.SelectInformation;
            numericUpDown32.Value = m_CurrentSectorObject.Unknown_14;
            numericUpDown34.Value = m_CurrentSectorObject.Unknown_15;
            numericUpDown15.Value = m_CurrentSectorObject.Unknown_16;
            numericUpDown33.Value = m_CurrentSectorObject.Unknown_17;
            numericUpDown17.Value = m_CurrentSectorObject.Unknown_18;
            numericUpDown31.Value = m_CurrentSectorObject.Unknown_19;
            numericUpDown14.Value = m_CurrentSectorObject.Unknown_20;
            numericUpDown36.Value = m_CurrentSectorObject.Unknown_21;

        }
        private void button35_Click(object sender, EventArgs e)
        {
            var dialog = new UI.TypeSelectDialog();
            dialog.ShowDialog();

            if (dialog.Done)
            {
                if(dialog.ParentID == 0)
                    m_GameHook.GameCodeRunner.CreateSectorObject(dialog.MainType, dialog.SubType, m_GameHook.SectorObjectManager.GetSpace());
                else
                {
                    var obj = m_GameHook.GameCodeRunner.CreateSectorObject(dialog.MainType, dialog.SubType);
                    if(obj != null)
                        m_GameHook.GameCodeRunner.DockObject(obj, m_GameHook.SectorObjectManager.GetSectorObject(dialog.ParentID));
                }
            }
        }
        private void LoadSectorObject(int SectorObjectID)
        {
            try
            {
                var SO = m_GameHook.SectorObjectManager.GetSectorObject(Convert.ToInt32(SectorObjectID));
                if (!SO.pNext.IsValid || !SO.pPrevious.IsValid)
                {
                    textBox2.Text = "Object Not Found!";
                    return;
                }
                m_CurrentSectorObject = SO;
            }
            catch (Exception)
            {
                textBox2.Text = "Object Not Found!";
                return;
            }
            ReloadSectorObjectData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_GameHook.SectorObjectManager.GetPlayerShip().SectorObjectID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }

        private void SectorObjectTabAutoReloader_Tick(object sender, EventArgs e)
        {
            // If the current tab is open and the current object isn't null
            if (tabControl1.SelectedTab.Name == "SectorObjectTab" && m_CurrentSectorObject != null)
                LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SectorObjectTabAutoReloader.Enabled = checkBox1.Checked;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Main Object
            m_CurrentSectorObject.Speed = Convert.ToInt32(numericUpDown12.Value);
            m_CurrentSectorObject.TargetSpeed = Convert.ToInt32(numericUpDown13.Value);

            // Data
            var data = m_CurrentSectorObject.GetData();
            data.Position = vector3Display3.Vector;

            // Save
            m_CurrentSectorObject.SaveData(data);

            m_CurrentSectorObject.Save();
        }

        #region Meta Data

        private int GetMetaTabIndex(string Name)
        {
            int i = 0;
            foreach (TabPage tab in tabControl3.TabPages)
            {
                if (tab.Name == Name)
                    return i;
                i++;
            }
            return -1;
        }

        private void LoadShipMeta()
        {
            tabControl3.SelectedIndex = GetMetaTabIndex("ShipMetaDataTab");
            var Meta = (ShipMeta) m_CurrentSectorObject.GetMetaData();
            if (Meta.pFirstChild.IsValid)
            {
                numericUpDown20.Value = (Meta.pFirstChild.obj).SectorObjectID;
                numericUpDown21.Value = (Meta.pLastChild.obj).SectorObjectID;
            }
        }

        private void LoadShipGunMeta()
        {
            tabControl3.SelectedIndex = GetMetaTabIndex("ShipGunMetaDataTab");

        }

        private void LoadShieldMeta()
        {
            tabControl3.SelectedIndex = GetMetaTabIndex("ShieldMetaDataTab");

        }

        private void LoadSectorMeta()
        {
            tabControl3.SelectedIndex = GetMetaTabIndex("SectorMetaDataTab");
            var Meta = (SectorMeta) m_CurrentSectorObject.GetMetaData();
            numericUpDown37.Value = (Meta.pFirstChild.obj).SectorObjectID;
            numericUpDown38.Value = (Meta.pLastChild.obj).SectorObjectID;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown20.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown21.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }
        #endregion
        private void button8_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown23.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown22.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }
        private void button9_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown24.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }
        private void button31_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown37.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }
        private void button32_Click(object sender, EventArgs e)
        {
            numericUpDown11.Value = numericUpDown38.Value;
            LoadSectorObject(Convert.ToInt32(numericUpDown11.Value));
        }
        private void button37_Click(object sender, EventArgs e)
        {
            m_GameHook.GameCodeRunner.DestroyObject(m_CurrentSectorObject);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (checkedListBox1.SelectedIndex)
            {
                case 0:
                    m_CurrentSectorObject.InteractionFlags.Unknown1 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 1:
                    m_CurrentSectorObject.InteractionFlags.IsPlayerShip = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 2:
                    m_CurrentSectorObject.InteractionFlags.Unknown3 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 3:
                    m_CurrentSectorObject.InteractionFlags.Unknown4 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 4:
                    m_CurrentSectorObject.InteractionFlags.Unknown5 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 5:
                    m_CurrentSectorObject.InteractionFlags.IsShip = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 6:
                    m_CurrentSectorObject.InteractionFlags.Unknown7 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 7:
                    m_CurrentSectorObject.InteractionFlags.Unknown8 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 8:
                    m_CurrentSectorObject.InteractionFlags.Unknown9 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 9:
                    m_CurrentSectorObject.InteractionFlags.Unknown10 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 10:
                    m_CurrentSectorObject.InteractionFlags.Unknown11 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 11:
                    m_CurrentSectorObject.InteractionFlags.Unknown12 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 12:
                    m_CurrentSectorObject.InteractionFlags.BlockSeta = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 13:
                    m_CurrentSectorObject.InteractionFlags.CollisionWarning = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 14:
                    m_CurrentSectorObject.InteractionFlags.Unknown15 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 15:
                    m_CurrentSectorObject.InteractionFlags.Unknown16 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 16:
                    m_CurrentSectorObject.InteractionFlags.Unknown17 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 17:
                    m_CurrentSectorObject.InteractionFlags.Unknown18 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 18:
                    m_CurrentSectorObject.InteractionFlags.Unknown19 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 19:
                    m_CurrentSectorObject.InteractionFlags.IsAIControled = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 20:
                    m_CurrentSectorObject.InteractionFlags.Unknown21 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 21:
                    m_CurrentSectorObject.InteractionFlags.Unknown22 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 22:
                    m_CurrentSectorObject.InteractionFlags.Unknown23 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 23:
                    m_CurrentSectorObject.InteractionFlags.Unknown24 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 24:
                    m_CurrentSectorObject.InteractionFlags.Unknown25 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 25:
                    m_CurrentSectorObject.InteractionFlags.Unknown26 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 26:
                    m_CurrentSectorObject.InteractionFlags.Unknown27 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 27:
                    m_CurrentSectorObject.InteractionFlags.IsPendingDestruction = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 28:
                    m_CurrentSectorObject.InteractionFlags.Unknown29 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 29:
                    m_CurrentSectorObject.InteractionFlags.Unknown30 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 30:
                    m_CurrentSectorObject.InteractionFlags.Unknown31 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
                case 31:
                    m_CurrentSectorObject.InteractionFlags.Unknown32 = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
                    break;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            //m_GameHook.GameCodeRunner.DockObject(m_CurrentSectorObject, m_GameHook.SectorObjectManager.GetSectorObject((int)numericUpDown39.Value));
        }
    }
}
