using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankschliessfach
{
    class Schliessfach
    {
        private static int _nummer = 1;
        private int _nr;
        private List<string> _inhalt;
        internal bool IstBelegt { get; set; }

        public Schliessfach()
        {
            _nr = _nummer++;
            _inhalt = new List<string>();
            IstBelegt = false;
        }

        internal List<string> GetInhalt()
        {
            return _inhalt;
        }

        public override string ToString()
        {
            string belegt = (IstBelegt) ? "Belegt" : "Frei";
            return _nr + " | " + belegt;
        }

        internal void Hineinlegen(string wertsache)
        {
            _inhalt.Add(wertsache);
        }
    }
}
