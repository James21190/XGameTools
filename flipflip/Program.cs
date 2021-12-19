using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flipflip
{
    internal class Program
    {
        public static void ToggleEncryption(ref byte[] data)
        {
            byte key = data[0];
            for (int i = 0; i < data.Length; i++)
                data[i] ^= (byte)(key ^ 200);
        }
        static void Main(string[] args)
        {
            var bytes = File.ReadAllBytes("./input.pck");
            ToggleEncryption(ref bytes);
            File.WriteAllBytes("./output.pck", bytes);
        }
    }
}
