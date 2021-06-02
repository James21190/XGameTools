using CommonToolLib.Memory;

namespace XCommonLib.RAM.Generics
{
    public interface INumericIDObject : IMemoryObject
    {
        int ID { get; }
    }
}
