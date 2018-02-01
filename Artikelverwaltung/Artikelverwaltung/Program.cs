using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            Waschmachine a = new Waschmachine(700, 2);
            Kühlschrank b = new Kühlschrank(500, 3);
            Waschmachine c = new Waschmachine(1200, 1);
            Kühlschrank d = new Kühlschrank(900, 4);

            Console.WriteLine("------Nur Waschmachinen--------");
            Artikelliste<Waschmachine> launderette = new Artikelliste<Waschmachine>();
            launderette.Hinzufügen(a, c);
            foreach (Waschmachine art in launderette.AlleArtikel())
            {
                Console.WriteLine(art);
            }
            Console.WriteLine();

            Console.WriteLine("------Nur Kühlschränke--------");
            Artikelliste<Kühlschrank> kühlkammer = new Artikelliste<Kühlschrank>();
            kühlkammer.Hinzufügen(b, d);
            foreach (Kühlschrank art in kühlkammer.AlleArtikel())
            {
                Console.WriteLine(art);
            }
            Console.WriteLine();

            Console.WriteLine("------Alle Haushaltsgeräte--------");
            Artikelliste<Artikel> meineArtikel = new Artikelliste<Artikel>();
            meineArtikel.Hinzufügen(a, b, c, d);
            foreach(Artikel art in meineArtikel.AlleArtikel())
            {
                Console.WriteLine(art);
            }
            
        }
    }
}
