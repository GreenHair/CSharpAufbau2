using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildpark
{
    class Gehege<T> where T:Tiere
    {
        public List<T> Tiere { get; private set; }
        public double Länge { get; private set; }
        public double Breite { get; private set; }
        public double Höhe { get; private set; }
        public string Zaun { get; protected set; }

        public Gehege()
        {
            Tiere = new List<T>();
        }

        public void Add(T tier)
        {
            Tiere.Add(tier);
        }
    }

    class GehegeTyp1 : Gehege<Raubkatze>
    {
        public GehegeTyp1()
        {
            Zaun = "Starkstrom";
        }
    }
}
