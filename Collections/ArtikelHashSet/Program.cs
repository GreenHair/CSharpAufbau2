using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikelHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Artikel> liste = new HashSet<Artikel>();
            liste.Add(new Artikel("A1", 23.45));
            liste.Add(new Artikel("A2", 35.69));
            liste.Add(new Artikel("A3", 27.99));
            liste.Add(new Artikel("A1", 23.45));
            liste.Add(new Artikel("A2", 35.69));

            Console.WriteLine("Anzahl Artikel in der Liste: " + liste.Count);
            Console.WriteLine(new string('_', 30));
            int i = 1;
            foreach (Artikel a in liste)
            {
                if (i == 2)
                    Console.WriteLine(a);
                i++;
            }
            Console.WriteLine(new string('_', 30));
            foreach(Artikel a in liste)
            {
                if (a.Preis < 25)
                    Console.WriteLine(a);
            }
        }
    }
}
