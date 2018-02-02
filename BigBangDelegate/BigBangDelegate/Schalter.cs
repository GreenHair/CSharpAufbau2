using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangDelegate
{
    class Schalter
    {
        public List<Element> Was { get; private set; }

        public Schalter()
        {
            Was = new List<Element>();
        }

        public void Hinzufügen(Element was)
        {
            Was.Add(was);
        }

        public void Ein()
        {
            foreach(Element e in Was)
            {
                e.Einschalten();
            }
        }

        public void Aus()
        {
            foreach (Element e in Was)
            {
                e.Ausschalten();
            }
        }
    }
}
