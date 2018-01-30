using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mitarbeiter> liste = new List<Mitarbeiter>();
            liste.Add(new Mitarbeiter("MA 1", 40, 1450));
            liste.Add(new Mitarbeiter("MA 2", 35, 1200));
            liste.Add(new Mitarbeiter("MA 3", 42, 1560));
            liste.Add(new Mitarbeiter("MA 4", 23, 1350));

            foreach (Mitarbeiter m in liste)
                Console.WriteLine(m);
            Console.WriteLine(new string('_', 50));
            liste.Remove(new Mitarbeiter("MA 2", 35, 1200));
            Console.WriteLine("Es gibt nur noch {0} Mitarbeiter", liste.Count);
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Mitarbeiter mit weniger als 1500,00EUR:");
            foreach (Mitarbeiter m in liste.FindAll(ma => ma.Gehalt < 1500))
                Console.WriteLine(m);
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Der dritte Mitarbeiter ist:");
            Console.WriteLine(liste[2]);

            Console.ReadLine();
        }
    }
}
