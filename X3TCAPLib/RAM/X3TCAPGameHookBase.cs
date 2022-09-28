using XCommonLib.RAM;

namespace X3TCAPLib.RAM
{
    public abstract class X3TCAPGameHookBase : GameHook
    {
        internal enum RaceID_X3TCAP : ushort
        {
            NA,
            Argon,
            Boron,
            Split,
            Paranid,
            Teladi,
            Xenon,
            Khaak,
            Pirate,
            Gonor,
            Player,

            Unowned = 12,
            Friendly,
            Unknown,

            ATF = 17,
            Terran,
            Yaki,
            None = 65535
        }

        internal enum MainType_X3TCAP
        {
            Bullet,
            Sector,
            Background,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Laser,
            Shield,
            Missile,
            Ware_E,
            Ware_N,
            Ware_B,
            Ware_F,
            Ware_M,
            Ware_T,
            Asteroid,
            Gate,
            Camera,
            Special,
            Type_21,
            Type_22,
            Type_23,
            Type_24,
            Cockpit = 25,
            Type_26,
            Type_27 = 27,
            Debris = 28,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }
    }
}
