using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entenhausen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sack> liste = new List<Sack>();

            Random rnd = new Random();

            int menge = rnd.Next(10000, 12001);
            Console.WriteLine("Taler im Speicher: " + menge);

            Geldspeicher speicher = new Geldspeicher(menge);

            Ente dagobert = new Ente(liste, speicher);

            Task aufgabe = Task.Factory.StartNew(dagobert.schaufeln);

            //aufgabe.Start();  // ERgibt eine Fehler, der Task wird sofort im Hintergrund ausgeführt


            Task<int> aufgabe2 = Task<int>.Factory.StartNew(
                () =>
                {
                    int sum = 0;
                    foreach (Sack s in liste) sum += s.Taler;
                    return sum;
                }
            );
        }

        static void Mit_Parallel()
        {
            List<Sack> liste = new List<Sack>();

            Random rnd = new Random();

            int menge = rnd.Next(10000, 12001);
            Console.WriteLine("Taler im Speicher: " + menge);

            Geldspeicher speicher = new Geldspeicher(menge);

            Ente dagobert = new Ente(liste, speicher);

            //Stopuhr einschalten
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Parallel.Invoke(dagobert.schaufeln, dagobert.schaufeln);
            //dagobert.schaufeln();

            watch.Stop();

            Console.WriteLine("Anzahl Säcke: " + liste.Count);
            Console.WriteLine("Durchschnittlich: " + liste.Average(s => s.Taler));
            Console.WriteLine("Maximum: " + liste.Max(s => s.Taler));
            Console.WriteLine("Minimum: " + liste.Min(s => s.Taler));
            Console.WriteLine("Zeit: " + watch.Elapsed);

            //Die Taler sollen per Hand gezählt werden, die for Schleife soll auf mehrere Threads Verteilt werden
            int Summe = 0;
            Parallel.For(0, liste.Count, i => Summe += liste[i].Taler);
            Console.WriteLine("Anzahl aller Taler: " + Summe);

            // In einem der Säcke Diamant verstecken
            int zufall = rnd.Next(liste.Count);
            liste[zufall].Adden();

            ParallelLoopResult plr =  
                Parallel.ForEach(liste, (s,option) => { if (s.Diamant) { Console.WriteLine("Gefunden"); option.Break(); } });
            Console.WriteLine("Diamant gefunden in Sack nr.: " + plr.LowestBreakIteration);

        }

        static void Ohne_Threads()
        {
            List<Sack> liste = new List<Sack>();

            Random rnd = new Random();

            int menge = rnd.Next(10000, 12001);
            Console.WriteLine("Taler im Speicher: " + menge);

            Geldspeicher speicher = new Geldspeicher(menge);

            Ente dagobert = new Ente(liste, speicher);


            dagobert.schaufeln();

            Console.WriteLine("Anzahl Säcke: " + liste.Count);
            Console.WriteLine("Durchschnittlich: " + liste.Average(s => s.Taler));
            Console.WriteLine("Maximum: " + liste.Max(s => s.Taler));
            Console.WriteLine("Minimum: " + liste.Min(s => s.Taler));
        }

    }
}
