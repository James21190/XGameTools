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
        public string[] GetInternalFiles(string basePath, bool depth = false)
        {
            List<string> files = new List<string>();
            foreach (var file in GetInternalFiles())
            {
                // If the current file is longer than the base path...
                if (file.Length > basePath.Length)
                {
                    // Compare the start of the path
                    for (int i = 0; i < basePath.Length; i++)
                    {
                        if (file[i] != basePath[i])
                            goto end;
                    }

                    // If depth is not enabled, make sure it's not in a deeper directory
                    if (!depth)
                    {
                        for (int i = basePath.Length + 1; i < file.Length; i++)
                        {
                            if (file[i] == '/' || file[i] == '\\')
                                goto end;
                        }
                    }

                    files.Add(file);
                }
            end:;
            }

            return files.ToArray();
        }
        public abstract byte[] GetInternalFile(string internalPath, ExtractionMode extractionMode);
        public abstract void ExtractAll(string targetDirectory, ExtractionMode extractionMode = ExtractionMode.None);
    }
    public class CatDatPair <C,D,P> : AbstractCatDatPair 
        where C : CatFile, new() 
        where D : DatFile, new() 
        where P : CompressedFile, new()
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
        /// <summary>
        /// Returns the internal bytes. Extraction mode can be set if it's a compressed file to decrypt it if required.
        /// </summary>
        /// <param name="internalPath"></param>
        /// <param name="extractionMode"></param>
        /// <returns></returns>
        public override byte[] GetInternalFile(string internalPath, ExtractionMode extractionMode = ExtractionMode.None)
        {
            var internalFileLocation = m_CatFile.GetInternalFileLocation(internalPath);
            var data = m_DatFile.GetData(internalFileLocation);
            if (extractionMode == ExtractionMode.None)
                return data;
            // If the file is identified as a compressed file...
            var compressedFile = new P();
            compressedFile.SetData(data);
            if (extractionMode == ExtractionMode.Decrypt)
                return compressedFile.CompressedData;
            return compressedFile.DecompressedData;
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
                byte[] fileBytes = GetInternalFile(internalPath);

                // Apply decryption and extraction if needed
                if (extractionMode == ExtractionMode.Decrypt || extractionMode == ExtractionMode.DecryptAndExtract)
                {
                    // Decrypt and write.
                    var extension = Path.GetExtension(internalPath);
                    switch (extension)
                    {
                        // Compressed files
                        case ".pbd":
                        case ".pck":
                            var compressedFile = new P();
                            compressedFile.SetData(fileBytes);
                            // If only decrypt
                            if (extractionMode == ExtractionMode.Decrypt)
                            {
                                File.WriteAllBytes(targetPath, compressedFile.CompressedData);
                            }
                            // If decrypt and extract
                            else
                            {
                                // Get new extension
                                string newExtension;
                                switch (Path.GetExtension(internalPath))
                                {
                                    case ".pbd":
                                        newExtension = ".bod";
                                        break;
                                    case ".pck":
                                        newExtension = ".txt";
                                        break;
                                    default:
                                        throw new NotImplementedException();
                                }
                                File.WriteAllBytes(Path.ChangeExtension(targetPath, newExtension), compressedFile.DecompressedData);
                            }
                            break;
                        default:
                            File.WriteAllBytes(targetPath, fileBytes);
                            break;
                    }
                }
                // Write raw internal file without decryption
                else
                {
                    File.WriteAllBytes(targetPath, fileBytes);
                }

            }
        }
    }
}
