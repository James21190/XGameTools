using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.Memory;
using XCommonLib.RAM.Bases.Sector;
using XCommonLib.RAM.Bases.Story;

namespace XCommonLib.RAM
{
    public abstract class GameHook : ApplicationHook
    {
        /// <summary>
        /// The SectorBase is responsible for managing all in-sector objects.
        /// Returns null if not found.
        /// </summary>
        public abstract SectorBase SectorBase { get; }
        public abstract StoryBase StoryBase { get; }

        public static readonly int MainTypeCount = 32;

        public abstract string GetRaceIDName(ushort id);
    }
}
