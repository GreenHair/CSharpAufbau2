using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaufhaus
{
    class Program
    {
        static void Main(string[] args)
        {
            Warenhaus Galeria = new Warenhaus();
            Kunde ronny = new Kunde("Ronny", true);
            Kunde winfried = new Kunde("Winfried", false);
            Galeria.Scanner += ScanKunde;

            Galeria.Ausgang(ronny);
            Galeria.Ausgang(winfried);

            Console.WriteLine(Galeria.AnzahlDiebe);
        }

        private static bool ScanKunde(Kunde k)
        {
            if (k.IstDieb)
            {
                Console.WriteLine(new String('I', 200));
                Console.WriteLine("Ein Dieb passiert die Anlage.");
                return true;
            }
            return false;
        }
    }
}
