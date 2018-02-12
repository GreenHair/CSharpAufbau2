using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versandhaus_DB.Klassen;

namespace Versandhaus_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Artikel a in Abfragen.getAlleArtikel())
            {
                Console.WriteLine(a);
            }

            Console.WriteLine(new string('-', 50));
            foreach(Kunde k in Abfragen.AlleKundenDetail())
            {
                Console.WriteLine("{0}\t{1,-15}\t{2,-15}\t{3}\t{4}",k.Kunden_Id, k.Nachname, k.Vorname, k.Geburtsdatum.Date, k.BildPfad);
            }
        }
    }
}
