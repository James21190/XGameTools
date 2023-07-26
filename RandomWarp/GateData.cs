using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.RAM;
using XCommonLib.RAM.Bases.Galaxy;

namespace RandomWarp
{
    internal class GateData : IComparable
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
}
