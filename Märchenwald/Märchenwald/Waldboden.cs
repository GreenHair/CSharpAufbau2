using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Märchenwald
{
    class Waldboden
    {
        public List<Brotkrümmel> Aufgefangen;
        
        public Waldboden()
        {
            Aufgefangen = new List<Brotkrümmel>();
        }

        public void Auffangen(Brotkrümmel b)
        {
            Aufgefangen.Add(b);
        }
    }
}
