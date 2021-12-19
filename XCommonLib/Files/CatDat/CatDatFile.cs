using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    public class CatDatFile : IComparable
    {
        public string InternalPath;
        public byte[] Data;
        public DateTime Created;

        public string Extension 
        { 
            get
            {
                return Path.GetExtension(InternalPath);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is CatDatFile))
                throw new ArgumentException();
            var other = (CatDatFile)obj;

            var comparison = InternalPath.CompareTo(other.InternalPath);
            if (comparison != 0)
                return comparison;
            
            return Data.Length.CompareTo(other.Data.Length);
        }

        public T ConvertToBinaryObject<T>() where T : IBinaryObject,new()
        {
            var newt = new T();
            newt.SetData(Data);
            return newt;
        }

        public void LoadFromBinaryObject<T>(T obj) where T : IBinaryObject, new()
        {
            Data = obj.GetBytes();
        }
    }
}
