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
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;
using Common.Memory;

namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    public partial class EventObject_Station_Display : Form
    {
        EventObject m_EventObject;
        IScriptMemoryObject_Station m_DockData { get {
                IScriptMemoryObject_Station obj;
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3TC: obj = new ScriptMemoryObject_TC_Station(); break;
                    case GameHook.GameVersions.X3AP: obj = new ScriptMemoryObject_AP_Station(); break;
                    default: throw new Exception();
                }

                obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                obj.ReloadFromMemory();

                return obj;
            } }
        public EventObject_Station_Display()
        {
            InitializeComponent();
        }

        public void LoadObject(EventObject eventObject)
        {
            m_EventObject = eventObject;
            eventObjectPannel1.EventObject = eventObject;
            Reload();
        }

        public void Reload()
        {
            m_EventObject.ReloadFromMemory();
            //if (!m_FactoryData.IsValid) txtCargo.Text = "Object Invalid";
            var cargo = m_DockData.Cargo;
            Array.Sort(cargo);
            txtCargo.Text = string.Join("\n", cargo);
            for (int i = 0; i < GameHook.GetTypeDataCount((int)m_DockData.MainType); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString((SectorObject.Main_Type)m_DockData.MainType, i));
            }
            cmbSubType.SelectedIndex = m_DockData.SubType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            //display.LoadObject(m_FactoryData.PreviousSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            //display.LoadObject(m_FactoryData.CurrentSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
            display.Show();
        }

        private void eventObjectPannel1_EventObjectLoaded(object sender, EventArgs e)
        {
            m_EventObject = eventObjectPannel1.EventObject;
            Reload();
        }

        private void EventObject_Ship_Display_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var display = new EventObject_RaceData_Display();
            //display.LoadObject(m_FactoryData.OwnerDataEventObject);
            display.Show();
        }
    }
}
