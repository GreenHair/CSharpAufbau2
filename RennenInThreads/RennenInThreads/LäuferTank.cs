using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RennenInThreads
{
    class LäuferTank
    {
        public Tank myTank { get; private set; }

        public LäuferTank(Tank t)
        {
            myTank = t;
        }

        public void Rennen()
        {
            bool result = true;
            do
            {
                lock (myTank)
                {
                    result = myTank.reduzieren(30);
                    if (result)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + " rennt und trinkt");
                    }
                    Thread.Sleep(500);
                }
            } while (result);
            Console.WriteLine(Thread.CurrentThread.Name + " sagt: Tank ist leer, das wars.");
        }
    }

    class Tank
    {
        public double Liter { get; private set; }
        public Tank(double _liter)
        {
            Liter = _liter;
        }

        public bool reduzieren(double wieviel)
        {
            if(Liter >= wieviel)
            {
                Liter -= wieviel;
                Console.WriteLine(Thread.CurrentThread.Name +  " hat reduziert");
                Console.WriteLine("Im Tank sind: " + Liter);
                Thread.Sleep(400);
                return true;
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " sagt: nicht genügend im Tank");
                return false;
            }
        }
    }
}
