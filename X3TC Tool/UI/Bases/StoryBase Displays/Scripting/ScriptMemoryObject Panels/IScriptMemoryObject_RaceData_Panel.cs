using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools;

using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Sector_Objects;

namespace X3_Tool.UI.Bases.StoryBase_Displays.Scripting.ScriptMemoryObject_Panels
{
    public partial class IScriptMemoryObject_RaceData_Panel : UserControl, IScriptMemoryObject_Panel
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
            public ScriptingObject ScriptingObject;
            public IScriptMemoryObject_Ship ship;
            public IScriptMemoryObject_Sector sector;

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


                if (ship.SubType > type.ship.SubType)
                {
                    return -1;
                }

                if (ship.SubType < type.ship.SubType)
                {
                    return 1;
                }

                if (sector.SectorX > type.sector.SectorX)
                {
                    return -1;
                }

                if (sector.SectorX < type.sector.SectorX)
                {
                    return 1;
                }

                if (sector.SectorY > type.sector.SectorY)
                {
                    return -1;
                }

                if (sector.SectorY < type.sector.SectorY)
                {
                    return 1;
                }

                return 0;
            }
        }

        private struct StationData : IComparable
        {
            public ScriptingObject ScriptingObject;
            public IScriptMemoryObject_Station factory;
            public IScriptMemoryObject_Sector sector;

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

                if (factory.MainType > type.factory.MainType)
                {
                    return -1;
                }

                if (factory.MainType < type.factory.MainType)
                {
                    return 1;
                }

                if (factory.SubType > type.factory.SubType)
                {
                    return -1;
                }

                if (factory.SubType < type.factory.SubType)
                {
                    return 1;
                }

                if (sector.SectorX > type.sector.SectorX)
                {
                    return -1;
                }

                if (sector.SectorX < type.sector.SectorX)
                {
                    return 1;
                }

                if (sector.SectorY > type.sector.SectorY)
                {
                    return -1;
                }

                if (sector.SectorY < type.sector.SectorY)
                {
                    return 1;
                }

                return 0;
            }
        }

        public IScriptMemoryObject_RaceData_Panel()
        {
            InitializeComponent();
        }

        private IScriptMemoryObject_RaceData m_Data;
        public void LoadObject(ScriptingObject ScriptingObject)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3AP: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>(); break;
                case GameHook.GameVersions.X3TC: m_Data = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData>(); break;
            }
            Reload();
        }

        public void LoadObject(IScriptMemoryObject_RaceData scriptMemoryObject_RaceData)
        {
            m_Data = scriptMemoryObject_RaceData;
            Reload();
        }

        public void Reload()
        {
            textBox1.Text = m_Data.RaceID.ToString();
            lstOwnedShips.Items.Clear();
            lstOwnedStations.Items.Clear();

            var gso = GameHook.gateSystemObject;
            #region Ships

            List<ShipData> ships = new List<ShipData>();
            foreach (DynamicValue shipID in m_Data.OwnedShipScriptingObjectIDHashTableObject.hashTable.ScanContents())
            {
                try
                {
                    ScriptingObject ScriptingObject = GameHook.storyBase.GetScriptingObject(shipID.Value);
                    IScriptMemoryObject_Ship shipData;
                    IScriptMemoryObject_Sector sectorData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            shipData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>();
                            sectorData = shipData.CurrentSectorScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            shipData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>();
                            sectorData = shipData.CurrentSectorScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                            break;
                        default: throw new Exception();
                    }

                    if (shipData.IsValid && sectorData.IsValid)
                    {
                        ships.Add(new ShipData()
                        {
                            ScriptingObject = ScriptingObject,
                            ship = shipData,
                            sector = sectorData
                        });
                    }
                }
                catch (Exception)
                {

                }
            }

            ships.Sort();
            ships.Reverse();

            foreach (ShipData ship in ships)
            {
                lstOwnedShips.Items.Add(new ListItem()
                {
                    obj = ship.ScriptingObject,
                    txt = string.Format("{0} ({1})", SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, ship.ship.SubType), gso.GetSectorName(ship.sector.SectorX, ship.sector.SectorY))
                });
            }

            #endregion

            #region Stations

            List<StationData> factories = new List<StationData>();
            foreach (DynamicValue factoryID in m_Data.OwnedStationScriptingObjectIDHashTableObject.hashTable.ScanContents())
            {
                try
                {
                    ScriptingObject ScriptingObject = GameHook.storyBase.GetScriptingObject(factoryID.Value);
                    IScriptMemoryObject_Station factoryData;
                    IScriptMemoryObject_Sector sectorData;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3TC:
                            factoryData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Station>();
                            sectorData = factoryData.CurrentSectorScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                            break;
                        case GameHook.GameVersions.X3AP:
                            factoryData = ScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Station>();
                            sectorData = factoryData.CurrentSectorScriptingObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                            break;
                        default: throw new Exception();
                    }

                    if (/*factoryData.IsValid &&*/ sectorData.IsValid)
                    {
                        factories.Add(new StationData()
                        {
                            ScriptingObject = ScriptingObject,
                            factory = factoryData,
                            sector = sectorData
                        });
                    }
                }
                catch (Exception)
                {

                }
            }

            factories.Sort();
            factories.Reverse();

            foreach (StationData factory in factories)
            {
                lstOwnedStations.Items.Add(new ListItem()
                {
                    obj = factory.ScriptingObject,
                    txt = string.Format("{0} ({1})", SectorObject.GetSubTypeAsString((SectorObject.Main_Type)factory.factory.MainType, factory.factory.SubType), gso.GetSectorName(factory.sector.SectorX, factory.sector.SectorY))
                });
            }

            #endregion
        }

        private void lstOwnedShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedShips.SelectedIndex < 0 || lstOwnedShips.SelectedIndex >= lstOwnedShips.Items.Count)
            {
                return;
            }

            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject((ScriptingObject)((ListItem)lstOwnedShips.Items[lstOwnedShips.SelectedIndex]).obj);
            display.Show();
        }

        private void lstOwnedStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedStations.SelectedIndex < 0 || lstOwnedStations.SelectedIndex >= lstOwnedStations.Items.Count)
            {
                return;
            }

            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject((ScriptingObject)((ListItem)lstOwnedStations.Items[lstOwnedStations.SelectedIndex]).obj);
            display.Show();
        }
    }
}

