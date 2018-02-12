using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versandhaus_DB.Klassen
{
    public enum Lager
    {
        Technik,Kleidung,Möbel,Unbekannt
    }

    class Artikel
    {
        public int Id;
        public double EPreis;
        public double VPreis;
        public string Bezeichnung;
        public Lager LagerArt;

        public override string ToString()
        {
            return string.Format("{0}\t{1,8:F2}\t{2,8:F2}\t{3,-15}\t{4}",Id,EPreis,VPreis,Bezeichnung,LagerArt);
        }
    }
}
