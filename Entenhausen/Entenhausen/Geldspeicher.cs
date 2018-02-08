using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entenhausen
{
    class Geldspeicher
    {
        Random rand;
        public int Taler { get; private set; }

        public Geldspeicher()
        {
            rand = new Random();
            Taler = rand.Next(10000, 12001);
        }

        public int Entnehmen()
        {
            int Schaufel = rand.Next(301);
            if(Taler - Schaufel >= 0)
            {
                Taler -= Schaufel;
            }
            else
            {
                Schaufel = Taler;
                Taler = 0;
            }
            return Schaufel;
        }
    }
}
