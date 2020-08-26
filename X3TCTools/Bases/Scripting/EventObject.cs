using Common.Memory;
using System;
using X3TCTools.Bases.Scripting.ScriptingMemory;

namespace X3TCTools.Bases.Scripting
{
    /// <summary>
    /// The EventObject is an object within the game that keeps track of variables used by the scripting engine.
    /// It keeps track of how many variables are stored and the amount of ScriptObjects that reference it.
    /// </summary>
    public partial class EventObject : MemoryObject
    {
        public const int ByteSize = 16;

        public int NegativeID;
        public int ReferenceCount;
        public MemoryObjectPointer<EventObjectSub> pSub = new MemoryObjectPointer<EventObjectSub>();
        public MemoryObjectPointer<ScriptMemoryObject> pScriptVariableArr = new MemoryObjectPointer<ScriptMemoryObject>();

        public EventObject_Type ObjectType
        {
            get
            {
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3AP:
                        switch ((AP_EventObject_Type)pSub.obj.ID)
                        {
                            case AP_EventObject_Type.RaceData_2:
                            case AP_EventObject_Type.RaceData_3:
                            case AP_EventObject_Type.RaceData_4:
                            case AP_EventObject_Type.RaceData_5:
                            case AP_EventObject_Type.RaceData: return EventObject_Type.RaceData;
                            case AP_EventObject_Type.RaceData_Player: return EventObject_Type.RaceData_Player;

                            case AP_EventObject_Type.Sector: return EventObject_Type.Sector;

                            case AP_EventObject_Type.Planet: return EventObject_Type.Planet;

                            case AP_EventObject_Type.Sun: return EventObject_Type.Sun;

                            case AP_EventObject_Type.Gate: return EventObject_Type.Gate;

                            case AP_EventObject_Type.Station_Trading: return EventObject_Type.Station_Trading;
                            case AP_EventObject_Type.Station_Equipment: return EventObject_Type.Station_Equipment;
                            case AP_EventObject_Type.Station_Shipyard: return EventObject_Type.Station_Shipyard;
                            case AP_EventObject_Type.Station_Factory: return EventObject_Type.Station_Factory;

                            case AP_EventObject_Type.Station_3: return EventObject_Type.Station_Unknown_3;

                            case AP_EventObject_Type.Ship_1: return EventObject_Type.Ship_Unknown_1;
                            case AP_EventObject_Type.Ship_2: return EventObject_Type.Ship_Unknown_2;
                            case AP_EventObject_Type.Ship_3: return EventObject_Type.Ship_Unknown_3;
                            case AP_EventObject_Type.Ship_4: return EventObject_Type.Ship_Unknown_4;
                            case AP_EventObject_Type.Ship_5: return EventObject_Type.Ship_Unknown_5;
                            case AP_EventObject_Type.Ship_Player: return EventObject_Type.Ship_Player;
                            case AP_EventObject_Type.Ship_6: return EventObject_Type.Ship_Unknown_6;
                        }
                        break;
                    case GameHook.GameVersions.X3TC:
                        switch (pSub.obj.ID)
                        {

                        }
                        break;
                }
                return EventObject_Type.Unknown;
            }
        }

        public T GetScriptVariableArrayAsObject<T>() where T : ScriptMemoryObject, new()
        {
            T obj = new T();
            obj.SetLocation(GameHook.hProcess, pScriptVariableArr.address);
            obj.Resize(pSub.obj.ScriptVariableCount);
            return obj;
        }

        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();
            collection.Append(NegativeID);
            collection.Append(ReferenceCount);
            collection.Append(pSub);
            collection.Append(pScriptVariableArr);
            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            NegativeID = objectByteList.PopInt();
            ReferenceCount = objectByteList.PopInt();
            pSub = objectByteList.PopIMemoryObject<MemoryObjectPointer<EventObjectSub>>();
            pScriptVariableArr = objectByteList.PopIMemoryObject<MemoryObjectPointer<ScriptMemoryObject>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pScriptVariableArr.SetLocation(hProcess, address + 0x8);
            pSub.SetLocation(hProcess, address + 0xc);
        }

    }
}
