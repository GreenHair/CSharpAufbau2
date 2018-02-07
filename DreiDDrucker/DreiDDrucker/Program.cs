using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreiDDrucker
{
    class Program
    {
        static void Main(string[] args)
        {
            Ablauf1();
            Console.ReadLine();
            Ablauf2();
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
