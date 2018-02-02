using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunktezählerWerbeApp
{
    class WerbeApp
    {
        public int Punktkonto { get; private set; }

        public int Untersuchen(Video film)
        {
            if (film.IstWerbung)
            {
                Punktkonto++;
            }
            return Punktkonto;
        }
    }
}
