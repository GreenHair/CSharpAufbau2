using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBangDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Schalter button = new Schalter();
            button.Hinzufügen(new Licht());
            button.Hinzufügen(new Spinne());

            button.Ein();
            button.Aus();

            Console.WriteLine("--------------------------------------");

            DelSchalter otherButton = new DelSchalter();

            otherButton.MethodEin = new Licht().Einschalten;
            otherButton.MethodEin += new Spinne().Einschalten;
            otherButton.MethodEin += Tanzen;
            otherButton.MethodEin += () =>  Console.WriteLine("on y va!");

            otherButton.MethodAus = new Licht().Ausschalten;
            otherButton.MethodAus += new Spinne().Ausschalten;

            otherButton.Ein();
            otherButton.Aus();
        }

        public static void Tanzen()
        {
            Console.WriteLine("Menuett wenn ich bitten darf!");
        }
    }
}
