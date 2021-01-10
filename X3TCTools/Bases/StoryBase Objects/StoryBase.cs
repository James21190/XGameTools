using Common.Memory;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using X3Tools.Bases.StoryBase_Objects.Scripting;
using X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3Tools.Generics;

namespace X3Tools.Bases.StoryBase_Objects
{
    public class StoryBase : MemoryObject
    {
        #region Memory

        public MemoryObjectPointer<HashTable<ScriptTaskObject>> pHashTable_ScriptTaskObject;

        public MemoryObjectPointer<MemoryByte> pInstructionArray;

        public MemoryObjectPointer<MemoryString> pStrings = new MemoryObjectPointer<MemoryString>();

        public int FunctionArrayCount;
        public EventFunctionStruct[] FunctionArray = new EventFunctionStruct[32];

        public MemoryObjectPointer<HashTable<TextPage>>[] TextHashTableArray;

        public MemoryObjectPointer<HashTable<ScriptInstance>> pHashTable_ScriptInstance;

        public MemoryObjectPointer<ScriptTaskObject> pCurrentScriptObject = new MemoryObjectPointer<ScriptTaskObject>();


        public MemoryObjectPointer<HashTable<ScriptStringObject>> pHashTable_ScriptStringObject = new MemoryObjectPointer<HashTable<ScriptStringObject>>();
        public MemoryObjectPointer<HashTable<ScriptArrayObject>> pHashTable_ScriptArrayObject = new MemoryObjectPointer<HashTable<ScriptArrayObject>>();

        public MemoryObjectPointer<HashTable<ScriptTableObject>> pHashTable_ScriptTableObject = new MemoryObjectPointer<HashTable<ScriptTableObject>>();

        #endregion


        public StoryBase()
        {
            for (int i = 0; i < FunctionArray.Length; i++)
            {
                FunctionArray[i] = new EventFunctionStruct();
            }

            pHashTable_ScriptTaskObject = new MemoryObjectPointer<HashTable<ScriptTaskObject>>();
            pInstructionArray = new MemoryObjectPointer<MemoryByte>();
            pHashTable_ScriptInstance = new MemoryObjectPointer<HashTable<ScriptInstance>>();
        }

        public MemoryString GetStringFromStoryBaseCharArray(int offset)
        {
            var memorystring = new MemoryString();
            memorystring.SetLocation(GameHook.hProcess, pStrings.address + offset);
            memorystring.ReloadFromMemory();
            return memorystring;
        }

        #region Text Pages

        /// <summary>
        /// Returns a text page with a given language and page.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="pageID"></param>
        /// <returns></returns>
        public TextPage GetTextPage(GameHook.Language language, int pageID)
        {
            HashTable<TextPage> table = TextHashTableArray[(int)language].obj;
            return table.GetObject(pageID);
        }

        /// <summary>
        /// Returns an unparsed text from a page.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="pageID"></param>
        /// <param name="txtID"></param>
        /// <returns></returns>
        public string GetText(GameHook.Language language, int pageID, int txtID)
        {
            var page = GetTextPage(language, pageID);
            return page.GetText(txtID);
        }

        /// <summary>
        /// Returns a parsed text from a page.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="txt"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        private string _GetParsedText(GameHook.Language language, string txt, List<int> previous)
        {
            if (previous == null)
                previous = new List<int>();
            Regex regex = new Regex(@"\{.*?\}");
            MatchCollection matches = regex.Matches(txt);

            foreach (Match match in matches)
            {
                string[] numbers = match.Value.Trim('{', '}').Split(',');
                if (numbers.Length == 2)
                {
                    int page;
                    int id;
                    if (int.TryParse(numbers[0], out page) && int.TryParse(numbers[1], out id) && !previous.Contains(id))
                    {
                        previous.Add(id);
                        string replacement = GetText(language, page, id);
                        if (!string.IsNullOrWhiteSpace(replacement))
                        {
                            txt = txt.Replace(match.Value, replacement);
                        }
                        txt = _GetParsedText(language, txt, previous);
                    }
                }
            }
            return txt;

        }
        /// <summary>
        /// Returns a parsed text from a page.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetParsedText(GameHook.Language language, string txt)
        {
            return _GetParsedText(language, txt, null);
        }

        #endregion
        public int GetScriptingFunctionAddressFromInstruction(byte instruction)
        {
            return GameHook.pProcessEventSwitch[GameHook.pProcessEventSwitchArray[instruction - 1].Value].Value;
        }

        public int GetScriptingFunctionAddressFromInstructionIndex(int index)
        {
            return GetScriptingFunctionAddressFromInstruction(pInstructionArray[index].Value);
        }

        public ScriptInstance GetScriptingObject(int ID)
        {
            int value = ID < 0 ? -ID - 1 : ID;
            return pHashTable_ScriptInstance.obj.GetObject(value);
        }

        public IScriptMemoryObject_RaceData_Player GetRaceData_Player()
        {
            var PlayerShip = GameHook.sectorObjectManager.GetPlayerObject();
            if (PlayerShip == null) return null;
            return PlayerShip.ScriptInstance.GetMemoryInterfaceShip().OwnerDataScriptingObject.GetMemoryInterfaceRaceData_Player();
        }

        public ScriptMemoryObject GetScriptingObjectScriptingVariables(int ID)
        {
            ScriptMemoryObject obj = new ScriptMemoryObject();
            obj.SetLocation(m_hProcess, GetScriptingObject(ID).pScriptVariableArr.address);
            obj.ReloadFromMemory();
            return obj;
        }

        public ScriptTaskObject[] GetScriptObjectsWithReferenceTo(int ScriptingObjectID)
        {
            int negativeID = ScriptingObjectID < 0 ? ScriptingObjectID : -1 - ScriptingObjectID;
            List<ScriptTaskObject> results = new List<ScriptTaskObject>();

            foreach (int id in pHashTable_ScriptTaskObject.obj.ScanContents())
            {
                try
                {
                    ScriptTaskObject ScriptObject = pHashTable_ScriptTaskObject.obj.GetObject(id);
                    ScriptInstance ScriptingObject = ScriptObject.pScriptInstance.obj;
                    if (ScriptingObject.NegativeID == negativeID)
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

            pHashTable_ScriptTaskObject = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptTaskObject>>>();
            pInstructionArray = collection.PopIMemoryObject<MemoryObjectPointer<MemoryByte>>(0x8);
            pStrings = collection.PopIMemoryObject < MemoryObjectPointer<MemoryString>>(0x14);

            FunctionArrayCount = collection.PopInt(0x2c);
            FunctionArray = collection.PopIMemoryObjects<EventFunctionStruct>(FunctionArray.Length);

            TextHashTableArray = collection.PopIMemoryObjects<MemoryObjectPointer<HashTable<TextPage>>>(45, 0x334);

            pHashTable_ScriptInstance = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptInstance>>>(0x12d0);
            pCurrentScriptObject = collection.PopIMemoryObject<MemoryObjectPointer<ScriptTaskObject>>(0x1434);

            pHashTable_ScriptStringObject = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptStringObject>>>(0x15f8);
            pHashTable_ScriptArrayObject = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptArrayObject>>>();
            pHashTable_ScriptTableObject = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptTableObject>>>();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            pHashTable_ScriptTaskObject.SetLocation(hProcess, address + 0);
            pInstructionArray.SetLocation(hProcess, address + 0x8);

            pStrings.SetLocation(hProcess, address + 0x20);

            pHashTable_ScriptInstance.SetLocation(hProcess, address + 0x12d0);
            pCurrentScriptObject.SetLocation(hProcess, address + 0x1434);

            pHashTable_ScriptStringObject.SetLocation(hProcess, address + 0x15f8);
            pHashTable_ScriptArrayObject.SetLocation(hProcess, address + 0x15fc);
            pHashTable_ScriptTableObject.SetLocation(hProcess, address + 0x1600);
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
