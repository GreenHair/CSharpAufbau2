using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class ZimmerVergleich : IEqualityComparer<Zimmer>
    {
        public bool Equals(Zimmer x, Zimmer y)
        {
            return x.ZimmerNr == y.ZimmerNr;
        }

        public int GetHashCode(Zimmer obj)
        {
            return obj.ZimmerNr;
        }
    }
}
