using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCAPLib.RAM.Bases.Galaxy
{
    public class SectorData : XCommonLib.RAM.Bases.Galaxy.SectorData
    {
        #region Memory Fields
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Galaxy.GateData[] Gates { get; set; }
        #endregion

        #region IMemoryObject
        public const int BYTE_SIZE = 0xe0;
        public override int ByteSize => BYTE_SIZE;


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            Gates = memoryObjectConverter.PopIMemoryObjects<GateData>(6);
        }
        #endregion
    }
}
