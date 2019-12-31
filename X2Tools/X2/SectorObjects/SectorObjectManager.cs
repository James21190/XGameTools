using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects.Meta;
using Common;
using Common.Memory;


namespace X2Tools.X2.SectorObjects
{
    /// <summary>
    /// The main interface with all sector objects.
    /// </summary>
    public class SectorObjectManager
    {
        /// <summary>
        /// Pointer to the first sector object in a linear list.
        /// </summary>
        public IntPtr pFirstSectorObject { get; private set; }
        /// <summary>
        /// Pointer to the last sector object in a linear list.
        /// </summary>
        public IntPtr pLastSectorObject { get; private set; }
        /// <summary>
        /// Pointer to the hash table containing all SectorObject.
        /// </summary>
        private IntPtr pObjectHashTable;
        /// <summary>
        /// Pointer to the SectorObject the player is currently piloting.
        /// </summary>
        public IntPtr pPlayerShip { get; private set; }
        

        private readonly GameHook m_GameHook;
        public SectorObjectManager(GameHook gameHook)
        {
            m_GameHook = gameHook;

            Reload();
        }

        /// <summary>
        /// Reloads all values stored in the SectorObjectManager
        /// </summary>
        public void Reload()
        {
            var pThis = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)GlobalAddresses.pSectorObjectManager);
            pFirstSectorObject = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (pThis + 8));
            pLastSectorObject = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (pThis + 16));
            pObjectHashTable = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (pThis + 20));
            pPlayerShip = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (pThis + 56));
        }

        #region SectorObject Get
        /// <summary>
        /// Returns the SectorObject that is stored at the given address.
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(IntPtr Address)
        {
            if(Address != IntPtr.Zero)
                return new SectorObject(m_GameHook, Address);
            throw new AddressNullException();
        }

        /// <summary>
        /// Returns the SectorObject with a given ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(int ID)
        {
            // Reload memory to check for changes.
            Reload();
            // Load the hash table
            var HashTable = new HashTable(m_GameHook, MemoryControl.Read(m_GameHook.hProcess, pObjectHashTable, 16));
            return GetSectorObject(HashTable.GetObjectWithID(ID));
        }

        /// <summary>
        /// Returns the main space SectorObject
        /// </summary>
        /// <returns></returns>
        public SectorObject GetSpace()
        {
            foreach(var item in GetSectorObjects(IntPtr.Zero, false))
            {
                if (item.MainType == SectorObject.Main_Type.Sector && (SectorObject.Sector_Sub_Type)item.SubType == SectorObject.Sector_Sub_Type.Space)
                    return item;
            }
            throw new IndexOutOfRangeException();
        }

        public bool SectorObjectExists(int ID, out SectorObject sectorObject)
        {
            sectorObject = null;
            var HashTable = new HashTable(m_GameHook, MemoryControl.Read(m_GameHook.hProcess, pObjectHashTable, 16));
            var id = HashTable.GetObjectWithID(ID);
            if (id == IntPtr.Zero)
                return false;
            sectorObject = GetSectorObject(id);
            return true;
        }

        /// <summary>
        /// Returns an array of all SectorObjects and its children from a start address.
        /// If the address is 0, all SectorObjects are collected.
        /// </summary>
        /// <param name="Start"></param>
        /// <returns></returns>
        public SectorObject[] GetSectorObjects(IntPtr Start, bool TraverseDown = true)
        {
            Reload();
            if (Start == IntPtr.Zero)
                Start = pFirstSectorObject;
            List<SectorObject> objects = new List<SectorObject>();
            // Get first
            var so = GetSectorObject(Start);

            // If at end of array, return
            while (so.Next != IntPtr.Zero)
            {
                objects.Add(so);
                if(TraverseDown)
                    switch (so.MainType)
                    {
                        case SectorObject.Main_Type.Sector:
                            var sectorMeta = new SectorMeta(m_GameHook.hProcess, so.pMeta);
                            objects.AddRange(GetSectorObjects(sectorMeta.FirstChild));
                            break;
                        case SectorObject.Main_Type.Ship:
                            var shipMeta = new ShipMeta(m_GameHook.hProcess, so.pMeta);
                            objects.AddRange(GetSectorObjects(shipMeta.FirstChild));
                            break;
                    }
                so = GetSectorObject(so.Next);
            }
            return objects.ToArray();
        }

        public SectorObject[] GetSectorObjectsWithType(IntPtr Start, SectorObject.Main_Type main_Type, bool TraverseDown = true)
        {
            List<SectorObject> results = new List<SectorObject>();
            foreach(var item in GetSectorObjects(Start, TraverseDown))
            {
                if (item.MainType == main_Type)
                    results.Add(item);
            }
            return results.ToArray();
        }

        /// <summary>
        /// Returns the address of a SectorObject with a given ID.
        /// Returns a null pointer if the object is not found.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IntPtr GetAddressOfSectorObject(int ID)
        {
            Reload();
            var HashTable = new HashTable(m_GameHook, MemoryControl.Read(m_GameHook.hProcess, pObjectHashTable, 16));
            return HashTable.GetObjectWithID(ID);
        }

        /// <summary>
        /// Returns the SectorObject the player is currently flying.
        /// </summary>
        /// <returns></returns>
        public SectorObject GetPlayerShip()
        {
            Reload();
            return new SectorObject(m_GameHook, pPlayerShip);
        }
        #endregion

    }
}
