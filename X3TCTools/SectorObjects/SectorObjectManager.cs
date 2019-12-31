using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace X3TCTools.SectorObjects
{
    /// <summary>
    /// Main object that holds references to all active SectorObjects.
    /// </summary>
    public class SectorObjectManager : IMemoryObject
    {
        public const int ByteSize = 0x68;

        GameHook m_GameHook;
        public IntPtr pThis;

        public int Unknown_1;
        public int Unknown_2;
        public IntPtr pFirst;
        public int Unknown_3;
        public IntPtr pLast;
        public IntPtr pObjectHashTable;
        public int Unknown_4;
        public int Unknown_5;
        public int Unknown_6;
        public int Unknown_7;
        public int Unknown_8;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public IntPtr pPlayerShip;
        public int Unknown_12;
        public int Unknown_13;
        public int Unknown_14;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public int Unknown_19;
        public int Unknown_20;
        public int Unknown_21;
        public int Unknown_22;

        public SectorObjectManager(GameHook gameHook)
        {
            m_GameHook = gameHook;
            pThis = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)GameHook.GlobalAddresses.SectorObjectManager);
            Reload();
        }

        public SectorObject GetSpace()
        {
            var so = GetSectorObject(pFirst);
            while(so.MainType != SectorObject.Main_Type.Sector)
            {
                if (!SectorObjectExists(so.pNext, out so))
                    throw new Exception("Sector not found.");
            }
            return so;
        }

        public SectorObject GetPlayerObject()
        {
            SectorObject so;
            if (SectorObjectExists(pPlayerShip, out so))
            {
                return so;
            }
            else
                throw new Exception("Player not found.");
        }

        #region Sector Object Primary

        #region Via Address

        /// <summary>
        /// Returns true if the data at the given could be a valid SectorObject.
        /// Unsafe method, use the object's ID instead.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="sectorObject"></param>
        /// <returns></returns>
        public bool SectorObjectExists(IntPtr address, out SectorObject sectorObject)
        {
            // If not end of list, get object and return
            if (SectorObjectExists(address))
            {
                sectorObject = new SectorObject(m_GameHook, address);
                return true;
            }
            sectorObject = null;
            return false;
        }
        /// <summary>
        /// Returns true if the data at the given could be a valid SectorObject.
        /// Unsafe method, use the object's ID instead.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool SectorObjectExists(IntPtr address)
        {
            return (MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)((int)address + (int)SectorObject.Offsets.pNext)) != 0 && MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)((int)address + (int)SectorObject.Offsets.pPrevious)) != 0);
        }
        /// <summary>
        /// Returns a SectorObject at the given address.
        /// Unsafe method, use the object's ID instead.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(IntPtr address)
        {
            return new SectorObject(m_GameHook, address);
        }
        #endregion

        #region Via ID

        /// <summary>
        /// Returns true if a SectorObject with the given ID is found.
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="sectorObject"></param>
        /// <returns></returns>
        public bool SectorObjectExists(int objectID, out SectorObject sectorObject)
        {
            var table = new HashTable(m_GameHook.hProcess, pObjectHashTable);
            var address = table.GetAddressOfObject(objectID);

            if (address == IntPtr.Zero)
            {
                sectorObject = null;
                return false;
            }
            sectorObject = new SectorObject(m_GameHook, address);
            return true;
        }
        /// <summary>
        /// Returns true if a SectorObject with the given ID is found.
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public bool SectorObjectExists(int objectID)
        {
            var table = new HashTable(m_GameHook.hProcess, pObjectHashTable);
            var address = table.GetAddressOfObject(objectID);

            if (address == IntPtr.Zero)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns the SectorObject with a given ID.
        /// </summary>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public SectorObject GetSectorObject(int objectID)
        {
            var table = new HashTable(m_GameHook.hProcess, pObjectHashTable);
            return new SectorObject(m_GameHook, table.GetAddressOfObject(objectID));

        }

        #endregion


        #endregion

        #region Memory
        /// <summary>
        /// Reload all values from memory.
        /// </summary>
        public void Reload()
        {
            pThis = (IntPtr)MemoryControl.ReadInt(m_GameHook.hProcess, (IntPtr)GameHook.GlobalAddresses.SectorObjectManager);
            SetData(MemoryControl.Read(m_GameHook.hProcess, pThis, ByteSize));
        }
        public byte[] GetBytes()
        {
            var collection = new ObjectByteList();
            collection.Append(Unknown_1);
            collection.Append(Unknown_2);
            collection.Append(pFirst);
            collection.Append(Unknown_3);
            collection.Append(pLast);
            collection.Append(pObjectHashTable);
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
            collection.Append(Unknown_13);
            collection.Append(Unknown_14);
            collection.Append(Unknown_15);
            collection.Append(Unknown_16);
            collection.Append(Unknown_17);
            collection.Append(Unknown_18);
            collection.Append(Unknown_19);
            collection.Append(Unknown_20);
            collection.Append(Unknown_21);
            collection.Append(Unknown_22);

            return collection.GetBytes();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList();
            collection.SetData(Memory);
            
            collection.PopFirst(ref Unknown_1);
            collection.PopFirst(ref Unknown_2);
            collection.PopFirst(ref pFirst);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref pLast);
            collection.PopFirst(ref pObjectHashTable);
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
            collection.PopFirst(ref Unknown_13);
            collection.PopFirst(ref Unknown_14);
            collection.PopFirst(ref Unknown_15);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref Unknown_17);
            collection.PopFirst(ref Unknown_18);
            collection.PopFirst(ref Unknown_19);
            collection.PopFirst(ref Unknown_20);
            collection.PopFirst(ref Unknown_21);
            collection.PopFirst(ref Unknown_22);
        }
        #endregion
    }
}
