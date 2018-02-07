using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DreiDDrucker
{
    class Variant1
    {
        private bool isOver = false;

        public void Threading1()
        {
            string Zeile;
            do
           // while (!isOver)
            {
                Zeile = Console.ReadLine();
            }
            while (!isOver);
            Console.WriteLine("is over");
        }

        public void Threading1_Clock()
        {
            Random rnd = new Random();
            int zufall = rnd.Next(5, 25);
            for(int i= zufall; i > 0; i--)
            {
                Thread.Sleep(1000);
            }
            isOver = true;
        }
    }
}
