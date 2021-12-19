using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public interface ICatDatCollection
    {
        CatDatFile GetFile(string internalPath);
    }
}
