using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreiDDrucker
{
    class Druckauftrag
    {
        public readonly string Beschreibung;
        public int Dauer;
        private Random rand;

        public Druckauftrag(string _beschreibung)
        {
            Beschreibung = _beschreibung;
            rand = new Random();
            Dauer = rand.Next(1000);
        }
    }
}
