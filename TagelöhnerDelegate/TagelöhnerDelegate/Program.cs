using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagelöhnerDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Tagelöhner Ole = new Tagelöhner();

            // Es werden alle Methoden Aufgeführt, aber nur der letzte Rückgabewert wird übernommen
            Ole.Was += new Bäcker().BackenBrot;            
            Console.WriteLine("Mit Brotbacken habe ich verdient: " + Ole.Arbeiten(5));

            Ole.Was += new Dachdecker().DeckeDach;
                        
            Console.WriteLine("Mit Brotbacken und Dachdecken habe ich verdient: " + Ole.Arbeiten(5));

            Ole.Was += Aufgaben.Kellnern;
            Console.WriteLine("Nach Kellnern: " + Ole.Arbeiten(3));

            Ole.Was += Aufgaben.TrojanerBauen;
            Console.WriteLine("Nach Trojaner: " + Ole.Arbeiten(10));

            Ole.Was += (zahl) => zahl * 9.5;
            Console.WriteLine("Unbekannte Arbeit: " + Ole.Arbeiten(6));

            Bäcker b = new Bäcker();
            b.urteilen += Beurteilen;
            Praktikant Ronny = new Praktikant("Ronny", 65);
            Console.WriteLine(b.urteilen(Ronny, "Ofen Putzen"));

            b.urteilen += (p, was) => (p.Moral > 80) ? p.Name + " hat Aufgabe " + was + " ganz toll gemacht" : p.Name + " war nicht so gut";
            Console.WriteLine(b.urteilen(Ronny, "Verkaufen"));

        }

        static string Beurteilen(Praktikant p, string was)
        {
            if(p.Moral < 70)
            {
                return p.Name + " hat Aufgabe " + was + " nicht erfüllt";
            }
            return p.Name + " hat Aufgabe " + was + " zur Zufriedenheid erfüllt";
        }
    }
}
