using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using XCommonLib.Files.CatDat;
using System.IO;

namespace X3TCAPLib.Files.CatDat
{
    public class X3CompressedFile : CompressedFile
    {
        protected override void CompressData(byte[] data)
        {
            List<byte> result = new List<byte>();
            using (var gzip = new GZipStream(new MemoryStream(data), CompressionMode.Compress))
            {
                int value = gzip.ReadByte();
                while (value != -1)
                {
                    result.Add((byte)value);
                    value = gzip.ReadByte();
                }
            }
            CompressedData = result.ToArray();
        }
        protected override byte[] DecompressData()
        {
            List<byte> result = new List<byte>();
            using (var gzip = new GZipStream(new MemoryStream(CompressedData), CompressionMode.Decompress))
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
        public override void SetData(byte[] Memory)
        {
            byte[] decrypted = new byte[Memory.Length];
            Array.Copy(Memory,decrypted,decrypted.Length);
            base.SetData(decrypted);
        }
        // test
        public override byte[] GetBytes()
        {
            var decrypted = base.GetBytes();
            byte[] encrypted = new byte[decrypted.Length];
            Array.Copy(decrypted, encrypted, encrypted.Length);
            return encrypted;
        }
    }
}
