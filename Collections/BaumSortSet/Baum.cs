using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumSortSet
{
    class Baum:IComparable<Baum>
    {
        public readonly string Art;// { get; private set; }
        public readonly double Groesse;// { get; private set; }

        public Baum(string _art, double _groesse)
        {
            Art = _art;
            Groesse = _groesse;
        }
        
        public override string ToString()
        {
            return Art + " | " + Groesse;
        }

        public int CompareTo(Baum other)
        {
            return Art.CompareTo(other.Art);
        }
    }
}
