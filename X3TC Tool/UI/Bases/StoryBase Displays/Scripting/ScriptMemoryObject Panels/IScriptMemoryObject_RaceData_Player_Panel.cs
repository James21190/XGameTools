using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_RaceData_Player_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private struct RaceData : IComparable
        {
            public ScriptingObject ScriptingObject;
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
        public void LoadObject(ScriptingObject ScriptingObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>(); break;
                case GameHook.GameVersions.X3TC: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData_Player>(); break;
            }
            RaceDataPanel.LoadObject(m_Data);
            Reload();
        }

        public void Reload()
        {
            RaceDataPanel.Reload();

            List<RaceData> races = new List<RaceData>();
            foreach (DynamicValue raceID in m_Data.RaceDataScriptingObjectIDHashTable.hashTable.ScanContents())
            {
                try
                {
                    ScriptingObject ScriptingObject = GameHook.storyBase.GetScriptingObject(raceID.Value);
                    IScriptMemoryObject_RaceData raceData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            raceData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            raceData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();
                            break;
                        default: throw new Exception();
                    }

                    races.Add(new RaceData()
                    {
                        ScriptingObject = ScriptingObject,
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

            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(((RaceData)lstRaces.Items[lstRaces.SelectedIndex]).ScriptingObject);
            display.Show();
        }
    }
}
