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
        public const int BYTE_SIZE = 0x7a8;
        public override int ByteSize => BYTE_SIZE;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            memoryObjectConverter.Seek(0xb4);
            LaunchParamCount = memoryObjectConverter.PopInt();
            ppLaunchParams = memoryObjectConverter.PopIMemoryObject<MemoryObjectPointer<MemoryObjectPointer<MemoryString>>>();


            // Seek to end to consume the correct amount of bytes.
            memoryObjectConverter.Seek(BYTE_SIZE);
        }
        #endregion
    }
}
