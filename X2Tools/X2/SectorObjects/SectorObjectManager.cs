using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects.Meta;
using CommonToolLib;
using CommonToolLib.ProcessHooking;


namespace X2Tools.X2.SectorObjects
{
    /// <summary>
    /// The main interface with all sector objects.
    /// </summary>
    public class SectorObjectManager : MemoryObject
    {
        #region MemoryValues
        public const int ByteSize = 100;

        public int Unknown_1;
        public int Unknown_2;
        /// <summary>
        /// Pointer to the first sector object in a linear list.
        /// </summary>
        public MemoryObjectPointer<SectorObject> pFirstSectorObject = new MemoryObjectPointer<SectorObject>();
        /// <summary>
        /// Pointer to the last sector object in a linear list.
        /// </summary>
        public int Unknown_3;
        public MemoryObjectPointer<SectorObject> pLastSectorObject = new MemoryObjectPointer<SectorObject>();
        /// <summary>
        /// Pointer to the hash table containing all SectorObject.
        /// </summary>
        public MemoryObjectPointer<HashTable<SectorObject>> pSectorObjectHashTable = new MemoryObjectPointer<HashTable<SectorObject>>();
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        /// <summary>
        /// Pointer to the SectorObject the player is currently piloting.
        /// </summary>
        public MemoryObjectPointer<SectorObject> pPlayerShip = new MemoryObjectPointer<SectorObject>();
        public int Unknown_12;
        public int PlayerShotsFired;
        public int PlayerMissilesLaunched;
        public int PlayerShotsHit;
        public int PlayerMissilesHit;
        public int PlayerSubDistanceDravelled;
        public int PlayerDistanceTraveled;
        public int Unknown_13;
        public int Unknown_14;
        public int Unknown_15;
        #endregion

        public SectorObjectManager()
        {

        }

        #region SectorObject Get
        /// <summary>
        /// Returns the SectorObject with a given ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(int ID)
        {
            // Load the hash table
            var HashTable = pSectorObjectHashTable.obj;
            return HashTable.GetObjectWithID(ID);
        }

        /// <summary>
        /// Returns the main space SectorObject
        /// </summary>
        /// <returns></returns>
        public SectorObject GetSpace()
        {
            var objects = GetSectorObjects(pFirstSectorObject.obj, false);
            foreach (var obj in objects)
            {
                if (obj.MainType == SectorObject.Main_Type.Sector)
                    return obj;
            }
            return null;
        }


        /// <summary>
        /// Returns an array of all SectorObjects and its children from a start address.
        /// If the address is 0, all SectorObjects are collected.
        /// </summary>
        /// <param name="Start"></param>
        /// <returns></returns>
        public SectorObject[] GetSectorObjects(SectorObject start, bool TraverseDown = true)
        {
            List<SectorObject> objs = new List<SectorObject>();
            var so = start;
            while (so.IsValid)
            {
                objs.Add(so);

                if (TraverseDown)
                {
                    var child = so.GetMetaData().GetFirstChild();
                    if (child != null && child.IsValid)
                        objs.AddRange(GetSectorObjects(child));
                }

                so = so.pNext.obj;
            }

            return objs.ToArray();
        }

        public SectorObject[] GetSectorObjectsWithType(SectorObject start, SectorObject.Main_Type main_Type, bool TraverseDown = true)
        {
            List<SectorObject> objs = new List<SectorObject>();
            var so = start;
            while (so.IsValid)
            {
                if (so.MainType == main_Type)
                    objs.Add(so);

                if (TraverseDown)
                {
                    var child = so.GetMetaData().GetFirstChild();
                    if (child != null && child.IsValid)
                        objs.AddRange(GetSectorObjectsWithType(child,main_Type));
                }

                so = so.pNext.obj;
            }

            return objs.ToArray();
        }

        /// <summary>
        /// Returns the SectorObject the player is currently flying.
        /// </summary>
        /// <returns></returns>
        public SectorObject GetPlayerShip()
        {
            return pPlayerShip.obj;
        }
        #endregion

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new BinaryObjectConverter();
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(pFirstSectorObject);
            collection.Append(Unknown_3);
            collection.Append(pLastSectorObject);
            collection.Append(pSectorObjectHashTable);
            collection.Append(Unknown_4);
            collection.Append(Unknown_5);
            collection.Append(Unknown_6);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(Unknown_9);
            collection.Append(Unknown_10);
            collection.Append(Unknown_11);
            collection.Append(pPlayerShip);
            collection.Append(Unknown_12);
            collection.Append(PlayerShotsFired);
            collection.Append(PlayerMissilesLaunched);
            collection.Append(PlayerShotsHit);
            collection.Append(PlayerMissilesHit);
            collection.Append(PlayerSubDistanceDravelled);
            collection.Append(PlayerDistanceTraveled);
            collection.Append(Unknown_13);
            collection.Append(Unknown_14);
            collection.Append(Unknown_15);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new BinaryObjectConverter(Memory);
            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref pFirstSectorObject);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref pLastSectorObject);
            collection.PopFirst(ref pSectorObjectHashTable);
            collection.PopFirst(ref Unknown_4);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref Unknown_6);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref Unknown_8);
            collection.PopFirst(ref Unknown_9);
            collection.PopFirst(ref Unknown_10);
            collection.PopFirst(ref Unknown_11);
            collection.PopFirst(ref pPlayerShip);
            collection.PopFirst(ref Unknown_12);
            collection.PopFirst(ref PlayerShotsFired);
            collection.PopFirst(ref PlayerMissilesLaunched);
            collection.PopFirst(ref PlayerShotsHit);
            collection.PopFirst(ref PlayerMissilesHit);
            collection.PopFirst(ref PlayerSubDistanceDravelled);
            collection.PopFirst(ref PlayerDistanceTraveled);
            collection.PopFirst(ref Unknown_13);
            collection.PopFirst(ref Unknown_14);
            collection.PopFirst(ref Unknown_15);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pPlayerShip.SetLocation(hProcess, address+56);
            pFirstSectorObject.SetLocation(hProcess, address);
            pLastSectorObject.SetLocation(hProcess, address);
            pSectorObjectHashTable.SetLocation(hProcess, address);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
