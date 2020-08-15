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
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;

namespace X3TC_Tool.UI.Displays.ScriptingMemoryObjects
{
    public partial class EventObject_Sector_Display : Form
    {
        private EventObject m_EventObject;
        IScriptMemoryObject_Sector m_SectorData
        {
            get
            {
                IScriptMemoryObject_Sector obj;
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3TC: obj = new ScriptMemoryObject_TC_Sector(); break;
                    case GameHook.GameVersions.X3AP: obj = new ScriptMemoryObject_AP_Sector(); break;
                    default: throw new Exception();
                }

                obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                obj.ReloadFromMemory();

                return obj;
            }
        }
        public EventObject_Sector_Display()
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
            vector2Display1.X = m_SectorData.SectorX;
            vector2Display1.Y = m_SectorData.SectorY;
            textBox1.Text = GameHook.gateSystemObject.GetSectorName(m_SectorData.SectorX, m_SectorData.SectorY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var display = new EventObject_RaceData_Display();
            display.LoadObject(m_SectorData.OwningRaceDataEventObject);
            display.Show();
        }
    }
}
