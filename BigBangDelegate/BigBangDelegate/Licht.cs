using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangDelegate
{
    class Licht : Element
    {
        public void Ausschalten()
        {
            Console.WriteLine("Leuchtet nicht");            
        }

        public void Einschalten()
        {
            Console.WriteLine("Leuchtet");
        }
    }
}
