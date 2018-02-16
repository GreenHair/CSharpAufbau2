using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekteLib
{
    public class Personal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Arbeit> Aufgaben { get; set; }

        public Personal()
        {
            Aufgaben = new List<Arbeit>();
        }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
