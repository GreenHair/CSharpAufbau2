using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum
{
    class Kind
    {
        private double Eintritt;

        public Kind()
        {
            Eintritt = 3;
        }

        public double Kind_Betrag(int anz)
        {
            Console.WriteLine("Das Kind zahlt für {0} Kinder.", anz);
            return Eintritt * anz;
        }
    }
}
