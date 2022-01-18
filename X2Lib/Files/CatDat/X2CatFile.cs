using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommonLib.Files.CatDat;

namespace X2Lib.Files.CatDat
{
    public class X2CatFile : CatFile
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
        public string DatName;
        public List<CatEntry> Entries = new List<CatEntry>();
        #endregion

        public X2CatFile()
        {

        }

        public static void ToggleEncryption(ref byte[] data, int index = 0)
        {
            for (int i = 0; i < data.Length; i++)
            {
                byte xorValue = (byte)((index + i) - 0x25);
                data[i] ^= xorValue;
            }
        }
        public override void LoadEntriesFromFile(string path)
        {
            DatName = null;
            Entries.Clear();
            var bytes = File.ReadAllBytes(path);
            ToggleEncryption(ref bytes);
            var sb = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                var nextChar = (char)bytes[i];
                if(nextChar == '\n')
                {
                    if(DatName == null)
                    {
                        DatName = sb.ToString();
                    }
                    else
                    {
                        var newEntry = new CatEntry();
                        var split = sb.ToString().Split(' ');
                        newEntry.InternalPath = split[0];
                        newEntry.Length = int.Parse(split[1]);
                        Entries.Add(newEntry);
                    }
                    sb.Clear();
                }
                else
                {
                    sb.Append(nextChar);
                }
            }
        }
        public override void SaveEntriesToFile(string path, bool forceNoEncryption)
        {
            var sb = new StringBuilder();
            sb.Append(DatName);
            foreach(var entry in Entries)
            {
                sb.Append('\n' + entry.ToString());
            }

            var bytes = Encoding.ASCII.GetBytes(sb.ToString());

            if (!forceNoEncryption)
                ToggleEncryption(ref bytes);

            File.WriteAllBytes(path, bytes);
        }
        public override string[] GetInternalFiles()
        {
            string[] fileNames = new string[Entries.Count];
            for(int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Entries[i].InternalPath;
            }
            return fileNames;
        }
        public override FileLocationData[] GetInternalFileLocations()
        {
            FileLocationData[] fileLocationDatas = new FileLocationData[Entries.Count];
            int offset = 0;
            for(int i = 0; i < fileLocationDatas.Length; i++)
            {
                fileLocationDatas[i] = new FileLocationData()
                {
                    Length = Entries[i].Length,
                    InternalPath = Entries[i].InternalPath,
                    DatIndex = offset
                };
                offset += Entries[i].Length;
            }
            return fileLocationDatas;
        }
        public override FileLocationData GetInternalFileLocation(string internalPath)
        {
            int offset = 0;
            foreach (var entry in Entries)
            {
                if(entry.InternalPath == internalPath)
                {
                    var fld = new FileLocationData();
                    fld.InternalPath = internalPath;
                    fld.Length = entry.Length;
                    fld.DatIndex = offset;
                    return fld;
                }

                offset += entry.Length;
            }
            throw new FileNotFoundException();
        }
    }
}
