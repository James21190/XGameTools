using System;
using System.Collections.Generic;
using System.IO;

namespace CommonToolLib.ProcessHooking
{
    /// <summary>
    /// A class for managing assembly scripts in a process.
    /// </summary>
    public class EventManager
    {
        public const string SystemModDirectory = ".\\DATA\\EventManager Scripts\\";
        public class GameCode
        {
            public int DataHeaderSize;
            public string Name;
            public string IntendedEvent;
            public readonly byte[] Code;


            public int Length => DataHeaderSize + Code.Length;

            public GameCode(string Path)
            {
                ScriptAssembler.ScriptCode data = ScriptAssembler.ParseScript(File.ReadAllLines(Path));
                DataHeaderSize = data.DataSize;
                Name = data.Name;
                IntendedEvent = data.Event;
                Code = data.Code;


            }

            /// <summary>
            /// Writes the code to game memory.
            /// Returns the address to the start of the new allocation.
            /// </summary>
            /// <param name="hProcess"></param>
            /// <returns></returns>
            public IntPtr WriteNewToMemory(IntPtr hProcess, byte[] Footer)
            {
                // Allocate memory for the injection
                IntPtr pCode = MemoryControl.AllocateMemory(hProcess, 5 + Length + Footer.Length);

                byte[] buffer = new byte[5 + Length + Footer.Length];
                for (int i = 0; i < DataHeaderSize; i++)
                {
                    buffer[i] = 0;
                }

                // Set EAX to the address of the injection
                // TODO: NOT GOOD, SHOULD BE EBP!!!!
                Array.Copy(ScriptAssembler.SetRegister(ScriptAssembler.x86Register.EAX, (uint)pCode), 0, buffer, DataHeaderSize, 5);
                Array.Copy(Code, 0, buffer, DataHeaderSize + 5, Code.Length);
                Array.Copy(Footer, 0, buffer, DataHeaderSize + 5 + Code.Length, Footer.Length);

                MemoryControl.Write(hProcess, pCode, buffer);

                return pCode;
            }
        }

        public class GameCodeList
        {
            #region Public Fields
            public int Count { private get; set; } = 0;
            #endregion

            #region Private Fields
            private readonly IntPtr m_hProcess;
            private List<IntPtr> m_Addresses = new List<IntPtr>();
            private IntPtr m_pStart;
            #endregion

            public GameCodeList(IntPtr Start, IntPtr hProcess)
            {
                m_pStart = Start;
                m_hProcess = hProcess;
            }


            #region Public Methods
            public IntPtr GetIndexPointer(int Index)
            {
                return m_Addresses[Index];
            }

            /// <summary>
            /// Appends bytes to a list.
            /// Returns the pointer to allocation.
            /// </summary>
            /// <param name="Code"></param>
            /// <returns></returns>
            public IntPtr Append(GameCode Code)
            {
                // 0: pNext
                // 4: pCode

                IntPtr pCode = Code.WriteNewToMemory(m_hProcess, new byte[] { 0xc3 });
                IntPtr pEntry = GameEvent.EventMain.WriteNewToMemory(m_hProcess, new byte[] { 0xc3 });
                if (Count > 0)
                {
                    IntPtr last = GetIndexPointer(Count - 1);
                    MemoryControl.Write(m_hProcess, last, BitConverter.GetBytes((int)pEntry + 8));
                    MemoryControl.Write(m_hProcess, last + 4, BitConverter.GetBytes((int)pCode + Code.DataHeaderSize));
                }
                else
                {
                    MemoryControl.Write(m_hProcess, m_pStart, BitConverter.GetBytes((int)pEntry + 8));
                    MemoryControl.Write(m_hProcess, m_pStart + 4, BitConverter.GetBytes((int)pCode + Code.DataHeaderSize));
                }

                m_Addresses.Add(pEntry);

                Count++;
                return pCode;
            }
            #endregion
        }

        public class GameEvent
        {
            #region Public Fields
            public readonly string EventName;
            public static readonly GameCode EventMain = new GameCode(SystemModDirectory + "GameCodeList.mod");
            #endregion

            #region Private Fields
            private readonly GameCodeList m_List;
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
            public GameEvent(IntPtr hProcess, string EventName, IntPtr InjectionPoint, byte[] Footer, int NOPLength)
            {
                // Set the process handle, event name, and write the injection point.
                m_hProcess = hProcess;
                this.EventName = EventName;
                IntPtr pInjection = EventMain.WriteNewToMemory(m_hProcess, Footer);

                m_List = new GameCodeList(pInjection, hProcess);

                byte[] injection = new byte[7 + NOPLength];

                Array.Copy(ScriptAssembler.FarCall(pInjection + 8, ScriptAssembler.x86Register.EAX), 0, injection, 0, 7);

                for (int i = 0; i < NOPLength; i++)
                {
                    injection[i + 7] = 0x90;
                }

                MemoryControl.Write(m_hProcess, InjectionPoint, injection);
            }

            #region Public Methods
            /// <summary>
            /// Subscribe GameCode to the event
            /// </summary>
            /// <param name="GC"></param>
            /// <returns></returns>
            public IntPtr Subscribe(GameCode GC)
            {
                return m_List.Append(GC);
            }
            #endregion

            #region Private Methods

            #endregion
        }

        public struct SubscriptionData
        {
            public GameCode Code;
            public string Event;
            public IntPtr pCode;
        }

        private List<GameEvent> m_Events = new List<GameEvent>();
        private List<SubscriptionData> m_Subscriptions = new List<SubscriptionData>();
        private IntPtr m_hProcess;

        public EventManager(IntPtr hProcess)
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
            m_Events.Add(new GameEvent(m_hProcess, EventName, Address, Footer, NOPLength));
        }

        public GameEvent GetEvent(string EventName)
        {
            foreach (GameEvent item in m_Events)
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

        public IntPtr Subscribe(string EventName, GameCode Code)
        {
            IntPtr p = GetEvent(EventName).Subscribe(Code);

            m_Subscriptions.Add(new SubscriptionData()
            {
                Code = Code,
                Event = EventName,
                pCode = p
            });

            return p;
        }
    }
}
