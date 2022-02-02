using System;
using System.Collections.Generic;
using System.IO;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A class for managing assembly scripts in a process.
    /// </summary>
    public class InjectionManager
    {
        public const string SystemModDirectory = ".\\DATA\\EventManager Scripts\\";
        #region Event Injection
        /// <summary>
        /// A list in process memory 
        /// </summary>
        public class EventCodeList
        {
            #region Public Fields
            public int Count { private get; set; } = 0;
            #endregion

            #region Private Fields
            private readonly IntPtr m_hProcess;
            private List<IntPtr> m_Addresses = new List<IntPtr>();
            private IntPtr m_pStart;
            #endregion

            public EventCodeList(IntPtr Start, IntPtr hProcess)
            {
                m_pStart = Start;
                m_hProcess = hProcess;
            }


            #region Public Methods
            /// <summary>
            /// Returns the pointer to a given event code.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public IntPtr GetIndexPointer(int index)
            {
                return m_Addresses[index];
            }

            /// <summary>
            /// Appends bytes to a list.
            /// Returns the pointer to allocation.
            /// </summary>
            /// <param name="Code"></param>
            /// <returns></returns>
            public IntPtr Append(ScriptAssembler.ScriptCode Code)
            {
                // 0: pNext
                // 4: pCode

                // Write the code block into a new allocation and get the pointer
                IntPtr pCode = MemoryControl.AllocateMemory(m_hProcess, Code.DataSize + Code.Code.Length);
                for (int i = 0; i < Code.DataSize; i++)
                {
                    MemoryControl.Write(m_hProcess, pCode + i, (byte)0);
                }
                MemoryControl.Write(m_hProcess, pCode + Code.DataSize, Code.Code);
                // Write next list entry to reference
                IntPtr pEntry = MemoryControl.AllocateMemory(m_hProcess, EventInjectionObject.EventListScript.DataSize + EventInjectionObject.EventListScript.Code.Length + 1);
                for (int i = 0; i < EventInjectionObject.EventListScript.DataSize; i++)
                {
                    MemoryControl.Write(m_hProcess, pEntry + i, (byte)0);
                }
                MemoryControl.Write(m_hProcess, pEntry + EventInjectionObject.EventListScript.DataSize, EventInjectionObject.EventListScript.Code);
                // Write return
                MemoryControl.Write(m_hProcess, pEntry + EventInjectionObject.EventListScript.DataSize + EventInjectionObject.EventListScript.Code.Length, 0xc3);

                // Write parameters
                if (Count > 0)
                {
                    IntPtr last = GetIndexPointer(Count - 1);
                    // Write pointer to next entry
                    MemoryControl.Write(m_hProcess, last, BitConverter.GetBytes((int)pEntry));
                    // Write pointer to script
                    MemoryControl.Write(m_hProcess, last + 4, BitConverter.GetBytes((int)pCode + Code.DataSize));
                }
                else
                {
                    // Write pointer to next entry
                    MemoryControl.Write(m_hProcess, m_pStart, BitConverter.GetBytes((int)pEntry));
                    // Write pointer to script
                    MemoryControl.Write(m_hProcess, m_pStart + 4, BitConverter.GetBytes((int)pCode + Code.DataSize));
                }

                m_Addresses.Add(pEntry);

                Count++;
                return pCode;
            }
            #endregion
        }

        const string PreEventListScriptPath = "PreEventList.txt";
        const string EventListScriptPath = "EventList.txt";
        const string PostEventListScriptPath = "PostEventList.txt";

        public class EventInjectionObject
        {
            #region Public Fields
            public readonly string EventName;
            public static readonly ScriptAssembler.ScriptCode PreEventListScript = ScriptAssembler.ParseScript(SystemModDirectory + PreEventListScriptPath);
            public static readonly ScriptAssembler.ScriptCode EventListScript = ScriptAssembler.ParseScript(SystemModDirectory + EventListScriptPath);
            public static readonly ScriptAssembler.ScriptCode PostEventListScript = ScriptAssembler.ParseScript(SystemModDirectory + PostEventListScriptPath);
            #endregion

            #region Private Fields
            private readonly EventCodeList m_List;
            private readonly IntPtr m_hProcess;
            #endregion

            /// <summary>
            /// Create an event at a given address
            /// </summary>
            /// <param name="hProcess">Process handle</param>
            /// <param name="EventName">The name of the event</param>
            /// <param name="InjectionPoint">The address at which the call should be injected</param>
            /// <param name="Footer">Code at the end of the injection to replace the overwritten code at the injection site</param>
            /// <param name="NOPLength">The number of NOPs after the injected call</param>
            public EventInjectionObject(IntPtr hProcess, string EventName, IntPtr InjectionPoint, byte[] Footer, int NOPLength)
            {
                // Set the process handle, event name, and write the injection point.
                m_hProcess = hProcess;
                this.EventName = EventName;

                // Write list entry
                IntPtr pInjection = MemoryControl.AllocateMemory(hProcess, PreEventListScript.Code.Length + EventListScript.DataSize + EventListScript.Code.Length + PostEventListScript.Code.Length + Footer.Length + 1);
                for(int i = 0; i < EventListScript.DataSize; i++)
                {
                    MemoryControl.Write(m_hProcess, pInjection + i, (byte)0);
                }
                // Write pre code
                MemoryControl.Write(hProcess, pInjection, PreEventListScript.Code);
                // Write main code
                MemoryControl.Write(hProcess, pInjection + PreEventListScript.Code.Length + EventListScript.DataSize, EventListScript.Code);
                // Write post code
                MemoryControl.Write(hProcess, pInjection + PreEventListScript.Code.Length + EventListScript.DataSize + EventListScript.Code.Length, PostEventListScript.Code);

                MemoryControl.Write(hProcess, pInjection + PreEventListScript.Code.Length + EventListScript.DataSize + EventListScript.Code.Length + PostEventListScript.Code.Length, Footer);
                // Write return
                MemoryControl.Write(hProcess, pInjection + PreEventListScript.Code.Length + EventListScript.DataSize + EventListScript.Code.Length + PostEventListScript.Code.Length + Footer.Length, 0xc3);

                m_List = new EventCodeList(pInjection + PreEventListScript.Code.Length, hProcess);

                byte[] injection = new byte[7 + NOPLength];

                Array.Copy(ScriptAssembler.FarCall(pInjection, ScriptAssembler.x86Register.EAX), 0, injection, 0, 7);

                for (int i = 0; i < NOPLength; i++)
                {
                    injection[i + 7] = 0x90;
                }

                MemoryControl.Write(m_hProcess, InjectionPoint, injection);
            }

            #region Public Methods
            /// <summary>
            /// Subscribe EventCode to the event
            /// </summary>
            /// <param name="GC"></param>
            /// <returns></returns>
            public IntPtr Subscribe(ScriptAssembler.ScriptCode GC)
            {
                return m_List.Append(GC);
            }
            #endregion

            #region Private Methods

            #endregion
        }

        public struct SubscriptionData
        {
            public string Event;
            public IntPtr pCode;
        }

        private List<EventInjectionObject> m_Events = new List<EventInjectionObject>();
        private List<SubscriptionData> m_Subscriptions = new List<SubscriptionData>();
        private IntPtr m_hProcess;

        public InjectionManager(IntPtr hProcess)
        {
            m_hProcess = hProcess;

        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="EventName">The name of the event</param>
        /// <param name="Address">The address at which </param>
        /// <param name="Footer"></param>
        /// <param name="NOPLength"></param>
        public void CreateNewEvent(string EventName, IntPtr Address, byte[] Footer, byte NOPLength)
        {
            m_Events.Add(new EventInjectionObject(m_hProcess, EventName, Address, Footer, NOPLength));
        }

        public EventInjectionObject GetEvent(string EventName)
        {
            foreach (EventInjectionObject item in m_Events)
            {
                if (item.EventName == EventName)
                {
                    return item;
                }
            }

            throw new Exception("Event not found.");
        }

        public SubscriptionData[] GetSubscriptions()
        {
            return m_Subscriptions.ToArray();
        }

        public IntPtr Subscribe(ScriptAssembler.ScriptCode Code)
        {
            return Subscribe(Code.Event, Code);
        }
        public IntPtr Subscribe(string EventName, ScriptAssembler.ScriptCode Code)
        {
            IntPtr p = GetEvent(EventName).Subscribe(Code);

            m_Subscriptions.Add(new SubscriptionData()
            {
                Event = EventName,
                pCode = p
            });

            return p;
        }
        #endregion

        public void OverwriteCode(string scriptPath)
        {
            var code = ScriptAssembler.ParseScript(File.ReadAllLines(scriptPath));
            OverwriteCode(code.IntendedAddress, code.Code);
        }

        /// <summary>
        /// Overwrites code bytes at a given address
        /// </summary>
        /// <param name="pInjection"></param>
        /// <param name="code"></param>
        public void OverwriteCode(IntPtr pInjection, byte[] code)
        {
            MemoryControl.Write(m_hProcess, pInjection, code);
        }
    }
}
