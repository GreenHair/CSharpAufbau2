using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Märchenwald
{
    class Program
    {
        static Waldboden Boden = new Waldboden();
        static Random rand = new Random();
        static void Main(string[] args)
        {            
            List<Brotkrümmel> Brot = new List<Brotkrümmel>();
            HänselGretel HansGrietje = new HänselGretel(Brot);
            
            Vogel Spatz = new Vogel(Boden.Aufgefangen);
            Vogel Amsel = new Vogel(Boden.Aufgefangen);
           // Boden.Aufgefangen = Brot;
            Thread t1 = new Thread(Gehen);
            Thread t2 = new Thread(Spatz.Essen) { Name = "Spatz" };
            Thread t3 = new Thread(Amsel.Essen) { Name = "Amsel" };
            t1.Start(HansGrietje);
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Der Spatz hat {0} Brotkrümmel gegessen", Spatz.Gegessen);
            Console.WriteLine("Die Amsel hat {0} Brotkrümmel gegessen", Amsel.Gegessen);
        }

        static void Gehen(object hg)
        {
            HänselGretel HansGrietje = hg as HänselGretel;
            bool fertig = false;
            while (!fertig)
            {
                Brotkrümmel b = HansGrietje.Werfen();
                if(b != null)
                {
                    Boden.Aufgefangen.Add(b);
                    Console.WriteLine("Brot ist geworfen");
                    Thread.Sleep(rand.Next(400, 800));
                }
                else
                {
                    fertig = true;
                }
            }
        }
    }
}
