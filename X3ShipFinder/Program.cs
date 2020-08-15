using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory.AP;
using X3TCTools.SectorObjects;

namespace X3ShipFinder
{
    class Program
    {
        public static GameHook GameHook { get; private set; }

        public struct Ship
        {
            public int SubType;
            public int Race;
            public int SectorX, SectorY;

            public override string ToString()
            {
                return string.Format("{0} | {1} {2}",GameHook.gateSystemObject.GetSectorName(SectorX, SectorY), SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, SubType), ((GameHook.RaceID)Race).ToString());
            }
        }

        public static List<Ship> ships = new List<Ship>();

        public static List<string> sectors = new List<string>();
        static void Main(string[] args)
        {
            // Hook into the game memory
            var processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();

            GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);

            var raceData = GameHook.storyBase.GetEventObject(555).GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();//GameHook.sectorObjectManager.GetSpace().EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>().OwningRaceDataEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();

            AddRace(raceData);

            File.WriteAllText ("./a.txt", string.Join("\n", ships));

        }

        public static void AddRace(ScriptMemoryObject_AP_RaceData raceData)
        {
            foreach (var shipID in raceData.OwnedShipEventObjectIDHashTableObject.hashTable.ScanContents())
            {
                var ship = GameHook.storyBase.GetEventObject(shipID.Value).GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>();

                ships.Add(new Ship()
                {
                    SubType = ship.SubType,
                    Race = raceData.RaceID,
                    SectorX = ship.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>().SectorX,
                    SectorY = ship.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>().SectorY,
                });
            }
        }

    }
}
