using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X2Tools.X2.SectorObjects
{
    public partial class SectorObject
    {
        public void SetInstalledShields(byte Shield_1MW_Count, byte Shield_5MW_Count, byte Shield_25MW_Count, byte Shield_125MW_Count)
        {

            byte Installed_1MW_Count = 0;
            byte Installed_5MW_Count = 0;
            byte Installed_25MW_Count = 0;
            byte Installed_125MW_Count = 0;

            // Get count of all currently installed shields
            foreach (var installed in m_GameHook.SectorObjectManager.GetSectorObjectsWithType(GetFirstChildPointer(), Main_Type.Shield, false))
            {
                switch ((SectorObject.Shield_Sub_Type)installed.SubType)
                {
                    case Shield_Sub_Type.Shield_1MW: Installed_1MW_Count++; break;
                    case Shield_Sub_Type.Shield_5MW: Installed_5MW_Count++; break;
                    case Shield_Sub_Type.Shield_25MW: Installed_25MW_Count++; break;
                    case Shield_Sub_Type.Shield_125MW: Installed_125MW_Count++; break;
                }
            }

            // If not enough of a type, install more
            for(int i = Installed_1MW_Count; i < Shield_1MW_Count; i++)
            {
                var shield = m_GameHook.GameCodeRunner.CreateSectorObject(Main_Type.Shield, (byte)Shield_Sub_Type.Shield_1MW);
                m_GameHook.GameCodeRunner.DockObject(shield, this);
            }
            for (int i = Installed_5MW_Count; i < Shield_5MW_Count; i++)
            {
                var shield = m_GameHook.GameCodeRunner.CreateSectorObject(Main_Type.Shield, (byte)Shield_Sub_Type.Shield_5MW);
                m_GameHook.GameCodeRunner.DockObject(shield, this);
            }
            for (int i = Installed_25MW_Count; i < Shield_25MW_Count; i++)
            {
                var shield = m_GameHook.GameCodeRunner.CreateSectorObject(Main_Type.Shield, (byte)Shield_Sub_Type.Shield_25MW);
                m_GameHook.GameCodeRunner.DockObject(shield, this);
            }
            for (int i = Installed_125MW_Count; i < Shield_125MW_Count; i++)
            {
                var shield = m_GameHook.GameCodeRunner.CreateSectorObject(Main_Type.Shield, (byte)Shield_Sub_Type.Shield_125MW);
                m_GameHook.GameCodeRunner.DockObject(shield, this);
            }
        }
    }
}
