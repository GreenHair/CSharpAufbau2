using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RennenInThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Teil 1: Zwei unabhängiger Threads
            Teil1();
            Console.ReadLine();
            // Teil 2: Thread mit Übergabeparemeter
            Teil2();
            Console.ReadLine();
            // Teil 3 und 4: Die Main() gibt deb startschüsss und überwacht das Ende ( Join() )
            // Die Threads werden von einem anderen Thread beendet
            Teil4();
            Console.ReadLine();
            // Teil 5: Gemeinsam genutzte Ressource (Objekt)
            Teil5();
        }
        static void Teil5()
        {
            Tank Wassertank = new Tank(400);
            LäuferTank ole = new LäuferTank(Wassertank);
            LäuferTank ronny = new LäuferTank(Wassertank);

            Thread t1 = new Thread(ole.Rennen);
            Thread t2 = new Thread(ronny.Rennen);

            t1.Name = "Ole";
            t2.Name = "Ronny";

            t1.Start();
            t2.Start();
        }


        static void Teil4()
        {
            LäuferMitUhr Usain = new LäuferMitUhr();
            LäuferMitUhr Usain2 = new LäuferMitUhr();

            Thread t1 = new Thread(Usain.Rennen);
            Thread t2 = new Thread(Usain.Stopuhr);
            Thread t3 = new Thread(Usain2.Rennen);

            t1.Name = "Ole";
            t3.Name = "Ronny";

            t2.Start();
            t1.Start();
            t3.Start();

            t2.Join();
            t1.Join();
            t3.Join();

            Console.WriteLine("Rennen beendet. Überwundene Strecke : " + Usain.Strecke);
        }


        static void Teil2()
        {
            Läufer ole = new Läufer(ConsoleColor.Red);

            Läufer ronny = new Läufer(ConsoleColor.Yellow);

            // Parameterized Threadstart braucht ein object als Parameter
            Thread t1 = new Thread(ole.Laufen2);
            Thread t2 = new Thread(ronny.Laufen2);

            t1.Name = "Ole";
            t2.Name = "Ronny";

            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.Highest;

            Console.WriteLine("*****START******");
            t1.Start(250);
            t2.Start(100);

            //Aktueller Thread (Main) wartet auf das thread das join() aufruft
            t1.Join();

            // wird ausgegeben wenn t1 beendet ist, ABER das muss nicht direkt danach sein
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("t1 beendet");

            t2.Join();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*****ENDE*******");
        }


        static void Teil1()
        {
            Läufer per = new Läufer(ConsoleColor.Red);
            
            Läufer ronny = new Läufer(ConsoleColor.Yellow);

            // Funktion ohne Übergabeparameter
            Thread t1 = new Thread(per.Laufen);
            Thread t2 = new Thread(ronny.Laufen);

            // Name dient die Zuordnung in der Ausgabe
            t1.Name = "Per";
            t2.Name = "Ronny";

            t1.Start();
            t2.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("******ENDE******");
        }
    }
}
