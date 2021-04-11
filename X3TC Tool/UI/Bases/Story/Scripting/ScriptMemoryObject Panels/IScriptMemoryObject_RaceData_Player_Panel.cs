using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.AP;
using X3Tools.RAM.Bases.Story.Scripting.ScriptingMemory.TC;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_RaceData_Player_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private struct RaceData : IComparable
        {
            public ScriptInstance ScriptingObject;
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
            nudCredits.Maximum = int.MaxValue;
            nudCredits.Minimum = int.MinValue;
        }

        private IScriptMemoryObject_RaceData_Player m_Data;
        public void LoadObject(ScriptInstance ScriptingObject)
        {
            m_Data = ScriptingObject.GetMemoryInterfaceRaceData_Player();
            RaceDataPanel.LoadObject(m_Data);
            Reload();
        }

        public void Reload()
        {
            RaceDataPanel.Reload();

            nudCredits.Value = m_Data.Credits;
            nudFightRank.Value = m_Data.FightRank;
            nudTradeRank.Value = m_Data.TradeRank;

            List<RaceData> races = new List<RaceData>();
            foreach (DynamicValue raceID in m_Data.RaceDataScriptingObjectIDHashTable.hashTable.ScanContents())
            {
                try
                {
                    ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(raceID.Value);
                    IScriptMemoryObject_RaceData raceData = ScriptingObject.GetMemoryInterfaceRaceData();
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

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(((RaceData)lstRaces.Items[lstRaces.SelectedIndex]).ScriptingObject);
            display.Show();
        }

        private void IScriptMemoryObject_RaceData_Player_Panel_Load(object sender, EventArgs e)
        {
        }
    }
}
