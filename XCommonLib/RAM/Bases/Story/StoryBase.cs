﻿using CommonToolLib.ProcessHooking;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XCommonLib.RAM.Bases.Story
{
    public abstract class StoryBase : MemoryObject
    {
        #region Memory
        #endregion

        #region Scripting
        #region ScriptTaskObject
        /// <summary>
        /// Search the hash table for the ScriptTaskObject.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract ScriptTaskObject GetScriptTaskObject(int id);
        public abstract ScriptTaskObject GetScriptTaskObject(IntPtr pAddress);
        public abstract int[] GetAllScriptTaskObjects();
        #endregion
        #region ScriptInstance
        public abstract ScriptInstance GetScriptInstance(int id);
        public abstract ScriptInstance GetScriptInstance(IntPtr pAddress);
        public abstract int[] GetAllScriptInstances();
        #endregion
        #region ScriptTable
        public abstract ScriptTableObject GetScriptHashTable(IntPtr address);
        public abstract ScriptTableObject GetScriptHashTable(int id);
        #endregion
        #region ScriptArray
        public abstract ScriptArrayObject GetScriptArrayObject(IntPtr address);
        public abstract ScriptArrayObject GetScriptArrayObject(int id);
        #endregion
        #region ScriptString
        public abstract ScriptStringObject GetScriptStringObject(int id);
        public abstract ScriptStringObject GetScriptStringObject(IntPtr pAddress);
        public abstract int[] GetAllScriptStringObjects();
        #endregion
        #endregion

        public abstract MemoryString GetStringFromArray(int index);
        public abstract TextPage GetTextPage(int languageId, int pageId);
        public MemoryString GetText(int languageId, int pageId, int textId)
        {
            var page = GetTextPage(languageId, pageId);
            return page.GetText(textId);
        }

        /// <summary>
        /// Returns a parsed text from a page.
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string GetParsedText(int languageId, string txt)
        {
            return _GetParsedText(languageId, txt, null);
        }
        /// <summary>
        /// Returns a parsed text from a page.
        /// </summary>
        /// <param name="languageId"></param>
        /// <param name="txt"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        private string _GetParsedText(int languageId, string txt, List<int> previous)
        {
            if (previous == null)
            {
                previous = new List<int>();
            }

            Regex regex = new Regex(@"\{.*?\}");
            MatchCollection matches = regex.Matches(txt);
            bool shouldRecheck = false;
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
                        string replacement = GetText(languageId, page, id).Value;
                        if (!string.IsNullOrWhiteSpace(replacement))
                        {
                            shouldRecheck = true;
                            txt = txt.Replace(match.Value, replacement);
                        }
                    }
                }
            }
            if (shouldRecheck)
            {
                txt = _GetParsedText(languageId, txt, previous);
            }

            return txt;

        }
    }
}
