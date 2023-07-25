using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommonLib.RAM;

namespace RandomWarp
{
    public partial class Form1 : Form
    {
        GameHook _GameHook;
        public Form1()
        {
            InitializeComponent();


            _GameHook = XWrapperLib.XGameHookFactory.GetGameHook();

            if (_GameHook == null)
            {
                this.Close();
            }


            RandomizeGateConnections();
        }

        public class GateCollection
        {
            public List<GateData> Gates;
            public GateData GetGate(int sectorX, int sectorY, int index)
            {
                foreach(var gate in Gates)
                {
                    if (gate.SectorX == sectorX && gate.SectorY == sectorY && gate.Index == index)
                        return gate;
                }
                return null;
            }

            public GateData GetRandomGate()
            {
                Random r = new Random();

                return Gates[r.Next(Gates.Count)];
            }
        }
        public class GateData
        {
            public int ScriptInstanceID;
            public int Index;
            public int SectorX;
            public int SectorY;
            public int DestIndex;
            public int DestSectorX;
            public int DestSectorY;

            public void ApplyDestToMemory(ref GameHook gameHook)
            {
                var scriptInstance = gameHook.StoryBase.GetScriptInstance(ScriptInstanceID);
                scriptInstance.ReferenceType = gameHook.DataFileManager.GetScriptInstanceType(scriptInstance.Class);

                var destX = scriptInstance.GetVariable("Destination_X");
                var destY = scriptInstance.GetVariable("Destination_Y");
                var destIndex = scriptInstance.GetVariable("Destination_Index");

                destX.Value = DestSectorX;
                destY.Value = DestSectorY;
                destIndex.Value = DestIndex;

                // Write to game memory
                gameHook.WriteBinaryObject(destX.pThis, destX);
                gameHook.WriteBinaryObject(destY.pThis, destY);
                gameHook.WriteBinaryObject(destIndex.pThis, destIndex);
            }
        }

        public void RandomizeGateConnections()
        {
            var Gates = GetGateList();

            while(Gates.Gates.Count > 1)
            {
                var gateA = Gates.GetRandomGate();
                var gateB = Gates.GetRandomGate();

                if(gateA != gateB)
                {
                    Gates.Gates.Remove(gateA);
                    Gates.Gates.Remove(gateB);

                    gateA.DestSectorX = gateB.SectorX;
                    gateA.DestSectorY = gateB.SectorY;
                    gateA.DestIndex = gateB.Index;

                    gateB.DestSectorX = gateA.SectorX;
                    gateB.DestSectorY = gateA.SectorY;
                    gateB.DestIndex = gateA.Index;

                    gateA.ApplyDestToMemory(ref _GameHook);
                    gateB.ApplyDestToMemory(ref _GameHook);
                }
            }
        }

        public GateCollection GetGateList()
        {
            // Get list of race ids
            var playerShip_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(_GameHook.SectorBase.Player.ScriptInstanceID);
            playerShip_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(playerShip_ScriptInstance.Class);
            var playerRace_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(playerShip_ScriptInstance.GetVariable("OwningRaceScriptInstanceID").Value);
            playerRace_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(playerRace_ScriptInstance.Class);

            var raceHashTable = _GameHook.StoryBase.GetScriptHashTable((IntPtr)playerRace_ScriptInstance.GetVariable("RaceDataWithSectorScriptInstanceIDHashTable").Value);

            var racesIDs = raceHashTable.ScanContents();

            // Get every gate
            List<GateData> GateList = new List<GateData>();

            foreach(var raceID in racesIDs)
            {
                var race_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(raceID.Value);
                race_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(race_ScriptInstance.Class);

                var sectorHashTable = _GameHook.StoryBase.GetScriptHashTable((IntPtr)race_ScriptInstance.GetVariable("OwnedSectorScriptInstanceIDHashTable").Value);
                var sectorIDs = sectorHashTable.ScanContents();

                foreach(var sectorID in sectorIDs)
                {
                    var sector_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(sectorID.Value);
                    sector_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(sector_ScriptInstance.Class);

                    var SectorX = sector_ScriptInstance.GetVariable("Sector_X").Value;
                    var SectorY = sector_ScriptInstance.GetVariable("Sector_Y").Value;

                    var gateHashTable = _GameHook.StoryBase.GetScriptHashTable((IntPtr)sector_ScriptInstance.GetVariable("GateScriptInstanceIDHashTable").Value);
                    
                    var gateIDs = gateHashTable.ScanContents();

                    foreach(var gateID in gateIDs)
                    {
                        var gate_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(gateID.Value);
                        gate_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(gate_ScriptInstance.Class);

                        GateList.Add(new GateData()
                        {
                            ScriptInstanceID = gate_ScriptInstance.ID,
                            Index = gate_ScriptInstance.GetVariable("Index").Value,
                            SectorX = SectorX,
                            SectorY = SectorY,
                            DestIndex = gate_ScriptInstance.GetVariable("Destination_Index").Value,
                            DestSectorX = gate_ScriptInstance.GetVariable("Destination_X").Value,
                            DestSectorY = gate_ScriptInstance.GetVariable("Destination_Y").Value
                        });

                    }
                }
            }

            return new GateCollection()
            {
                Gates = GateList
            };
        }
    }
}
