using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Märchenwald
{
    class HänselGretel
    {
        private List<Brotkrümmel> Brot;
        static Random rnd = new Random();

        public HänselGretel(List<Brotkrümmel> _brot)
        {
            //Brot = _brot;
            Brot = new List<Brotkrümmel>();
            for(int i = 0; i < 20; i++)
            {
                Brot.Add(new Brotkrümmel());
            }
        }

        public Brotkrümmel Werfen()
        {
            Brotkrümmel b;
            if (Brot.Count > 0)
            {
                b = Brot.Last();
                Brot.Remove(b);
            }
            else
            {
                b = null;
            }
            return b;
        }

        public void Fallenlassen()
        {
            for(int i = 0; i < 20; i++)
            {
                lock (Brot)
                {
                    Brot.Add(new Brotkrümmel());
                    Console.WriteLine("Brot geworfen");
                }
                Thread.Sleep(rnd.Next(500, 800));
            }
        }
    }
}
