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
    public partial class EventObjectDisplay : Form
    {
        private GameHook m_GameHook;
        private EventObject m_EventObject;
        public EventObjectDisplay(GameHook gameHook)
        {
            InitializeComponent();
            m_GameHook = gameHook;
        }

        public void LoadObject(int ID)
        {
            var storyBase = m_GameHook.storyBase;
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
            var display = new DynamicValueArrayDisplay(m_GameHook);
            display.LoadFrom(m_EventObject.pScriptVariableArr.address, 0, 0);
            display.Show();
        }

        private void LoadSubButton_Click(object sender, EventArgs e)
        {
            var display = new EventObjectSubDisplay(m_GameHook);
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
    }
}
