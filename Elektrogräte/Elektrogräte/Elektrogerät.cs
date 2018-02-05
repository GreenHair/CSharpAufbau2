using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrogräte
{
    public abstract class Elektrogerät
    {
        public bool isOn { get; protected set; }

        public Elektrogerät()
        {
            isOn = false;
        }

        public virtual string EinAus()
        {
            isOn = !isOn;
            if (isOn)
            {
                return "Das "+ GetType().Name + " ist an";
            }
            else
            {
                return "Das " + GetType().Name + " ist aus";
            }
        }

        public override string ToString()
        {
            return (isOn) ? "ON" : "OFF";
        }
    }
}
