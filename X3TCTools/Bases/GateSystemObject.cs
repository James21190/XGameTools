using System;
using System.Collections.Generic;
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
    public class GateSystemObject : IMemoryObject
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
            #endregion
        }

        #endregion

        /// <summary>
        /// All identified sector names.
        /// </summary>
        public enum SectorName
        {
            Kingdom_End = 0x00000000,
            Rolks_Drift = 0x00000001,
            Queens_Space = 0x00000002,
            Menelaus_Frontier = 0x00000003,
            Ceos_Buckzoid = 0x00000004,
            Teladi_Gain = 0x00000005,
            Family_Whi = 0x00000006,
            Family_Zein = 0x00010006,
            Thuruks_Pride = 0x00020006,
            Ronkars_Fire = 0x00030006,
            Ronkars_Clouds = 0x00030007,
            Tharkas_Sun = 0x00030008,
            Chos_Defeat = 0x00030009,
            Patriarchs_Keep = 0x00040009,
            Two_Grand = 0x0004000a,
            Freedoms_Reach = 0x00070004,
            Xenon_Sector_534 = 0x00000011,
            Xenon_Sector_596 = 0x00000013,
            Three_Worlds = 0x00010000,
            Cloudbase_North_West = 0x00020000,
            Players_Sector = 0x00020014,
            Ringo_Moon = 0x00030000,
            Red_Light = 0x00040000,
            Ckoudbase_South_West = 0x00050000,
            Emperor_Mines = 0x00060000,
            Savage_Spur = 0x00070000,
            Ocracokes_Storm = 0x00080000,
            Senators_Badlands = 0x00090000,
            Weavers_Tempest = 0x000a0000,
            Omicron_Lyrae = 0x0006000d,
            Circle_Of_Labor = 0x0005000d,
            Heretics_End = 0x0004000d,
            Asteroid_Belt = 0x0003000b,
            Mars = 0x0003000c,
            Venus = 0x0002000c,
            The_Moon = 0x0002000d,
            Earth = 0x0003000d,
            The_Hub = 0x0008000d,
            Argon_Prime = 0x00030001
        }


        public const int byteSize = 0xfb410;
        // Height of the sector grid.
        public const int height = 0x14;
        // Width of the sector grid.
        public const int width = 0x15;
        // Max recognisable sector id
        public const int maxSectorID = width * height;

        // Function index where the script functions for modifying this object is found.
        public uint gateSystemFunctionIndex;
        public int unknown_1;
        public int unknown_2;
        public int unknown_3;
        // Collection of sector data
        public SectorData[] sectorData { get; } = new SectorData[width * height];

        private GameHook m_GameHook;

        private IntPtr pThis;

        public GateSystemObject(GameHook gameHook)
        {
            this.m_GameHook = gameHook;
            for (int i = 0; i < maxSectorID; i++)
            {
                sectorData[i] = new SectorData();
            }
            Reload();
        }

        /// <summary>
        /// Returns the name of a sector at given sector coordinates. Returns null if no friendly name is found.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public string GetSectorName(short X, short Y)
        {
            var result = ((SectorName)GetSectorFullPos(X, Y)).ToString();
            int o;
            if (int.TryParse(result, out o))
                return string.Format("({0},{1})", X, Y);
            return result;
        }

        /// <summary>
        /// Returns a single 32 bit intager with both x and y positions.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public int GetSectorFullPos(short X, short Y)
        {
            return (int)((ushort)Y << 16 | (ushort)X);
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

        /// <summary>
        /// Reload all variables.
        /// </summary>
        public void Reload()
        {
            pThis = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)GameHook.GlobalAddresses.GateSystemObject);
            SetData(MemoryControl.Read(m_GameHook.hProcess, pThis, byteSize));

            

        }

        #region IMemoryObject
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(byteSize);
            collection.Append(unknown_1);
            collection.Append(unknown_2);
            collection.Append(unknown_3);
            collection.Append(sectorData);
            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return byteSize;
        }

        public void SetData(byte[] Memory)
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
        #endregion
    }
}
