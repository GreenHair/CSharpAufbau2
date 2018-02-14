using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekatologLib
{
    public class Reiseziel
    {
        public string Land { get; set; }
        public string Ort { get; set; }
        public List<Hotel> Unterkunft { get; set; }
    }
}
