using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum
{
    class Program
    {
        static void Main(string[] args)
        {
            Einlasskontrolle Kasse = new Einlasskontrolle();
            Erwachsene Erwin = new Erwachsene();
            Kind Katrin = new Kind();

            Kasse.Besucher += Erwin.Zahlen;
            Console.WriteLine("Der Umsatz für {1} Besucher ist: {0:F2}", Kasse.Abkassieren(3), Kasse.Anzahl_Besucher) ;

           // Kasse.Besucher -= Erwin.Zahlen;
            Kasse.Besucher += Katrin.Kind_Betrag;
            Console.WriteLine("Der Umsatz ist: {0:F2}", Kasse.Abkassieren(2));
            Console.WriteLine("Tagesumsatz: {0:F2}", Kasse.Tagesumsatz);

            //Kasse.Besucher -= Katrin.Kind_Betrag;
            Kasse.Besucher += (anz) => anz * 2;
            Console.WriteLine("Die Audioführung hat {0:F2}Eur eingebracht.", Kasse.Abkassieren(Kasse.Anzahl_Besucher));
        }
    }
}
