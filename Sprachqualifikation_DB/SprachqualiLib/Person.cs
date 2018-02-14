using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprachqualiLib
{
    public class Person
    {
        public string Pers_nr { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public List<Sprache> Sprachen { get; set; }
    }

    public class Sprache
    {
        public string Welche { get; set; }
        public int Niveau { get; set; }
        public string Pers_nr { get; set; }
    }
}
