﻿using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_Gate : IMemoryObject
    {
        int DestSectorX { get; }
        int DestSectorY { get; }
    }
}