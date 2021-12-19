using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.Files.CatDat;

namespace X2Lib.Files.CatDat
{
    public class X2CatFile : ICatFile
    {
        public struct CatEntry
        {
            public string InternalPath;
            public int Length;

            public override string ToString()
            {
                return InternalPath + " " + Length.ToString();
            }
        }

        #region Fields
        public string FilePath { get; private set; }
        public string DatName { get; set; }
        public string DatPath
        {
            get
            {
                //var internalDefinedPath = Path.Combine(Path.GetDirectoryName(this.FilePath), DATName);
                //if (File.Exists(internalDefinedPath))
                //    return internalDefinedPath;
                //else
                    return Path.Combine(Path.GetDirectoryName(this.FilePath), Path.GetFileNameWithoutExtension(this.FilePath) + ".dat");
            }
        }
        public List<CatEntry> Entries = new List<CatEntry>();
        #endregion

        public X2CatFile()
        {

        }

        public static void ToggleEncryption(ref byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                byte xorValue = (byte)(i - 0x25);
                data[i] ^= xorValue;
            }
        }

        public XCommonLib.Files.CatDat.CatEntry GetFile(string internalPath)
        {
            int index = 0;
            foreach (var item in Entries)
            {
                if (item.InternalPath == internalPath)
                    return new XCommonLib.Files.CatDat.CatEntry()
                    {
                        InternalPath = internalPath,
                        DatIndex = index,
                        Length = item.Length
                    };
                index += item.Length;
            }
            return null;
        }
        public string[] GetDirectories()
        {
            List<string> files = new List<string>();
            foreach (var entry in Entries)
            {
                var splitPath = entry.InternalPath.Split('/');
                var dirPath = string.Join("/", splitPath.Take(splitPath.Length - 1));
                if (!files.Contains(dirPath))
                    files.Add(dirPath);
            }
            return files.ToArray();
        }
        public string[] GetFiles()
        {
            List<string> files = new List<string>();
            foreach (var entry in Entries)
                if (!files.Contains(entry.InternalPath))
                    files.Add(entry.InternalPath);
            return files.ToArray();
        }

        public void LoadFromFile(string path)
        {
            FilePath = path;
            var bytes = File.ReadAllBytes(FilePath);
            // Remove the encryption
            ToggleEncryption(ref bytes);

            int Start = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == '\n' || bytes[i] == '\r' || i == bytes.Length - 1)
                {
                    byte[] temp = new byte[(i - Start)];
                    Array.Copy(bytes, Start, temp, 0, temp.Length);
                    var str = Encoding.Default.GetString(temp);
                    if (Start == 0)
                        DatName = str;
                    else
                    {
                        var split = str.Split(' ');
                        var entry = new CatEntry()
                        {
                            InternalPath = string.Join(" ", split.Take(split.Length - 1)),
                            Length = int.Parse(split.Last())
                        };
                        Entries.Add(entry);
                    }
                    Start = i + 1;
                }
            }
        }

        public void ExportToFile(string path, bool readable)
        {
            List<string> lines = new List<string>();
            lines.Add(DatName);
            foreach(var entry in Entries)
            {
                lines.Add(entry.ToString());
            }
            var result = Encoding.ASCII.GetBytes(string.Join("\n", lines));
            if (!readable)
                ToggleEncryption(ref result);

            File.WriteAllBytes(path, result);
        }

        public void Append(XCommonLib.Files.CatDat.CatEntry entry)
        {
            Entries.Add(new CatEntry()
            {
                InternalPath = entry.InternalPath,
                Length = entry.Length
            });
        }
    }
}
