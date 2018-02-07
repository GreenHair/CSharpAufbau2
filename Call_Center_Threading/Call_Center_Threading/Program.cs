using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Call_Center_Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Anruf> Warteschlange = new SortedSet<Anruf>(new PrioritätVergleich());
            
            
            Agent Center1 = new Agent(Warteschlange);
            Agent Center2 = new Agent(Warteschlange);
           // Hinzufügen(Warteschlange);
            Thread t1 = new Thread(Center1.Bearbeiten) { Name = "Center 1" };
            Thread t2 = new Thread(Center2.Bearbeiten) { Name = "Center 2" };
            Thread t3 = new Thread(Hinzufügen);
            t3.Start(Warteschlange);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Die Bearbeitung de Warteschlange hat {0} Sekunden gedauert.", Center1.Arbeitszeit + Center2.Arbeitszeit);
            Console.WriteLine("Center 1 hat {0} Kunden bearbeitet, center 2 hat {1} Kunden bearbeitet",
                Center1.Pensum, Center2.Pensum);

            Console.ReadLine();
        }

        static void Hinzufügen(object _schlange)
        {
            SortedSet<Anruf> schlange = _schlange as SortedSet<Anruf>;
            Random rand = new Random();
            int Zeit;
            for (int i = 0; i < 25; i++)
            {
                 schlange.Add(new Anruf(i + 1));
                 Console.WriteLine("Ein neuer Anruf");   
                 Zeit = rand.Next(400, 1500);   
                 Thread.Sleep(Zeit);      
                
            }
        }
    }
}
