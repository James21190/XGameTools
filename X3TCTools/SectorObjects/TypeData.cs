using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.SectorObjects
{
    public partial class TypeData : MemoryObject
    {


        #region IMemoryObject
        public const int ByteSize = 3512;

        public int ObjectClass;
        public int MaxSpeed;
        public int ShieldPowerGenrator;
        public int MaxLaserEnergy;
        public int LaserRechargeRate;
        public SectorObject.Shield_Sub_Type MaxShieldClass;
        public int MaxShieldCount;
        public int MinimumCargoSpace;
        public int MaximumCargoSpace;
        public GameHook.RaceID OriginRace;
        public int MaxHull;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
            var collection = new ObjectByteList();

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            int temp = 0;
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref ObjectClass,0x14);
            collection.PopFirst(ref MaxSpeed,0x44);
            collection.PopFirst(ref ShieldPowerGenrator,0x5c);
            collection.PopFirst(ref MaxLaserEnergy,0x78);
            collection.PopFirst(ref LaserRechargeRate);
            collection.PopFirst(ref temp);
            MaxShieldClass = (SectorObject.Shield_Sub_Type)temp;
            collection.PopFirst(ref MaxShieldCount);
            collection.PopFirst(ref MinimumCargoSpace,0x9c);
            collection.PopFirst(ref MaximumCargoSpace);
            collection.PopFirst(ref temp, 0xb4);
            OriginRace = (GameHook.RaceID)temp;
            collection.PopFirst(ref MaxHull);

        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
