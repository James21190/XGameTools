using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common
{
    /// <summary>
    /// Object that can be used to patch executables with patch files.
    /// </summary>
    public static class Patcher
    {
        /// <summary>
        /// Patch data
        /// </summary>
        private struct Patch
        {
            public string notes;
            public int address;
            public byte[] bytes;
        }

        /// <summary>
        /// Converts a string array into a byte array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static byte[] _StringArrToByteArr(string[] arr)
        {
            byte[] res = new byte[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                res[i] = byte.Parse(arr[i], System.Globalization.NumberStyles.HexNumber);
            }
            return res;
        }

        /// <summary>
        /// Copies the original file and writes changes to it sorced from multiple files, then outputs a file to the specified path.
        /// If the file already exists it is overwritten.
        /// Returns a list of patch notes.
        /// </summary>
        /// <param name="originalPath"></param>
        /// <param name="destPath"></param>
        /// <param name="patchPaths"></param>
        /// <param name="exeBaseOffset"></param>
        /// <param name="bytesBeforeBase"></param>
        /// <returns></returns>
        public static string PatchExe(string originalPath, string destPath, string[] patchPaths, int exeBaseOffset, int bytesBeforeBase)
        {
            string[] output = new string[patchPaths.Length];
            File.Copy(originalPath, destPath, true);
            int i = 0;
            foreach(var patch in patchPaths)
            {

                output[i++] = PatchExe(destPath, destPath, patch, exeBaseOffset, bytesBeforeBase);
            }

            return string.Join("", output);
        }

        /// <summary>
        /// Copies the original file and writes changes to it, then outputs a file to the specified path.
        /// If the file already exists it is overwritten.
        /// Returns a list of patch notes.
        /// </summary>
        /// <param name="originalPath"></param>
        /// <param name="destPath"></param>
        /// <param name="patchPath"></param>
        /// <param name="exeBaseOffset"></param>
        /// <returns></returns>
        public static string PatchExe(string originalPath, string destPath, string patchPath, int exeBaseOffset, int bytesBeforeBase)
        {
            List<Patch> patches = new List<Patch>();
            // Get all patch objects
            foreach(var line in File.ReadAllLines(patchPath))
            {
                var comp = line.Split(':');
                var patch = new Patch() { notes = comp[0], address = int.Parse(comp[1], System.Globalization.NumberStyles.HexNumber), bytes = _StringArrToByteArr(comp[2].Split(' ')) };
                patches.Add(patch);
            }

            StringBuilder sb = new StringBuilder();

            byte[] file = File.ReadAllBytes(originalPath);

            foreach (var patch in patches)
            {
                var patchBase = patch.address - exeBaseOffset + bytesBeforeBase;
                for (int i = 0; i < patch.bytes.Length; i++)
                {
                    file[patchBase + i] = patch.bytes[i];
                }

                sb.Append(string.Format("Overwritten {0} bytes at 0x{1} with note: {2}\n", patch.bytes.Length, patch.address.ToString("X"), patch.notes));

            }

            File.WriteAllBytes(destPath, file);

            return sb.ToString();
        }
    }
}
