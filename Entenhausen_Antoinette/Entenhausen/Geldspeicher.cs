using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entenhausen
{
    class Geldspeicher
    {
        public int Taler { get; private set; }

        public Geldspeicher(int taler)
        {
            this.Taler = taler;
        }

        public int leeren(int menge)
        {
            int entleert;
            if (Taler >= menge)
            {
                Taler -= menge;
                entleert = menge;
            }
            else if (Taler > 0)
            {
                entleert = Taler;
                Taler = 0;
            }
            else
            {
                entleert = 0;
            }
            return entleert;
        }
    }
}
