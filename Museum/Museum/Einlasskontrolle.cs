using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum
{
    delegate double Kassieren(int anz);

    class Einlasskontrolle
    {
        public Kassieren Besucher = null;
        public double Tagesumsatz { get; private set; }
        public int Anzahl_Besucher { get; private set; }

        public double Abkassieren(int anz)
        {
            double Umsatz = 0.0;
            if (Besucher != null)
            {
                Anzahl_Besucher += anz;
                Umsatz = Besucher(anz);
                Tagesumsatz += Umsatz;
            }
            return Umsatz;
        }
    }
}
