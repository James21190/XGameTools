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
using X3TCTools.Bases.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;

namespace X3TC_Tool.UI.Displays
{
    public partial class EventObjectDisplay : Form
    {
        public enum LoadAsItems
        {
            Ship,
            Sector,
            Station,
            Gate,
            Ware,
            RaceData,
            RaceData_Player,
        }
        private EventObject m_EventObject;
        public EventObjectDisplay()
        {
            InitializeComponent();
            int i = 0;
            while (((LoadAsItems)(i)).ToString() != i.ToString())
            {
                comboBox1.Items.Add((LoadAsItems)i++);
            }
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
                m_EventObject = null;
            }

            eventObjectPannel1.EventObject = m_EventObject;

            switch (m_EventObject.ObjectType)
            {

            }

            Reload();
        }


        public void LoadObject(EventObject eventObject)
        {
            m_EventObject = eventObject;
            eventObjectPannel1.EventObject = eventObject;

            switch (eventObject.ObjectType)
            {

            }

            Reload();
        }

        public void LoadAsType(LoadAsItems type)
        {
            comboBox1.SelectedIndex = (int)type;
        }

        public void LoadObject(EventObject eventObject, LoadAsItems defaultType)
        {
            LoadObject(eventObject);
            LoadAsType(defaultType);
        }
        public void LoadObject(int id, LoadAsItems defaultType)
        {
            LoadObject(id);
            LoadAsType(defaultType);
        }

        public void Reload()
        {
            LoadVariablesButton.Enabled = m_EventObject.pScriptVariableArr.IsValid;
        }

        private void LoadVariablesButton_Click(object sender, EventArgs e)
        {
            var display = new DynamicValueObjectDisplay();
            var obj = new ScriptMemoryObject(m_EventObject.pSub.obj.ScriptVariableCount);
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

        public static ScriptMemoryObject GetScriptMemoryObjectType(LoadAsItems type)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                    switch (type)
                    {

                    }
                    break;
                case GameHook.GameVersions.X3AP:
                    switch (type)
                    {
                        case LoadAsItems.Sector: return new ScriptMemoryObject_AP_Sector();
                        case LoadAsItems.Ship: return new ScriptMemoryObject_AP_Ship();
                        case LoadAsItems.Gate: return new ScriptMemoryObject_AP_Gate();
                        case LoadAsItems.Station: return new ScriptMemoryObject_AP_Station();
                        case LoadAsItems.RaceData: return new ScriptMemoryObject_AP_RaceData();
                        case LoadAsItems.RaceData_Player: return new ScriptMemoryObject_AP_RaceData_Player();
                    }
                    break;
            }
            return new ScriptMemoryObject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScriptMemoryObject obj = GetScriptMemoryObjectType((LoadAsItems)comboBox1.SelectedIndex);
            obj.SetLocation(GameHook.hProcess, m_EventObject.pScriptVariableArr.address);
            obj.ReloadFromMemory();
            obj.Resize(m_EventObject.pSub.obj.ScriptVariableCount);

            if (!chkLoadWithArray.Checked)
                switch ((LoadAsItems)comboBox1.SelectedIndex)
                {
                    case LoadAsItems.Sector:
                        var sectorDisplay = new EventObject_Sector_Display();
                        sectorDisplay.LoadObject(m_EventObject);
                        sectorDisplay.Show();
                        return;
                    case LoadAsItems.Ship:
                        var shipDisplay = new EventObject_Ship_Display();
                        shipDisplay.LoadObject(m_EventObject);
                        shipDisplay.Show();
                        return;
                    case LoadAsItems.RaceData:
                    case LoadAsItems.RaceData_Player:
                        var raceDataDisplay = new EventObject_RaceData_Display();
                        raceDataDisplay.LoadObject(m_EventObject);
                        raceDataDisplay.Show();
                        return;
                    case LoadAsItems.Station:
                        var dockDataDisplay = new EventObject_Station_Display();
                        dockDataDisplay.LoadObject(m_EventObject);
                        dockDataDisplay.Show();
                        return;
                }

            DynamicValueObjectDisplay display;
            display = new DynamicValueObjectDisplay();
            display.LoadObject(obj);
            display.Show();
        }

        private void EventObjectDisplay_Load(object sender, EventArgs e)
        {
            
        }

        private void eventObjectPannel1_EventObjectLoaded(object sender, EventArgs e)
        {
            m_EventObject = eventObjectPannel1.EventObject;
            Reload();
        }
    }
}
