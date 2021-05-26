using CommonToolLib.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Lib.RAM.Bases.Sector;
using X2Lib.RAM.Bases.Story;

namespace X2Lib.RAM
{
    public class X2GameHook : XCommonLib.RAM.GameHook
    {
        public enum RaceID : ushort
        {
            Argon,
            Boron,
            Split,
            Paranid,
            Teladi,
            Xenon,
            Khaak,
            Pirates,
            Gonor,
            Player,
            EnemyRace,
            NeutralRace,
            FriendlyRace,
            Unknown,
            Race1,
            Race2,
            Race3,
            Race4,
            Race5,

            None = 65535
        }

        public enum GlobalAddressesX2
        {
            TypeDataArray = 0x15d65b0,
            pSectorBase = 0x15d66a8,
            pStoryBase = 0x15d6700
        }
        #region Pointers
        public static MemoryObjectPointer<MemoryObjectPointer<SectorBase>> ppSectorBase;
        public static MemoryObjectPointer<MemoryObjectPointer<StoryBase>> ppStoryBase;
        #endregion
        #region Objects
        public override XCommonLib.RAM.Bases.Sector.SectorBase SectorBase => ppSectorBase != null ? ppSectorBase.obj.obj : null;
        public override XCommonLib.RAM.Bases.Story.StoryBase StoryBase => ppStoryBase != null ? ppStoryBase.obj.obj : null;
        #endregion

        public X2GameHook(Process process)
        {
            HookIntoProcess(process);

            ppSectorBase = new MemoryObjectPointer<MemoryObjectPointer<SectorBase>>(hProcess, (IntPtr)GlobalAddressesX2.pSectorBase);
            ppStoryBase = new MemoryObjectPointer<MemoryObjectPointer<StoryBase>>(hProcess, (IntPtr)GlobalAddressesX2.pStoryBase);
        }

        ~X2GameHook()
        {
            Unhook();
        }

        public override string GetRaceIDName(ushort id)
        {
            throw new NotImplementedException();
        }
    }
}
