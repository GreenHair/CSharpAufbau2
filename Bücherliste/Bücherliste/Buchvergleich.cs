using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bücherliste
{
    class Buchvergleich : IComparer<Buch>
    {
        public int Compare(Buch x, Buch y)
        {
            return y.Preis.CompareTo(x.Preis);
        }
    }
}
