using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandomWarp.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using XCommonLib.RAM;

namespace RandomWarp
{
    internal class GateRandomizer
    {
        public List<GateData> Gates;
        public List<Sector> Sectors;
        private List<GateData> _ToRandomize = new List<GateData>();

        private GateData _GetDest(GateData origin)
        {
            return GetGate(origin.DestSectorX, origin.DestSectorY, origin.DestIndex);
        }

        public void RemoveUnlinkedGates()
        {
            for(int s = 0; s < Sectors.Count;)
            {
                var sector = Sectors[s];
                for(int g = 0; g < sector.Gates.Count;)
                {
                    var gate = sector.Gates[g];
                    if(_GetDest(gate) == null)
                    {
                        sector.Gates.RemoveAt(g);
                        Gates.Remove(gate);
                    }
                    else
                    {
                        g++;
                    }
                }
                if(sector.Gates.Count == 0)
                {
                    Sectors.RemoveAt(s);
                }
                else
                {
                    s++;
                }
            }
        }

        public bool LinkGates(GateData gateA, GateData gateB)
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

        public Sector GetSector(int x, int y)
        {
            foreach (var sector in Sectors)
                if (sector.SectorX == x && sector.SectorY == y)
                    return sector;
            return null;
        }

        public GateData GetGate(int sectorX, int sectorY, int index)
        {
            foreach (var gate in Gates)
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
            foreach (var gate in origin.Gates)
            {
                var nextSector = GetSector(gate.DestSectorX, gate.DestSectorY);
                if (unvisited.Contains(nextSector))
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
                if (unvisited.Count > 0)
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
}
