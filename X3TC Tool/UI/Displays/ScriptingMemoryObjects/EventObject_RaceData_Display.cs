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
    public partial class EventObject_RaceData_Display : Form
    {
        private EventObject m_EventObject;
        IScriptMemoryObject_RaceData m_RaceData
        {
            get
            {
                IScriptMemoryObject_RaceData obj;
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3TC: obj = new ScriptMemoryObject_TC_RaceData(); break;
                    case GameHook.GameVersions.X3AP: obj = new ScriptMemoryObject_AP_RaceData(); break;
                    default: throw new Exception();
                }

                obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
                obj.ReloadFromMemory();

                return obj;
            }
        }
        public EventObject_RaceData_Display()
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
            textBox1.Text = m_RaceData.RaceID.ToString();
        }

        private void eventObjectPannel1_EventObjectLoaded(object sender, EventArgs e)
        {
            m_EventObject = eventObjectPannel1.EventObject;
            Reload();
        }
    }
}
