using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DreiDDrucker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Ablauf1();
            //Console.ReadLine();
            //Ablauf2();
            //Console.ReadLine();
            // Variante1();
            Variante2();
        }

        static void Variante1()
        {
            Variant1 v1 = new Variant1();

            Thread t1 = new Thread(v1.Threading1);
            Thread t2 = new Thread(v1.Threading1_Clock);

            t1.Start();
            t2.Start();

        }

        static void Variante2()
        {
            Queue<Druckauftrag> Warteschlange = new Queue<Druckauftrag>();
            Drucker Printer = new Drucker(Warteschlange);
            Variant2 Arbeiter = new Variant2(Warteschlange);
            Thread t1 = new Thread(Arbeiter.GenerierenAufträge);
            Thread t2 = new Thread(Printer.Drucken);
            t1.Start();
            t2.Start();
        }

        static void Ablauf1()
        {
            Console.WriteLine("Ablauf 1:\n");
            Drucker Epson = new Drucker();
            Epson.Hinzufügen(new Druckauftrag("Würfel"));
            Epson.Hinzufügen(new Druckauftrag("Kegel"));
            Epson.Hinzufügen(new Druckauftrag("Zylinder"));

            Epson.Drucken();
            Console.WriteLine("Insegesamt würde {0} Sekunden gedrückt",Epson.Betriebszeit);
        }

        static void Ablauf2()
        {
            Console.Clear();
            Console.WriteLine("Ablauf 2:\n");
            string Eingabe;
            bool DruckauftragErstellen;
            Drucker Canon = new Drucker();
            do
            {
                Console.WriteLine("Was möchten sie drücken? (Enter zum beenden)");
                Eingabe = Console.ReadLine();
                DruckauftragErstellen = Eingabe.Length > 0;
                if(DruckauftragErstellen)
                {
                    Canon.Hinzufügen(new Druckauftrag(Eingabe));
                }

            } while (DruckauftragErstellen);

            Console.WriteLine("Drucken wird gestartet.");
            Canon.Drucken();
            Console.WriteLine("Insegesamt würde {0} Sekunden gedrückt", Canon.Betriebszeit);
        }
    }
}
