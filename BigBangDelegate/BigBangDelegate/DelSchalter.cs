using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangDelegate
{
    delegate void DelEin();
    delegate void DelAus();

    class DelSchalter
    {
        public DelEin MethodEin;
        public DelAus MethodAus;

        public void Ein()
        {
            MethodEin();
        }

        public void Aus()
        {
            MethodAus();
        }
    }
}
