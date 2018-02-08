using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entenhausen
{
    class Sack
    {
        public int Inhalt { get; private set; }

        public Sack(int _inhalt)
        {
            Inhalt = _inhalt;
        }
    }
}
