using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Gast
    {
        public readonly string Name;
        public int Alter { get; private set; }

        public Gast(string _name, int _alter)
        {
            Name = _name;
            Alter = _alter;
        }

        public override string ToString()
        {
            return Name + " | " + Alter;
        }
    }
}
