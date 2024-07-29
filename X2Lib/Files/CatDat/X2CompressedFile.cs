﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using XCommonLib.Files.CatDat;
using System.IO;

namespace X2Lib.Files.CatDat
{
    public class X2CompressedFile : CompressedFile
    {

        // The first byte is an encryption key and should be ignored when compressing and decompressing.
        public static void ToggleEncryption(ref byte[] data)
        {
            byte key = (byte)(data[0] ^ 200);
            for (int i = 1; i < data.Length; i++)
                data[i] ^= key;
        }
        protected override void CompressData(byte[] data)
        {
            List<byte> result = new List<byte>();
            result.Add(0x0);
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
            byte[] skipped = CompressedData.Skip(1).ToArray();
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
        public override void SetData(byte[] data, out int bytesConsumed)
        {
            byte[] decrypted = new byte[data.Length];
            Array.Copy(data,decrypted,decrypted.Length);
            ToggleEncryption(ref decrypted);
            base.SetData(decrypted, out bytesConsumed);
        }

        public override byte[] GetBytes()
        {
            var decrypted = base.GetBytes();
            byte[] encrypted = new byte[decrypted.Length];
            Array.Copy(decrypted, encrypted, encrypted.Length);
            ToggleEncryption(ref encrypted);
            return encrypted;
        }
    }
}
