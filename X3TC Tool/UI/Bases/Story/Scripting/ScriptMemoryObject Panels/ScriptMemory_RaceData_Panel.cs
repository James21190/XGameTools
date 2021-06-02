using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools.RAM;
using X3Tools.RAM.Bases.Galaxy;
using X3Tools.RAM.Bases.Sector;
using X3Tools.RAM.Bases.Story.Scripting;

namespace X3TC_RAM_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class ScriptMemory_RaceData_Panel : UserControl, IScriptMemoryObject_Panel
    {
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

        public ScriptMemory_RaceData_Panel()
        {
            InitializeComponent();
        }

        private ScriptInstance m_ScriptInstance;

        private MessengerFunction m_MessengerFunction;
        public MessengerFunction MessengerFunction { get => m_MessengerFunction; set => m_MessengerFunction = value; }

        public void LoadObject(ScriptInstance ScriptInstance, bool reload = true)
        {
            if (!ScriptInstance.ScriptInstanceType.InheritsFrom("RaceData"))
            {
                throw new NotSupportedException("Object doesn't inherit from RaceData");
            }

            m_ScriptInstance = ScriptInstance;
            if (reload)
            {
                Reload();
            }
        }

        public void Reload()
        {

            textBox1.Text = ((GameHook.RaceID)m_ScriptInstance.GetVariableByName("RaceID").Value).ToString();

            GalaxyBase galaxyBase = GameHook.galaxyBase;

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
                    m_MessengerFunction(string.Format("ScriptInstance type undefined, expected station : {0}", ScriptingObject.pSub.obj.Class));
                }
                else if (!ScriptingObject.ScriptInstanceType.InheritsFrom("Station"))
                {
                    m_MessengerFunction(string.Format("ScriptInstance type \"{0}\" invalid, expected station : {1}", ScriptingObject.ScriptInstanceType.Name, ScriptingObject.pSub.obj.Class));
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
    }
}

