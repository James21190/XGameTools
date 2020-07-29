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
using X3TCTools.SectorObjects;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TC_Tool.UI.Displays.ScriptingMemoryObjects;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;

namespace X3TC_Tool.UI.Displays
{
    public partial class EventObjectDisplay : Form
    {
        private EventObject m_EventObject;
        public EventObjectDisplay()
        {
            InitializeComponent();
        }

        public void LoadObject(int ID)
        {
            var storyBase = GameHook.storyBase;
            var EventObjectHashTable = storyBase.pEventObjectHashTable.obj;
            var value = ID < 0 ? -ID - 1 : ID;
            try
            {
                m_EventObject = EventObjectHashTable.GetObject(value);
            }
            catch (Exception)
            {
                AddressBox.Text = "Not Found!";
                return;
            }
            Reload();
        }

        public void Reload()
        {
            IDNumericUpDown.Value = -m_EventObject.NegativeID-1;
            AddressBox.Text = m_EventObject.pThis.ToString("X");
            ScriptsOnStackBox.Text = m_EventObject.ReferenceCount.ToString();
            LoadVariablesButton.Enabled = m_EventObject.pScriptVariableArr.IsValid;
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            LoadObject(Convert.ToInt32(IDNumericUpDown.Value));
        }

        private void LoadVariablesButton_Click(object sender, EventArgs e)
        {
            var display = new DynamicValueObjectDisplay();
            var obj = new ScriptingMemoryObject(10);
            obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
            display.LoadObject(obj);
            display.Show();
        }

        private void LoadSubButton_Click(object sender, EventArgs e)
        {
            var display = new EventObjectSubDisplay();
            display.LoadObject(m_EventObject.pSub.obj);
            display.Show();
        }

        private void AutoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = AutoReloadCheckBox.Checked;
        }

        private void AutoReloader_Tick(object sender, EventArgs e)
        {
            m_EventObject.ReloadFromMemory();
            Reload();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = (comboBox1.SelectedIndex >= 0) ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScriptingMemoryObject obj;
            switch (GameHook.GameVersion) 
            {
                case GameHook.GameVersions.X3TC:
                    switch (comboBox1.SelectedItem)
                    {
                        default:
                            obj = new ScriptingMemoryObject();
                            obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                            obj.ReloadFromMemory();
                            break;
                    }
                    break;
                case GameHook.GameVersions.X3AP:
                    switch (comboBox1.SelectedItem)
                    {
                        case "Sector":
                            obj = m_EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();

                            if (chkLoadWithArray.Checked) break;

                            var sectorDisplay = new ScriptMemory_Sector_Display();
                            sectorDisplay.LoadObject((IScriptMemoryObject_Sector)obj);
                            sectorDisplay.Show();
                            return;
                        case "Ship":
                            obj = m_EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>();

                            if (chkLoadWithArray.Checked) break;

                            var shipDisplay = new ScriptMemory_Ship_Display();
                            shipDisplay.LoadObject((IScriptMemoryObject_Ship)obj);
                            shipDisplay.Show();
                            return;

                        default:
                            obj = new ScriptingMemoryObject();
                            obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                            obj.ReloadFromMemory();
                            break;
                    }
                    break;
                default: return;
            }

            DynamicValueObjectDisplay display;
            display = new DynamicValueObjectDisplay();
            display.LoadObject(obj);
            display.Show();
        }
    }
}
