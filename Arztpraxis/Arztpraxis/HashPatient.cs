using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis
{
    class HashPatient
    {
        public string Name { get; private set; }
        public int Alter { get; private set; }

        public HashPatient(string _name, int _alter)
        {
            Name = _name;
            Alter = _alter;
        }

        public override string ToString()
        {
            return Name + " | " + Alter ;
        }
    }
}
