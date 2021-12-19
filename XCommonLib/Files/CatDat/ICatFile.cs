using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public interface ICatFile
    {
        string FilePath { get; }
        string DatName { get; set; }
        string DatPath { get; }
        CatEntry GetFile(string internalPath);
        string[] GetFiles();
        string[] GetDirectories();
        void Append(CatEntry entry);
        void LoadFromFile(string path);
        void ExportToFile(string path, bool readable);
    }
}
