﻿using CommonToolLib.Memory;

namespace X3Tools.RAM.Bases.Sector
{
    public class TypeData_Sun : TypeData
    {
        public int ModelID;
        public int AppearenceID;
        protected override void SetUniqueData(ObjectByteList obl)
        {
            ModelID = obl.PopInt();
            AppearenceID = obl.PopInt();
        }
    }
}
