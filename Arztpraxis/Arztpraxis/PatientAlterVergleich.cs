using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis
{
    class PatientAlterVergleich : IComparer<Patient>
    {
        public int Compare(Patient x, Patient y)
        {
            return y.Alter.CompareTo(x.Alter);
        }
    }
}
