using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    abstract class Themen
    {
        public string Beschreibung { get; private set; }
        public List<Autor> Autoren;

        public Themen(string _beschreibung,List<Autor> _autor)
        {
            Beschreibung = _beschreibung;
            Autoren = new List<Autor>();
            foreach(Autor a in _autor)
            {
                Autoren.Add(a);
            }
        }

        public override string ToString()
        {
            return GetType().Name + ": " + Beschreibung;
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() == GetType())
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return GetType().Name.Length;
        }
    }
}
