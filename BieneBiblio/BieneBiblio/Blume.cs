using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BieneBiblio
{
    public class Blume
    {
        public string Farbe { get; private set; }
        public string Art { get; private set; }

        public Blume(string _farbe, string _art)
        {
            Farbe = _farbe;
            Art = _art;
        }

        internal string Bestaeuben()
        {
            return "Bestäubt";
        }
    }
}
