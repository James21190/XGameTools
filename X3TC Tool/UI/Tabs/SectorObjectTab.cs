using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;
using Common.Memory;
using X3TCTools.SectorObjects.Meta;

namespace X3TC_Tool
{
    partial class X3TCToolForm
    {
        private SectorObject m_LoadedObject;
        public void LoadSectorObject(SectorObject sectorObject)
        {
            m_LoadedObject = sectorObject;
            ReloadSectorObjectTab();
        }

        public void ReloadSectorObjectUI()
        {
            comboBox1.Items.Clear();
            for(int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                comboBox1.Items.Add((SectorObject.Main_Type)i);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(m_LoadedObject != null)
                LoadSectorObject(m_GameHook.SectorObjectManager.GetSectorObject(m_LoadedObject.pThis));
        }

        public void ReloadSectorObjectChildren()
        {
            var meta = m_LoadedObject.GetMeta();

            if (meta != null)
            {

                var ChildrenList = meta.GetChildrenList();
                if (ChildrenList != null)
                {
                    groupBox9.Enabled = true;
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        var children = ChildrenList[comboBox1.SelectedIndex];
                        SectorObject child;
                        if (m_GameHook.SectorObjectManager.SectorObjectExists(children.pFirst, out child))
                        {
                            textBox10.Text = child.ObjectID.ToString();
                            button5.Enabled = true;
                        }
                        else
                        {
                            button5.Enabled = false;
                            textBox10.Text = "";
                        }
                        if (m_GameHook.SectorObjectManager.SectorObjectExists(children.pFirst, out child))
                        {

                            textBox11.Text = child.ObjectID.ToString();
                            button6.Enabled = true;
                        }
                        else
                        {
                            button6.Enabled = false;
                            textBox11.Text = "";
                        }
                    }
                    else
                    {
                        textBox10.Text = textBox11.Text = "";
                        button5.Enabled = button6.Enabled = false;
                    }
                    return;
                }
            }
            
            groupBox9.Enabled = false;
        }

        public void ReloadSectorObjectTab()
        {
            if (m_LoadedObject == null)
                return;
            // Load pointers
            textBox3.Text = m_LoadedObject.pThis.ToString("X");
            SectorObject temp;
            if (m_GameHook.SectorObjectManager.SectorObjectExists(m_LoadedObject.pParent, out temp))
            {
                textBox1.Text = temp.ObjectID.ToString();
                button1.Enabled = true;
            }
            else
            {
                textBox1.Text = "";
                button1.Enabled = false;
            }
            if (m_GameHook.SectorObjectManager.SectorObjectExists(m_LoadedObject.pNext, out temp))
            {
                textBox8.Text = temp.ObjectID.ToString();
                button3.Enabled = true;
            }
            else
            {
                textBox8.Text = "";
                button3.Enabled = false;
            }
            if (m_GameHook.SectorObjectManager.SectorObjectExists(m_LoadedObject.pPrevious, out temp))
            {
                textBox9.Text = temp.ObjectID.ToString();
                button4.Enabled = true;
            }
            else
            {
                textBox9.Text = "";
                button4.Enabled = false;
            }
            // Load SectorObject values
            textBox2.Text = MemoryControl.ReadNullTerminatedString(m_GameHook.hProcess, m_LoadedObject.pDefaultName);
            
            // Enums
            textBox5.Text = m_LoadedObject.MainType.ToString();
            textBox12.Text = m_LoadedObject.RaceID.ToString();
            // Numerics
            numericUpDown1.Value = m_LoadedObject.Hull;
            numericUpDown2.Value = m_LoadedObject.Speed;
            numericUpDown3.Value = m_LoadedObject.TargetSpeed;
            // Vectors
            vector3Display1.Vector = m_LoadedObject.Position_Copy;
            vector3Display2.Vector = m_LoadedObject.EulerRotationCopy;
            vector3Display3.Vector = m_LoadedObject.PositionStrafeDelta;
            vector3Display4.Vector = m_LoadedObject.LocalEulerRotationDelta;
            // Load type dependent values
            textBox7.Text = m_LoadedObject.GetSubTypeAsString();

            // Load meta

            if (m_LoadedObject.pMeta != IntPtr.Zero)
            {
                ReloadSectorObjectChildren();
            }
            else
                groupBox8.Enabled = false;

            // Load Data
            if (m_LoadedObject.pData != IntPtr.Zero) 
            {
                var data = m_LoadedObject.GetData();
            }
        }

        #region Buttons
        private void button2_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_GameHook.SectorObjectManager.GetPlayerObject());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_GameHook.SectorObjectManager.GetSectorObject(m_LoadedObject.pParent));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_GameHook.SectorObjectManager.GetSectorObject(m_LoadedObject.pNext));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadSectorObject(m_GameHook.SectorObjectManager.GetSectorObject(m_LoadedObject.pPrevious));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var meta = m_LoadedObject.GetMeta();
            LoadSectorObject(new SectorObject(m_GameHook, meta.GetChildrenList()[comboBox1.SelectedIndex].pFirst));
                   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var meta = m_LoadedObject.GetMeta();
            LoadSectorObject(new SectorObject(m_GameHook, meta.GetChildrenList()[comboBox1.SelectedIndex].pLast));
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSectorObjectChildren();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var dialog = new UI.TypeSelectDialog();
            dialog.ShowDialog();
            if(dialog.Done == true)
            {
                m_GameHook.GameCodeRunner.CreateSectorObject(dialog.MainType, dialog.SubType, m_GameHook.SectorObjectManager.GetSpace());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SectorObjectTabReloader.Enabled = checkBox1.Checked;
        }
    }
}
