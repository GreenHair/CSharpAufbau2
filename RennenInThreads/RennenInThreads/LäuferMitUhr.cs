using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RennenInThreads
{
    class LäuferMitUhr
    {
        public static bool IsStopped { get; private set; }
        public int Strecke { get; private set; }

        public void Rennen()
        {
            while (!IsStopped)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " läuft " + Strecke + "m");
                Strecke += 10;
                Thread.Sleep(200);
            }
            Console.WriteLine(Thread.CurrentThread.Name + " hält an");
        }

        public void Stopuhr()
        {
            IsStopped = false;
            for(int i = 60; i > 0; i--)
            {
                Console.WriteLine("noch " + i + " Sekunden");
                Thread.Sleep(200);
            }
            Console.WriteLine("Zeit ist um");
            IsStopped = true;
        }
    }
}
