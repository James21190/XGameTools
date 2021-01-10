using System;
using System.Collections.Generic;
using System.Windows.Forms;
using X3Tools;

using X3Tools.Bases.SectorBase_Objects;
using X3Tools.Bases.StoryBase_Objects;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;

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
            public ScriptInstance ScriptingObject;
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
            public ScriptInstance ScriptingObject;
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
        public void LoadObject(ScriptInstance ScriptingObject)
        {
            m_Data = ScriptingObject.GetMemoryInterfaceRaceData();
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
                    ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(shipID.Value);
                    IScriptMemoryObject_Ship shipData = ScriptingObject.GetMemoryInterfaceShip();
                    IScriptMemoryObject_Sector sectorData = shipData.CurrentSectorScriptingObject.GetMemoryInterfaceSector();
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
                    ScriptInstance ScriptingObject = GameHook.storyBase.GetScriptingObject(factoryID.Value);
                    IScriptMemoryObject_Station factoryData = ScriptingObject.GetMemoryInterfaceStation();
                    IScriptMemoryObject_Sector sectorData = factoryData.CurrentSectorScriptingObject.GetMemoryInterfaceSector();
                    factories.Add(new StationData()
                    {
                        ScriptingObject = ScriptingObject,
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

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject((ScriptInstance)((ListItem)lstOwnedShips.Items[lstOwnedShips.SelectedIndex]).obj);
            display.Show();
        }

        private void lstOwnedStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOwnedStations.SelectedIndex < 0 || lstOwnedStations.SelectedIndex >= lstOwnedStations.Items.Count)
            {
                return;
            }

            ScriptInstanceDisplay display = new ScriptInstanceDisplay();
            display.LoadObject((ScriptInstance)((ListItem)lstOwnedStations.Items[lstOwnedStations.SelectedIndex]).obj);
            display.Show();
        }
    }
}

