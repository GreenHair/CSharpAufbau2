using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besitztümer
{
    abstract class Besitz:IComparable<Besitz>
    {
        public string Bezeichnung { get; private set; }
        public double Wert { get; private set; }

        public Besitz(string _bezeichnung, double _wert)
        {
            Bezeichnung = _bezeichnung;
            Wert = _wert;
        }

        public override string ToString()
        {
            return Bezeichnung + " | " + Wert;
        }

        public override int GetHashCode()
        {
            // wenn der typ gleich ist könnte das Objekt gleich sein
            return GetType().Name.Length;
        }

        public override bool Equals(object obj)
        {
            // Vergleich der Typen der beiden Objekte
            string typ1 = GetType().Name;
            string typ2 = obj.GetType().Name;

            if (typ1 == typ2)
            {
                Besitz vgl = obj as Besitz;
                if(Bezeichnung == vgl.Bezeichnung && Wert == vgl.Wert)
                {
                    return true;
                }
                
            }
            return false;
        }

        public int CompareTo(Besitz other)
        {
            return other.Wert.CompareTo(Wert);
        }
    }
}
