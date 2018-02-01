using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    class Teenager:Person,IMobile
    {
        public Teenager(string _name) : base(_name) { }

        public string fortbewegen()
        {
            return "Roller";
        }
    }
}
