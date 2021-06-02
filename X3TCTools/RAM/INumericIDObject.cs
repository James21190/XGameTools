using CommonToolLib.Memory;

namespace X3Tools.RAM
{
    public interface INumericIDObject : IMemoryObject
    {
        int ID { get; }
    }
}
