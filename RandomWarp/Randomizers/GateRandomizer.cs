using System;
using System.Collections.Generic;
using System.Linq;
using XCommonLib.RAM.Bases.Galaxy;
using XCommonLib.RAM.Bases.Story;

namespace Randomizer.Randomizers
{
    public static class GateRandomizer
    {
        private class GateData : IComparable
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
                return "Gate " + SectorX + ", " + SectorY + ", " + Index;
            }

            public void ApplyDestToScriptInstance(ref StoryBase storyBase)
            {
                var scriptInstance = storyBase.GetScriptInstance(ScriptInstanceID);
                scriptInstance.ReferenceType = Program.GameHook.DataFileManager.GetScriptInstanceType(scriptInstance.Class);

                var destX = scriptInstance.GetVariable("Destination_X");
                var destY = scriptInstance.GetVariable("Destination_Y");
                var destIndex = scriptInstance.GetVariable("Destination_Index");

                destX.Value = DestSectorX;
                destY.Value = DestSectorY;
                destIndex.Value = DestIndex;

                // Write to game memory
                Program.GameHook.WriteBinaryObject(destX.pThis, destX);
                Program.GameHook.WriteBinaryObject(destY.pThis, destY);
                Program.GameHook.WriteBinaryObject(destIndex.pThis, destIndex);
            }
            public void ApplyDestToGalaxyBase(ref GalaxyBase galaxyBase)
            {
                var sectorIndex = galaxyBase.GetSectorIndex(SectorX, SectorY);
                var gate = galaxyBase.Sectors[sectorIndex].Gates[Index];
                gate.DestinationSectorX = DestSectorX;
                gate.DestinationSectorY = DestSectorY;
                gate.DestinationSectorIndex = DestIndex;

                gate.WriteToMemory();
            }

            public int CompareTo(object obj)
            {
                var other = (GateData)obj;

                if (SectorX > other.SectorX) return 1;
                if (SectorX < other.SectorX) return -1;

                if (SectorY > other.SectorY) return 1;
                if (SectorY < other.SectorY) return -1;

                if (Index > other.Index) return 1;
                if (Index < other.Index) return -1;

                return 0;
            }
        }

        private class Sector
        {
            public int SectorX;
            public int SectorY;
            public List<GateData> Gates = new List<GateData>();

            public override string ToString()
            {
                return "Sector " + SectorX + ", " + SectorY;
            }
        }

        private static List<GateData> _Gates;
        private static List<Sector> _Sectors;
        private static Random _Random;
        private static int _GateRandomness;

        public static void RandomizeGateConnections(int randomSeed, int gateRandomness)
        {
            _Random = new Random(randomSeed);
            _GateRandomness = gateRandomness;

            _UpdateData();
            _RemoveUnlinkedGates();
            _RandomizePairs();
            _ValidateAndFixAssumeBidirectional();
            WriteScriptInstance();
            WriteGalaxyBase();
        }

        private static void _UpdateData()
        {
            List<XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance> sector_ScriptInstances = new List<XCommonLib.RAM.Bases.Story.Scripting.ScriptInstance>();
            var ids = Program.GameHook.StoryBase.GetAllScriptInstances();
            foreach (var scriptInstanceID in ids)
            {
                var scriptInstance = Program.GameHook.StoryBase.GetScriptInstance(scriptInstanceID);
                scriptInstance.ReferenceType = Program.GameHook.DataFileManager.GetScriptInstanceType(scriptInstance.Class);

                if (scriptInstance.ReferenceType != null && scriptInstance.ReferenceType.IsDerivedFrom("Sector"))
                {
                    sector_ScriptInstances.Add(scriptInstance);
                }

                if (sector_ScriptInstances.Count == 480)
                    break;
            }

            _Gates = new List<GateData>();
            _Sectors = new List<Sector>();

            foreach (var sector_ScriptInstance in sector_ScriptInstances)
            {
                var SectorX = sector_ScriptInstance.GetVariable("Sector_X").Value;
                var SectorY = sector_ScriptInstance.GetVariable("Sector_Y").Value;

                var CurrentSector = new Sector();
                CurrentSector.SectorX = SectorX;
                CurrentSector.SectorY = SectorY;

                var gateHashTable = Program.GameHook.StoryBase.GetScriptHashTable((IntPtr)sector_ScriptInstance.GetVariable("GateScriptInstanceIDHashTable").Value);

                var gateIDs = gateHashTable.ScanContents();

                bool hasValidGates = false;
                // For every gate in the sector
                foreach (var gateID in gateIDs)
                {
                    var gate_ScriptInstance = Program.GameHook.StoryBase.GetScriptInstance(gateID.Value);
                    gate_ScriptInstance.ReferenceType = Program.GameHook.DataFileManager.GetScriptInstanceType(gate_ScriptInstance.Class);

                    var index = gate_ScriptInstance.GetVariable("Index").Value;
                    var destIndex = gate_ScriptInstance.GetVariable("Destination_Index").Value;
                    if (index == -1 || destIndex == -1)
                        continue;

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
                    _Gates.Add(newData);

                    hasValidGates = true;
                }
                if (hasValidGates)
                    _Sectors.Add(CurrentSector);
            }

            _Gates.Sort();
        }
        private static void _RemoveUnlinkedGates()
        {
            for (int s = 0; s < _Sectors.Count;)
            {
                var sector = _Sectors[s];
                for (int g = 0; g < sector.Gates.Count;)
                {
                    var gate = sector.Gates[g];
                    if (_GetDest(gate) == null)
                    {
                        sector.Gates.RemoveAt(g);
                        _Gates.Remove(gate);
                    }
                    else
                    {
                        g++;
                    }
                }
                if (sector.Gates.Count == 0)
                {
                    _Sectors.RemoveAt(s);
                }
                else
                {
                    s++;
                }
            }
        }
        private static void _RandomizePairs()
        {
            List<GateData> toRandomize = new List<GateData>(_Gates);

            GateData getRandomGateFromToRandomize()
            {
                return toRandomize[_Random.Next(toRandomize.Count)];
            }

            while (toRandomize.Count > _Gates.Count * ((100 - _GateRandomness) / 100.0f))
            {
                var gateA = getRandomGateFromToRandomize();
                toRandomize.Remove(gateA);
                var gateB = getRandomGateFromToRandomize();
                toRandomize.Remove(gateB);

                LinkGates(gateA, gateB);
            }
        }
        private static void WriteScriptInstance()
        {
            var storyBase = Program.GameHook.StoryBase;
            foreach (var gate in _Gates)
                gate.ApplyDestToScriptInstance(ref storyBase);
        }

        private static void WriteGalaxyBase()
        {
            var galaxyBase = Program.GameHook.GalaxyBase;
            foreach (var gate in _Gates)
                gate.ApplyDestToGalaxyBase(ref galaxyBase);
        }


        private static GateData _GetDest(GateData origin)
        {
            return GetGate(origin.DestSectorX, origin.DestSectorY, origin.DestIndex);
        }

        private static bool LinkGates(GateData gateA, GateData gateB)
        {
            var gateC = _GetDest(gateA);
            var gateD = _GetDest(gateB);

            if (gateC == null || gateD == null)
                return false;

            gateA.DestSectorX = gateB.SectorX;
            gateA.DestSectorY = gateB.SectorY;
            gateA.DestIndex = gateB.Index;
            gateB.DestSectorX = gateA.SectorX;
            gateB.DestSectorY = gateA.SectorY;
            gateB.DestIndex = gateA.Index;


            gateC.DestSectorX = gateD.SectorX;
            gateC.DestSectorY = gateD.SectorY;
            gateC.DestIndex = gateD.Index;
            gateD.DestSectorX = gateC.SectorX;
            gateD.DestSectorY = gateC.SectorY;
            gateD.DestIndex = gateC.Index;

            return true;
        }

        private static Sector GetSector(int x, int y)
        {
            foreach (var sector in _Sectors)
                if (sector.SectorX == x && sector.SectorY == y)
                    return sector;
            return null;
        }

        private static GateData GetGate(int sectorX, int sectorY, int index)
        {
            foreach (var gate in _Gates)
            {
                if (gate.SectorX == sectorX && gate.SectorY == sectorY && gate.Index == index)
                    return gate;
            }
            return null;
        }

        private static GateData GetRandomGate()
        {
            return _Gates[_Random.Next(_Gates.Count)];
        }

        private static void _SearchSectors(ref List<Sector> unvisited, Sector origin)
        {
            unvisited.Remove(origin);
            foreach (var gate in origin.Gates)
            {
                var nextSector = GetSector(gate.DestSectorX, gate.DestSectorY);
                if (unvisited.Contains(nextSector))
                    _SearchSectors(ref unvisited, nextSector);
            }
        }

        private static void _ValidateAndFixAssumeBidirectional()
        {
            // Fix islands
            if (_Sectors.Count > 0)
            {
                while (true)
                {
                    var origin = _Sectors[_Random.Next(_Sectors.Count)];
                    List<Sector> unvisited = new List<Sector>(_Sectors);

                    _SearchSectors(ref unvisited, origin);

                    // Fix then repeat if needed
                    // This fix method in theory could be repeated infinite times before a solution is found, however that will never happen.
                    if (unvisited.Count > 0)
                    {
                        var targetSector = unvisited[_Random.Next(unvisited.Count())];
                        Sector toConnect;
                        do
                        {
                            toConnect = _Sectors[_Random.Next(_Sectors.Count)];
                        } while (unvisited.Contains(toConnect));

                        var gateA = targetSector.Gates[_Random.Next(targetSector.Gates.Count)];
                        var gateB = toConnect.Gates[_Random.Next(toConnect.Gates.Count)];

                        LinkGates(gateA, gateB);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
