using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    public struct FileProfile
    {
        /// <summary>
        /// A structure to represent how the data address of a file changes at specific points in the file.
        /// Such as when an exe is loaded into data.
        /// </summary>
        public struct Region
        {
            /// <summary>
            /// The index in bytes within the file the address is set.
            /// </summary>
            public int FileIndex;
            /// <summary>
            /// The data address the file index will be loaded in data.
            /// </summary>
            public int Address;

            public override string ToString()
            {
                return FileIndex.ToString() + " " + Address.ToString("X");
            }

            public static Region FromString(string line)
            {
                Region region = new Region();

                var split = line.Split(' ');

                region.FileIndex = int.Parse(split[0]);
                region.Address = int.Parse(split[1], System.Globalization.NumberStyles.HexNumber);

                return region;
            }
        }

        /// <summary>
        /// The expected file name.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The expected hash of the file.
        /// </summary>
        public string FileHash;

        public Region[] dataRegions;

        public static string GenerateFileHash(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var hashAlgorithm = SHA256.Create())
                {
                    var hash = hashAlgorithm.ComputeHash(fileStream);
                    return Convert.ToBase64String(hash);
                }
            }
        }

        public Region GetRegionOfAddress(int address)
        {
            // Get the region that the address falls into.
            Region currentRegion = new Region()
            {
                FileIndex = 0,
                Address = 0
            };

            for (int i = 0; i < dataRegions.Length; i++)
            {
                var region = dataRegions[i];
                // If the region address is less than the target, and higher than the current, set the region as current.
                if (region.Address <= address && region.Address > currentRegion.Address)
                {
                    currentRegion = region;
                }
            }

            return currentRegion;
        }

        public Region GetRegionOfFileIndex(int index)
        {
            // Get the region that the index falls into.
            Region currentRegion = new Region()
            {
                FileIndex = 0,
                Address = 0
            };

            for (int i = 0; i < dataRegions.Length; i++)
            {
                var region = dataRegions[i];
                // If the region index is less than the target, and higher than the current, set the region as current.
                if (region.FileIndex <= index && region.FileIndex > currentRegion.FileIndex)
                {
                    currentRegion = region;
                }
            }

            return currentRegion;
        }

        public int GetIndexOfAddress(int address)
        {
            var region = GetRegionOfAddress(address);

            return region.FileIndex + (address - region.Address);
        }

        public int GetAddressOfFileIndex(int index)
        {
            var region = GetRegionOfFileIndex(index);

            return region.Address + (index - region.FileIndex);
        }

        public static FileProfile FromFile(string path)
        {
            var result = new FileProfile();

            var lines = File.ReadAllLines(path);
            result.FileHash = lines[0];
            result.FileHash = lines[1];

            result.dataRegions = new Region[lines.Length - 2];

            for(int i = 2; i < lines.Length; i++)
            {
                var line = lines[i];

                var region = Region.FromString(line);
                result.dataRegions[i-2] = region;

            }

            return result;
        }

        public void ToFile(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(FileName);
            sw.WriteLine(FileHash);

            foreach(var region in dataRegions)
            {
                sw.WriteLine(region.ToString());
            }

        }
    }
}
