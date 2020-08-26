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
using X3TCTools.SectorObjects;

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
                    case GameHook.GameVersions.X3TC:
                        switch (m_EventObject.ObjectType)
                        {
                            case EventObject.EventObject_Type.RaceData: obj = new ScriptMemoryObject_TC_RaceData(); break;
                            case EventObject.EventObject_Type.RaceData_Player: obj = new ScriptMemoryObject_TC_RaceData_Player(); break;
                            default: throw new Exception();
                        }
                        break;
                    case GameHook.GameVersions.X3AP:
                        switch (m_EventObject.ObjectType)
                        {
                            case EventObject.EventObject_Type.RaceData: obj = new ScriptMemoryObject_AP_RaceData(); break;
                            case EventObject.EventObject_Type.RaceData_Player: obj = new ScriptMemoryObject_AP_RaceData_Player(); break;
                            default: throw new Exception();
                        }
                        break;
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

        struct ListItem
        {
            public object obj;
            public string txt;

            public override string ToString()
            {
                return txt;
            }
        }

        struct ShipData : IComparable
        {
            public EventObject eventObject;
            public IScriptMemoryObject_Ship ship;
            public IScriptMemoryObject_Sector sector;

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                if (!(obj is ShipData)) throw new Exception("Type missmatch");

                var type = (ShipData)obj;


                if (this.ship.SubType > type.ship.SubType) return -1;
                if (this.ship.SubType < type.ship.SubType) return 1;

                if (this.sector.SectorX > type.sector.SectorX) return -1;
                if (this.sector.SectorX < type.sector.SectorX) return 1;

                if (this.sector.SectorY > type.sector.SectorY) return -1;
                if (this.sector.SectorY < type.sector.SectorY) return 1;
                return 0;
            }
        }

        struct StationData : IComparable
        {
            public EventObject eventObject;
            public IScriptMemoryObject_Station factory;
            public IScriptMemoryObject_Sector sector;

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                if (!(obj is StationData)) throw new Exception("Type missmatch");

                var type = (StationData)obj;

                if (this.factory.MainType > type.factory.MainType) return -1;
                if (this.factory.MainType < type.factory.MainType) return 1;

                if (this.factory.SubType > type.factory.SubType) return -1;
                if (this.factory.SubType < type.factory.SubType) return 1;

                if (this.sector.SectorX > type.sector.SectorX) return -1;
                if (this.sector.SectorX < type.sector.SectorX) return 1;

                if (this.sector.SectorY > type.sector.SectorY) return -1;
                if (this.sector.SectorY < type.sector.SectorY) return 1;
                return 0;
            }
        }

        public void Reload()
        {
            var raceData = m_RaceData;
            textBox1.Text = raceData.RaceID.ToString();
            lstOwnedShips.Items.Clear();

            #region Ships

            List<ShipData> ships = new List<ShipData>();
            foreach (var shipID in raceData.OwnedShipEventObjectIDHashTableObject.hashTable.ScanContents())
            {
                try
                {
                    EventObject eventObject = GameHook.storyBase.GetEventObject(shipID.Value);
                    IScriptMemoryObject_Ship shipData;
                    IScriptMemoryObject_Sector sectorData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            shipData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>();
                            sectorData = shipData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            shipData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>();
                            sectorData = shipData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                            break;
                        default: throw new Exception();
                    }

                    if (shipData.IsValid && sectorData.IsValid)
                        ships.Add(new ShipData()
                        {
                            eventObject = eventObject,
                            ship = shipData,
                            sector = sectorData
                        });
                }
                catch (Exception)
                {

                }
            }

            ships.Sort();
            ships.Reverse();

            foreach(var ship in ships)
            {
                lstOwnedShips.Items.Add(new ListItem()
                {
                    obj = ship.eventObject,
                    txt = string.Format("{0} ({1})", SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, ship.ship.SubType), GameHook.gateSystemObject.GetSectorName(ship.sector.SectorX, ship.sector.SectorY))
                });
            }

            #endregion

            #region Stations

            List<StationData> factories = new List<StationData>();
            foreach (var factoryID in raceData.OwnedStationEventObjectIDHashTableObject.hashTable.ScanContents())
            {
                try
                {
                    EventObject eventObject = GameHook.storyBase.GetEventObject(factoryID.Value);
                    IScriptMemoryObject_Station factoryData;
                    IScriptMemoryObject_Sector sectorData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            factoryData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Station>();
                            sectorData = factoryData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            factoryData = eventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Station>();
                            sectorData = factoryData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                            break;
                        default: throw new Exception();
                    }

                    if (/*factoryData.IsValid &&*/ sectorData.IsValid)
                        factories.Add(new StationData()
                        {
                            eventObject = eventObject,
                            factory = factoryData,
                            sector = sectorData
                        });
                }
                catch (Exception)
                {

                }
            }

            factories.Sort();
            factories.Reverse();

            foreach (var factory in factories)
            {
                lstOwnedStations.Items.Add(new ListItem()
                {
                    obj = factory.eventObject,
                    txt = string.Format("{0} ({1})", SectorObject.GetSubTypeAsString((SectorObject.Main_Type)factory.factory.MainType, factory.factory.SubType), GameHook.gateSystemObject.GetSectorName(factory.sector.SectorX, factory.sector.SectorY))
                });
            }

            #endregion
        }

        private void eventObjectPannel1_EventObjectLoaded(object sender, EventArgs e)
        {
            m_EventObject = eventObjectPannel1.EventObject;
            Reload();
        }

        private void lstOwnedShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedShips.SelectedIndex < 0 || lstOwnedShips.SelectedIndex >= lstOwnedShips.Items.Count) return;
            var display = new EventObjectDisplay();
            display.LoadObject((EventObject)((ListItem)lstOwnedShips.Items[lstOwnedShips.SelectedIndex]).obj, EventObjectDisplay.LoadAsItems.Ship);
            display.Show();
        }

        private void lstOwnedFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedStations.SelectedIndex < 0 || lstOwnedStations.SelectedIndex >= lstOwnedStations.Items.Count) return;
            var display = new EventObjectDisplay();
            display.LoadObject((EventObject)((ListItem)lstOwnedStations.Items[lstOwnedStations.SelectedIndex]).obj, EventObjectDisplay.LoadAsItems.Ship);
            display.Show();
        }
    }
}
