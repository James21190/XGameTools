using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files.Patcher
{
    public struct FileProfile
    {
        /// <summary>
        /// A structure to represent how the memory address of a file changes at specific points in the file.
        /// Such as when an exe is loaded into memory.
        /// </summary>
        public struct Region
        {
            /// <summary>
            /// The index in bytes within the file the address is set.
            /// </summary>
            public int FileIndex;
            /// <summary>
            /// The memory address the file index will be loaded in memory.
            /// </summary>
            public int Address;
        }

        /// <summary>
        /// The expected file name.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The expected hash of the file.
        /// </summary>
        public string FileHash;

        public Region[] MemoryRegions;

        public Region GetRegionOfAddress(int address)
        {
            // Get the region that the address falls into.
            Region currentRegion = new Region()
            {
                FileIndex = 0,
                Address = 0
            };

            for (int i = 0; i < MemoryRegions.Length; i++)
            {
                var region = MemoryRegions[i];
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

            for (int i = 0; i < MemoryRegions.Length; i++)
            {
                var region = MemoryRegions[i];
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
    }
}
