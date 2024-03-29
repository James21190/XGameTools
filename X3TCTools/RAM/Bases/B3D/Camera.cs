﻿using CommonToolLib.Memory;
using CommonToolLib.Vector;
using System;

namespace X3Tools.RAM.Bases.B3D
{
    public class Camera : MemoryObject, INumericIDObject
    {
        public int ID;

        public int FunctionIndex;

        public uint Flags;

        public int Focus;
        public int Pri;

        public Vector3_32 Background;

        public Vector2_32 Aspect;

        public Vector3_32 Fog;

        public uint FadeValue;

        public MemoryObjectPointer<Camera> EnvironmentSource = new MemoryObjectPointer<Camera>();

        public Camera()
        {

        }

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int ByteSize => 1936;

        int INumericIDObject.ID => ID;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory);

            collection.GoTo(0x28);
            collection.PopFirst(ref ID);
            collection.GoTo(0x250);
            collection.PopFirst(ref FunctionIndex);
            collection.GoTo(0x270);
            collection.PopFirst(ref Flags);
            collection.GoTo(298);
            collection.PopFirst(ref Focus);
            collection.PopFirst(ref Pri);
            collection.GoTo(0x2ac);
            collection.PopFirst(ref Background);
            collection.GoTo(0x300);
            collection.PopFirst(ref Aspect);
            collection.GoTo(0x368);
            collection.PopFirst(ref Fog);
            collection.GoTo(0x77c);
            collection.PopFirst(ref FadeValue);
            collection.GoTo(0x78c);
            collection.PopFirst(ref EnvironmentSource);
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            EnvironmentSource.SetLocation(hProcess, address + 0x78c);
        }
    }
}
