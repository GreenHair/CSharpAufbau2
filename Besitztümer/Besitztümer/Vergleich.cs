using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besitztümer
{
    class Vergleich : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.Length;
        }
    }
}
