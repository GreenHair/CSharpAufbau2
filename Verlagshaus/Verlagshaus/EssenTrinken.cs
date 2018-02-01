using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlagshaus
{
    class EssenTrinken:Themen
    {
        public EssenTrinken(string _beschreibung, List<Autor> _autor) : base(_beschreibung, _autor) { }
    }
}
