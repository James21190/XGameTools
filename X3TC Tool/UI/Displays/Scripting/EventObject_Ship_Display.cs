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
    public partial class EventObject_Ship_Display : Form
    {
        EventObject m_EventObject;
        IScriptMemoryObject_Ship m_ShipData { get {
                IScriptMemoryObject_Ship obj;
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3TC: obj = new ScriptMemoryObject_TC_Ship(); break;
                    case GameHook.GameVersions.X3AP: obj = new ScriptMemoryObject_AP_Ship(); break;
                    default: throw new Exception();
                }

                obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                obj.ReloadFromMemory();

                return obj;
            } }
        public EventObject_Ship_Display()
        {
            InitializeComponent();

            for (int i = 0; i < GameHook.GetTypeDataCount(7); i++)
            {
                cmbSubType.Items.Add(SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, i));
            } 

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
            if (!m_ShipData.IsValid) txtCargo.Text = "Object Invalid";
            var cargo = m_ShipData.CargoEntries;
            Array.Sort(cargo);
            txtCargo.Text = string.Join("\n", cargo);
            cmbSubType.SelectedIndex = m_ShipData.SubType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            display.LoadObject(m_ShipData.PreviousSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
            display.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var display = new EventObjectDisplay();
            display.LoadObject(m_ShipData.CurrentSectorEventObjectID, EventObjectDisplay.LoadAsItems.Sector);
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
            display.LoadObject(m_ShipData.OwnerDataEventObject);
            display.Show();
        }
    }
}
