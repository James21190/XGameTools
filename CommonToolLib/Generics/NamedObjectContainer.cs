using System;
using System.Runtime.CompilerServices;

namespace CommonToolLib.Generics
{
    /// <summary>
    /// Structure to assign a text name to an object.
    /// Intended for use in Windows Forms
    /// </summary>
    public struct NamedObjectContainer : IComparable
    {
        public string Name;
        public object Obj;

        public NamedObjectContainer(string name, object obj)
        {
            Name = name;
            Obj = obj;
        }

        public int CompareTo(object obj)
        {
            if(obj is NamedObjectContainer)
            {
                return Name.CompareTo(((NamedObjectContainer)obj).Name);
            }
            throw new ArgumentException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
