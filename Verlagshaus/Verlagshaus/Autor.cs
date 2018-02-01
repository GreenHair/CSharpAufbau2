using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    class Autor
    {
        public string Name { get; private set; }

        public Autor(string _name)
        {
            Name = _name;
        }

        public override bool Equals(object obj)
        {
            if(obj is Autor)
            {
                if(((Autor)obj).Name == Name)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.Length;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
