using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaufhaus
{
    delegate bool Alarmanlage(Kunde k);
    class Warenhaus
    {
        public event Alarmanlage Scanner = null;
        public int AnzahlDiebe { get; private set; }

        public void Ausgang(Kunde k)
        {
            if(Scanner?.Invoke(k) == true)      // Es wird Gleichzeitig auf null geprüft und auf true
            {
                AnzahlDiebe++;
            }
        }
    }
}
