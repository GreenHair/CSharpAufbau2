using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekteLib
{
    public class Abteilung
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Personal> Arbeiter { get; set; }

        public Abteilung()
        {
            Arbeiter = new List<Personal>();
        }
    }
}
