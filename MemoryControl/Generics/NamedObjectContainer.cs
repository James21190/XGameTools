namespace CommonToolLib.Generics
{
    /// <summary>
    /// Structure to assign a text name to an object.
    /// Intended for use in Windows Forms
    /// </summary>
    public struct NamedObjectContainer
    {
        public string Name;
        public object Obj;

        public NamedObjectContainer(string name, object obj)
        {
            Name = name;
            Obj = obj;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
