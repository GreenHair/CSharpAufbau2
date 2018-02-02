using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagelöhnerDelegate
{
    class Aufgaben
    {
        public static double ZettelVerteilen(int std)
        {
            return 8.84 * std;
        }

        public static double Kellnern(int std)
        {
            return 9.2 * std;
        }

        public static double TrojanerBauen(int std)
        {
            return 50 * std;
        }
    }
}
