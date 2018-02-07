using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DreiDDrucker
{
    class Variant2
    {
        public Queue<Druckauftrag> Warteschlange { get; private set; }

        public Variant2(Queue<Druckauftrag> _warteschlange)
        {
            Warteschlange = _warteschlange;
        }

        public void GenerierenAufträge()
        {
            for(int i = 0; i < 20; i++)
            {
                //lock (Warteschlange)
                //{
                    Warteschlange.Enqueue(new Druckauftrag("Würfel"));
               // }
                Console.WriteLine("Ein neuer Auftrag...");
                Thread.Sleep(900);
            }
        }
    }
}
