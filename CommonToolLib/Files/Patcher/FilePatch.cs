using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    public struct FilePatch
    {
        public enum PatchMethod
        {
            COPY,
            XOR
        }
        
        public struct Section
        {
            public int Address;
            public byte[] Bytes;
        }

        public string Name;
        public string Description;

        public PatchMethod Method;
        public Section[] Sections;
    }
}
