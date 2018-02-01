using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    class Program
    {
        static void Main(string[] args)
        {
            Zeitschrift<Themen> Bunte = new Zeitschrift<Themen>();
            Bunte.Hinzufügen(new Politik("Einwanderung"), new Prominenz("Boris Becker"), new Wirtschaft("Bitcoin"), new EssenTrinken("Kohlroulade"));
            foreach(Themen t in Bunte.Inhalt())
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("Artikel zum Thema Politik");
            foreach(Politik p in Bunte.ArtikelZumThema(typeof(Politik)))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Anzahl der Artikel zum Thema Politik: " + Bunte.ArtikelZumThema(typeof(Politik)).Count);
        }
    }
}
