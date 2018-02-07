using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Call_Center_Threading
{
    class Agent
    {
        static bool fertig = false;
        public SortedSet<Anruf> Warteliste;
        public int Arbeitszeit { get; private set; }
        public int Pensum { get; private set; }

        public Agent(SortedSet<Anruf> liste)
        {
            Warteliste = liste;
        }

        public void Bearbeiten()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " fängt an zu arbeiten");
            Random rand = new Random();
            Anruf Kunde;
            int Zeit;
            while (!fertig)
            {
                lock (Warteliste)
                {
                    if (Warteliste.Count > 0)
                    {
                        Zeit = rand.Next(2, 5);
                    
                        Kunde = Warteliste.First();

                        Console.WriteLine("Anruf {0} wird bearbeitet von {1}, Dauer {2} Sekunden, Priorität: {3}",
                            Kunde.Nummer, Thread.CurrentThread.Name, Zeit, Kunde.Wichtigkeit);
                        Arbeitszeit += Zeit;
                        Warteliste.Remove(Kunde);
                        Pensum++;
                        Thread.Sleep(Zeit * 1000);
                        fertig = Warteliste.Count == 0;
                    }

                }
                
            }
            Console.WriteLine(Thread.CurrentThread.Name + " ist fertig");
        }
    }
}
