using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ArbeitslagerThreading
{
    class Oberaufseher
    {
        ArrayList Ergebnis;
        public int Tagesproduktion { get; private set; }

        public Oberaufseher(ArrayList kiste)
        {
            Ergebnis = kiste;
        }

        public void Nachschauen(object spanne)
        {
            for(int i = 0; i < 3; i++)
            {
                Thread.Sleep((int)spanne);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Thread.CurrentThread.Name + " schaut nach:");
                Console.WriteLine("Es sind {0} Schlüsselanhänger in der Kiste", Ergebnis.Count);
                Tagesproduktion += Ergebnis.Count;
                Ergebnis.Clear();
            }
        }
    }

    class Schlüsselhänger
    {

    }

    class Arbeiter
    {
        ArrayList Pensum;
        Random rand;
        ConsoleColor farbe;
        public int PersönlicheLeistung;

        public Arbeiter(ArrayList kiste/*, ConsoleColor _farbe*/)
        {
            Pensum = kiste;
            rand = new Random();
           // farbe = _farbe;
        }

        public void Arbeiten()
        {
            int Leistung = rand.Next(50);
            for(int i = 0; i < Leistung; i++)
            {
                Pensum.Add(new Schlüsselhänger());
                PersönlicheLeistung++;
                //Console.ForegroundColor = farbe;
                Console.WriteLine(Thread.CurrentThread.Name + " hat einen Schlüsselhänger erstellt");
                Thread.Sleep(500);
            }            
        }
    }
}
