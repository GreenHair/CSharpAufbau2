using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bibo
{
    public class Pizza
    {   
        public String Size {get;set;}
        public List<String> Belag {get;set;}
        public bool Fertig { get; set; }
        public String Sonder { get; set; }
    }
}
