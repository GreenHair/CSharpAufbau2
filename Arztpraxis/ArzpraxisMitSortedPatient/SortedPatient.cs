using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArzpraxisMitSortedPatient
{
    class SortedPatient:IComparable<SortedPatient>
    {
        public string Name { get; private set; }
        public int Alter { get; private set; }

        public SortedPatient(string _name, int _alter)
        {
            Name = _name;
            Alter = _alter;
        }

        public override string ToString()
        {
            return Name + " | " + Alter;
        }

        // Sortiert aufsteigend nach Name und prüft auf doppelte
        public int CompareTo(SortedPatient other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
