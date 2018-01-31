using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besitztümer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictioinary ist eine zuordnung nach Key, Value
            // ein Key ist eindeutig, die values können mehrfach vorkommen

            // Key ist ein string, value ist eine collection von Objekte
            Dictionary<string, HashSet<Besitz>> map = new Dictionary<string, HashSet<Besitz>>();
            map.Add("Haus", new HashSet<Besitz>());
            map["Haus"].Add(new Haus("Villa am Hafen", 5000, 300));
            map["Haus"].Add(new Haus("Gartenhaus", 50, 120));

            map.Add("Auto", new HashSet<Besitz>());
            map["Auto"].Add(new Auto("Ente", 12000));

            Dictionary<string, HashSet<Besitz>>.KeyCollection keys = map.Keys;
            Dictionary<string, HashSet<Besitz>>.KeyCollection.Enumerator iter =  keys.GetEnumerator();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
                foreach (Besitz b in map[iter.Current])
                {
                    Console.WriteLine(b);
                }
            }


            Dictionary<Person, HashSet<Besitz>> map2 = new Dictionary<Person, HashSet<Besitz>>();
            map2.Add(new Person("Hans"), new HashSet<Besitz>());
            map2.Add(new Person("Hans"), new HashSet<Besitz>());

            Console.WriteLine(map2.Keys.Count); // Ergibt 2

            // mit implementierung der IEquality und Vergleichsklasse kommt ein Fehler
            //Dictionary<Person, HashSet<Besitz>> map2 = new Dictionary<Person, HashSet<Besitz>>(new Vergleich());


        }


        static void set_generics()
        {
            HashSet<Besitz> vermögen = new HashSet<Besitz>();
            vermögen.Add(new Boot("Gummiboot", 350));
            vermögen.Add(new Boot("Yacht", 5000000));
            vermögen.Add(new Boot("Yacht", 5000000));
            vermögen.Add(new Haus("Villa am Hafen", 5000, 300));
            vermögen.Add(new Haus("Gartenhaus", 50, 120));
            vermögen.Add(new Auto("Ente", 12000));

            foreach (Besitz b in vermögen)
                Console.WriteLine(b);
            Console.WriteLine("______Sortiert______");
            // vermögen sortieren, aber Sort() gibt es nur bei List
            // ...also umwandeln!
            List<Besitz> liste = new List<Besitz>(vermögen);
            liste.Sort();
            foreach (Besitz b in liste)
                Console.WriteLine(b);

            Console.WriteLine("Summe: " + liste.Sum(b => b.Wert));
            Console.WriteLine("Durchschnittswert: " + liste.Average(b => b.Wert));
            Console.WriteLine("Maximum: " + liste.Max(b => b.Wert));
            Console.WriteLine("Minimum: " + liste.Min(b => b.Wert));

            Console.WriteLine("** Gerichtsvollzieher **");
            Console.WriteLine("Der höchste Wert: " + liste[0]);

            // noch eine Collection-Typ
            Queue<Besitz> schlange = new Queue<Besitz>(liste);
            // Es kann nur das erste Element entfernt werden
            // FIFO (first in, first out)
            Console.WriteLine("Erster Gegenstand weg: " + schlange.Dequeue());
            Console.WriteLine("Zweiter Gegenstand weg: " + schlange.Dequeue());

            // was passiert wenn das vermögen etwas zugefügt wird?
            vermögen.Add(new Auto("Trabbi", 2500));
            Console.WriteLine("----------Vermögen----------");
            foreach (Besitz b in vermögen)
                Console.WriteLine(b);
            Console.WriteLine("----------Liste----------");
            foreach (Besitz b in liste)
                Console.WriteLine(b);
            Console.WriteLine(new string('_',50));
            //____________________________________________________
            // vermögen sortiert nach typ
            // gruppiert ist intern eine Mappe (Dictionary)
            IEnumerable<IGrouping<string,Besitz>> gruppiert = vermögen.GroupBy(b => b.GetType().Name);

            // Ausgabe von gruppiert
            foreach(IGrouping<string,Besitz> g in gruppiert)
            {
                Console.WriteLine("Der Key: " + g.Key);
                Console.WriteLine("Die Objekte: ");
                //IEnumerator<Besitz> iterator = g.GetEnumerator();
                //while (iterator.MoveNext())
                //{
                //    Console.WriteLine("\t" + iterator.Current);
                //}
                foreach (Besitz b in g)
                {
                    Console.WriteLine("\t" + b);
                }
                Console.WriteLine("Summe: " + g.Sum(b => b.Wert));
                
            }
        }

        static void test()
        {
            Besitz b1 = new Boot("Yacht", 5000000);
            Besitz b2 = new Boot("Gummiboot", 350);
            Besitz b3 = new Haus("Villa am Hafen", 5000, 300);

            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);

            Console.WriteLine("Boot und Boot: " + b1.Equals(b2));
            Console.WriteLine("Boot und Haus: " + b2.Equals(b3));
        }
    }
}
