using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elektrogräte;

namespace Wohnhaus
{
    class Program
    {
        static void Main(string[] args)
        {
            Radio omisAlteRadio = new Radio();

            Console.WriteLine(omisAlteRadio.EinAus());
            omisAlteRadio.Lauter(300);
            omisAlteRadio.Leiser(200);
            omisAlteRadio.Lauter(40);
            Console.WriteLine(omisAlteRadio);
            Console.WriteLine(omisAlteRadio.EinAus());
            Console.WriteLine(omisAlteRadio);
            omisAlteRadio.SenderSpeichern("BFBS", 103.00);
            omisAlteRadio.SenderSpeichern("Wolke7", 97.4);
            Console.WriteLine("BFBS sendet auf {0:F2}", Radio.toFreq("BFBS"));
            Fernseher tv = new Fernseher();
            Console.WriteLine(tv.EinAus());
            tv.Zappen("Kika");
            Console.WriteLine(tv);
            DVD_Player samsung = new DVD_Player();
            Console.WriteLine(samsung.EinAus());

            Elektrogerät[] meineGeräte = new Elektrogerät[5];
            meineGeräte[0] = new Radio("Wolke7");
            meineGeräte[1] = new Radio();
            meineGeräte[2] = new Fernseher();
            meineGeräte[3] = new Radio(81.50);
            meineGeräte[4] = new Rauchmelder();
            foreach (Elektrogerät e in meineGeräte)
                Console.WriteLine(e);
        }
    }
}
