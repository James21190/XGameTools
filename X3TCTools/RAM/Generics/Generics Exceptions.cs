using System;

namespace X3Tools.RAM.Generics
{
    public class HashTableElementNotFoundException : Exception
    {
        private int ID;
        public HashTableElementNotFoundException(int id)
        {
            ID = id;
        }
        public new string Message => string.Format("Object with ID {0} was not found within the hash table.", ID);
    }
}
