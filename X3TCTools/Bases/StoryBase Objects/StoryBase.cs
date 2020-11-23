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
        public MemoryObjectPointer<HashTable<ScriptingTaskObject>> pScriptObjectHashTable;

        public MemoryObjectPointer<MemoryByte> pInstructionArray;

        public int FunctionArrayCount;
        public EventFunctionStruct[] FunctionArray = new EventFunctionStruct[32];

        public MemoryObjectPointer<HashTable<TextPage>>[] TextHashTableArray;

        public MemoryObjectPointer<HashTable<ScriptingObject>> pEventObjectHashTable;

        public MemoryObjectPointer<ScriptingTaskObject> pCurrentScriptObject = new MemoryObjectPointer<ScriptingTaskObject>();


        public MemoryObjectPointer<HashTable<ScriptingTextObject>> pScriptingTextObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingTextObject>>();
        public MemoryObjectPointer<HashTable<StoryBase15fc>> pScriptingArrayObject_HashTable = new MemoryObjectPointer<HashTable<StoryBase15fc>>();

        public MemoryObjectPointer<HashTable<ScriptingHashTableObject>> pScriptingHashTableObject_HashTable = new MemoryObjectPointer<HashTable<ScriptingHashTableObject>>();

        #endregion


        public StoryBase()
        {
            for (int i = 0; i < FunctionArray.Length; i++)
            {
                FunctionArray[i] = new EventFunctionStruct();
            }

            pScriptObjectHashTable = new MemoryObjectPointer<HashTable<ScriptingTaskObject>>();
            pInstructionArray = new MemoryObjectPointer<MemoryByte>();
            pEventObjectHashTable = new MemoryObjectPointer<HashTable<ScriptingObject>>();
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

        public ScriptingObject GetEventObject(int ID)
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

        public ScriptingTaskObject[] GetScriptObjectsWithReferenceTo(int EventObjectID)
        {
            int negativeID = EventObjectID < 0 ? EventObjectID : -1 - EventObjectID;
            List<ScriptingTaskObject> results = new List<ScriptingTaskObject>();

            foreach (int id in pScriptObjectHashTable.obj.ScanContents())
            {
                try
                {
                    ScriptingTaskObject ScriptObject = pScriptObjectHashTable.obj.GetObject(id);
                    ScriptingObject EventObject = ScriptObject.pEventObject.obj;
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
            pScriptObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingTaskObject>>>();
            pInstructionArray = collection.PopIMemoryObject<MemoryObjectPointer<MemoryByte>>(0x8);

            FunctionArrayCount = collection.PopInt(0x2c);
            FunctionArray = collection.PopIMemoryObjects<EventFunctionStruct>(FunctionArray.Length);

            TextHashTableArray = collection.PopIMemoryObjects<MemoryObjectPointer<HashTable<TextPage>>>(45, 0x334);

            pEventObjectHashTable = collection.PopIMemoryObject<MemoryObjectPointer<HashTable<ScriptingObject>>>(0x12d0);
            pCurrentScriptObject = collection.PopIMemoryObject<MemoryObjectPointer<ScriptingTaskObject>>(0x1434);

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
