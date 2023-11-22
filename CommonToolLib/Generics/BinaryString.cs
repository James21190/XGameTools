using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics
{
    public class BinaryString : IBinaryObject
    {
        public int ByteSize => throw new NotImplementedException();

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public SetDataResult SetData(byte[] Memory)
        {
            throw new NotImplementedException();
        }
    }
}
