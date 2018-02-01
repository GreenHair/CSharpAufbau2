using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltung
{
    abstract class Artikel
    {
        private static int _artikelnr { get; set; }
        public int Artikelnr { get; private set; }
        public string Bezeichnung { get; set; }
        public double Preis { get; private set; }
        public int Menge { get; private set; }

        public Artikel(string _bezeichnung, double _preis, int _menge)
        {
            Artikelnr = ++_artikelnr;
            Bezeichnung = _bezeichnung;
            Preis = _preis;
            Menge = _menge;
        }

        public override string ToString()
        {
            return string.Format("{0}| {1,-15}|{2,8:F2} |{3,4}", Artikelnr, Bezeichnung, Preis, Menge);
        }
    }
}
