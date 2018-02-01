using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class Person
    {
        public int Skills { get; private set; }

        public Person(int _skills)
        {
            Skills = _skills;
        }
    }
}
