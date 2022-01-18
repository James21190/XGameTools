using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public abstract class AbstractCatDatPair
    {
        public enum ExtractionMode
        {
            None,
            Decrypt,
            DecryptAndExtract
        }
        internal AbstractCatDatPair()
        {
        }

        public abstract string[] GetInternalFiles();
        public abstract byte[] GetInternalFile(string internalPath);
        public abstract void ExtractAll(string targetDirectory, ExtractionMode extractionMode = ExtractionMode.None);
    }
    public class CatDatPair <C,D,P> : AbstractCatDatPair where C : CatFile, new() where D : DatFile, new() where P : PckFile, new()
    {

        private C m_CatFile = new C();
        private D m_DatFile = new D();

        #region Constructors
        public CatDatPair(string catPath, string datPath)
        {
            m_CatFile.LoadEntriesFromFile(catPath);
            m_DatFile.Path = datPath;
        }
        public CatDatPair(string path)
        {
            m_CatFile.LoadEntriesFromFile(path + ".cat");
            m_DatFile.Path = path + ".dat";
        }
        #endregion

        public override string[] GetInternalFiles()
        {
            return m_CatFile.GetInternalFiles();
        }
        public override byte[] GetInternalFile(string internalPath)
        {
            var internalFileLocation = m_CatFile.GetInternalFileLocation(internalPath);
            return m_DatFile.GetData(internalFileLocation);
        }
        public override void ExtractAll(string targetDirectory, ExtractionMode extractionMode = ExtractionMode.None)
        {
            foreach(var internalPath in GetInternalFiles())
            {
                // Get the path of the destination file
                var targetPath = Path.Combine(targetDirectory, internalPath);
                // Ensure target directory exists
                if(!Directory.Exists(Path.GetDirectoryName(targetPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                }
                // Get the internal file from the .dat file
                var fileBytes = GetInternalFile(internalPath);

                // Apply decryption and extraction if needed
                if (extractionMode == ExtractionMode.Decrypt || extractionMode == ExtractionMode.DecryptAndExtract)
                {
                    switch(Path.GetExtension(internalPath))
                    {
                        case ".pck":
                            var pckFile = new P();
                            pckFile.SetData(fileBytes);
                            if(extractionMode == ExtractionMode.DecryptAndExtract)
                            {
                                fileBytes = pckFile.DecompressedData;
                            }
                            else
                            {
                                fileBytes = pckFile.CompressedData;
                            }
                            break;
                    }
                }

                // Write the internal file to the path
                File.WriteAllBytes(targetPath, fileBytes);
            }
        }
    }
}
