using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagelöhnerDelegate
{
    delegate string Urtreil(Praktikant p, string was);
    class Bäcker
    {
        public Urtreil urteilen = null;

        public double BackenBrot(int std)
        {
            return std * 11.5;
        }

        public string Einsetzen(Praktikant p, string was)
        {
            if(urteilen != null)
            {
                return urteilen(p, was);
            }
            return "Nichts zum beurteilen gefunden";
        }
    }
}
