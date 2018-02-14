using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReisekatologLib;

namespace Reisekatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Katalog kat = new Katalog();
            kat.Log += Console.WriteLine;
            kat.AlleZiele();
            kat.HotelsInZiel("Rom");
            kat.HotelsInZiel("Bern", 4);
        }
    }
}
