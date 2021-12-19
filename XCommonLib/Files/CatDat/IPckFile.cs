using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public interface IPckFile : IBinaryObject
    {
        byte[] Contents{ get; }
        byte[] Decompress();
        void Compress(byte[] data);
    }
}
