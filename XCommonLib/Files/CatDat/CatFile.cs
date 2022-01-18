using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public abstract class CatFile
    {
        /// <summary>
        /// Returns the paths of all internal files.
        /// </summary>
        /// <returns></returns>
        public abstract string[] GetInternalFiles();

        /// <summary>
        /// Returns the location in dat of an internal file.
        /// </summary>
        /// <param name="internalPath"></param>
        /// <returns></returns>
        public abstract FileLocationData GetInternalFileLocation(string internalPath);

        /// <summary>
        /// Returns the locations of all internal files in dat.
        /// </summary>
        /// <returns></returns>
        public abstract FileLocationData[] GetInternalFileLocations();

        /// <summary>
        /// Loads a .cat file.
        /// </summary>
        /// <param name="path"></param>
        public abstract void LoadEntriesFromFile(string path);

        /// <summary>
        /// Saves a .cat file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="forceNoEncryption">If true, any encryption that would be applied is ignored when saving.</param>
        public abstract void SaveEntriesToFile(string path, bool forceNoEncryption);
    }
}
