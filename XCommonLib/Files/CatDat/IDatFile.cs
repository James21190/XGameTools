using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public interface IDatFile
    {
        string FilePath { get; set; }
        byte[] GetData(int index, int length);
        void Append(byte[] data);
        void Clear();
        void StartAppendStream();
        void CloseAppendStream();
    }
}
