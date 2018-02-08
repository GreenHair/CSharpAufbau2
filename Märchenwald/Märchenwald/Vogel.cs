using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Märchenwald
{
    class Vogel
    {
        private static Random rand = new Random();
        private List<Brotkrümmel> heruntergefallenes;
        private static bool AlleAlle = false;
        public int Gegessen { get; private set; }

        public Vogel(List<Brotkrümmel> _heruntergefallenes)
        {
            heruntergefallenes = _heruntergefallenes;
        }

        public void Essen()
        {
            while (!AlleAlle)
            {
                lock (heruntergefallenes)
                {
                    if (heruntergefallenes.Count > 0)
                    {
                        heruntergefallenes.RemoveAt(0);
                        Gegessen++;
                        Console.WriteLine(Thread.CurrentThread.Name + " isst");                        
                    }                    
                }
                Thread.Sleep(rand.Next(1200,2000));
                AlleAlle = heruntergefallenes.Count == 0;
            }
            Console.WriteLine(Thread.CurrentThread.Name + " ist satt");
        }
    }
}
