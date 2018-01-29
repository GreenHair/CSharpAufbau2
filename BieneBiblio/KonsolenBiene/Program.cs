using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BieneBiblio;

namespace KonsolenBiene
{
    class Program
    {
        static void Main(string[] args)
        {
            Biene maja = new Biene(2, 1.2, Biene.EGeschlecht.Männlich);
            Blume rose = new Blume();
        }
    }
}
