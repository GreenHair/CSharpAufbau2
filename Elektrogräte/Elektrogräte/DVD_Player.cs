using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrogräte
{
    public class DVD_Player:Elektrogerät
    {
        public bool IstLeer { get; private set; }

        public DVD_Player()
        {
            IstLeer = true;
        }

        public override string EinAus()
        {
            string result;
            isOn = !isOn;
            if (isOn)
            {                
                 result = "Das " + GetType().Name + " ist an";
                if (IstLeer)
                {
                    result += "\nAchtung: Der Disctray ist leer!";
                }
            }
            else
            {
                result = "Das " + GetType().Name + " ist aus";
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + " | " + ((IstLeer) ? "Kein Disc Eingelegt" : "Bereit zum abspielen");
        }
    }
}
