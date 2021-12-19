using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public class CatDatReader<C,D,P> : ICatDatCollection where C:ICatFile,new() where D:IDatFile,new() where P:IPckFile,new()
    {
        private struct CatDatPair
        {
            public ICatFile CatFile;
            public IDatFile DatFile;
        }

        private List<CatDatPair> _Pairs = new List<CatDatPair>();

        public void AppendCatDat(string catPath)
        {
            var newCat = new C();
            newCat.LoadFromFile(catPath);
            var newDat = new D();
            newDat.FilePath = newCat.DatPath;
            _Pairs.Add(new CatDatPair { CatFile = newCat, DatFile = newDat });
        }

        #region Gets
        public CatDatFile GetFile(string internalPath)
        {
            for (int i = _Pairs.Count - 1; i >= 0; i--)
            {
                var reference = _Pairs[i].CatFile.GetFile(internalPath);
                if (reference != null)
                {
                    return new CatDatFile()
                    {
                        InternalPath = reference.InternalPath,
                        Data = _Pairs[i].DatFile.GetData(reference.DatIndex, reference.Length)
                    };
                }
            }
            return null;
        }
        public P GetPckFile(string internalPath)
        {
            return GetFile(internalPath).ConvertToBinaryObject<P>();
        }
        public string[] GetFiles()
        {
            List<string> files = new List<string>();
            foreach(var pair in _Pairs)
            {
                foreach(var file in pair.CatFile.GetFiles())
                {
                    if(!files.Contains(file))
                        files.Add(file);
                }
            }
            return files.ToArray();
        }
        public string[] GetFiles(string baseInternalPath, bool direct = true)
        {
            List<string> result = new List<string>();
            var targetSplit = baseInternalPath == null ? new string[0] : baseInternalPath.Split('/');
            foreach (var file in GetFiles())
            {
                var fileSplit = file.Split('/');

                if ((direct && fileSplit.Length - 1 == targetSplit.Length) || (!direct && fileSplit.Length > targetSplit.Length))
                {
                    bool DoesMatch = true;
                    for (int i = 0; i < targetSplit.Length; i++)
                    {
                        if (fileSplit[i] != targetSplit[i])
                        {
                            DoesMatch = false;
                            break;
                        }
                    }

                    if (DoesMatch)
                    {
                        result.Add(file);
                    }
                }
            }
            return result.ToArray();
        }
        public string[] GetDirectories()
        {
            List<string> dirs = new List<string>();
            foreach (var pair in _Pairs)
            {
                foreach (var dir in pair.CatFile.GetDirectories())
                {
                    if (!dirs.Contains(dir))
                        dirs.Add(dir);
                }
            }
            return dirs.ToArray();
        }
        public string[] GetDirectories(string baseInternalPath, bool direct = true)
        {
            List<string> result = new List<string>();
            var targetSplit = baseInternalPath == null ? new string[0] : baseInternalPath.Split('/');
            foreach (var file in GetFiles())
            {
                var fileSplit = file.Split('/');

                fileSplit = fileSplit.Take(fileSplit.Length - 1).ToArray();
                if (fileSplit.Length > targetSplit.Length)
                {
                    bool DoesMatch = true;
                    for (int i = 0; i < targetSplit.Length; i++)
                    {
                        if (fileSplit[i] != targetSplit[i])
                        {
                            DoesMatch = false;
                            break;
                        }
                    }

                    if (DoesMatch)
                    {
                        if(direct)
                            fileSplit = fileSplit.Take(targetSplit.Length + 1).ToArray();
                        var dirPath = string.Join("/", fileSplit);
                        if (!result.Contains(dirPath))
                            result.Add(dirPath);
                    }
                }
            }
            return result.ToArray();
        }
        #endregion

        /// <summary>
        /// Extract all files within the loaded dat files into the directory.
        /// </summary>
        /// <param name="dir"></param>
        public void ExportToDirectory(string dir, bool decryptAll = true)
        {
            foreach (var file in GetFiles())
            {
                var targetPath = Path.Combine(dir, file);
                var targetDir = Path.GetDirectoryName(targetPath);
                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);
                var internalFile = GetFile(file);
                byte[] data;
                if(decryptAll)
                {
                    switch (internalFile.Extension)
                    {
                        case ".pck":
                            var pckFile = internalFile.ConvertToBinaryObject<P>();
                            data = pckFile.Contents;
                            break;
                        default:
                            data = internalFile.Data;
                            break;
                    }
                }
                else
                {
                    data = internalFile.Data;
                }
                File.WriteAllBytes(targetPath, data);
            }
        }

        public void ExportCatsToDirectory(string dir, bool encrypted)
        {
            int i = 1;
            foreach(var pair in _Pairs)
            {
                pair.CatFile.ExportToFile(Path.Combine(dir, i++.ToString("D2") + ".cat"), encrypted);
            }
        }

        public CatDatBuilder<C,D,P> ToBuilder()
        {
            var builder = new CatDatBuilder<C, D,P>();
            foreach (var file in GetFiles())
            {
                builder.SetFile(file, GetFile(file).Data);
            }
            return builder;
        }
        public void Clear()
        {
            _Pairs.Clear();
        }

    }
}
