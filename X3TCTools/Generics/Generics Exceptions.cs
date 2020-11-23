using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3Tools.Generics
{
    public class HashTableElementNotFoundException : Exception
    {
        int ID;
        public HashTableElementNotFoundException(int id)
        {
            ID = id;
        }
        public new string Message { get { return string.Format("Object with ID {0} was not found within the hash table.",ID); } }
    }
}
