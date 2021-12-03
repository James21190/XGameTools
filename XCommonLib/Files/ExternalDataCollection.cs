using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files
{
    public class ExternalDataCollection
    {
        #region CAT and DAT
        public class FileRecord : IComparable
        {
            public string DatPath;
            public string InternalPath;
            public int Index;
            public int Size;

            public string[] InternalDirectories
            {
                get
                {
                    return Path.GetDirectoryName(InternalPath).Split('\\');
                }
            }
            public string InternalFileName
            {
                get
                {
                    return Path.GetFileName(InternalPath);
                }
            }

            public int CompareTo(object obj)
            {
                if(obj is FileRecord)
                {
                    return InternalPath.CompareTo(((FileRecord)obj).InternalPath);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public bool IsInDirectory(string dir)
            {
                if (string.IsNullOrWhiteSpace(dir))
                {
                    return InternalDirectories.Length == 0;
                }
                var dirSplit = dir.Split('/');
                if (InternalDirectories.Length != dirSplit.Length)
                    return false;
                for (int i = 0; i < dirSplit.Length; i++)
                {
                    if (InternalDirectories[i] != dirSplit[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private struct CATFile
        {
            public struct Entry
            {
                public string Path;
                public int Size;

                public Entry(string path, int size)
                {
                    Path = path;
                    Size = size;
                }

                public override string ToString()
                {
                    return string.Format("{0} {1}",Path,Size);
                }
            }
            public string DatName;
            public string Path;
            public Entry[] Entries;

            public FileRecord[] GetRecords()
            {
                FileRecord[] result = new FileRecord[Entries.Length];
                int offset = 0;
                for(int i = 0; i < Entries.Length; i++)
                {
                    result[i] = new FileRecord()
                    {
                        DatPath = System.IO.Path.Combine(Path,DatName),
                        InternalPath = Entries[i].Path,
                        Index = offset,
                        Size = Entries[i].Size
                    };
                    offset += Entries[i].Size;
                }
                return result;
            }

            public static CATFile FromFile(string path)
            {
                var result = new CATFile();
                result.Path = System.IO.Path.GetDirectoryName(path);
                var bytes = File.ReadAllBytes(path);

                List<Entry> entries = new List<Entry>();

                int Start = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    byte value = (byte)(i - 0x25);
                    bytes[i] = (byte)((int)bytes[i] ^ value);
                    
                    if(bytes[i] == '\n' || bytes[i] == '\r' || i == bytes.Length - 1)
                    {
                        byte[] temp = new byte[(i - Start)];
                        Array.Copy(bytes, Start, temp, 0, temp.Length);
                        var str = Encoding.Default.GetString(temp);
                        if (Start == 0)
                            result.DatName = str;
                        else
                        {
                            var split = str.Split(' ');
                            var entry = new Entry()
                            {
                                Path = split[0],
                                Size = int.Parse(split[1])
                            };
                            entries.Add(entry);
                        }
                        Start = i + 1;
                    }
                }
                result.Entries = entries.ToArray();
                return result;
            }

        }

        private List<FileRecord> _Records = new List<FileRecord>();
        public FileRecord[] Records
        {
            get
            {
                var result = new FileRecord[_Records.Count()];
                Array.Copy(_Records.ToArray(),result, result.Length);
                return result;
            }
        }

        public ExternalDataCollection()
        {
            
        }
        public ExternalDataCollection(params string[] catPaths)
        {

            foreach (var path in catPaths)
                LoadCat(path);
        }

        public void LoadCat(string path)
        {
            var catFile = CATFile.FromFile(path);
            var newRecords = catFile.GetRecords();
            foreach (var record in newRecords)
                RemoveFile(record.InternalPath);
            _Records.AddRange(newRecords);
            _Records.Sort();
        }

        public void RemoveFile(string internalPath)
        {
            for(int i = 0; i < _Records.Count; i++)
            {
                var currentRecord = _Records[i];
                if (currentRecord.InternalPath == internalPath)
                {
                    _Records.RemoveAt(i);
                    return;
                }
            }
        }

        public void AddFile(string internalPath, byte[] data)
        {
            throw new NotImplementedException();
        }

        private void _ToggleEncryption(ref byte value)
        {
            value = (byte)((int)value ^ 0x33);
        }
        private byte[] _GetData(string datFilePath, long index, int size)
        {
            byte[] result = new byte[size];
            using (var fs = File.OpenRead(datFilePath))
            {
                fs.Seek(index, SeekOrigin.Begin);
                fs.Read(result,0,size);
            }

            // Decript data
            for(int count = size - 1; count >=0; count--)
            {
                _ToggleEncryption(ref result[count]);
            }

            return result;
        }
        public FileRecord GetRecord(string path)
        {
            foreach (var item in _Records)
                if (item.InternalPath == path)
                    return item;
            return null;
        }
        public byte[] GetFile(FileRecord record)
        {
            return _GetData(record.DatPath, record.Index, record.Size);
        }
        public byte[] GetFile(string path)
        {
            FileRecord record = GetRecord(path);
            if (record == null)
                return null;
            return _GetData(record.DatPath, record.Index, record.Size);
        }
        public string[] GetFiles()
        {
            string[] result = new string[Records.Length];
            for(int i = 0; i < Records.Length; i++)
            {
                result[i] = Records[i].InternalPath;
            }
            return result;
        }
        public void ExtractAll(string destDir)
        {
            foreach(var record in Records)
            {
                var path = Path.Combine(destDir, record.InternalPath);
                var dir = Path.GetDirectoryName(path);

                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllBytes(path,GetFile(record));

            }
        }
        public string[] GetDirectories(string baseDir)
        {
            List<string> result = new List<string>();
            string[] targetDirs = new string[0];
            if (!string.IsNullOrWhiteSpace(baseDir))
            {
                targetDirs = baseDir.Split('/');
            }
            foreach(var record in _Records)
            {
                var dirs = record.InternalDirectories;
                if (targetDirs == null)
                {
                    if(!result.Contains(dirs[0]))
                        result.Add(dirs[0]);
                    continue;
                }
                if (dirs.Length < targetDirs.Length + 1)
                    continue;
                bool temp = true;
                for(int i = 0; i < targetDirs.Length; i++)
                {
                    if(dirs[i] != targetDirs[i])
                    {
                        temp = false;
                        break;
                    }
                }
                if (temp)
                {
                    string[] resultPathSplit = new string[targetDirs.Length + 1];
                    Array.Copy(dirs, resultPathSplit, resultPathSplit.Length);
                    var resultPath = string.Join("/", resultPathSplit);
                    if (dirs.Length > targetDirs.Length && !result.Contains(resultPath))
                    {
                        result.Add(resultPath);
                    }
                }
            }
            return result.ToArray();
        }
        public string[] GetFiles(string baseDir)
        {
            List<string> files = new List<string>();
            foreach(var file in _Records)
                if(file.IsInDirectory(baseDir))
                    files.Add(file.InternalPath);
            return files.ToArray();
        }
    }
    #endregion
}
