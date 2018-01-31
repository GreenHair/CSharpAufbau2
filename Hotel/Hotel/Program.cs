using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<Zimmer, List<Gast>> Hilton = new Dictionary<Zimmer, List<Gast>>(new ZimmerVergleich());
            //Hilton.Add(new Zimmer(100, 56, true, true, true), new List<Gast>());
            //Hilton.Add(new Zimmer(101, 60, false, true, true), new List<Gast>());
            //Dictionary<Zimmer, List<Gast>>.KeyCollection Schlüsseln = Hilton.Keys;
            //Dictionary<Zimmer, List<Gast>>.KeyCollection.Enumerator iter = Schlüsseln.GetEnumerator();
            //while (iter.MoveNext())
            //{
            //    Console.WriteLine(iter.Current.TageBelegt);
            //}

            HotelGebäude Continental = new HotelGebäude();
            Continental.AddZimmer(new Zimmer(100, 56, true, true, true));
            Continental.AddZimmer(new Zimmer(101, 56, true, true, true));
            Continental.AddZimmer(new Zimmer(102, 57, true, true, true));
            Continental.AddZimmer(new Zimmer(103, 60, true, true, true));
            Continental.AddZimmer(new Zimmer(104, 30, true, true, true));
            Continental.AddZimmer(new Zimmer(105, 25, true, true, true));
            Continental.Zimmern[100].Buchen(new List<Gast> { new Gast("Walter", 65) },2);
            Continental.Zimmern[100].Buchen(new List<Gast> { new Gast("Heinrich", 65),
            new Gast("Gertrude",63)  }, 5);
            Continental.Zimmern[103].Buchen(new List<Gast> { new Gast("Heinz", 35),
            new Gast("Kunz",37),new Gast("Fritz",33)}, 7);
            Continental.Zimmern[105].Buchen(new List<Gast> { new Gast("Walter", 65) }, 2);
            Continental.Zimmern[104].Buchen(new List<Gast> { new Gast("Waltraud", 27) }, 25);
            Continental.Zimmern[102].Buchen(new List<Gast> { new Gast("Sieglinde", 75) }, 8);
            //Console.WriteLine(Continental.Zimmern[100].Gäste.Count);
            Console.WriteLine(Continental.Zimmern.Sum(z => z.Value.Gäste.Count));
            foreach(KeyValuePair<int,Zimmer> room in Continental.Zimmern)
            {
                Console.WriteLine("Zimmer {0} \t{1} Gäste", room.Key, room.Value.Gäste.Count);
            }

            foreach (KeyValuePair<int, Zimmer> room in Continental.Zimmern)
            {
                if(room.Value.Buchung != null)
                    Console.WriteLine("Zimmer {0} hat durchschnittlich {1} Gäste", room.Key, room.Value.Buchung.Average( g => g.Count));
            }

            foreach (KeyValuePair<int, Zimmer> room in Continental.Zimmern)
            {
                Console.WriteLine("Zimmer {0} wurde {1} Tage gebucht", room.Key, room.Value.TageBelegt);
            }
        }
    }
}
