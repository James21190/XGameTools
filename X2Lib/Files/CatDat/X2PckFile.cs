using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using XCommonLib.Files.CatDat;
using System.IO;

namespace X2Lib.Files.CatDat
{
    public class X2PckFile : IPckFile
    {
        public byte[] Contents { get; private set; }

        public static void ToggleEncryption(ref byte[] data)
        {
            byte key = data[0];
            for (int i = 0; i < data.Length; i++)
                data[i] ^= (byte)(key ^ 200);
        }


        //public static void ToggleAdditionalEncryption(ref byte[] data)
        //{
        //    for (int i = 0; i < data.Length; i++)
        //        data[i] ^= (byte)0x7c;
        //}

        //bool _HasAdditionalEncryption = false;

        #region IBinaryObject
        public int ByteSize => Contents.Length;
        public byte[] GetBytes()
        {
            var arr = new byte[Contents.Length];
            Array.Copy(Contents, 0, arr, 0, Contents.Length);
            ToggleEncryption(ref arr);
           //if(_HasAdditionalEncryption)
           //     ToggleAdditionalEncryption(ref arr);
            return arr;
        }
        public void SetData(byte[] memory)
        {
            var newContents = new byte[memory.Length];
            Array.Copy(memory, 0, newContents, 0, memory.Length);
            ToggleEncryption(ref newContents);
            //if(newContents[0] != 200)
            //{
            //    ToggleAdditionalEncryption(ref newContents);
            //    _HasAdditionalEncryption = true;
            //}
            //else
            //{
            //    _HasAdditionalEncryption = false;
            //}
            Contents = newContents;
        }
        #endregion

        public void Compress(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] Decompress()
        {
            List<byte> result = new List<byte>();
            byte[] skipped = Contents.Skip(1).ToArray();
            using (var gzip = new GZipStream(new MemoryStream(skipped), CompressionMode.Decompress))
            {
                int value = gzip.ReadByte();
                while (value != -1)
                {
                    result.Add((byte)value);
                    value = gzip.ReadByte();
                }
            }
            return result.ToArray();
        }
    }
}
