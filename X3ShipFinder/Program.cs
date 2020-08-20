using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X3TCTools;
using X3TCTools.Bases.Scripting;
using X3TCTools.Bases.Scripting.ScriptingMemory;
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
            public GameHook.RaceID Race;
            public int SectorX, SectorY;

            public override string ToString()
            {
                return string.Format("{0},{1},{2}",Race.ToString(), SectorObject.GetSubTypeAsString(SectorObject.Main_Type.Ship, SubType), GameHook.gateSystemObject.GetSectorName(SectorX, SectorY));
            }
        }

        public static List<Ship> ships = new List<Ship>();

        public static List<string> sectors = new List<string>();
        static void Main(string[] args)
        {
            // Hook into the game memory
            var processX3AP = Process.GetProcessesByName("X3AP").FirstOrDefault();

            GameHook = new GameHook(processX3AP, GameHook.GameVersions.X3AP);

            var PlayerRaceData = GameHook.sectorObjectManager.GetPlayerObject().EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>().OwnerDataEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>();

            var RaceHashTable = PlayerRaceData.RaceDataEventObjectIDHashTable;

            foreach(var race in RaceHashTable.hashTable.ScanContents())
            {
                var raceEventObject = GameHook.storyBase.GetEventObject(race.Value);
                IScriptMemoryObject_RaceData raceData = raceEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>();
                if (raceData != null)
                {
                    Console.WriteLine("Recording " + raceData.OwnedShipEventObjectIDHashTableObject.hashTable.Count + " ships in race " + raceData.RaceID.ToString());
                    AddRace(raceData);
                }
                
            }

            Console.WriteLine("Writing " + ships.Count() + " to file...");

            File.WriteAllText("./a.csv", string.Join("\n", ships));

        }

        public static void AddRace(IScriptMemoryObject_RaceData raceData)
        {
            foreach (var shipID in raceData.OwnedShipEventObjectIDHashTableObject.hashTable.ScanContents())
            {
                try
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
                catch (Exception)
                {

                }
            }
        }

    }
}
