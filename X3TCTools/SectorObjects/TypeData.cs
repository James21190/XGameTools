using Common.Memory;
using Common.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public abstract class TypeData : MemoryObject
    {

        public Vector3 RotationSpeed;
        public int ObjectClass;
        public int NameID;

        public int Price;
        public int PriceRangePercentage;

        public MemoryObjectPointer<MemoryString> pTypeString;

        public const int ByteSize = 3512;
        public override sealed byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override sealed int GetByteSize()
        {
            return ByteSize;
        }

        public override sealed void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);

            RotationSpeed = collection.PopIMemoryObject<Vector3>(0x8);
            ObjectClass = collection.PopInt();
            NameID = collection.PopInt();

            Price = collection.PopInt(0x20);
            PriceRangePercentage = collection.PopInt();

            pTypeString = collection.PopIMemoryObject<MemoryObjectPointer<MemoryString>>(0x40);

            SetUniqueData(collection);
        }
        public virtual string GetObjectClassAsString() { return ObjectClass.ToString(); }

        protected abstract void SetUniqueData(ObjectByteList obl);


    }
}
