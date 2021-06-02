using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Sector;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemory_RaceData_Player_Panel : UserControl, IScriptMemoryObject_Panel
    {
        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set => m_MessengerFunction = value; }
        private struct ListItem
        {
            public object obj;
            public string txt;

            public override string ToString()
            {
                return txt;
            }
        }
        private struct ShipData : IComparable
        {
            public ScriptInstance Ship;

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is ShipData))
                {
                    throw new Exception("Type missmatch");
                }

                ShipData type = (ShipData)obj;



                int thisSubType = Ship.GetVariableByName("SubType").Value;
                int thatSubType = type.Ship.GetVariableByName("SubType").Value;



                if (thisSubType > thatSubType)
                {
                    return -1;
                }

                if (thisSubType < thatSubType)
                {
                    return 1;
                }

                return 0;
            }
        }

        private struct StationData : IComparable
        {
            public ScriptInstance Station;

            public int CompareTo(object obj)
            {
                if (obj == null)
                {
                    return 1;
                }

                if (!(obj is StationData))
                {
                    throw new Exception("Type missmatch");
                }

                StationData type = (StationData)obj;

                int thisMainType = Station.GetVariableByName("MainType").Value;
                int thatMainType = type.Station.GetVariableByName("MainType").Value;

                if (thisMainType > thatMainType)
                {
                    return -1;
                }

                if (thisMainType < thatMainType)
                {
                    return 1;
                }

                int thisSubType = Station.GetVariableByName("SubType").Value;
                int thatSubType = type.Station.GetVariableByName("SubType").Value;

                if (thisSubType > thatSubType)
                {
                    return -1;
                }

                if (thisSubType < thatSubType)
                {
                    return 1;
                }

                return 0;
            }
        }
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
        public ScriptMemory_RaceData_Player_Panel()
        {
            InitializeComponent();
            nudCredits.Maximum = int.MaxValue;
            nudCredits.Minimum = int.MinValue;
        }

        private ScriptInstance m_ScriptInstance;
        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("RaceData_Player"))
            {
                throw new NotSupportedException("Object doesn't inherit from RaceData_Player");
            }

            m_ScriptInstance = ScriptInstance;
            if (reload)
            {
                Reload();
            }
        }

        public void Reload()
        {

            nudCredits.Value = m_ScriptInstance.GetVariableByName("Credits").Value;
            nudFightRank.Value = m_ScriptInstance.GetVariableByName("FightRank").Value;
            nudTradeRank.Value = m_ScriptInstance.GetVariableByName("TradeRank").Value;
            #region Races
            lstRaces.Items.Clear();

            List<RaceData> races = new List<RaceData>();
            ScriptTableObject table = m_ScriptInstance.GetVariableByName("RaceDataScriptInstanceIDHashTable").GetAsHashTableObject();

            foreach (DynamicValue raceID in table.hashTable.ScanContents())
            {
                ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(raceID.Value);
                if (ScriptingObject.ScriptInstanceType == null)
                {
                    m_MessengerFunction(string.Format("ScriptInstance type undefined, expected RaceData : {0}", ScriptingObject.pSub.obj.Class));
                }
                else if (!ScriptingObject.ScriptInstanceType.InheritsFrom("RaceData"))
                {
                    if (!ScriptingObject.ScriptInstanceType.InheritsFrom("RaceData_Player"))
                    {
                        m_MessengerFunction(string.Format("ScriptInstance type \"{0}\" invalid, expected RaceData : {1}", ScriptingObject.ScriptInstanceType.Name, ScriptingObject.pSub.obj.Class));
                    }
                }
                else
                {
                    races.Add(new RaceData()
                    {
                        ScriptingObject = ScriptingObject,
                        raceID = (GameHook.RaceID)ScriptingObject.GetVariableByName("RaceID").Value
                    });
                }
            }

            races.Sort();
            races.Reverse();
            foreach (RaceData race in races)
            {
                lstRaces.Items.Add(race);
            }
            #endregion
            #region Ships
            lstOwnedShips.Items.Clear();

            List<ShipData> ships = new List<ShipData>();
            foreach (DynamicValue shipID in m_ScriptInstance.GetVariableByName("OwnedShipScriptInstanceIDHashTable").GetAsHashTableObject().hashTable.ScanContents())
            {
                ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(shipID.Value);
                if (ScriptingObject.ScriptInstanceType == null)
                {
                    m_MessengerFunction(string.Format("ScriptInstance type undefined, expected ship : {0}", ScriptingObject.pSub.obj.Class));
                }
                else if (!ScriptingObject.ScriptInstanceType.InheritsFrom("Ship"))
                {
                    m_MessengerFunction(string.Format("ScriptInstance type \"{0}\" invalid, expected ship : {1}", ScriptingObject.ScriptInstanceType.Name, ScriptingObject.pSub.obj.Class));
                }
                else
                {
                    ships.Add(new ShipData()
                    {
                        Ship = ScriptingObject
                    });
                }
            }
            try
            {
                ships.Sort();
                ships.Reverse();
            }
            catch (Exception)
            {

            }

            foreach (ShipData ship in ships)
            {
                lstOwnedShips.Items.Add(new ListItem()
                {
                    obj = ship.Ship,
                    txt = SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, ship.Ship.GetVariableByName("SubType").Value)
                }); ;
            }

            #endregion

            #region Stations

            lstOwnedStations.Items.Clear();

            List<StationData> stations = new List<StationData>();
            foreach (DynamicValue stationID in m_ScriptInstance.GetVariableByName("OwnedStationScriptInstanceIDHashTable").GetAsHashTableObject().hashTable.ScanContents())
            {
                ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(stationID.Value);
                if (ScriptingObject.ScriptInstanceType == null)
                {
                    m_MessengerFunction(string.Format("ScriptInstance type undefined, expected Station : {0}", ScriptingObject.pSub.obj.Class));
                }
                else if (!ScriptingObject.ScriptInstanceType.InheritsFrom("Station"))
                {
                    m_MessengerFunction(string.Format("ScriptInstance type \"{0}\" invalid, expected Station : {1}", ScriptingObject.ScriptInstanceType.Name, ScriptingObject.pSub.obj.Class));
                }
                else
                {
                    stations.Add(new StationData()
                    {
                        Station = ScriptingObject
                    });
                }

            }
            try
            {
                stations.Sort();
                stations.Reverse();
            }
            catch (Exception)
            {

            }

            foreach (StationData station in stations)
            {
                lstOwnedStations.Items.Add(new ListItem()
                {
                    obj = station.Station,
                    txt = SectorObject.GetSubTypeAsString((SectorObject.Main_Type)station.Station.GetVariableByName("MainType").Value, station.Station.GetVariableByName("SubType").Value)
                }); ;
            }
            #endregion
        }

        private void lstRaces_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IScriptMemoryObject_RaceData_Player_Panel_Load(object sender, EventArgs e)
        {
        }

        private void lstOwnedStations_DoubleClick(object sender, EventArgs e)
        {
            if (lstOwnedStations.SelectedIndex < 0 || lstOwnedStations.SelectedIndex >= lstOwnedStations.Items.Count)
            {
                return;
            }

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject((ScriptInstance)((ListItem)lstOwnedStations.Items[lstOwnedStations.SelectedIndex]).obj);
            display.Show();
        }

        private void lstOwnedShips_DoubleClick(object sender, EventArgs e)
        {
            if (lstOwnedShips.SelectedIndex < 0 || lstOwnedShips.SelectedIndex >= lstOwnedShips.Items.Count)
            {
                return;
            }

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject((ScriptInstance)((ListItem)lstOwnedShips.Items[lstOwnedShips.SelectedIndex]).obj);
            display.Show();
        }

        private void lstRaces_DoubleClick(object sender, EventArgs e)
        {
            if (lstRaces.SelectedIndex < 0 || lstRaces.SelectedIndex >= lstRaces.Items.Count)
            {
                return;
            }

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject(((RaceData)lstRaces.Items[lstRaces.SelectedIndex]).ScriptingObject);
            display.Show();
        }
    }
}
