using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikelHashSet
{
    class Artikel
    {
        public string Bezeichnung { get; private set; }
        public double Preis { get; private set; }

        public Artikel(string was, double wieviel)
        {
            Bezeichnung = was;
            Preis = wieviel;
        }

        public override bool Equals(object obj)
        {
            if (obj is Artikel)
            {
                Artikel art = obj as Artikel;
                if(art.Bezeichnung == Bezeichnung && art.Preis == Preis)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Bezeichnung.Length + (int)Preis;
        }

        public override string ToString()
        {
            return Bezeichnung + "\t" + Preis;
        }
    }
}
