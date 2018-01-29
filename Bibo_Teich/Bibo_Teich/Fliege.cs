using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibo_Teich
{
    public class Fliege
    {
        public static readonly int Beine = 6;
        public static readonly int Fluegel = 2;
        bool _WurdeGefressen = false;

        public bool Wurdegefressen
        {
            get
            {
                return _WurdeGefressen;
            }
        }

        internal string WirdGefressen()
        {
            _WurdeGefressen = true;
            return "Guten Hunger";
        }
    }
}
