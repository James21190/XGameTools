using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CommonToolLib
{
    public class PageReference<T>
    {
        private static class PageMaster
        {
            private static int _Index = 0;
            private const string _TempFolder = @".\PagingTemp\";

            public static string GetNewPagePath()
            {
                // Check temp folder exists
                if (!Directory.Exists(_TempFolder))
                {
                    Directory.CreateDirectory(_TempFolder);
                }

                string DesiredPath;
                // Get next available file name
                // Shouldn't be nessassary as the folder is cleared, but just in case
                do
                {
                    DesiredPath = _TempFolder + _Index++;
                } while (File.Exists(DesiredPath));
                return DesiredPath;
            }
        }
        public enum StorageType
        {
            BinaryArray,
            String,
            Bitmap,
            CSObject
        }
        public enum StorageMode
        {
            Read,
            ReadWrite
        }
        private string _Path;
        public readonly StorageType StoredType;
        public readonly StorageMode Mode;

        public T StoredObject
        {
            get
            {
                return (T)_StoredObject;
            }
            set
            {
                _StoredObject = value;
            }
        }
        private object _StoredObject
        {
            get
            {
                switch (StoredType)
                {
                    case StorageType.BinaryArray:
                        return File.ReadAllBytes(_Path);
                    case StorageType.String:
                        return File.ReadAllText(_Path);
                    case StorageType.Bitmap:
                        var stream = File.Open(_Path, FileMode.Open);
                        return new Bitmap(stream);
                    case StorageType.CSObject:
                        BinaryFormatter bf = new BinaryFormatter();
                        return bf.Deserialize(File.Open(_Path, FileMode.Open));
                }
                throw new NotImplementedException();
            }
            set
            {
                if (Mode != StorageMode.ReadWrite)
                    throw new Exception();
                switch (StoredType)
                {
                    case StorageType.BinaryArray:
                        File.WriteAllBytes(_Path, (byte[])value);
                        break;
                    case StorageType.String:
                        File.WriteAllText(_Path, (string)value);
                        break;
                    case StorageType.Bitmap:
                        ((Bitmap)value).Save(_Path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case StorageType.CSObject:
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(File.Open(_Path, FileMode.Create), value);
                        break;
                }
            }
        }

        public PageReference(T obj)
        {
            switch (obj)
            {
                case byte[] t:
                    StoredType = StorageType.BinaryArray;
                    break;
                case string t:
                    StoredType = StorageType.String;
                    break;
                case Bitmap t:
                    StoredType = StorageType.Bitmap;
                    break;
                default:
                    StoredType = StorageType.CSObject;
                    break;

            }
            _Path = PageMaster.GetNewPagePath();
            Mode = StorageMode.ReadWrite;
            StoredObject = obj;
        }

        ~PageReference()
        {
            switch (Mode)
            {
                case StorageMode.ReadWrite:
                    if (File.Exists(_Path))
                    {
                        File.Delete(_Path);
                    }
                    break;
            }
        }

        public void SaveAs(string path)
        {
            File.Copy(_Path, path, true);
        }
    }
}
