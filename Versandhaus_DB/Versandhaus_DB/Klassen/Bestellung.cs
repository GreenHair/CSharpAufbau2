using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versandhaus_DB.Klassen
{
    class Bestellung
    {
        public int Kunden_Id;
        public DateTime Datum;
        public int Bestellnummer;
        public List<Bestellposition> Positionen;
    }
}
