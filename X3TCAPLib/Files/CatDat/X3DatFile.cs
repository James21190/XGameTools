using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.Files.CatDat;

namespace X3TCAPLib.Files.CatDat
{
    public class X3DatFile : DatFile
    {
        
        public X3DatFile()
        {
        }

        public static void ToggleEncryption(ref byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
                data[i] ^= 0x33;
        }

        public override byte[] GetData(int index, int length)
        {
            byte[] data = new byte[length];
            using (var fs = File.OpenRead(Path))
            {
                fs.Seek(index, SeekOrigin.Begin);
                fs.Read(data, 0, length);
            }
            ToggleEncryption(ref data);
            return data;
        }
    }
}
