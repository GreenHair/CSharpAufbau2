using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bücherliste
{
    class Buch:IComparable<Buch>
    {
        public string Autor { get; private set; }
        public string Titel { get; private set; }
        public int Auflage { get; private set; }
        public double Preis { get; private set; }

        public Buch(string autor, string titel, int auflage, double preis)
        {
            Autor = autor;
            Titel = titel;
            Auflage = auflage;
            Preis = preis;
        }
        // Gleicher Autor + gleicher Titel -> die Bücher sind gleich
        public override bool Equals(object obj)
        {
            if(obj is Buch)
            {
                Buch vgl = obj as Buch;
                if(Autor == vgl.Autor && Titel == vgl.Titel)
                {
                    return true;
                }
            }
            return false;
        }
        // Gleicher Autor -> die Bücher könnten identisch sein
        public override int GetHashCode()
        {
            return Autor.Length;
        }

        public override string ToString()
        {
            return Autor + " | " + Auflage  + " | " + Preis;
        }

        public int CompareTo(Buch other)
        {
            return Autor.CompareTo(other.Autor);
        }
    }
}
