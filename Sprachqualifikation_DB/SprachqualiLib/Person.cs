using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprachqualiLib
{
    public class Person
    {
        public string Pers_nr;
        public string Vorname;
        public string Nachname;
        public List<Sprache> Sprachen;
    }

    public class Sprache
    {
        public string Welche;
        public int Niveau;
        public string Pers_nr;
    }
}
