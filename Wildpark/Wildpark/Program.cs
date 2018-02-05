using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildpark
{
    class Program
    {
        static void Main(string[] args)
        {
            Gehege<Raubkatze> Gehege1 = new Gehege<Raubkatze>();
            Gehege1.Add(new Löwe());
           // Gehege1.Add(new Papagei());

            GehegeTyp1 Gehege2 = new GehegeTyp1();
            Gehege2.Add(new Löwe());
           // Gehege2.Add(new Papagei());
        }
    }
}
