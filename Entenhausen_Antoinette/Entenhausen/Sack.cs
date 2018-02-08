using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entenhausen
{
    class Sack
    {
        public const int Max = 301;
        public int Taler { get; private set; }
        public bool Diamant { get; private set; }

        public Sack(int Taler)
        {
            this.Taler = Taler;
            Diamant = false;
        }

        public void Adden()
        {
            Diamant = true;
        }
    }
}
