using CommonToolLib.Memory;
using System;
using System.CodeDom.Compiler;
using X3Tools.RAM.Generics;

namespace X3Tools.RAM.Bases.SystemBase_Objects
{
    public class SystemBase : MemoryObject
    {
        #region Memory
        public int SystemFlags;

        public MemoryObjectPointer<SystemBaseStringCollection> pStringCollection;

        public X3FixedPointValue TimeWarpFactor = new X3FixedPointValue();

        public GameHook.Language Language;

        #endregion
        public SystemBase()
        {

        }

        #region Set Individual
        public void SaveSETA()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                case GameHook.GameVersions.X3AP:
                    MemoryControl.Write(this.hProcess, pThis + 204, TimeWarpFactor.GetBytes());
                    break;
                case GameHook.GameVersions.X3FL:
                    throw new GameVersionNotImplementedException();
                    break;
            }
        }

        public void SaveLanguage()
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                case GameHook.GameVersions.X3AP:
                    MemoryControl.Write(this.hProcess, pThis + 0x768, BitConverter.GetBytes((int)Language));
                    break;
                case GameHook.GameVersions.X3FL:
                    throw new GameVersionNotImplementedException();
                    break;
            }
        }
        #endregion

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 1960;

        protected override void SetDataFromObjectByteList(ObjectByteList objectByteList)
        {
            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC:
                case GameHook.GameVersions.X3AP:
                    SystemFlags = objectByteList.PopInt(0xbc);

                    pStringCollection = objectByteList.PopIMemoryObject<MemoryObjectPointer<SystemBaseStringCollection>>(0xd8);

                    TimeWarpFactor = objectByteList.PopIMemoryObject<X3FixedPointValue>(0xcc);

                    Language = (GameHook.Language)objectByteList.PopInt(0x768);
                    break;
                case GameHook.GameVersions.X3FL:
                    Language = (GameHook.Language)objectByteList.PopInt(0x75c);
                    break;
            }
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
        #endregion
    }
}
