using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangDelegate
{
    class Spinne : Element
    {
        public void Ausschalten()
        {
            Console.WriteLine("Die Spinne rennt.");            
        }

        public void Einschalten()
        {
            Console.WriteLine("Die Spinne erstarrt.");
        }
    }
}
