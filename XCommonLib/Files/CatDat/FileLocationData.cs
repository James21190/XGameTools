using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    /// <summary>
    /// The location of a block of data within a dat file.
    /// </summary>
    public struct FileLocationData
    {
        public string InternalPath;
        public int DatIndex;
        public int Length;
    }
}
