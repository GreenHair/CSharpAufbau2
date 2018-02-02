using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunktezählerWerbeApp
{
    delegate int Plugin(Video film);

    class Browser
    {
        public Plugin Zähler = null;

        public int Abspielen(Video film)
        {
            if(Zähler != null)
            {
                return Zähler(film);
            }
            return 0;
        }
    }
}
