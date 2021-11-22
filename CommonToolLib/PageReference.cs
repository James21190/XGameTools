using System;
using System.Drawing;
using System.IO;

namespace CommonToolLib
{
    public class PageReference
    {
        private static class PageMaster
        {
            private static int _Index = 0;
            private const string _TempFolder = @".\PagingLibTemp\";


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
            Image
        }
        public enum StorageMode
        {
            Read,
            ReadWrite
        }
        private string _Path;
        public readonly StorageType StoredType;
        public readonly StorageMode Mode;
        public object StoredObject
        {
            get
            {
                switch (StoredType)
                {
                    case StorageType.Image:
                        return _GetAsBitmap();
                }
                throw new NotImplementedException();
            }
        }

        public PageReference(string path, StorageType storageType, StorageMode mode)
        {
            StoredType = storageType;
            Mode = mode;
            switch (mode)
            {
                case StorageMode.Read:
                    _Path = path;
                    break;
                case StorageMode.ReadWrite:
                    _Path = PageMaster.GetNewPagePath();
                    File.Copy(path, _Path);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public PageReference(Bitmap obj)
        {
            _Path = PageMaster.GetNewPagePath();
            StoredType = StorageType.Image;
            Mode = StorageMode.ReadWrite;
            obj.Save(_Path, System.Drawing.Imaging.ImageFormat.Jpeg);
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

        private Bitmap _GetAsBitmap()
        {
            Bitmap result;
            using (var stream = File.Open(_Path, FileMode.Open))
            {
                result = new Bitmap(stream);
            }
            return result;
        }

    }
}
