using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibo_Teich;

namespace Test_Bibo_Teich
{
    class Program
    {
        static void Main(string[] args)
        {
            Frosch fritz = new Frosch("Fritz", 2, 5, true);
            Fliege sjors = new Fliege();

            Console.WriteLine(fritz);
            Console.WriteLine(fritz.Geburtag());
            Console.WriteLine(fritz.Springen(10));
            Console.WriteLine(fritz.Fressen(ref sjors));
            Console.WriteLine(fritz.Springen(15));
            if (sjors != null)
                Console.WriteLine(fritz.Fressen(ref sjors));
            else
                Console.WriteLine("Sjors wurde schon gegessen");
        }
    }
}
