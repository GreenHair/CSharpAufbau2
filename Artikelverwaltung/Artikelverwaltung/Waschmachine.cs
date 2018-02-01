using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltung
{
    class Waschmachine:Artikel
    {
        public Waschmachine(double preis, int menge):base ("Waschmachine", preis, menge) { }
    }
}
