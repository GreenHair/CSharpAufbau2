using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SupermarktThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Weizenkleie> Vorrat = new List<Weizenkleie>();
            Vorrat.Add(new Weizenkleie());
            Vorrat.Add(new Weizenkleie());

            Kunde k1 = new Kunde(Vorrat);
            Kunde k2 = new Kunde(Vorrat);
            Kunde k3 = new Kunde(Vorrat);

            Thread t1 = new Thread(k1.Einkaufen);
            Thread t2 = new Thread(k2.Einkaufen);
            Thread t3 = new Thread(k3.Einkaufen);

            t1.Name = "Brunnhilde";
            t2.Name = "Gudrun";
            t3.Name = "Sieglinde";

            t1.Start();
            t2.Start();
            t3.Start();

        }
    }
}
