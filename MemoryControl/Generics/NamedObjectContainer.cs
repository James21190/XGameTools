namespace CommonToolLib.Generics
{
    public struct NamedObjectContainer
    {
        public string Name;
        public object Obj;

        public NamedObjectContainer(string name, object obj)
        {
            Name = name;
            Obj = obj;
        }
    }
}
