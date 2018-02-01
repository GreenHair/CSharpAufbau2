using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikelverwaltung
{
    class Artikelliste<T> where T:Artikel
    {
        private List<T> _artikelliste;

        public Artikelliste()
        {
            _artikelliste = new List<T>();
        }

        public void Hinzufügen(params T[] liste)
        {
            foreach (T a in liste)
            {
                _artikelliste.Add(a);
            }
        }

        public void Löschen(T a)
        {
            _artikelliste.Remove(a);
        }

        public T Suchen(int index)
        {                        
            return _artikelliste.Find(a => a.Artikelnr == index);
        }

        public T[] AlleArtikel()
        {
            return _artikelliste.ToArray();
        }
    }
}
