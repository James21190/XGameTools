using Common.Memory;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using X3TCTools.Bases.StoryBase_Objects.Scripting;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Generics;

namespace X3TCTools.Bases.StoryBase_Objects
{
    public class StoryBase : MemoryObject
    {
        public MemoryObjectPointer<HashTable<ScriptObject>> pScriptObjectHashTable;

        public MemoryObjectPointer<MemoryByte> pInstructionArray;

        public int FunctionArrayCount;
        public EventFunctionStruct[] FunctionArray = new EventFunctionStruct[32];

        public MemoryObjectPointer<HashTable<TextPage>>[] TextHashTableArray;

        public MemoryObjectPointer<HashTable<EventObject>> pEventObjectHashTable;

        public MemoryObjectPointer<ScriptObject> pCurrentScriptObject = new MemoryObjectPointer<ScriptObject>();


        public MemoryObjectPointer<HashTable<ScriptingTextObject>> pScriptingTextObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingTextObject>>();
        public MemoryObjectPointer<HashTable<StoryBase15fc>> pScriptingArrayObject_HashTable = new MemoryObjectPointer<HashTable<StoryBase15fc>>();

        public MemoryObjectPointer<HashTable<ScriptingHashTableObject>> pScriptingHashTableObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingHashTableObject>>();



        public StoryBase()
        {
            for (int i = 0; i < FunctionArray.Length; i++)
            {
                FunctionArray[i] = new EventFunctionStruct();
            }

            pScriptObjectHashTable = new MemoryObjectPointer<HashTable<ScriptObject>>();
            pInstructionArray = new MemoryObjectPointer<MemoryByte>();
            pEventObjectHashTable = new MemoryObjectPointer<HashTable<EventObject>>();
        }

        public TextPage GetTextPage(GameHook.Language language, int pageID)
        {
            HashTable<TextPage> table = TextHashTableArray[(int)language].obj;
            return table.GetObject(pageID);
        }

        public string GetText(GameHook.Language language, int pageID, int txtID)
        {
            // Temporary until text page has been implemented.
            switch (pageID)
            {
                case 17:
                    switch (txtID)
                    {
                        case 2911: return "Drone";
                        case 3531: return "Falcon";
                        case 4351: return "Jaguar";

                        case 6652: return "Seeker Missile";
                        case 6654: return "High Yield";

                        case 7740: return "Production Complex";
                        case 7817: return "Light Shield";
                        case 7818: return "Medium Shield";
                        case 7819: return "Heavy Shield";

                        case 10022: return "Prototype";
                        case 10024: return "Enhanced";

                        case 16041: return "Shipyard";
                    }
                    break;
            }
            return "";
        }

        public string ParseText(GameHook.Language language, string txt)
        {
            Regex regex = new Regex(@"\{.*?\}");
            MatchCollection matches = regex.Matches(txt);

            foreach (Match match in matches)
            {
                string[] numbers = match.Value.Trim('{', '}').Split(',');
                string replacement = GetText(language, Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]));
                if (!string.IsNullOrWhiteSpace(replacement))
                {
                    txt = txt.Replace(match.Value, "(" + replacement + ")");
                }
            }
            return txt;
        }

        public int GetScriptingFunctionAddressFromInstruction(byte instruction)
        {
            return GameHook.pProcessEventSwitch[GameHook.pProcessEventSwitchArray[instruction - 1].Value].Value;
        }

        public int GetScriptingFunctionAddressFromInstructionIndex(int index)
        {
            return GetScriptingFunctionAddressFromInstruction(pInstructionArray[index].Value);
        }

        public EventObject GetEventObject(int ID)
        {
            int value = ID < 0 ? -ID - 1 : ID;
            return pEventObjectHashTable.obj.GetObject(value);
        }

        public ScriptMemoryObject GetEventObjectScriptingVariables(int ID)
        {
            ScriptMemoryObject obj = new ScriptMemoryObject();
            obj.SetLocation(m_hProcess, GetEventObject(ID).pScriptVariableArr.address);
            obj.ReloadFromMemory();
            return obj;
        }

        public ScriptObject[] GetScriptObjectsWithReferenceTo(int EventObjectID)
        {
            int negativeID = EventObjectID < 0 ? EventObjectID : -1 - EventObjectID;
            List<ScriptObject> results = new List<ScriptObject>();

            foreach (int id in pScriptObjectHashTable.obj.ScanContents())
            {
                try
                {
                    ScriptObject ScriptObject = pScriptObjectHashTable.obj.GetObject(id);
                    EventObject EventObject = ScriptObject.pEventObject.obj;
                    if (EventObject.NegativeID == negativeID)
                    {
                        results.Add(ScriptObject);
                    }
                }
                catch (Exception)
                {

                }
            }

            return results.ToArray();
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 5648;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, m_hProcess, pThis);
            pScriptObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptObject>>>();
            pInstructionArray = collection.PopIMemoryObject<MemoryObjectPointer<MemoryByte>>(0x8);

            FunctionArrayCount = collection.PopInt(0x2c);
            FunctionArray = collection.PopIMemoryObjects<EventFunctionStruct>(FunctionArray.Length);

            TextHashTableArray = collection.PopIMemoryObjects<MemoryObjectPointer<HashTable<TextPage>>>(45, 0x334);

            pEventObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<EventObject>>>(0x12d0);
            pCurrentScriptObject = collection.PopIMemoryObject<MemoryObjectPointer<ScriptObject>>(0x1434);

            pScriptingTextObject_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingTextObject>>>(0x15f8);
            pScriptingArrayObject_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<StoryBase15fc>>>();
            pScriptingHashTableObject_HashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingHashTableObject>>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pScriptObjectHashTable.SetLocation(hProcess, address + 0);
            pInstructionArray.SetLocation(hProcess, address + 0x8);
            pEventObjectHashTable.SetLocation(hProcess, address + 0x12d0);
            pCurrentScriptObject.SetLocation(hProcess, address + 0x1434);

            pScriptingTextObject_HashTable.SetLocation(hProcess, address + 0x15f8);
            pScriptingArrayObject_HashTable.SetLocation(hProcess, address + 0x15fc);
            pScriptingHashTableObject_HashTable.SetLocation(hProcess, address + 0x1600);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
