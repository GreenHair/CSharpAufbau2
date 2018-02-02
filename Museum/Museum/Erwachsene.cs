using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum
{
    class Erwachsene
    {
        public string Name { get; private set; }
        private double Eintritt;

        public Erwachsene()
        {
            Name = "Anonym";
            Eintritt = 6;
        }

        public Erwachsene(string _name)
        {
            Name = _name;
            Eintritt = 6;
        }

        public double Zahlen(int anz)
        {
            Console.WriteLine("{0} zahlt für {1} Erwachsenen.",Name,anz);
            return anz * Eintritt;
        }
    }
}
