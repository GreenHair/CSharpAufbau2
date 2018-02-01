using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    class Zeitschrift<T> where T:Themen 
    {
        private List<T> Themen;

        public Zeitschrift()
        {
            Themen = new List<T>();
        }

        public void Hinzufügen(params T[] beiträge)
        {
            foreach(T b in beiträge)
            {
                Themen.Add(b);
            }
        }

        public void Hinzufügen(T beitrag)
        {
            Themen.Add(beitrag);
        }

        public T[] Inhalt()
        {
            return Themen.ToArray();
        }

        public List<T> ArtikelZumThema( Type thema)
        {
            return Themen.FindAll(t => t.GetType().Equals(thema));
        }

        public List<string> SucheAutor(string name)
        {
            List<string> temp = new List<string>();
            foreach(Themen thema in Themen)
            {
                Autor autor = thema.Autoren.Find(a => a.Name == name);
                if(autor != null)
                {
                    temp.Add(thema.GetType().Name);
                }
            }
            return temp;
        }

        public string Ausliefern<P>(P wer) where P : Person, IMobile
        {
            return wer.Name + " liefert aus mit seinem " + wer.fortbewegen();
        }
    }
}
