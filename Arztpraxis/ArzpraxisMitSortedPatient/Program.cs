using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArzpraxisMitSortedPatient
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<SortedPatient> set = new SortedSet<SortedPatient>();
            set.Add(new SortedPatient("Ole", 24));
            set.Add(new SortedPatient("Ronny", 34));
            set.Add(new SortedPatient("Mandy", 25));
            set.Add(new SortedPatient("Alfred", 32));

            foreach (SortedPatient p in set)
                Console.WriteLine(p);
            Console.WriteLine(new string('-', 25));
            // auch Remove orientiert sich an CompareTo
            set.Remove(new SortedPatient("Ole", 24));
            foreach (SortedPatient p in set)
                Console.WriteLine(p);

        }
    }
}
