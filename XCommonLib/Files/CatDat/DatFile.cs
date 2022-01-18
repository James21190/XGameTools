using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public abstract class DatFile
    {
        public string Path;

        /// <summary>
        /// Returns data from the dat file as a new IBinaryObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileLocationData"></param>
        /// <returns></returns>
        public T GetDataAsBinaryObject<T>(FileLocationData fileLocationData) where T : IBinaryObject, new()
        {
            var result = new T();
            result.SetData(GetData(fileLocationData));
            return result;
        }
        /// <summary>
        /// Returns data from the dat file.
        /// </summary>
        /// <param name="fileLocationData"></param>
        /// <returns></returns>
        public byte[] GetData(FileLocationData fileLocationData)
        {
            return GetData(fileLocationData.DatIndex, fileLocationData.Length);
        }
        /// <summary>
        /// Returns data from the dat file as a new IBinaryObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public T GetDataAsBinaryObject<T>(int index, int length) where T : IBinaryObject, new()
        {
            var result = new T();
            result.SetData(GetData(index, length));
            return result;
        }
        /// <summary>
        /// Returns data from the dat file.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public abstract byte[] GetData(int index, int length);
    }
}
