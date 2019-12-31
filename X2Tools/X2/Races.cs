using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Tools.X2
{
    public class Race
    {
        public const int RACE_COUNT = 22;
        /// RaceID is offset by 2 because there is a race id of -2
        public enum RaceID : short
        {
            None = 0,
            Argon = 3,
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
            Race5
        }
        public static RaceID ConvertToRaceID(short ID) { return (RaceID)(ID + 2); }
        public static RaceID ConvertToRaceID(int ID) { return (RaceID)(ID + 2); }
        public static short ConvertToShort(RaceID ID) { return (short)(ID - 2); }
    }
}
