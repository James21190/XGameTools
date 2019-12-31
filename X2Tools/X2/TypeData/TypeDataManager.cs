using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2;
using X2Tools.X2.SectorObjects;
using Common;
using Common.Memory;

namespace X2Tools.X2.TypeData
{
    public class TypeDataManager
    {
        #region Public Fields
        // The pointer to the Projectile TypeData array
        public IntPtr pTypeData_Projectile { get; private set; }
        // The pointer to the Sector TypeData array
        public IntPtr pTypeData_Sector { get; private set; }
        // The pointer to the TypeData array of MainType 2
        public IntPtr pTypeData_2 { get; private set; }
        // The pointer to the Sun TypeData array
        public IntPtr pTypeData_Sun { get; private set; }
        // The pointer to the Planet TypeData array
        public IntPtr pTypeData_Planet { get; private set; }
        // The pointer to the Dock TypeData array
        public IntPtr pTypeData_Dock { get; private set; }
        // The pointer to the Factory TypeData array
        public IntPtr pTypeData_Factory { get; private set; }
        // The pointer to the Ship TypeData array
        public IntPtr pTypeData_Ship { get; private set; }
        // The pointer to the ShipGun TypeData array
        public IntPtr pTypeData_ShipGun { get; private set; }
        // The pointer to the Shield TypeData array
        public IntPtr pTypeData_Shield { get; private set; }
        // The pointer to the TypeData array of MainType 10
        public IntPtr pTypeData_10 { get; private set; }

        public ShipTypeData[] ShipTypeDataArray { get; private set; } = new ShipTypeData[SectorObjects.SectorObject.SHIP_SUBTYPE_COUNT];
        #endregion

        #region Private Fields
        private readonly IntPtr m_hProcess;
        #endregion

        public TypeDataManager(IntPtr hProcess)
        {
            m_hProcess = hProcess;

            ReloadAddresses();

            ReloadShipTypeData();
        }

        #region Public Methods
        public void ReloadAddresses()
        {
            pTypeData_Projectile = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray);
            pTypeData_Sector = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 4);
            pTypeData_2 = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 8);
            pTypeData_Sun = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 12);
            pTypeData_Planet = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 16);
            pTypeData_Dock = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 20);
            pTypeData_Factory = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 24);
            pTypeData_Ship = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 28);
            pTypeData_ShipGun = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 32);
            pTypeData_Shield = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 36);
            pTypeData_10 = (IntPtr)MemoryControl.ReadInt(m_hProcess, (IntPtr)GlobalAddresses.TypeDataArray + 40);
        }

        public void ReloadShipTypeData()
        {
            for(int i = 0; i < SectorObjects.SectorObject.SHIP_SUBTYPE_COUNT; i++)
            {
                ShipTypeDataArray[i] = new ShipTypeData(MemoryControl.Read(m_hProcess, pTypeData_Ship + (ShipTypeData.Length * i), ShipTypeData.Length));
            }
        }
        #endregion
    }
}
