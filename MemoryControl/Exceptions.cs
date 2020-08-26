using System;

namespace Common
{
    public class AddressNullException : Exception
    {
        public new string Message = "Game memory pointer is null.";
    }

    public class SystemModCodeMissingException : Exception
    {
        public new string Message = "A system mod file is missing.";
    }

    public class InvalidModCodeMetaException : Exception
    {
        public new string Message = "Mod file has invalid meta.";
    }

    public class KnownBrokenMethodExcption : Exception
    {
        public new string Message = "This is know to cause crashes, and has been disabled until fixed.";
    }
}
