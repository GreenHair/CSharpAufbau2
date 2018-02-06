using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ArbeitslagerThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList Kiste = new ArrayList();
            Oberaufseher ronny = new Oberaufseher(Kiste);
            //Arbeiter a1 = new Arbeiter(Kiste,ConsoleColor.Cyan);
            //Arbeiter a2 = new Arbeiter(Kiste, ConsoleColor.Green);
            //Arbeiter a3 = new Arbeiter(Kiste, ConsoleColor.Red);
            //Arbeiter a4 = new Arbeiter(Kiste, ConsoleColor.Yellow);
            List<Arbeiter> Belegschaft = new List<Arbeiter>();
            for (int i = 0; i < 20; i++)
            {
                Belegschaft.Add(new Arbeiter(Kiste));
            }

            Thread t1 = new Thread(ronny.Nachschauen) { Name = "Ronny" };
            //Thread ta1 = new Thread(a1.Arbeiten) { Name = "Ole" };
            //Thread ta2 = new Thread(a2.Arbeiten) { Name = "Klaus" };
            //Thread ta3 = new Thread(a3.Arbeiten) { Name = "Berthold" };
            //Thread ta4 = new Thread(a4.Arbeiten) { Name = "Heinrich" };

            List<Thread> Produktion = new List<Thread>();
            for(int i = 0; i < Belegschaft.Count; i++)
            {
                Produktion.Add(new Thread(Belegschaft[i].Arbeiten) { Name = "Arbeiter " + i });
            }

            t1.Start(2000);
            //ta1.Start();
            //ta2.Start();
            //ta3.Start();
            //ta4.Start();

            foreach(Thread ta in Produktion)
            {
                ta.Start();
            }

            t1.Join();
            //ta1.Join();
            //ta2.Join();
            //ta3.Join();
            //ta4.Join();

            foreach (Thread ta in Produktion)
            {
                ta.Join();
            }

            Console.WriteLine("Es wurden {0} Schlüsselhänger dem Aufseher übergeben", ronny.Tagesproduktion);
            Console.WriteLine("Es sind noch {0} Schlüsselhänger in der Kiste. Gute Arbeit Kamaraden!",Kiste.Count);
            int max = Belegschaft.Max(m => m.PersönlicheLeistung);
            int MaDesTages = Belegschaft.FindIndex(m => m.PersönlicheLeistung == max);
            Console.WriteLine("Mitarbeiter des Tages ist Arbeiter {0} mit {1} erstellte Schlüsselhänger",MaDesTages,max);
        }
    }
}
