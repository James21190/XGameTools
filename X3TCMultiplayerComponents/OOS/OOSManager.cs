using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X3TCTools;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;

namespace X3TCMultiplayerComponents.OOS
{
    public class OOSManager
    {

        public struct RaceData : IBinaryObject
        {
            public struct ShipData : IBinaryObject
            {
                short SubType;
                byte SectorX, SectorY;
                int PositionX, PositionY, PositionZ;

                public void FromShipData(IScriptMemoryObject_Ship shipData)
                {
                    try
                    {
                        SubType = (short)shipData.SubType;
                        IScriptMemoryObject_Sector sectorData;
                        switch (GameHook.GameVersion)
                        {
                            case GameHook.GameVersions.X3AP: sectorData = shipData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>(); break;
                            case GameHook.GameVersions.X3TC: sectorData = shipData.CurrentSectorEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>(); break;
                            default: throw new Exception();
                        }
                        SectorX = (byte)sectorData.SectorX;
                        SectorY = (byte)sectorData.SectorY;

                        PositionX = 0;
                        PositionY = 0;
                        PositionZ = 0;
                    }
                    catch (Exception)
                    {

                    }
                }

                public const int ByteSize = 16;

                public byte[] GetBytes()
                {
                    var obl = new ObjectByteList();
                    obl.Append(SubType);
                    obl.Append(SectorX);
                    obl.Append(SectorY);
                    obl.Append(PositionX);
                    obl.Append(PositionY);
                    obl.Append(PositionZ);
                    return obl.GetBytes();
                }

                public int GetByteSize()
                {
                    return ByteSize;
                }

                public void SetData(byte[] Memory)
                {
                    throw new NotImplementedException();
                }
            }

            ShipData[] ships;

            public void FromRaceData(IScriptMemoryObject_RaceData raceData)
            {
                var shipDatas = raceData.Ships;
                ships = new ShipData[shipDatas.Length];
                for(int i = 0; i < ships.Length; i++) 
                {
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3AP: ships[i].FromShipData(shipDatas[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>()); break;
                        case GameHook.GameVersions.X3TC: ships[i].FromShipData(shipDatas[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>()); break;
                        default: throw new Exception();
                    }
                }
            }

            public int GetByteSize()
            {
                throw new NotImplementedException();
            }

            public void SetData(byte[] Memory)
            {
                throw new NotImplementedException();
            }

            public byte[] GetBytes()
            {
                throw new NotImplementedException();
            }
        }

        public RaceData[] GetRaces()
        {
            IScriptMemoryObject_RaceData_Player playerData;
            switch (GameHook.GameVersion) 
            {
                case GameHook.GameVersions.X3AP: playerData = GameHook.sectorObjectManager.GetPlayerObject().EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Ship>().OwnerDataEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>(); break;
                case GameHook.GameVersions.X3TC: playerData = GameHook.sectorObjectManager.GetPlayerObject().EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Ship>().OwnerDataEventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_RaceData_Player>(); break;
                default: throw new Exception();
            }

            var races = playerData.Races;
            RaceData[] raceDatas = new RaceData[races.Length];

            for (int i = 0; i < raceDatas.Length; i++)
            {
                raceDatas[i] = new RaceData();
                switch (races[i].ObjectType) {
                    case EventObject.EventObject_Type.RaceData:
                        switch (GameHook.GameVersion)
                        {   
                           case GameHook.GameVersions.X3AP: raceDatas[i].FromRaceData(races[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>()); break;
                           case GameHook.GameVersions.X3TC: raceDatas[i].FromRaceData(races[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData>()); break;
                           default: throw new Exception();
                        }   
                        break;
                    case EventObject.EventObject_Type.RaceData_Player:
                        switch (GameHook.GameVersion)
                        {
                            case GameHook.GameVersions.X3AP: raceDatas[i].FromRaceData(races[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>()); break;
                            case GameHook.GameVersions.X3TC: raceDatas[i].FromRaceData(races[i].GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_RaceData_Player>()); break;
                            default: throw new Exception();
                        }
                        break;
                    default: throw new Exception();
                }
            }
            return raceDatas;
        }
    }
}
