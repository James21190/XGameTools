using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X2Lib.RAM;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Galaxy;

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
        }

        private static Random _Rand;
        private static int _Randomness;

        public class GateCollection
        {
            public List<GateData> Gates;
            public List<Sector> Sectors;
            private List<GateData> _ToRandomize = new List<GateData>();

            public void LinkGates(GateData gateA, GateData gateB)
            {
                var gateC = GetGate(gateA.DestSectorX, gateA.DestSectorY, gateA.DestIndex);
                var gateD = GetGate(gateB.DestSectorX,gateB.DestSectorY, gateB.DestIndex);

                gateA.DestSectorX = gateB.SectorX;
                gateA.DestSectorY = gateB.SectorY;
                gateA.DestIndex =   gateB.Index;
                gateB.DestSectorX = gateA.SectorX;
                gateB.DestSectorY = gateA.SectorY;
                gateB.DestIndex =   gateA.Index;

                gateC.DestSectorX = gateD.SectorX;
                gateC.DestSectorY = gateD.SectorY;
                gateC.DestIndex =   gateD.Index;
                gateD.DestSectorX = gateC.SectorX;
                gateD.DestSectorY = gateC.SectorY;
                gateD.DestIndex =   gateC.Index;
            }

            public Sector GetSector(int x, int y)
            {
                foreach (var sector in Sectors)
                    if (sector.SectorX == x && sector.SectorY == y)
                        return sector;
                return null;
            }

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
                return Gates[_Rand.Next(Gates.Count)];
            }

            private GateData _GetRandomGateFromToRandomize()
            {
                return _ToRandomize[_Rand.Next(_ToRandomize.Count)];
            }

            public void RandomizePairs(int limit = -1, bool resetUsedList = true)
            {
                if (resetUsedList)
                    _ToRandomize = new List<GateData>(Gates);
                int counter = 0;

                while (_ToRandomize.Count > 1 && counter != limit)
                {
                    var gateA = _GetRandomGateFromToRandomize();
                    _ToRandomize.Remove(gateA);
                    var gateB = _GetRandomGateFromToRandomize();
                    _ToRandomize.Remove(gateB);

                    LinkGates(gateA, gateB);
                    counter++;
                }
            }

            public void WriteScriptInstance(ref GameHook gameHook)
            {
                foreach (var gate in Gates)
                    gate.ApplyDestToScriptInstance(ref gameHook);
            }

            public void WriteGalaxyBase(ref GameHook gameHook)
            {
                var gb = gameHook.GalaxyBase;
                foreach (var gate in Gates)
                    gate.ApplyDestToGalaxyBase(ref gb);
            }

            private void _SearchSectors(ref List<Sector> unvisited, Sector origin)
            {
                unvisited.Remove(origin);
                foreach(var gate in origin.Gates)
                {
                    var nextSector = GetSector(gate.DestSectorX, gate.DestSectorY);
                    if(unvisited.Contains(nextSector))
                        _SearchSectors(ref unvisited, nextSector);
                }
            }

            public void ValidateAndFix()
            {
                // Fix islands
                while (true)
                {
                    var origin = Sectors[_Rand.Next(Sectors.Count)];
                    List<Sector> unvisited = new List<Sector>(Sectors);

                    _SearchSectors(ref unvisited, origin);

                    // Fix then repeat if needed
                    if(unvisited.Count > 0)
                    {
                        var targetSector = unvisited[_Rand.Next(unvisited.Count())];
                        Sector toConnect;
                        do
                        {
                            toConnect = Sectors[_Rand.Next(Sectors.Count)];
                        } while (unvisited.Contains(toConnect));

                        var gateA = targetSector.Gates[_Rand.Next(targetSector.Gates.Count)];
                        var gateB = toConnect.Gates[_Rand.Next(toConnect.Gates.Count)];

                        LinkGates(gateA, gateB);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public class Sector
        {
            public int SectorX;
            public int SectorY;
            public List<GateData> Gates = new List<GateData>();

            public override string ToString()
            {
                return "Sector " + SectorX + ", " + SectorY;
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

            public override string ToString()
            {
                return "Gate " + SectorX+ ", " + SectorY + ", " + Index;
            }

            public void ApplyDestToScriptInstance(ref GameHook gameHook)
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
            public void ApplyDestToGalaxyBase(ref GalaxyBase gameHook)
            {
                var sectorIndex = gameHook.GetSectorIndex(SectorX, SectorY);
                var gate = gameHook.Sectors[sectorIndex].Gates[Index];
                gate.DestinationSectorX = DestSectorX;
                gate.DestinationSectorY = DestSectorY;
                gate.DestinationSectorIndex = DestIndex;

                gate.WriteSafeToMemory();
            }
        }

        public void RandomizeGateConnections()
        {
            button1.Enabled = false;
            _Rand = new Random((int)numericUpDown2.Value);
            _Randomness = (int)numericUpDown1.Value;
            backgroundWorker1.RunWorkerAsync();
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

            List<Sector> Sectors = new List<Sector>();
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

                    var CurrentSector = new Sector();
                    CurrentSector.SectorX = SectorX;
                    CurrentSector.SectorY = SectorY;

                    var gateHashTable = _GameHook.StoryBase.GetScriptHashTable((IntPtr)sector_ScriptInstance.GetVariable("GateScriptInstanceIDHashTable").Value);
                    
                    var gateIDs = gateHashTable.ScanContents();

                    bool hasValidGates = false;
                    // For every gate in the sector
                    foreach(var gateID in gateIDs)
                    {
                        var gate_ScriptInstance = _GameHook.StoryBase.GetScriptInstance(gateID.Value);
                        gate_ScriptInstance.ReferenceType = _GameHook.DataFileManager.GetScriptInstanceType(gate_ScriptInstance.Class);

                        var index = gate_ScriptInstance.GetVariable("Index").Value;
                        var destIndex = gate_ScriptInstance.GetVariable("Destination_Index").Value;
                        if (index == -1 || destIndex == -1)
                            continue;

                        //if (SectorX > 4 || SectorY > 4)
                        //    continue;

                        var destX = gate_ScriptInstance.GetVariable("Destination_X").Value;
                        var destY = gate_ScriptInstance.GetVariable("Destination_Y").Value;

                        var newData = new GateData()
                        {
                            ScriptInstanceID = gate_ScriptInstance.ID,
                            Index = index,
                            SectorX = SectorX,
                            SectorY = SectorY,
                            DestIndex = destIndex,
                            DestSectorX = destX,
                            DestSectorY = destY
                        };

                        CurrentSector.Gates.Add(newData);
                        GateList.Add(newData);

                        hasValidGates = true;
                    }
                    if(hasValidGates)
                        Sectors.Add(CurrentSector);
                }
            }

            return new GateCollection()
            {
                Gates = GateList,
                Sectors = Sectors
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var Gates = GetGateList();
            backgroundWorker1.ReportProgress(20);

            Gates.RandomizePairs((int)(Gates.Gates.Count * _Randomness / 100.0f));
            backgroundWorker1.ReportProgress(40);

            Gates.ValidateAndFix();
            backgroundWorker1.ReportProgress(60);

            Gates.WriteScriptInstance(ref _GameHook);
            backgroundWorker1.ReportProgress(80);
            Gates.WriteGalaxyBase(ref _GameHook);
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomizeGateConnections();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            numericUpDown2.Value = rand.Next((int)numericUpDown2.Minimum, (int)numericUpDown2.Maximum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            numericUpDown1.Value = rand.Next((int)numericUpDown1.Minimum, (int)numericUpDown1.Maximum);
        }
    }
}
