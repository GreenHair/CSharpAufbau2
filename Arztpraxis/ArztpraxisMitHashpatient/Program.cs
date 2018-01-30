using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arztpraxis;

namespace ArztpraxisMitHashpatient
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<HashPatient> set = new HashSet<HashPatient>();
            set.Add(new HashPatient("Ole", 24));
            set.Add(new HashPatient("Ronny", 34));
            set.Add(new HashPatient("Mandy", 25));
            set.Add(new HashPatient("Ronny", 32));

            foreach (HashPatient p in set)
                Console.WriteLine(p);

            // Direkterzugriff nicht möglich
            // Console.WriteLine(set[0]);

            //Löschen eines bestimmtes Objekt
            set.RemoveWhere(hp => hp.Name == "Ronny");

            //set.OrderBy(hp => hp.Name);
            //foreach (HashPatient p in set)
            //    Console.WriteLine(p);



        }
    }
}
