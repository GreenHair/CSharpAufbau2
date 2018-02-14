using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiboHotel;

namespace TestBiboHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel h = new Hotel();
            h.eintragen(2, "Franz", new DateTime(2018, 02, 14), new DateTime(2018, 02, 15));
            
            foreach(Buchung b in h.ausgebenAlle())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", b.Von, b.Bis, b.Name, b.Zimmer);
            }
            foreach(int i in h.ausgebenZimmer())
            {
                Console.WriteLine(i);
            }
            foreach (Buchung b in h.ausgebenZimmerBuchung(2))
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", b.Von, b.Bis, b.Name, b.Zimmer);
            }
            foreach (Buchung b in h.ausgebenNamen("Franz"))
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", b.Von, b.Bis, b.Name, b.Zimmer);
            }
            Console.WriteLine(h.ToString());
            
        }
    }
}
