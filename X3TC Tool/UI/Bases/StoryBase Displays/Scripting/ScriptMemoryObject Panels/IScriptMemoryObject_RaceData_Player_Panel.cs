using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3TCTools;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3TCTools.Bases.StoryBase_Objects.Scripting;

namespace X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_RaceData_Player_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private struct RaceData : IComparable
        {
            public EventObject eventObject;
            public GameHook.RaceID raceID;

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is RaceData))
                {
                    throw new Exception("Type missmatch");
                }

                RaceData type = (RaceData)obj;


                if (raceID > type.raceID)
                {
                    return -1;
                }

                if (raceID < type.raceID)
                {
                    return 1;
                }

                return 0;
            }

            public override string ToString()
            {
                return raceID.ToString();
            }
        }
        public IScriptMemoryObject_RaceData_Player_Panel()
        {
            InitializeComponent();
        }

        private IScriptMemoryObject_RaceData_Player m_Data;
        public void LoadObject(EventObject eventObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>(); break;
                case GameHook.GameVersions.X3TC: m_Data = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData_Player>(); break;
            }
            RaceDataPanel.LoadObject(m_Data);
            Reload();
        }

        public void Reload()
        {
            RaceDataPanel.Reload();

            List<RaceData> races = new List<RaceData>();
            foreach (DynamicValue raceID in m_Data.RaceDataEventObjectIDHashTable.hashTable.ScanContents())
            {
                try
                {
                    EventObject eventObject = GameHook.storyBase.GetEventObject(raceID.Value);
                    IScriptMemoryObject_RaceData raceData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            raceData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            raceData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();
                            break;
                        default: throw new Exception();
                    }

                    races.Add(new RaceData()
                    {
                        eventObject = eventObject,
                        raceID = raceData.RaceID
                    });
                }
                catch (Exception)
                {

                }
            }

            races.Sort();
            races.Reverse();

            foreach (RaceData race in races)
            {
                lstRaces.Items.Add(race);
            }
        }

        private void lstRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRaces.SelectedIndex < 0 || lstRaces.SelectedIndex >= lstRaces.Items.Count)
            {
                return;
            }

            EventObjectDisplay display = new EventObjectDisplay();
            display.LoadObject(((RaceData)lstRaces.Items[lstRaces.SelectedIndex]).eventObject);
            display.Show();
        }
    }
}
