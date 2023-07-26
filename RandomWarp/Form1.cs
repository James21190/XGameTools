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

        public static Random _Rand;
        public static int _Randomness;


        public void RandomizeGateConnections()
        {
            button1.Enabled = false;
            _Rand = new Random((int)numericUpDown2.Value);
            _Randomness = (int)numericUpDown1.Value;
            backgroundWorker1.RunWorkerAsync();
        }

        internal GateRandomizer GetGateList()
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

            return new GateRandomizer()
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
