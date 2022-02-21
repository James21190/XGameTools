using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonToolLib.ProcessHooking;

namespace X3TCAPLib.RAM.Bases.System
{
    public class SystemBase : XCommonLib.RAM.Bases.System.SystemBase
    {
        #region Memory Fields

        public int LaunchParamCount;
        public MemoryObjectPointer<MemoryObjectPointer<MemoryString>> ppLaunchParams;

        #endregion

        #region Common
        public override string[] LaunchParams
        {
            get
            {
                string[] result = new string[LaunchParamCount];
                for(int i = 0; i < LaunchParamCount; i++)
                {
                    result[i] = ppLaunchParams.GetObjectInArray(i).obj.Value;
                }
                return result;
            }
        }
        #endregion

        #region IMemoryObject
        public override int ByteSize => 0x7a8;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            LaunchParamCount = memoryObjectConverter.PopInt(0xb4);
            ppLaunchParams = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<MemoryString>>>();
        }
        #endregion
    }
}
