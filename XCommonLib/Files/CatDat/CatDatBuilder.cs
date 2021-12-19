using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public class CatDatBuilder<C, D, P> : ICatDatCollection where C : ICatFile, new() where D : IDatFile, new() where P : IPckFile, new()
    {
        private List<CatDatFile> _Files = new List<CatDatFile> ();
        public void SetFile(string internalPath, byte[] data)
        {
            DeleteFile(internalPath);
            _Files.Add(new CatDatFile()
            {
                InternalPath = internalPath,
                Data = data,
                Created = DateTime.Now
            });
        }
        public void DeleteFile(string internalPath)
        {
            for (int i = 0; i < _Files.Count; i++)
            {
                if (_Files[i].InternalPath == internalPath)
                {
                    _Files.RemoveAt(i);
                    return;
                }
            }
        }
        public void ExportToCatDat(string dirPath, string name)
        {
            _Files.Sort();
            var catFile = new C();
            var datFile = new D();

            datFile.FilePath = Path.Combine(dirPath,name+".dat");
            datFile.Clear();
            datFile.StartAppendStream();

            int currentIndex = 0;
            foreach(var file in _Files)
            {
                catFile.Append(new CatEntry()
                {
                    DatIndex = currentIndex,
                    InternalPath = file.InternalPath,
                    Length = file.Data.Length
                });

                currentIndex += file.Data.Length;
                datFile.Append(file.Data);
            }

            datFile.CloseAppendStream();
            catFile.DatName = name + ".dat";
            catFile.ExportToFile(Path.Combine(dirPath, name + ".cat"), false);
        }
        public void ExportToDirectory(string dirPath)
        {
            throw new NotImplementedException();
        }
        public void ImportDirectory(string dirPath)
        {
            throw new NotImplementedException();
        }

        public CatDatFile GetFile(string internalPath)
        {
            foreach(var file in _Files)
            {
                if (file.InternalPath == internalPath)
                    return file;
            }
            return null;
        }
    }
}
