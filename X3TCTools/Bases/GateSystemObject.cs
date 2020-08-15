using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;
using Common.Vector;

namespace X3TCTools.Bases
{
    /// <summary>
    /// Main object that represents the GateSystemObject.
    /// </summary>
    public class GateSystemObject : MemoryObject
    {
        #region Classes

        public class SectorData : IMemoryObject
        {

            public const int ByteSize = 0xe0;
            public GateData[] gateData { get; } = new GateData[6];
            public short unknown_1;
            public GameHook.RaceID owner;
            public int unknown_2;
            public int unknown_3;
            public int unknown_4;
            public int unknown_5;
            public int unknown_6;
            public int unknown_7;
            public int unknown_8;
            public class GateData : IMemoryObject
            {

                public const int ByteSize = 32;

                public byte DstSecX;
                public byte DstSecY;
                public ushort DstGateID;
                public int Unknown_1;
                public int Unknown_2;
                public int Unknown_3;
                public Vector3 Position;
                public int Unknown_4;

                #region IMemoryObject
                public byte[] GetBytes()
                {
                    var Collection = new ObjectByteList();
                    Collection.Append(DstSecX);
                    Collection.Append(DstSecY);
                    Collection.Append(DstGateID);
                    Collection.Append(Unknown_1);
                    Collection.Append(Unknown_2);
                    Collection.Append(Unknown_3);
                    Collection.Append(Position);
                    Collection.Append(Unknown_4);

                    return Collection.GetBytes();
                }

                public int GetByteSize()
                {
                    return ByteSize;
                }

                public void SetData(byte[] Memory)
                {
                    var collection = new ObjectByteList(Memory);
                    collection.PopFirst(ref DstSecX);
                    collection.PopFirst(ref DstSecY);
                    collection.PopFirst(ref DstGateID);
                    collection.PopFirst(ref Unknown_1);
                    collection.PopFirst(ref Unknown_2);
                    collection.PopFirst(ref Unknown_3);
                    collection.PopFirst(ref Position);
                    collection.PopFirst(ref Unknown_4);
                }
                public void SetLocation(IntPtr hProcess, IntPtr address)
                {
                    throw new NotImplementedException();
                }

                public void ReloadFromMemory()
                {
                    throw new NotImplementedException();
                }
                #endregion
            }

            public SectorData()
            {
                for(int i = 0; i < 6; i++)
                {
                    gateData[i] = new GateData();
                }
            }

            

            #region IMemoryObject

            public byte[] GetBytes()
            {
                var collection = new ObjectByteList();
                collection.Append(unknown_1);
                collection.Append((short)owner);
                collection.Append(unknown_2);
                collection.Append(unknown_3);
                collection.Append(unknown_4);
                collection.Append(unknown_5);
                collection.Append(unknown_6);
                collection.Append(unknown_7);
                collection.Append(unknown_8);

                return collection.GetBytes();
            }

            public int GetByteSize()
            {
                return ByteSize;
            }

            public void SetData(byte[] Memory)
            {
                var collection = new ObjectByteList(Memory);

                for (int i = 0; i < 6; i++)
                {
                    collection.PopFirst(ref gateData[i]);
                }

                short tempShort = 0;

                collection.PopFirst(ref unknown_1);
                collection.PopFirst(ref tempShort);
                owner = (GameHook.RaceID)tempShort;
                collection.PopFirst(ref unknown_2);
                collection.PopFirst(ref unknown_3);
                collection.PopFirst(ref unknown_4);
                collection.PopFirst(ref unknown_5);
                collection.PopFirst(ref unknown_6);
                collection.PopFirst(ref unknown_7);
                collection.PopFirst(ref unknown_8);
            }
            public void SetLocation(IntPtr hProcess, IntPtr address)
            {
                throw new NotImplementedException();
            }

            public void ReloadFromMemory()
            {
                throw new NotImplementedException();
            }
            #endregion
        }

        #endregion


        public const int byteSize = 0xfb410;
        // Height of the sector grid.
        public const int height = 20;
        // Width of the sector grid.
        public const int width = 24;
        // Max recognisable sector id
        public const int maxSectorID = width * height;

        // Function index where the script functions for modifying this object is found.
        public uint gateSystemFunctionIndex;
        public int unknown_1;
        public int unknown_2;
        public int unknown_3;
        // Collection of sector data
        public SectorData[] sectorData { get; } = new SectorData[width * height];

        public GateSystemObject()
        {
            for (int i = 0; i < maxSectorID; i++)
            {
                sectorData[i] = new SectorData();
            }
        }

        /// <summary>
        /// Returns the name of a sector at given sector coordinates. Returns null if no friendly name is found.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public string GetSectorName(int X, int Y)
        {
            string path;

            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC: path = "./Data/TC/X3TCSectorNames.csv"; break;
                case GameHook.GameVersions.X3AP: path = "./Data/AP/X3APSectorNames.csv"; break;
                default: throw new Exception();
            }

            if (!File.Exists(path)) goto failed;

            var lines = File.ReadAllLines(path);

            if (lines.Length <= Y || Y < 0) goto failed;

            var line = lines[Y];

            var names = line.Split(',');

            if (names.Length <= (int)X) goto failed;

            var name = names[(int)X];

            if (string.IsNullOrEmpty(name)) goto failed;

            return name;

        failed:
            return X + "," + Y;
        }

        /// <summary>
        /// Returns a single 32 bit intager with both x and y positions.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public int GetSectorFullPos(byte X, byte Y)
        {
            return (ushort)((byte)Y << 8 | (byte)X);
        }

        /// <summary>
        /// Returns the sector data at given sector coordinates.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public SectorData GetSector(short X, short Y)
        {
            return sectorData[Y + X * (width-1)];
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(byteSize);
            collection.Append(unknown_1);
            collection.Append(unknown_2);
            collection.Append(unknown_3);
            collection.Append(sectorData);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return byteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref gateSystemFunctionIndex);
            collection.PopFirst(ref unknown_1);
            collection.PopFirst(ref unknown_2);
            collection.PopFirst(ref unknown_3);
            for (int i = 0; i < maxSectorID; i++) {
                collection.PopFirst(ref sectorData[i]);
            }
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
