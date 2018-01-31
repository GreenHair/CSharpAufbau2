using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besitztümer
{
    class Haus:Besitz
    {
        public double Qm { get; private set; }
        public double QmPreis { get; private set; }

        public Haus(string _bezeichnung, double _qm, double _qmpreis)
            : base(_bezeichnung, _qm * _qmpreis)
        {
            Qm = _qm;
            QmPreis = _qmpreis;
        }

        public override string ToString()
        {
            return base.ToString() + " ( " + Qm + ", " + QmPreis + " )";
        }

        
    }
}
