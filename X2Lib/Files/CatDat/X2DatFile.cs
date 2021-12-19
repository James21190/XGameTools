using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.Files.CatDat;

namespace X2Lib.Files.CatDat
{
    public class X2DatFile : IDatFile
    {
        public string FilePath { get; set; }
        public X2DatFile()
        {
        }

        private FileStream _Stream;
        public static void ToggleEncryption(ref byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
                data[i] ^= 0x33;
        }
        public byte[] GetData(int index, int length)
        {
            byte[] result = new byte[length];
            using (var fs = File.OpenRead(FilePath))
            {
                fs.Seek(index, SeekOrigin.Begin);
                fs.Read(result, 0, length);
            }

            // Decript data
            ToggleEncryption(ref result);

            return result;
        }

        public void Clear()
        {
            File.WriteAllBytes(FilePath, new byte[0]);
        }
        public void Append(byte[] data)
        {
            // Encrypt data
            byte[] arr = new byte[data.Length];
            Array.Copy(data, arr, data.Length);
            ToggleEncryption(ref arr);
            _Stream.Write(arr, 0, arr.Length);
        }

        public void StartAppendStream()
        {
            _Stream = new FileStream(FilePath, FileMode.Append);
        }

        public void CloseAppendStream()
        {
            _Stream.Flush();
            _Stream = null;
        }
    }
}
