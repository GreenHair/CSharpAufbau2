using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RennenInThreads
{
    class Läufer
    {
        ConsoleColor farbe;

        public Läufer(ConsoleColor _farbe)
        {
            farbe = _farbe;
        }

        public void Laufen()
        {

            for (int i = 0; i <= 1000; i += 10)
            {
                Console.ForegroundColor = farbe;
                Console.Write(Thread.CurrentThread.Name + " : ");
                Console.WriteLine(i + "m Gelaufen");
                Thread.Sleep(500);
            }
        }

        public void Laufen2(object schrittlänge)
        {                            // Achtung cast zu int ohne sicherung!!!!!!!
            for (int i = 0; i <= 1000; i += (int)schrittlänge)
            {
                Console.ForegroundColor = farbe;
                Console.Write(Thread.CurrentThread.Name + " : ");
                Console.WriteLine(i + "m Gelaufen");
                Thread.Sleep(500);
            }
        }
    }
}
