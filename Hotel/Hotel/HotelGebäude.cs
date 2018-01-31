using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class HotelGebäude
    {
        public Dictionary<int, Zimmer> Zimmern { get; private set; }

        public HotelGebäude()
        {
            Zimmern = new Dictionary<int, Zimmer>();
        }

        public void AddZimmer(Zimmer z)
        {
            Zimmern.Add(z.ZimmerNr, z);
        }
    }
}
