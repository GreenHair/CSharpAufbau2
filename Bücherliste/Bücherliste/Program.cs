using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bücherliste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Buch> liste = new List<Buch>();
            liste.Add(new Buch("Zulu", "Titel1", 10000, 40));
            liste.Add(new Buch("Alpha", "Titel2", 6000, 25.99));
            liste.Add(new Buch("Oskar", "Titel3", 12000, 52.99));

            foreach (Buch b in liste)
                Console.WriteLine(b);

            Console.WriteLine(new string('-', 30));

            // Alle mit Auflage unter 10000 entfernen
            /* liste.RemoveAll(b => b.Auflage < 10000);
             foreach (Buch b in liste)
                 Console.WriteLine(b);*/

            liste.Sort();
            foreach (Buch b in liste)
                Console.WriteLine(b);

            Console.WriteLine(new string('-', 30));

            liste.Sort(new Buchvergleich());
            foreach (Buch b in liste)
                Console.WriteLine(b);

            Console.WriteLine(new string('-', 30));

            foreach (Buch buch in liste.FindAll(b => b.Preis > 34.99))
                Console.WriteLine(buch);

            Console.WriteLine(new string('-', 30));
            // Vor Binäresuche muß die liste sortiert werden
            liste.Sort();
            int index = liste.BinarySearch(new Buch("Oskar", "Titel3", 12000, 52.99));
            Console.WriteLine(index);
        }
    }
}
