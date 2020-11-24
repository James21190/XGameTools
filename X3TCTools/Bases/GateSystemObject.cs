using Common.Memory;
using Common.Vector;
using System;
using System.IO;

namespace X3Tools.Bases
{
    /// <summary>
    /// Main object that represents the GateSystemObject.
    /// </summary>
    public class GateSystemObject : MemoryObject
    {
        #region Classes

        public class SectorData : MemoryObject
        {
            public GateData[] gateData { get; } = new GateData[6];
            public short unknown_1;
            public GameHook.RaceID owningRace;
            public int unknown_2;
            public int unknown_3;
            public int unknown_4;
            public int unknown_5;
            public int unknown_6;
            public int unknown_7;
            public int unknown_8;
            public class GateData : MemoryObject
            {
                public byte DstSecX;
                public byte DstSecY;
                public ushort DstGateID;
                public int Unknown_1;
                public int Unknown_2;
                public int Unknown_3;
                public Vector3 Position;
                public int Unknown_4;

                #region IMemoryObject
                public override byte[] GetBytes()
                {
                    ObjectByteList Collection = new ObjectByteList();
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

                public override int ByteSize => 32;

                public override void SetData(byte[] Memory)
                {
                    ObjectByteList collection = new ObjectByteList(Memory);
                    collection.PopFirst(ref DstSecX);
                    collection.PopFirst(ref DstSecY);
                    collection.PopFirst(ref DstGateID);
                    collection.PopFirst(ref Unknown_1);
                    collection.PopFirst(ref Unknown_2);
                    collection.PopFirst(ref Unknown_3);
                    collection.PopFirst(ref Position);
                    collection.PopFirst(ref Unknown_4);
                }
                public override void SetLocation(IntPtr hProcess, IntPtr address)
                {
                    throw new NotImplementedException();
                }
                #endregion
            }

            public SectorData()
            {
                for (int i = 0; i < 6; i++)
                {
                    gateData[i] = new GateData();
                }
            }



            #region IMemoryObject

            public override byte[] GetBytes()
            {
                ObjectByteList collection = new ObjectByteList();
                collection.Append(unknown_1);
                collection.Append((short)owningRace);
                collection.Append(unknown_2);
                collection.Append(unknown_3);
                collection.Append(unknown_4);
                collection.Append(unknown_5);
                collection.Append(unknown_6);
                collection.Append(unknown_7);
                collection.Append(unknown_8);

                return collection.GetBytes();
            }

            public static int ByteSizeConst = 0xe0;
            public override int ByteSize => ByteSizeConst;

            public override void SetData(byte[] Memory)
            {
                ObjectByteList collection = new ObjectByteList(Memory);

                for (int i = 0; i < 6; i++)
                {
                    collection.PopFirst(ref gateData[i]);
                }

                short tempShort = 0;

                collection.PopFirst(ref unknown_1);
                collection.PopFirst(ref tempShort);
                owningRace = (GameHook.RaceID)tempShort;
                collection.PopFirst(ref unknown_2);
                collection.PopFirst(ref unknown_3);
                collection.PopFirst(ref unknown_4);
                collection.PopFirst(ref unknown_5);
                collection.PopFirst(ref unknown_6);
                collection.PopFirst(ref unknown_7);
                collection.PopFirst(ref unknown_8);
            }
            #endregion
        }

        #endregion

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
        public SectorData[] sectorData;

        public GateSystemObject()
        {
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

            if (!File.Exists(path))
            {
                goto failed;
            }

            string[] lines = File.ReadAllLines(path);

            if (lines.Length <= Y || Y < 0)
            {
                goto failed;
            }

            string line = lines[Y];

            string[] names = line.Split(',');

            if (names.Length <= X)
            {
                goto failed;
            }

            string name = names[X];

            if (string.IsNullOrEmpty(name))
            {
                goto failed;
            }

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
            return (ushort)(Y << 8 | X);
        }

        /// <summary>
        /// Returns the sector data at given sector coordinates.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public SectorData GetSector(short X, short Y)
        {
            return sectorData[GetIndexOfSector(X,Y)];
        }

        public static int GetIndexOfSector(short X, short Y)
        {
            return Y + X * height;
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(gateSystemFunctionIndex);
            collection.Append(unknown_1);
            collection.Append(unknown_2);
            collection.Append(unknown_3);
            collection.Append(sectorData);
            return collection.GetBytes();
        }

        public override int ByteSize => 0xfb410;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            gateSystemFunctionIndex = objectByteList.PopUInt();
            unknown_1 = objectByteList.PopInt();
            unknown_2 = objectByteList.PopInt();
            unknown_3 = objectByteList.PopInt();
            sectorData = objectByteList.PopIMemoryObjects<SectorData>(maxSectorID);
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            if(sectorData != null)
                for(int i = 0; i < sectorData.Length; i++)
                {
                    sectorData[i].SetLocation(hProcess, address + 0x10 + i * SectorData.ByteSizeConst);
                }
        }
        #endregion
    }
}
