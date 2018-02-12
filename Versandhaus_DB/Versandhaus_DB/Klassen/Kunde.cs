using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versandhaus_DB.Klassen
{
    class Kunde
    {
        public string Vorname;
        public string Nachname;
        public int Kunden_Id;
        public DateTime Geburtsdatum;
        public string BildPfad;
        public List<Bestellung> Bestellungen;
    }
}
