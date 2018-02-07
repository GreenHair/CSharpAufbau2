using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Center_Threading
{
    class PrioritätVergleich : IComparer<Anruf>
    {
        public int Compare(Anruf x, Anruf y)
        {
            if(x.Wichtigkeit == y.Wichtigkeit)
            {
                return x.Nummer.CompareTo(y.Nummer);
            }
            if(x.Wichtigkeit == Anruf.Priorität.Neukunde)
            {
                return -1;
            }
            if(y.Wichtigkeit == Anruf.Priorität.Neukunde)
            {
                return 1;
            }
            if(x.Wichtigkeit == Anruf.Priorität.Bestandskunde)
            {
                return -1;
            }
            if(y.Wichtigkeit == Anruf.Priorität.Bestandskunde)
            {
                return 1;
            }
            return 1;
        }
    }
}
