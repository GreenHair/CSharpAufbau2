using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagelöhnerDelegate
{
    delegate double DelBeruf(int std);

    class Tagelöhner
    {
        public DelBeruf Was = null;
        public double Lohn { get; private set; }

        public double Arbeiten(int std)
        {
            if(Was != null)
            {
                Lohn += Was(std);
            }
            return Lohn;
        }
    }
}
