using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiboHotel;

namespace Hotelbuchung
{
    class Vergleich : IEqualityComparer<Buchung>
    {
        public bool Equals(Buchung x, Buchung y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Buchung obj)
        {
            return obj.Name.Length;
        }
    }
}
