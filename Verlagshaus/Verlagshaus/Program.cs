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
            Bunte.Hinzufügen(new Politik("Einwanderung", new List<Autor> { new Autor("Fritz") }), 
                new Prominenz("Boris Becker", new List<Autor> { new Autor("Franz") }),
                new Wirtschaft("Bitcoin", new List<Autor> { new Autor("Ulrike") }), 
                new EssenTrinken("Kohlroulade", new List<Autor> { new Autor("Fritz"),new Autor("Henriette") }));
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

            Console.WriteLine("Autoren für Bunte:");
            foreach(Themen t in Bunte.Inhalt())
            {
                Console.WriteLine(t.GetType().Name + " :");
                foreach(Autor a in t.Autoren)
                {
                    Console.WriteLine(a);
                }
            }

            Console.WriteLine("Fritz schreibt Artikeln über:");
            foreach(string s in Bunte.SucheAutor("Fritz"))
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(Bunte.Ausliefern(new Teenager("Finn")));
        }
    }
}
