﻿using CommonToolLib.Memory;

namespace X3Tools.RAM.Bases.Sector
{
    public class TypeData_Factory : TypeData
    {
        public int OriginRaceID;

        public short HullCargoValue;


        public GameHook.RaceID OriginRace => (GameHook.RaceID)OriginRaceID;
        public int MaxHull => HullCargoValue * 1000000;

        public enum FactoryClassification
        {
            Shipyard,
            Tech,
            Bio,
            Food,
            Power,
            Mine,
            Storage,
            Complex,
            Default,
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {
            OriginRaceID = obl.PopInt(0x5c);

            HullCargoValue = obl.PopShort(0x6e);
        }

        public override string GetObjectClassAsString()
        {
            return ((FactoryClassification)ObjectClass).ToString();
        }
    }
}
