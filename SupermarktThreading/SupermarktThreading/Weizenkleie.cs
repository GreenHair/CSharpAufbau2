using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SupermarktThreading
{
    class Weizenkleie
    {
        public double Gewicht { get; private set; }

        public Weizenkleie()
        {
            Gewicht = 1000;
        }
    }

    class Kunde
    {
        public List<Weizenkleie> Vorrat { get; private set; }

        public Kunde( List<Weizenkleie> liste)
        {
            Vorrat = liste;
        }

        public void Einkaufen()
        {
            lock (Vorrat)
            {
                if (Vorrat.Count > 0)
                {
                    Vorrat.RemoveAt(0);
                    Console.WriteLine(Thread.CurrentThread.Name + " hat ein Päckchen Weizenkleie gekauft");
                    Console.WriteLine("Es sind noch {0} Päckchen Weizenkleie da", Vorrat.Count);
                    Thread.Sleep(500);
                    //  if (Vorrat.Count > 0) { Vorrat.RemoveAt(0); }
                    //  Console.WriteLine("Es sind noch {0} Päckchen Weizenkleie da", Vorrat.Count);
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + ": Alles Ausverkauft");
                }
            }
        }
    }
}
