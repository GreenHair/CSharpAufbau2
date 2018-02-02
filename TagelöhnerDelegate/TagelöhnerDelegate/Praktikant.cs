using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagelöhnerDelegate
{
    class Praktikant
    {
        public string Name { get; private set; }
        public int Moral { get; private set; }

        public Praktikant(string _name, int _moral)
        {
            Name = _name;
            Moral = _moral;
        }
    }
}
