using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Zimmer
    {
        public readonly int ZimmerNr;
        public readonly double Qm;
        public bool HatFernseher { get; private set; }
        public bool HatWlan { get; private set; }
        public bool HatKüche { get; private set; }
        public List<Gast> Gäste { get; private set; }
        public List<List<Gast>> Buchung { get; private set; }
        public int TageBelegt { get; private set; }

        public Zimmer(int _nr, double _qm, bool tv, bool wifi, bool _küche)
        {
            ZimmerNr = _nr;
            Qm = _qm;
            HatFernseher = tv;
            HatWlan = wifi;
            HatKüche = _küche;
            Gäste = new List<Gast>();
           // Buchung = new List<List<Gast>>();
        }

        public string Buchen(List<Gast> wer, int wielang)
        {
            if(Buchung == null)
            {
                Buchung = new List<List<Gast>>();
            }
            Buchung.Add(wer);
            foreach (Gast g in wer)
                Gäste.Add(g);
            TageBelegt += wielang;
            return "Zimmer wurde gebucht";
        }

        public override int GetHashCode()
        {
            return (int)Qm;
        }

        public override bool Equals(object obj)
        {
            if(obj is Zimmer)
            {
                if (ZimmerNr == ((Zimmer)obj).ZimmerNr)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return ZimmerNr + " | " + Qm + "qm";
        }
    }
}
