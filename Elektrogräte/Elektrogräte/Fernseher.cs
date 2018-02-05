using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrogräte
{
    public class Fernseher:Elektrogerät
    {
        public string Programm { get; private set; }
        //public bool isOn;

        public Fernseher()
        {
            isOn = false;
            Programm = "ARD";
        }

        //public string EinAus()
        //{
        //    isOn = !isOn;
        //    if (isOn)
        //    {
        //        return "Der Fernseher ist an";
        //    }
        //    else
        //    {
        //        return "Der Fernseher ist aus";
        //    }
        //}

        public void Zappen(string Sender)
        {
            Programm = Sender;
        }

        public override string ToString()
        {
            return base.ToString() + " | " + Programm;
        }
    }
}
