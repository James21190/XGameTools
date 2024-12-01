using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    /// <summary>
    /// The patcher opens a file to write patches to. Contents of the file are overwritten with the patch data.
    /// </summary>
    public class FilePatcher : IDisposable
    {
        private FileStream _file;
        private FileProfile _profile;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Path to the file to be patched.</param>
        /// <param name="profile">File profile detailing address spaces.</param>
        public FilePatcher(string filePath, FileProfile profile)
        {
            _file = File.Open(filePath, FileMode.Open);
            _profile = profile;
        }

        private delegate void WriteMethod(int index, byte[] bytes);

        private void _WriteCopy(int index, byte[] bytes)
        {
            _file.Seek(index, SeekOrigin.Begin);
            _file.Write(bytes, 0, bytes.Length);
        }

        private void _WriteXOR(int index, byte[] bytes)
        {
            byte[] tmp = new byte[bytes.Length];

            _file.Seek(index, SeekOrigin.Begin);
            _file.Read(tmp, 0, tmp.Length);

            for (int i = 0; i < tmp.Length; i++)
                tmp[i] ^= bytes[i];

            _file.Seek(index, SeekOrigin.Begin);
            _file.Write(tmp, 0, tmp.Length);
        }

        /// <summary>
        /// Applies a file patch to the loaded file.
        /// </summary>
        /// <param name="patch"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ApplyPatch(FilePatch patch)
        {

            WriteMethod writeMethod;

            switch (patch.Method)
            {
                case FilePatch.PatchMethod.COPY: writeMethod = _WriteCopy; break;
                case FilePatch.PatchMethod.XOR: writeMethod = _WriteXOR; break;
                default: throw new NotImplementedException();
            }

            foreach(var section in patch.Sections)
            {
                writeMethod(_profile.GetIndexOfAddress(section.Address), section.Bytes);
            }
        }

        public void Dispose()
        {
            _file.Dispose();
        }
    }
}
